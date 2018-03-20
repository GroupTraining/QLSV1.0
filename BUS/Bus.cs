﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Globalization;

namespace BUS
{
    public class Bus
    {
        DataDiagramDataContext data = new DataDiagramDataContext();
        public object getData1()//Lấy các dữ liệu liên quan đến giáo viên
        {
            var database = from u in data.GiaoViens
                           from v in data.MonHocs
                           where u.MaMon == v.MaMon
                           select new
                           {
                               MaGV = u.MaGV,
                               HoTen = u.TenGV,
                               NS = u.NgaySinh,
                               GT = u.Gioitinh,
                               SDT = u.SoDT,
                               MaMon = u.MaMon
                           };

            return database;
        }

        public object getData2()//Lấy các dữ liệu từ bảng học sinh +lớp
        {
            var database = from u in data.HocSinhs
                           from v in data.Lops
                               //from t in data.Diems
                               // from z in data.MonHocs
                           where u.MaLop == v.MaLop
                           // where u.MaSV == t.MaSV
                           //where t.MaMon == z.MaMon
                           select new
                           {
                               MaHS = u.MaSV,
                               HoTen = u.TenSV,
                               NgaySinh = u.NgaySinh,
                               GioiTinh = u.Gioitinh,
                               MaLop = u.MaLop,
                               /* TenMon = z.TenMon,
                                Diem = t.Diem1,*/

                           }


                           ;

            return database;
        }

        public object getData3()//lấy dữ liệu từ bảng học sinh + điểm
        {
            var database = from u in data.HocSinhs
                           from t in data.Diems
                           from z in data.MonHocs
                           where t.MaMon == z.MaMon
                           where t.MaSV == u.MaSV
                           select new
                           {
                               MaHocSinh = t.MaSV,
                               TenHocSinh = u.TenSV,
                               TenMon = z.TenMon,
                               Diem = t.Diem1,

                           }


                           ;

            return database;
        }

        public object addTeacher(string magv, string hoten, string gt, string ns, string sdt, string mamon)
        {
            GiaoVien gv = new GiaoVien();
            MonHoc mh = data.MonHocs.Single(a => a.MaMon == mamon);

            gv.MaGV = magv;
            gv.TenGV = hoten;

            if (gt == "Nam")
            {
                gv.Gioitinh = false;
            }
            if (gt == "Nữ")
            {
                gv.Gioitinh = true;
            }
            gv.NgaySinh = DateTime.ParseExact(ns, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            gv.SoDT = sdt;
            if (mh != null)
            {
                gv.MaMon = mamon;
            }


            data.GiaoViens.InsertOnSubmit(gv);
            data.SubmitChanges();


            return 1;
        }
        public object editTeacher(string ma, string ten, string ns, string gt, string sdt, string mon_hoc)
        {
            GiaoVien gv = data.GiaoViens.Single(a => a.MaGV == ma);
            gv.MaGV = ma;
            gv.TenGV = ten;
            // gv.NgaySinh = DateTime.ParseExact(ns, "dd/mm/yyyy", CultureInfo.InstalledUICulture);
            gv.NgaySinh = DateTime.Parse(ns, new CultureInfo("en-US", true));
            if (gt == "Nam")
            {
                gv.Gioitinh = false;
            }
            if (gt == "Nữ")
            {
                gv.Gioitinh = true;
            }
            gv.SoDT = sdt;
            gv.MaMon = mon_hoc;

            data.SubmitChanges();
            return 1;

        }
        public object DeleteTeacher(string ma)
        {
            var gv1 = from b in data.Lops
                      where b.MaGVCN == ma
                      select b;

            data.Lops.DeleteAllOnSubmit(gv1);
            var gv = from a in data.GiaoViens
                     where a.MaGV == ma
                     select a;

            data.GiaoViens.DeleteAllOnSubmit(gv);
            data.SubmitChanges();
            return 1;
        }
        public object addStudent(string masv, string tensv, string gt, string ns, string malop)
        {
            HocSinh hs = new HocSinh();
            Lop lop = data.Lops.Single(a => a.MaLop == malop);
            hs.MaSV = masv;
            hs.TenSV = tensv;

            if (gt == "Nam")
            {
                hs.Gioitinh = false;
            }
            if (gt == "Nữ")
            {
                hs.Gioitinh = true;
            }
            hs.NgaySinh = DateTime.ParseExact(ns, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (lop != null)
            {
                hs.MaLop = malop;
            }

            /*if (diem != null)
            {
                diem.MaMon = "m01";
                diem.Diem1 = Int32.Parse(toan);
            }
            if (van != null)
            {
                diem.MaMon = "m02";
                diem.Diem1 = Int32.Parse(van);
            }
            if (anh != null)
            {
                diem.MaMon = "m03";
                diem.Diem1 = Int32.Parse(anh);
            }*/
            data.HocSinhs.InsertOnSubmit(hs);
            data.SubmitChanges();


            return 1;
        }

