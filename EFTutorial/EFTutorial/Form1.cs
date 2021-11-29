using EFTutorial.BLL;
using EFTutorial.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFTutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ls = LopHocBll.GetList();
            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // khi có sự thay đổi trên combox này , hiển thị danh sách sinh viên
            var lopHoc = comboBox1.SelectedItem as LopHoc;
            if(lopHoc !=null)
            {
                var ls = SinhVienBLL.GetList(lopHoc.ID);
                sinhVienBindingSource.DataSource = ls;
                dataGridView1.DataSource = sinhVienBindingSource;
            }    
        }
    }
}
