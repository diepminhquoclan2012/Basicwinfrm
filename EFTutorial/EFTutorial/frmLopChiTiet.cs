using EFTutorial.BLL;
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
    
    public partial class frmLopChiTiet : Form
    {
        private LopHocVM LopHocVM;
        public frmLopChiTiet(LopHocVM lopHocVM = null)
        {
            this.LopHocVM = lopHocVM;
            InitializeComponent();
            if(LopHocVM == null)
            {
                this.Text = " Thêm mới lớp học";

            }
            else
            {
                this.Text = "Cập nhật dữ liệu lớp học";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var tenlop = textTenLop.Text;
            if(string.IsNullOrEmpty(tenlop))
            {
                errorProvider1.SetError(textTenLop, "Lớp học không được để trống");
                return;
            } 
            var rs = KETQUA.ThanhCong;
           if(LopHocVM==null)
            {
                // thêm vào csdl
               rs=  LopHocBll.Add(new LopHocVM { Name = tenlop });
               
            } 
           else
            {
                // cập nhật dữ liệu
                LopHocVM vm = new LopHocVM();
                vm.ID = LopHocVM.ID;
                vm.Name = tenlop;                
                rs = LopHocBll.Update(vm);
            }
            if (rs == KETQUA.ThanhCong)
            {
                DialogResult = DialogResult.OK;
            }
            else if (rs == KETQUA.TenTrung)
            {
                MessageBox.Show("Tên lớp không được trung nhau ", " Thông báo");
            }
        }
    }
}
