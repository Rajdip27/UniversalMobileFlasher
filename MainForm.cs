
using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UniversalMobileFlasher
{
    public partial class MainForm : Form
    {
        private ManagementEventWatcher watcher;

        public MainForm()
        {
            InitializeComponent();
            StartUSBWatcher();
        }

        private void StartUSBWatcher()
        {
            // Only attempt to use ManagementEventWatcher on supported Windows platforms
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                try
                {
                    watcher = new ManagementEventWatcher();
                    watcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
                    watcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
                    watcher.Start();
                }
                catch (PlatformNotSupportedException ex)
                {
                    lstLog.Items.Add("USB watcher not supported on this platform: " + ex.Message);
                }
                catch (Exception ex)
                {
                    lstLog.Items.Add("Failed to start USB watcher: " + ex.Message);
                }
            }
            else
            {
                lstLog.Items.Add("USB watcher is only supported on Windows desktop platforms.");
            }
            // Only attempt to use ManagementEventWatcher on supported Windows platforms
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                try
                {
                    watcher = new ManagementEventWatcher();
                    watcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
                    watcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
                    watcher.Start();
                }
                catch (PlatformNotSupportedException ex)
                {
                    lstLog.Items.Add("USB watcher not supported on this platform: " + ex.Message);
                }
                catch (Exception ex)
                {
                    lstLog.Items.Add("Failed to start USB watcher: " + ex.Message);
                }
            }
            else
            {
                lstLog.Items.Add("USB watcher is only supported on Windows desktop platforms.");
            }
        }

        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                lstLog.Items.Add("🔌 Phone connected.");
            });
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Firmware Files (*.img;*.mbn;*.bin)|*.img;*.mbn;*.bin|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        private void btnFlash_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            string chipset = cmbChipset.Text;

            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(chipset))
            {
                MessageBox.Show("Please select chipset and firmware file.");
                return;
            }

            string command = "";

            if (chipset == "Fastboot")
            {
                command = $"flash boot \"{filePath}\"";
                RunCommand("fastboot.exe", command);
            }
            else if (chipset == "Qualcomm (EDL)")
            {
                command = $"edl.py --loader \"{filePath}\" --memory emmc --reset";
                RunCommand("python", command);
            }
            else if (chipset == "MediaTek (MTK)")
            {
                command = $"mtkclient.py -p auto da \"{filePath}\"";
                RunCommand("python", command);
            }
            else
            {
                lstLog.Items.Add("❌ Unsupported chipset.");
            }
        }

        private void RunCommand(string exe, string args)
        {
            lstLog.Items.Add($"> {exe} {args}");
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(exe, args)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process proc = Process.Start(psi);
                string output = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
                lstLog.Items.Add(output);
            }
            catch (Exception ex)
            {
                lstLog.Items.Add("Error: " + ex.Message);
            }
        }
    }
}
