using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WF = System.Windows.Forms;
using System.Reflection;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace AwsController {
    public class StatePersistence {
        private System.Collections.Specialized.NameValueCollection formValues = null;
        string formStateFileName = string.Empty;
        private WF.Form form;

        public StatePersistence(WF.Form form) {
            this.form = form;
            this.form.Closing += new System.ComponentModel.CancelEventHandler(form_Closing);
            formStateFileName = Assembly.GetExecutingAssembly().Location.Substring(0,
                Assembly.GetExecutingAssembly().Location.LastIndexOf("\\")) + "\\" + form.Name + ".xml";
            LoadForm(form);
        }

        public void LoadForm(WF.Form form) {
            RetrieveFormState();
            LoadControlValues(form);
        }

        public void LoadControlValues(WF.Control control) {
            if (null != control.Controls) {
                foreach (WF.Control ctrl in control.Controls) {
                    if (null != ctrl.Controls && ctrl.Controls.Count > 0) {
                        LoadControlValues(ctrl);
                    }
                    if ((ctrl is WF.TextBox) && ((ctrl as WF.TextBox).Tag as string) != null &&
                        ((ctrl as WF.TextBox).Tag as string).ToLower().Equals("persist")) {
                        WF.TextBox tb = (ctrl as WF.TextBox);
                        tb.Text = formValues.Get(tb.Name);
                    }
                }
            }
        }

        public void SaveForm(WF.Form form) {
            SaveControlValues(form);
            SaveFormState();
        }

        public void SaveControlValues(WF.Control control) {
            if (null != control.Controls) {
                foreach (WF.Control ctrl in control.Controls) {
                    if (null != ctrl.Controls && ctrl.Controls.Count > 0) {
                        SaveControlValues(ctrl);
                    }

                    if ((ctrl is WF.TextBox) && ((ctrl as WF.TextBox).Tag as string) != null &&
                       ((ctrl as WF.TextBox).Tag as string).ToLower().Equals("persist")) {
                        WF.TextBox tb = (ctrl as WF.TextBox);
                        formValues.Set(tb.Name, tb.Text);
                    }
                }
            }
        }

        private void RetrieveFormState() {
            if (File.Exists(formStateFileName)) {
                object o = null;
                using (Stream stream = new FileStream(formStateFileName, FileMode.Open, FileAccess.Read)) {
                    SoapFormatter formatter = new SoapFormatter();
                    o = formatter.Deserialize(stream);
                    formValues = (NameValueCollection)o;
                }
            } else {
                formValues = new NameValueCollection();
            }
        }

        private void SaveFormState() {
            using (Stream s = new FileStream(formStateFileName, FileMode.Create, FileAccess.Write)) {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(s, formValues);

                using (StreamWriter w = new StreamWriter(s)) {
                    w.Flush();
                }
            }
        }

        private void form_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            SaveForm(this.form);
        }
    }
}
