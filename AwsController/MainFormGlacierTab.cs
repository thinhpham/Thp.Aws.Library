using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using System.Threading;
using Thp.Har.Utility;
using System.Windows.Forms;

namespace AwsController
{
    public partial class MainForm
    {
        private const string TAB_GLACIER = "m_guiTabGlacier";
        private const string TAB_GLACIER_VAULT = "m_guiTabGlacierVault";
        private const string TAB_GLACIER_JOB = "m_guiTabGlacierJob";
        private const string TAB_GLACIER_INVENTORY = "m_guiTabGlacierInventory";

        private void MainFormGlacierTab_Constructor()
        {
            m_guiTabGlacierMain.SelectedIndexChanged += new EventHandler(m_guiTabGlacerMain_SelectedIndexChanged);
            m_guiGlacierVaultGrid.AutoGenerateColumns = true;
        }

        void m_guiTabGlacerMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_SelectedGlacierTab = m_guiTabGlacierMain.SelectedTab;
            LoadGlacierTabControls(false);
        }

        private void LoadGlacierTabControls(bool isFromTimer)
        {
            if (m_SelectedGlacierTab == m_guiTabGlacierMain.TabPages[TAB_GLACIER_VAULT])
            {
                LoadGlacierVaults(m_SelectedRegion);
            }
            else if (m_SelectedGlacierTab == m_guiTabGlacierMain.TabPages[TAB_GLACIER_JOB])
            {
                LoadGlacierJobs(m_SelectedRegion);
            }
            else if (m_SelectedGlacierTab == m_guiTabGlacierMain.TabPages[TAB_GLACIER_INVENTORY])
            {
                LoadGlacierInventories(m_SelectedRegion);
            }
        }

        private void LoadGlacierVaults(RegionEndpoint region)
        {
            if (!string.IsNullOrEmpty(CacheObject.Settings.AWSAccessKey) && !string.IsNullOrEmpty(CacheObject.Settings.AWSSecretKey))
            {
                var thread = new Thread(new ThreadStart(() =>
                {
                    var result = AmazonGlacierUtility.ListVaults(region);
                    var list = result.ListVaultsResult.VaultList;

                    Invoke(new MethodInvoker(() =>
                    {
                        m_guiGlacierVaultGrid.DataSource = list;
                    }));
                }));
                thread.Start();
            }
            else
            {
                MessageBox.Show("Please provide AWSAccessKey and AWSSecretKey in app.config file");
            }
        }

        private void LoadGlacierJobs(RegionEndpoint region)
        {
            var thread = new Thread(new ThreadStart(() =>
            {
                var result = AmazonGlacierUtility.ListJobs(region, CacheObject.Settings.ArchiveIISLogVaultName, 0);
                var list = result.ListJobsResult.JobList;

                Invoke(new MethodInvoker(() =>
                {
                    m_guiGlacierJobGrid.DataSource = list;
                }));
            }));
            thread.Start();
        }

        private void LoadGlacierInventories(RegionEndpoint region)
        {

        }
    }
}
