using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicWinform
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
           Application.Run(new happy_new_year());
           //Application.Run(new TreeView());
           
        }
    }
    // Bài tập ? 
    // Thảy đổi hình nền thông tin cá nhân, bằng cách chọn màu --> màu nên sẽ thay đổi , 
}
