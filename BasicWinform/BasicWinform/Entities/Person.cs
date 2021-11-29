using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWinform.Entities
{
 public    class Person
    {
        /// <summary>
        /// mã người
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// TÊn
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Họ
        /// </summary>
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public EGioiTinh Sex { get; set; }
        /// <summary>
        /// Quê quán
        /// </summary>
        public string HomeTown { get; set; }
        public string IdFaculty { get; set; }

        // Mock data
        /// <summary>
        /// Lay toan bo danh sach sinh vien trong csdl
        /// </summary>
        /// <returns>
        /// Danh sach sinh vien</returns>
        public static List<Person> GetList()
        {
            var ls = new List<Person>();
            ls.Add(new Person
            {
                Id = "1",
                FirstName = "Võ",
                LastName = "Văn Nguyên",
                DOB = new DateTime(2000, 3, 2),
                HomeTown = "Quảng Bình",
                Sex = EGioiTinh.Nam,
                IdFaculty = "1"
            }) ;
            ls.Add(new Person
            {
                Id = "2",
                FirstName = "Hà",
                LastName = "Võ Kim ",
                DOB = new DateTime(2002, 2, 2),
                HomeTown = "Quảng Bình",
                Sex = EGioiTinh.Nu,
                 IdFaculty = "2"
            });
            return ls;
        }
        public static List<Person> GetList(string idFaculty)
        {
            var ls = GetList();
            var rs = ls.Where(e => e.IdFaculty == idFaculty).ToList();
            return rs;
        }
        /// <summary>
        /// Lay 1 sv tu csdl
        /// </summary>
        /// <param name="id"></param>
        /// <returns> sinh vien co ma tuong ung hoac
        /// null ko tim thay </returns>
        public static Person Get(string id)
        {
            var dbPerson = GetList();
            // Linq to SQl
            // lamda
            var person =
            dbPerson.Where(p=>p.Id==id).FirstOrDefault();
            return person;
        }
    }
    public enum EGioiTinh
        {
            Nam , Nu , Khac
        }
}


// frmUser:
/*
- Danh sách lịch sử học tập của sinh viên
    Cấp 1(1-5) --> Trường Nào --> Điểm Học Tập --> Hành kiểm 
    Cấp 2(6-9) 
    cap 3(10-12)*/