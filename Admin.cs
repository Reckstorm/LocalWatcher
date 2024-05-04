using Microsoft.Win32;
using ProcessAdmin_19._08.Converters;
using System.Diagnostics;
using System.Text.Json;

namespace ProcessAdmin_19._08
{
    public partial class Admin : Form
    {
        private List<Process> _processList { get; set; }
        private List<AllowedProcess> _allowedProcesses { get; set; }
        public string _pathProcesses { get; set; }

        private bool _running { get; set; }
        private object _lock { get; set; } = new object();

        private bool allowShowDisplay = false;
        public Admin(bool visibility = true)
        {
            InitializeComponent();
            CheckIfBGRunning();
            AddToStartup();
            string t = Application.ExecutablePath;
            _pathProcesses = $"{Application.ExecutablePath.Substring(0, t.LastIndexOf('\\'))}\\Rules.json";
            ReadProcesses();
            allowShowDisplay = visibility;
            foreach (Process item in Process.GetProcesses())
            {
                if (!this.ExistingProcesses.Items.Contains(item.ProcessName))
                {
                    this.ExistingProcesses.Items.Add(item.ProcessName);
                }
            }
            Load += RenewList;
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!allowShowDisplay)
            {
                RunBlock();
                base.SetVisibleCore(false);
            }
            else
            {
                base.SetVisibleCore(value);
            }
        }

        private void CheckIfBGRunning()
        {
            if (_processList == null) _processList = Process.GetProcesses().ToList();
            Process temp = _processList.FirstOrDefault(p => p.ProcessName.Equals(Application.ProductName));
            if (temp != null && temp.Id != Process.GetCurrentProcess().Id) temp.Kill();
        }

        private void ReadProcesses()
        {
            if (File.Exists(_pathProcesses))
            {
                string jsonStr = File.ReadAllText(_pathProcesses);

                var options = new JsonSerializerOptions()
                {
                    Converters = { new TimeOnlyJsonConverter() }
                };

                _allowedProcesses = JsonSerializer.Deserialize<List<AllowedProcess>>(jsonStr, options);
                _allowedProcesses.ForEach(p => this.ProcessesWithRules.Items.Add(p.ProcessName));
            }
            else
            {
                _allowedProcesses = new List<AllowedProcess>();
            }
        }

        private void WriteProcesses()
        {
            var options = new JsonSerializerOptions()
            {
                Converters = { new TimeOnlyJsonConverter() }
            };
            lock (_lock)
            {
                File.WriteAllText(_pathProcesses, JsonSerializer.Serialize(_allowedProcesses, options));
            }
        }

        private void AddRule(string procName)
        {
            AllowedProcess temp = new AllowedProcess(procName);
            _allowedProcesses.Add(temp);
        }

        private void SetBoundariesClick(object sender, EventArgs e)
        {
            _allowedProcesses.FirstOrDefault(p => p.ProcessName.Equals(this.ProcessesWithRules.SelectedItem.ToString())).BlockEndtTime = TimeOnly.Parse(this.TimePicker_dtp.Value.ToLongTimeString());
            WriteProcesses();
        }

        private void AllowedTimeSelectedChanged(object sender, EventArgs e)
        {
            if (this.ProcessesWithRules.SelectedItem == null) return;
            this.ProcessName_tb.Text = this.ProcessesWithRules.SelectedItem.ToString();
            var process = _allowedProcesses.FirstOrDefault(p => p.ProcessName.Equals(this.ProcessesWithRules.SelectedItem.ToString()));
            TimeOnly sTime = process.BlockStartTime;
            TimeOnly eTime = process.BlockEndtTime;
            if (TimeOnly.Parse(DateTime.Now.ToLongTimeString()) <= eTime)
            {
                this.TimeLeft_tb.Text = (sTime - eTime).ToString();
            }
            else
            {
                this.TimeLeft_tb.Text = (TimeOnly.MaxValue - TimeOnly.Parse(DateTime.Now.ToLongTimeString())).ToString().Substring(0, 8);
            }
            this.TimePicker_dtp.Value = DateTime.Parse($"01.01.1753 {eTime.Hour}:{eTime.Minute}:{eTime.Second}");
        }

        private void BlockProcessClick(object sender, EventArgs e)
        {
            if (this.ProcessesWithRules.Items.Contains(this.ExistingProcesses.SelectedItem)) return;
            AddRule(this.ExistingProcesses.SelectedItem.ToString());
            var t = this.ExistingProcesses.SelectedItem;
            this.ProcessesWithRules.Items.Add(t);
            this.ExistingProcesses.Items.Remove(t);
        }

        private void BlockProcessExeClick(object sender, EventArgs e)
        {
            string temp = "";
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "exe files(*.exe)|*.exe|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.Cancel) return;
            temp = fileDialog.FileName;
            temp = temp.Substring(temp.LastIndexOf('\\') + 1, temp.Length - temp.LastIndexOf('\\') - 1);
            temp = temp.Substring(0, temp.IndexOf('.'));
            if (this.ProcessesWithRules.Items.Contains(temp)) return;
            this.ProcessesWithRules.Items.Add(temp);
            AddRule(temp);
        }

        private void UnblockProcessClick(object sender, EventArgs e)
        {
            this._allowedProcesses.Remove(this._allowedProcesses.FirstOrDefault(process => process.ProcessName.Equals(this.ProcessesWithRules.SelectedItem)));
            this.ProcessesWithRules.Items.Remove(this.ProcessesWithRules.SelectedItem);
        }

        private void RunClick(object sender, EventArgs e)
        {
            RunBlock();
            this.Visible = false;
        }

        private void RenewList(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(20000);
                    this.ExistingProcesses.Invoke(() =>
                    {
                        this.ExistingProcesses.Items.Clear();
                        _processList.ForEach(p =>
                        {
                            if (!this.ExistingProcesses.Items.Contains(p.ProcessName))
                            {
                                this.ExistingProcesses.Items.Add(p.ProcessName);
                            }
                        });
                    });
                }
            });
        }

        private void RunBlock()
        {
            if (!_running)
            {
                this._running = true;
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        _processList = Process.GetProcesses().ToList();
                        foreach (Process process in _processList)
                        {
                            foreach (AllowedProcess p in _allowedProcesses)
                            {
                                if (p.ProcessName.Equals(Application.ProductName)) continue;
                                if (p.ProcessName.Equals(process.ProcessName)
                                && TimeOnly.Parse(DateTime.Now.ToLongTimeString()) <= p.BlockEndtTime
                                && TimeOnly.Parse(DateTime.Now.ToLongTimeString()) >= p.BlockStartTime)
                                {
                                    foreach (Process temp in Process.GetProcessesByName(p.ProcessName))
                                    {
                                        temp.Kill();
                                    }
                                    WriteProcesses();
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
                });
            }

        }

        private void AddToStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (rk.GetValue(Application.ProductName) == null)
                rk.SetValue(Application.ProductName, $"\"{Application.ExecutablePath}\" /background");
            rk.Close();
        }
    }
}