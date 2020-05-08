using System;
using System.Windows.Forms;

namespace SpecialFolder
{
    public partial class mainUI : Form
    {
        internal Operation Operation1 { get; set; } = new Operation();

        public mainUI()
        {
            InitializeComponent();
        }

        private void UnlockBtn_Click(object sender, EventArgs e)
        {
            String pw = pwTB.Text;
            String path = pathTB.Text;
            if (Operation1.CheckPath(path)) {
                Operation1.ChangePath(path);
                if (Operation1.CheckPass(pw, path))
                {
                    Operation1.UnLockDir();
                }
            }
        }

        private void LockBtn_Click(object sender, EventArgs e)
        {
            String path = pathTB.Text;
            String pw = pwTB.Text;
            if (Operation1.CheckPath(path)) {
                Operation1.ChangePath(path);
                if (Operation1.SetPass(pw, path))
                {
                    Operation1.LockDir();
                }
            }
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string folderPath = folderBrowserDialog1.SelectedPath;
            if (!(folderPath == "" || folderPath == null))
            {
                Console.WriteLine("[FolderBrowerDialog1] The selected path: \"{0}\"", folderPath);
                pathTB.Text = folderPath;
            } else
            {
                Console.WriteLine("[FolderBrowerDialog1] No path selected.");
            }
        }
    }
}
