using EFTutorial.DAL;
using EFTutorial.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EFTutorial.BLL
{
   
    class SinhVienBLL
    {
        
        public static List<SinhVien> GetList(long idLop)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            return model.SinhViens.Where(e => e.IDLop == idLop).ToList();
        }
        public static List<SinhVienVM> GetListVM(long idLop)
        {
          
            QLSinhVienModel model = new QLSinhVienModel();
            var ls1 = model.SinhViens.Where(e => e.IDLop == idLop).Select(item => new SinhVienVM
            {
                ID = item.ID,
                IDStudent = item.IDStudent,
                FirstName = item.FirstName,
                LastName = item.LastName,
                DOB = (DateTime)item.DOB,
                POB = item.POB,
                IDLop = (long)item.IDLop,

            }).ToList();
            return ls1;
        }
        public static void Delete(long id)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var sv = model.SinhViens.Where(e => e.ID == id).FirstOrDefault();
            if (sv != null)
                model.SinhViens.Remove(sv);
            else
            {
                throw new Exception("Sĩ Số Lớn Hơn Không");
            }
            model.SaveChanges();
        }

        public static KETQUA Add(SinhVienVM sinhVienVM)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var sv = model.SinhViens.Where(e => e.IDStudent == sinhVienVM.IDStudent).FirstOrDefault();
            if (sv != null)
                return KETQUA.TenTrung;
            else
            {
                SinhVien data = new SinhVien
                {
                    
                    IDStudent = sinhVienVM.IDStudent,
                    FirstName = sinhVienVM.FirstName,
                    LastName = sinhVienVM.LastName,
                    DOB = sinhVienVM.DOB,
                    POB = sinhVienVM.POB,
                    IDLop = sinhVienVM.IDLop
                };
                model.SinhViens.Add(data);
                model.SaveChanges();
                return KETQUA.ThanhCong;
            }
        }
    }
}
