using ScreenshotOnEnter.TakeScreenShot;
using System.Diagnostics;

namespace ScreenshotOnEnter.WindowForm
{
    public partial class Form1 : Form
    {
        private readonly string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Images"); 
        public Form1()
        {
            InitializeComponent();

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath); 

            listBox1.DoubleClick += listBox1_DoubleClick;
        } 
         
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GetFiles(string path)
        {
            listBox1.Items.Clear();

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                listBox1.Items.Add(file);
                Console.WriteLine(Path.GetFileName(file));
            }
        } 
        
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = listBox1.SelectedItem.ToString(),
                    UseShellExecute = true
                });
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                GetFiles(folderPath);
                string fileName = $"Screenshot_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";
                string fullPath = Path.Combine(folderPath, fileName);

                TakeAScreenshot.Capture(fullPath);

                MessageBox.Show("Screenshot saved: " + fullPath);
                return true;  
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        } 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
