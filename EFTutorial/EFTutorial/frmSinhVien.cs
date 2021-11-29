using EFTutorial.BLL;
using EFTutorial.DAL;
using EFTutorial.ViewModel;
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
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
            var ls = LopHocBll.GetList();
            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
        void NapSinhVien()
        {
            var Lh = comboBox1.SelectedItem as LopHoc;
            if (Lh != null)
            {
                var ls = SinhVienBLL.GetListVM(Lh.ID);
                sinhVienVMBindingSource.DataSource = ls;
                dataGridView1.DataSource = sinhVienVMBindingSource;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NapSinhVien();
        }

        public SinhVienVM selectSV
        {
            get
            {
                return sinhVienVMBindingSource.Current as SinhVienVM;
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (selectSV != null)
            {
                if (MessageBox.Show("Bạn có thực sự muốn xóa ?", "Chú ý",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SinhVienBLL.Delete(selectSV.ID);
                    sinhVienVMBindingSource.RemoveCurrent();
                    // confoem xác nhận
                    MessageBox.Show("ĐÃ xóa lớp thành công");
                }
            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            var Lh = comboBox1.SelectedItem as LopHoc;
            var f = new frmSVChiTiet(Lh.ID,null);
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                Console.WriteLine("da nap sv");
                NapSinhVien();
            }
        }
    }
}
