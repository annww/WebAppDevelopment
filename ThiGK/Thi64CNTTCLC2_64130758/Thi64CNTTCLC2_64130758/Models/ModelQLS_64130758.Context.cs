﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thi64CNTTCLC2_64130758.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Thi64CNTTCLC2_64130758Entities1 : DbContext
    {
        public Thi64CNTTCLC2_64130758Entities1()
            : base("name=Thi64CNTTCLC2_64130758Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
    
        public virtual int Sach_TimKiem(string tenSach, string tacGia)
        {
            var tenSachParameter = tenSach != null ?
                new ObjectParameter("TenSach", tenSach) :
                new ObjectParameter("TenSach", typeof(string));
    
            var tacGiaParameter = tacGia != null ?
                new ObjectParameter("TacGia", tacGia) :
                new ObjectParameter("TacGia", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sach_TimKiem", tenSachParameter, tacGiaParameter);
        }
    }
}