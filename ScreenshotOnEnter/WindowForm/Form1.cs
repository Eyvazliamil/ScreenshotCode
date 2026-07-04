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

            //KeyPreview = true;
            //KeyDown += Form1_KeyDown;

            listBox1.DoubleClick += listBox1_DoubleClick;
        }

        // ENTER basılanda Screenshot çək
        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{  
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        string fileName = $"Screenshot_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";
        //        string fullPath = Path.Combine(folderPath, fileName);

        //        TakeAScreenshot.Capture(fullPath);

        //        MessageBox.Show("Screenshot saved.");
        //    }
        //}

        // Şəkillərin adlarını ListBox-a yüklə
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    GetFiles(folderPath);
        //}

        // Çıxış
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

        // Şəkli Default Program (Photos) ilə aç
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                return true; // Enter-in düymələrə ötürülməsinin qarşısını alır
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}