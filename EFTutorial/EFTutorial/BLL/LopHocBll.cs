using EFTutorial.DAL;
using EFTutorial.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorial.BLL
{
    public enum KETQUA
    {
        TenTrung,ThanhCong
    }
    class LopHocBll
    {
        public static List<LopHoc> GetList()
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var ls = model.LopHocs.ToList();
            return ls;
        }
        public static List<LopHocVM> GetListVM()
        {

            QLSinhVienModel model = new QLSinhVienModel();
            //var ls = model.LopHocs.OrderByDescending(e => e.Name).ToList();
            var ls = model.LopHocs.Select(e => new LopHocVM
            {
                ID = e.ID,
                Name = e.Name,
                TottalStudent = e.SinhVienss.Count, }).ToList();
            return ls;
        
       
                    
        }
        public static void Delete(long idLop)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var lop = model.LopHocs.Where(e => e.ID == idLop ).FirstOrDefault();
            if (lop != null)
                model.LopHocs.Remove(lop);
            else
            {
                throw new Exception("Sĩ Số Lớn Hơn Không");
            }
            model.SaveChanges();
        }
        public static KETQUA Add(LopHocVM lopHocVM)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var lop = model.LopHocs.Where(e => e.Name == lopHocVM.Name).FirstOrDefault();
            if (lop != null)
                return KETQUA.TenTrung;
            else
            {
                lop = new LopHoc
                {
                    Name = lopHocVM.Name
                };
                model.LopHocs.Add(lop);
                model.SaveChanges();
                return KETQUA.ThanhCong;
            }
        }
        public static KETQUA Update(LopHocVM lophocvm)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var lop = model.LopHocs.Where(e => 
            e.ID != lophocvm.ID &&
            e.Name == lophocvm.Name).FirstOrDefault();
            if(lop !=null)
            {
                return KETQUA.TenTrung;
            }
            else
            {
                lop = model.LopHocs.Where(e=>e.ID ==lophocvm.ID).FirstOrDefault();
                lop.Name = lophocvm.Name;
                model.SaveChanges();
                return KETQUA.ThanhCong;
            }

        }
        // cứ có Id là nó xóa, giả sử trong lớp học đó có sinh viên không được xóa.
        // Báo lỗi trong lơp này có sinh viên. thực chất đây không phải lỗi , Chúng ta giả định đó là lỗi.
    }
}
