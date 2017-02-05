using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Thp.Har.Utility {
    public static class CryptographyUtility {
        #region Hash
        public static string ComputeHash(string value) {
            return ComputeHash(value, false);
        }

        public static string ComputeHash(string value, bool returnFriendlyString) {
            string result = String.Empty;

            if (!string.IsNullOrEmpty(value)) {
                HashAlgorithm hashAlgorithm = new SHA512CryptoServiceProvider();
                byte[] bytesToHash = UnicodeEncoding.ASCII.GetBytes(value);
                byte[] hashedBytes = hashAlgorithm.ComputeHash(bytesToHash);

                if (hashedBytes != null) {
                    if (returnFriendlyString) {
                        for (int i = 0; i < hashedBytes.Length; i++) {
                            result += string.Format("{0:X2}", hashedBytes[i]);
                        }
                    } else {
                        result = Convert.ToBase64String(hashedBytes);
                    }
                }
            }

            return result;
        }


        public static string CreatePassword(string plainString) {
            // Convert the string password value to a byte array
            byte[] plainData = UnicodeEncoding.ASCII.GetBytes(plainString);


            // Create a 4-byte salt using a cryptographically secure random number generator
            byte[] saltData = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltData);


            // Append the salt to the end of the password
            byte[] saltPlusPasswordData = new byte[plainData.Length + saltData.Length];
            Array.Copy(plainData, 0, saltPlusPasswordData, 0, plainData.Length);
            Array.Copy(saltData, 0, saltPlusPasswordData, plainData.Length, saltData.Length);


            // Create a new SHA instance and compute the hash
            HashAlgorithm hashAlgorithm = new SHA512CryptoServiceProvider();
            byte[] hashData = hashAlgorithm.ComputeHash(saltPlusPasswordData);


            // Add salt bytes onto end of the password hash for storage
            byte[] hashPlusSaltData = new byte[hashData.Length + saltData.Length];
            Array.Copy(hashData, 0, hashPlusSaltData, 0, hashData.Length);
            Array.Copy(saltData, 0, hashPlusSaltData, hashData.Length, saltData.Length);

            // Return the string data
            return Convert.ToBase64String(hashPlusSaltData);
        }

        public static bool ComparePassword(string plainString, string passwordString) {
            bool result = false;

            try {
                // First, pluck the four-byte salt off of the end of the hash
                byte[] saltData = new byte[4];
                byte[] hashPlusSaltData = Convert.FromBase64String(passwordString);
                Array.Copy(hashPlusSaltData, hashPlusSaltData.Length - saltData.Length, saltData, 0, saltData.Length);


                // Convert Password to bytes
                byte[] plainData = UnicodeEncoding.ASCII.GetBytes(plainString);


                // Append the salt to the end of the password
                byte[] saltedPasswordData = new byte[plainData.Length + saltData.Length];
                Array.Copy(plainData, 0, saltedPasswordData, 0, plainData.Length);
                Array.Copy(saltData, 0, saltedPasswordData, plainData.Length, saltData.Length);


                // Create a new SHA instance and compute the hash
                HashAlgorithm hashAlgorithm = new SHA512CryptoServiceProvider();
                byte[] newHashData = hashAlgorithm.ComputeHash(saltedPasswordData);


                // Tack salt bytes onto end of the password hash for comparison
                byte[] newHashPlusSaltData = new byte[newHashData.Length + saltData.Length];
                Array.Copy(newHashData, 0, newHashPlusSaltData, 0, newHashData.Length);
                Array.Copy(saltData, 0, newHashPlusSaltData, newHashData.Length, saltData.Length);


                // Compare and return
                result = (Convert.ToBase64String(hashPlusSaltData).Equals(Convert.ToBase64String(newHashPlusSaltData)));
            } catch {
                result = false;
            }

            return result;
        }
        #endregion


        #region Encryption
        public static string EncryptString(string plaintext, byte[] key, bool useHexString) {
            // The default AES key size under the .NET framework is 256.  The following
            // call will create an AES crypto provider and create a random initialization
            // vector and key. The crypto mode defaults to CBC ensuring the proper chaining 
            // of data to mitigate repetition of cipher text blocks.
            string ciphertext = "";
            RijndaelManaged rij = new RijndaelManaged();


            //Create an AES encryptor from the AES instance.
            ICryptoTransform aesencrypt = rij.CreateEncryptor(key, rij.IV);


            //Create crypto stream set to read and do an AES encryption transform on incoming bytes.
            MemoryStream ms = new MemoryStream();
            CryptoStream cipherstream = new CryptoStream(ms, aesencrypt, CryptoStreamMode.Write);


            // Encrypt
            byte[] bytearrayinput = UnicodeEncoding.ASCII.GetBytes(plaintext);
            cipherstream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cipherstream.FlushFinalBlock();
            cipherstream.Close();


            // Create a byte array to store our encrypted value plus IV
            ms.Flush();
            byte[] encryptedValueWithIV = new byte[rij.IV.Length + ms.ToArray().Length];
            Array.Copy(rij.IV, encryptedValueWithIV, rij.IV.Length);
            Array.Copy(ms.ToArray(), 0, encryptedValueWithIV, rij.IV.Length, ms.ToArray().Length);


            // Return encrypted string
            if (useHexString) {
                ciphertext = ByteArrayToHexString(encryptedValueWithIV);
            } else {
                ciphertext = Convert.ToBase64String(encryptedValueWithIV);
            }

            ms.Close();

            return ciphertext;
        }

        public static string DecryptString(string ciphertext, byte[] key, bool useHexString) {
            // The default AES key size under the .NET framework is 256.  The following
            // call will create an AES crypto provider and create a random initialization
            // vector and key. The crypto mode defaults to CBC ensuring the proper chaining 
            // of data to mitigate repetition of cipher text blocks.
            string decryptedtext = "";
            RijndaelManaged rij = new RijndaelManaged();


            //Because the input string is passed in as a Base64 encoded value we decode prior writing to 
            //the decryptor stream.
            byte[] encryptedValueWithIV = null;
            if (useHexString) {
                encryptedValueWithIV = HexStringToByteArray(ciphertext);
            } else {
                encryptedValueWithIV = Convert.FromBase64String(ciphertext);
            }

            byte[] iv = new byte[16];
            byte[] encrypted = new byte[encryptedValueWithIV.Length - 16];
            Array.Copy(encryptedValueWithIV, iv, 16);
            Array.Copy(encryptedValueWithIV, iv.Length, encrypted, 0, encrypted.Length);


            //Create an AES decryptor from the AES instance.
            ICryptoTransform aesdecrypt = rij.CreateDecryptor(key, iv);


            //Create a memorystream to which we'll decrypt our input string
            MemoryStream ms = new MemoryStream();
            CryptoStream ecs = new CryptoStream(ms, aesdecrypt, CryptoStreamMode.Write);


            ecs.Write(encrypted, 0, encrypted.Length);
            ecs.FlushFinalBlock();
            ecs.Close();

            // Return decrypted string
            ms.Flush();
            decryptedtext = UnicodeEncoding.ASCII.GetString(ms.ToArray());
            ms.Close();

            return decryptedtext;
        }
        #endregion


        #region Helper Methods
        public static string GenerateHMAC(string input, string secret) {
            // Instantiate the HMAC class
            HMACSHA256 hmac = new HMACSHA256();


            try {
                // We pass in a user supplied password to generate a strong key to be used in our HMAC
                // since people tend to use weak and potentially dictionary values for keys.  
                // Using the PasswordDerivedBytes helps to mitigate the risk of dictionary attacks
                // on our HMAC key


                // In the current implementation, regardless of the salt passed to the PasswordDeriveBytes
                // constructor the same derived password will be generated.
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(secret, null);


                byte[] pbytes = pdb.CryptDeriveKey("TripleDES", "SHA1", 192, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });


                hmac.Key = pbytes;
            } catch (Exception e) {
                Console.Error.WriteLine(e.ToString());
            }

            return UnicodeEncoding.ASCII.GetString(hmac.ComputeHash(UnicodeEncoding.ASCII.GetBytes(input)));
        }


        public static int GenerateRandomNumber() {
            // Create a secure RNG class and a byte array to hold the random data
            RNGCryptoServiceProvider secureRandom = new RNGCryptoServiceProvider();
            byte[] randBytes = new byte[4];


            // Generate 4 bytes of secure random number data and convert to 4-byte integer
            secureRandom.GetNonZeroBytes(randBytes);
            return (BitConverter.ToInt32(randBytes, 0));
        }

        public static byte[] GenerateRandomSalt(int length) {
            // Create a buffer
            byte[] randBytes;

            if (length >= 1) {
                randBytes = new byte[length];
            } else {
                randBytes = new byte[1];
            }

            // Create a new RNGCryptoServiceProvider.
            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
            rand.GetBytes(randBytes);

            // return the bytes.
            return randBytes;
        }

        public static string GenerateRandomKey(int length) {
            byte[] buff = new byte[length];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buff);

            StringBuilder sb = new StringBuilder(length * 2);
            for (int i = 0; i < buff.Length; i++) {
                sb.Append(string.Format("{0:X2}", buff[i]));
            }

            return sb.ToString();
        }


        public static string GetHexRepresentation(string val) {
            if (string.IsNullOrEmpty(val))
                return null;

            byte[] buff = UnicodeEncoding.ASCII.GetBytes(val);
            StringBuilder sb = new StringBuilder(buff.Length * 2);
            for (int i = 0; i < buff.Length; i++) {
                sb.Append(string.Format("{0:X2}", buff[i]));
            }

            return sb.ToString();
        }

        public static string ByteArrayToHexString(byte[] val) {
            StringBuilder sb = new StringBuilder(val.Length * 2);

            for (int i = 0; i < val.Length; i++) {
                sb.Append(string.Format("{0:X2}", val[i]));
            }

            return sb.ToString();
        }

        public static byte[] HexStringToByteArray(string val) {
            int numchars = val.Length;
            byte[] bytes = new byte[numchars / 2];

            for (int i = 0; i < numchars; i += 2) {
                try {
                    bytes[i / 2] = Convert.ToByte(val.Substring(i, 2), 16);
                } catch {
                    bytes[i / 2] = 0;
                }
            }

            return bytes;
        }



        public static void ClearBytes(byte[] buffer) {
            // Check arguments.
            if (buffer == null) {
                throw new ArgumentException("Buffer");
            }

            // Set each byte in the buffer to 0.
            for (int x = 0; x <= buffer.Length - 1; x++) {
                buffer[x] = 0;
            }
        }


        public static string GenerateASPNET20MachineKey() {
            string key64byte = GenerateRandomKey(64);
            string key32byte = GenerateRandomKey(32);

            StringBuilder aspnet20machinekey = new StringBuilder();
            aspnet20machinekey.AppendFormat("<machineKey validationKey=\"{0}\" decryptionKey=\"{1}\" validation=\"SHA1\" decryption=\"AES\" />", key64byte, key32byte);
            return aspnet20machinekey.ToString();
        }


        public static string GenerateASPNET11MachineKey() {
            string key64byte = GenerateRandomKey(64);
            string key24byte = GenerateRandomKey(24);

            StringBuilder aspnet11machinekey = new StringBuilder();
            aspnet11machinekey.AppendFormat("<machineKey validationKey=\"{0}\" decryptionKey=\"{1}\" validation=\"SHA1\" />", key64byte, key24byte);
            return aspnet11machinekey.ToString();
        }
        #endregion
    }
}
