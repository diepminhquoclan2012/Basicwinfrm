using EFTutorial.BLL;
using EFTutorial.ViewModel;
using System;
using System.Windows.Forms;

namespace EFTutorial
{
    public partial class frmLopHoc : Form
    {
        public frmLopHoc()
        {
            InitializeComponent();
            // có dữ liệu -> thêm , sửa ,  xóa
            NapLopHoc();
        }
        void NapLopHoc()
        {
            var ls = LopHocBll.GetListVM();
            lopHocVMBindingSource.DataSource = ls;
            dataGridView1.DataSource = lopHocVMBindingSource;
        }

        public LopHocVM selectLopHoc
        {
            get
            {
                return lopHocVMBindingSource.Current as LopHocVM;
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(selectLopHoc !=null)
            {
                if (MessageBox.Show("Bạn có thực sự muốn xóa ?", "Chú ý",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    LopHocBll.Delete(selectLopHoc.ID);
                    lopHocVMBindingSource.RemoveCurrent();
                    // confoem xác nhận
                    MessageBox.Show("ĐÃ xóa lớp thành công");
                }
            }    
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var f = new frmLopChiTiet();
            var rs = f.ShowDialog();
            if(rs == DialogResult.OK)
            {
                NapLopHoc();
            }    
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           
            var f = new frmLopChiTiet(selectLopHoc);
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapLopHoc();
            }
        }
    }
}
//1 Cộng trừ nhanh chia
//2 Bắn pháo hoa
//3 hiểm thị ảnh ở thư mục có ảnh 
//4 thêm sửa thông tin sinh viên