        public int editStudent(string masv, string tensv, string gt, string ns, string malop)
        {
            HocSinh sv = data.HocSinhs.Single(a => a.MaSV == masv);
            int solop = 0;
            if (malop == "")
            {
                solop = 1;
            }
            else
            {
                solop = (from lp in data.Lops where lp.MaLop == malop select lp).Count();
            }
            if (solop > 0)
            {
                if (tensv == "")
                {
                    sv.TenSV = null;
                }
                else
                {
                    sv.TenSV = tensv;
                }
                if (gt == "")
                {
                    sv.Gioitinh = null;
                }
                else if (gt == "Nam")
                {
                    sv.Gioitinh = true;
                }
                else
                {
                    sv.Gioitinh = false;
                }
                if (ns == "")
                {
                    sv.NgaySinh = null;
                }
                else
                {
                    sv.NgaySinh = Convert.ToDateTime(ns);
                }
                if (malop == "")
                {
                    sv.MaLop = null;
                }
                else
                {
                    sv.MaLop = malop;
                }
            }
            else
            {
                //MessageBox.Show("Mã lớp không tồn tại, nhập lại mã lớp!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return 0;
            }
            try
            {
                data.SubmitChanges();
            }
            catch (Exception e)
            {

                //MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }

        public object deleteStudent(string masv)
        {
            int sosv = (from sv in data.HocSinhs where sv.MaSV == masv select sv).Count();
            if (sosv == 1)
            {
                HocSinh nv4 = data.HocSinhs.Single(a => a.MaSV == masv);
                data.HocSinhs.DeleteOnSubmit(nv4);
            }
            try
            {
                data.SubmitChanges();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 1;
        }

        public object addMark(string msv, string mamon, string mark)
        {
            Diem diem = new Diem();
            HocSinh hs = data.HocSinhs.Single(a => a.MaSV == msv);

            diem.MaSV = msv;

            diem.MaMon = mamon;
            diem.Diem1 = Int32.Parse(mark);
            /*}
            if (van != null)
            {
                diem.MaMon = "m02";
                diem.Diem1 = Int32.Parse(van);
            }
            if (anh != null)
            {
                diem.MaMon = "m03";
                diem.Diem1 = Int32.Parse(anh);
            }*/
            data.Diems.InsertOnSubmit(diem);
            data.SubmitChanges();


            return 1;
        }

        public object ThongKeDiemTheoMon(string text)
        {
            var hs = from u in data.HocSinhs
                     from v in data.MonHocs
                     from t in data.Diems
                     from z in data.Lops
                     where v.TenMon == text
                     where v.MaMon == t.MaMon
                     where u.MaLop == z.MaLop
                     where t.MaSV == u.MaSV
                     select new
                     {
                         Mã = u.MaSV,
                         Tên = u.TenSV,
                         Lớp = z.TenLop,
                         Điểm = t.Diem1
                     };
            return hs;
        }

        public object ThongKeDiemTheoLop(string text)
        {
            var hs = from u in data.HocSinhs
                     from v in data.MonHocs
                     from t in data.Diems
                     from z in data.Lops
                     where z.TenLop == text
                     where v.MaMon == t.MaMon
                     where u.MaLop == z.MaLop
                     where t.MaSV == u.MaSV
                     select new
                     {
                         Mã = u.MaSV,
                         Tên = u.TenSV,
                         Lớp = z.TenLop,
                         Điểm = t.Diem1
                     };
            return hs;
        }
        public object SearchByKey(string GiaTri)
        {
            // DateTime dt =
            //teTime.ParseExact(GiaTri, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var tk = from u in data.HocSinhs
                     select new
                     {
                         MaSV = u.MaSV,
                         HoTen = u.TenSV,
                         NgaySinh = u.NgaySinh,
                         GioiTinh = u.Gioitinh,
                         MaLop = u.MaLop

                     } into timkiemSV
                     where timkiemSV.MaSV.Contains(GiaTri)
                         || timkiemSV.HoTen.Contains(GiaTri)
                         // || timkiemSV.NgaySinh.Contains(dt)
                         //||  timkiemSV.GioiTinh.Contains(InGiaTri)
                         || timkiemSV.MaLop.Contains(GiaTri)
                     select timkiemSV;
            return tk;
        }

    }
}
