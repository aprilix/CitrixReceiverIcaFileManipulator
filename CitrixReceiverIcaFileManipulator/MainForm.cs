using System;
using System.IO;
using System.Windows.Forms;

namespace CitrixReceiverIcaFileManipulator
{
    public partial class MainForm : Form {
        private readonly string fileName;

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
            IcsManipulator.manipulateFile(textBoxFile.Text, checkBoxResolution.Checked, checkBoxTransparentKeyPassthrough.Checked, textBoxHRes.Text, textBoxVRes.Text);
            execute();
            storeSettings();
        }

        private void buttonStore_Click(object sender, EventArgs e)
        {
            if (!checkFileOk()) return;
            IcsManipulator.manipulateFile(textBoxFile.Text, checkBoxResolution.Checked, checkBoxTransparentKeyPassthrough.Checked, textBoxHRes.Text, textBoxVRes.Text);
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
        
        private void buttonDragDropStore_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxFile.Text = files[0];
            if (!checkFileOk()) return;
            IcsManipulator.manipulateFile(textBoxFile.Text, checkBoxResolution.Checked, checkBoxTransparentKeyPassthrough.Checked, textBoxHRes.Text, textBoxVRes.Text);
            storeSettings();
        }

        private void buttonDragDropStoreAndExecute_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxFile.Text = files[0];
            if (!checkFileOk()) return;
            IcsManipulator.manipulateFile(textBoxFile.Text, checkBoxResolution.Checked, checkBoxTransparentKeyPassthrough.Checked, textBoxHRes.Text, textBoxVRes.Text);
            execute();
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
                IcsManipulator.manipulateFile(textBoxFile.Text, checkBoxResolution.Checked, checkBoxTransparentKeyPassthrough.Checked, textBoxHRes.Text, textBoxVRes.Text);
                execute();
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

        private void buttonDragAndDropExecute_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxFile.Text = files[0];
            if (!checkFileOk()) return;
            execute();
            storeSettings();
        }

        private void execute()
        {
            if (string.IsNullOrWhiteSpace(textBoxCitrix.Text)
                || !File.Exists(textBoxCitrix.Text))
            {
                MessageBox.Show("Citrix Client not configured or existing!");
                return;
            }
            System.Diagnostics.Process.Start(textBoxCitrix.Text, textBoxFile.Text);
        }

        private void buttonExecute_Click_1(object sender, EventArgs e)
        {
            if (!checkFileOk()) return;
            execute();
            storeSettings();
        }
    }
}