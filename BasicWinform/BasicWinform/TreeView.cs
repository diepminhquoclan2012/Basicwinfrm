using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BasicWinform
{
    public partial class TreeView : Form
    {
        public TreeView()
        {
            InitializeComponent();
            // Lấy danh sách tên ổ đĩa.
           
        }
        void addNode(TreeNode parentNode, string parentDirectory, int leve)
        {
            if (leve <=3)
            { 
                try
                {
                    var directoryInfo = new DirectoryInfo(parentDirectory);
                    var directories = directoryInfo.GetDirectories();
                    // giúp lấy thư mục con
                    if (directories.Length > 0)
                        foreach (var directory in directories)
                        {                        
                            TreeNode node = new TreeNode(directory.Name);                                                  
                            parentNode.Nodes.Add(node);                          
                            addNode(node, directory.FullName, leve + 1);

                        }


                }
                catch(Exception ee) { Console.WriteLine("loi " + ee.Message); }

            }
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            BackgroundWorker worker = new BackgroundWorker();
            List<TreeNode> ls = new List<TreeNode>();
            worker.DoWork += (t, w) =>
             {
                 
                 var drives = Environment.GetLogicalDrives();
                 foreach (var drive in drives)
                 {
                    
                     // Cái này là tạo ra  1 cái nút.
                     TreeNode nodeDrive = new TreeNode(drive);
                     // thêm cái nút đó vào .
                     ls.Add(nodeDrive);                    
                     addNode(nodeDrive, drive, 1);
                 }
             };
            worker.RunWorkerCompleted += (t, w) =>
             {
                  
                 pictureBox1.Visible = false;
                 treeView1.Nodes.AddRange(ls.ToArray());           
             };
            worker.RunWorkerAsync();
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selNode = e.Node;
            try
            {
                LoadImage(selNode.FullPath);
               
            }
            catch (Exception ex)
            {
                
            }
        }
        private void LoadImage(string path)
        {
            fPn.Controls.Clear();
            pictureBox2.Image = null;
            string[] Files = Directory.GetFiles(path);
            fPn.Controls.Clear();
            int i = 1;
            foreach (String image in Files)
            {
                if (image.ToLower().EndsWith(".jpg") || image.ToLower().EndsWith(".GIF") ||
                    image.ToLower().EndsWith(".png") || image.ToLower().EndsWith(".bmp") ||
                    image.ToLower().EndsWith(".jpeg"))
                {
                    PictureBox display = new PictureBox();
                    display.SizeMode = PictureBoxSizeMode.StretchImage;
                    display.Image = Image.FromFile(image);
                    display.Height = 80;
                    display.Width = 80;                  
                    display.Cursor = Cursors.Hand;
                    fPn.Controls.Add(display);
                    display.Click += new EventHandler(pic_Click);
                }
                if (i++ == 10)
                    Application.DoEvents();
            }
        }
        void pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pictureBox2.Image = pic.Image;
        }
    }
}
