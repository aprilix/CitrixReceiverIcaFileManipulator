using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form {
        private string fileName;

        public MainForm(string filename)
        {
            InitializeComponent();
            fileName = filename;
        }



        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1)
                {
                    if (files[0].EndsWith(".ica"))
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            textBoxFile.Text = files[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Citrix Receiver ica File (*.ica)|*.ica|All files (*.*)|*.*";
            fd.InitialDirectory = @"C:\";
            fd.Title = "Please select an ica file to manipulate.";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = fd.FileName;
            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            if (!checkFileOk()) return;
            manipulateFile();
            System.Diagnostics.Process.Start(textBoxFile.Text);
            storeSettings();
        }

        private void buttonStore_Click(object sender, EventArgs e)
        {
            if (!checkFileOk()) return;
            manipulateFile();
            storeSettings();
        }

        private bool checkFileOk()
        {
            if (String.IsNullOrWhiteSpace(textBoxFile.Text))
            {
                MessageBox.Show("Please fill in the File to manipulate!");
                return false;
            }

            if (!File.Exists(textBoxFile.Text))
            {
                MessageBox.Show("The File does not exist!");
                return false;
            }
            return true;
        }

        private void manipulateFile()
        {
            string content = readFile(textBoxFile.Text);
            content = manipulateResolution(content);
            content = manipulateTransparentKeyPassthrough(content);
            writeFile(textBoxFile.Text, content);
        }

        private string manipulateTransparentKeyPassthrough(string input)
        {
            if (checkBoxTransparentKeyPassthrough.Checked)
            {
                string[] elements = input.Split(new[] { '\r', '\n' });
                string output = "";
                foreach (string line in elements)
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        if (line.StartsWith("TransparentKeyPassthrough="))
                        {
                            output += "TransparentKeyPassthrough=Remote\n";
                        }
                        else
                        {
                            output += line + "\n";
                        }
                    }
                }
                return output;
            }
            else
            {
                return input;
            }
        }

        private string manipulateResolution(string input)
        {
            if (checkBoxResolution.Checked)
            {
                string[] elements = input.Split(new[] { '\r', '\n' });
                string output = "";
                foreach (string line in elements)
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        if (line.StartsWith("DesiredHRES="))
                        {
                            output += "DesiredHRES=" + textBoxHRes.Text + "\n";
                        }
                        else if (line.StartsWith("DesiredVRES="))
                        {
                            output += "DesiredVRES=" + textBoxVRes.Text + "\n";
                        }
                        else
                        {
                            output += line + "\n";
                        }
                    }
                }
                return output;
            }
            else
            {
                return input;
            }
        }

        private string readFile(String sFilename)
        {
            string sContent = "";

            if (File.Exists(sFilename))
            {
                StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
                sContent = myFile.ReadToEnd();
                myFile.Close();
            }
            return sContent;
        }

        private void writeFile(String sFilename, String sLines)
        {
            StreamWriter myFile = new StreamWriter(sFilename);
            myFile.Write(sLines);
            myFile.Close();
        }

        private void buttonDragDropStore_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxFile.Text = files[0];
            if (!checkFileOk()) return;
            manipulateFile();
            storeSettings();
        }

        private void buttonDragDropStoreAndExecute_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxFile.Text = files[0];
            if (!checkFileOk()) return;
            manipulateFile();
            System.Diagnostics.Process.Start(textBoxFile.Text);
            storeSettings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            checkBoxResolution.Checked = Properties.Settings.Default.checkBoxResolution;
            checkBoxTransparentKeyPassthrough.Checked = Properties.Settings.Default.checkBoxTransparentKeyPassthrough;
            textBoxHRes.Text = Properties.Settings.Default.HRes;
            textBoxVRes.Text = Properties.Settings.Default.VRes;
            textBoxCitrix.Text = Properties.Settings.Default.CitrixLocation;
            if (fileName != null)
            {
                textBoxFile.Text = fileName;
                manipulateFile();
                System.Diagnostics.Process.Start(textBoxCitrix.Text, textBoxFile.Text);
                Application.Exit();
            }
        }

        private void storeSettings()
        {
            Properties.Settings.Default.checkBoxResolution = checkBoxResolution.Checked;
            Properties.Settings.Default.checkBoxTransparentKeyPassthrough = checkBoxTransparentKeyPassthrough.Checked;
            Properties.Settings.Default.HRes = textBoxHRes.Text;
            Properties.Settings.Default.VRes = textBoxVRes.Text;
            Properties.Settings.Default.CitrixLocation = textBoxCitrix.Text;
            Properties.Settings.Default.Save();
        }

        private bool hResKeyNumeric = false;
        private void textBoxHRes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue < 48 || e.KeyValue > 57)
            {
                hResKeyNumeric = false;
            }
            else
            {
                hResKeyNumeric = true;
            }
        }

        private void textBoxHRes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!hResKeyNumeric)
            {
                e.Handled = true;
            }
            hResKeyNumeric = false;
        }

        private bool vResKeyNumeric = false;
        private void textBoxVRes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue < 48 || e.KeyValue > 57)
            {
                vResKeyNumeric = false;
            }
            else
            {
                vResKeyNumeric = true;
            }
        }

        private void textBoxVRes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!vResKeyNumeric)
            {
                e.Handled = true;
            }
            vResKeyNumeric = false;
        }

        private void buttonToggleAlwaysOnTop_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
            if (this.TopMost)
            {
                buttonToggleAlwaysOnTop.Text = "NOT Always On Top";
            }
            else
            {
                buttonToggleAlwaysOnTop.Text = "Always On Top";
            }
        }

        private void buttonFindCitrix_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Citrix Client|wfcrun32.exe|Executables (*.exe)|*.exe|All files (*.*)|*.*";
            fd.InitialDirectory = @"C:\Program Files (x86)\Citrix\ICA Client\";
            fd.Title = "Please select the location of wfcrun32.exe.";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxCitrix.Text = fd.FileName;
            }
        }

        private void textBoxCitrix_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxCitrix.Text = files[0];
        }

        private void textBoxCitrix_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1)
                {
                    if (files[0].EndsWith(".exe"))
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
