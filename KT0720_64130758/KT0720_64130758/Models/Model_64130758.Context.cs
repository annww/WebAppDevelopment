﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KT0720_64130758.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class KT0720_64130758Entities : DbContext
    {
        public KT0720_64130758Entities()
            : base("name=KT0720_64130758Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
    
        public virtual int SinhVien_TimKiem(string maSV, string hoTen, Nullable<System.DateTime> ngaySinh, Nullable<bool> gioiTinh, string anhSV, string diaChi, string maLop)
        {
            var maSVParameter = maSV != null ?
                new ObjectParameter("MaSV", maSV) :
                new ObjectParameter("MaSV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("HoTen", hoTen) :
                new ObjectParameter("HoTen", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var gioiTinhParameter = gioiTinh.HasValue ?
                new ObjectParameter("GioiTinh", gioiTinh) :
                new ObjectParameter("GioiTinh", typeof(bool));
    
            var anhSVParameter = anhSV != null ?
                new ObjectParameter("AnhSV", anhSV) :
                new ObjectParameter("AnhSV", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var maLopParameter = maLop != null ?
                new ObjectParameter("MaLop", maLop) :
                new ObjectParameter("MaLop", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SinhVien_TimKiem", maSVParameter, hoTenParameter, ngaySinhParameter, gioiTinhParameter, anhSVParameter, diaChiParameter, maLopParameter);
        }
    }
}