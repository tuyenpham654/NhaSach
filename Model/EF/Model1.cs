using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BANNER> BANNERs { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAMs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<Orderc> Orders { get; set; }
        public virtual DbSet<Orderdetailc> Orderdetails { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TINTUC> TINTUCs { get; set; }
        public virtual DbSet<USERGROUP> USERGROUPs { get; set; }
        public virtual DbSet<USERSS> USERSSes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaKH)
                .IsFixedLength();

            modelBuilder.Entity<LOAISANPHAM>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.LOAISANPHAM)
                .HasForeignKey(e => e.TheLoai);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.NHACUNGCAP)
                .HasForeignKey(e => e.NCC);

            modelBuilder.Entity<Orderc>()
                .HasMany(e => e.Orderdetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.Orderdetails)
                .WithRequired(e => e.SANPHAM)
                .HasForeignKey(e => e.ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERGROUP>()
                .HasMany(e => e.USERSSes)
                .WithOptional(e => e.USERGROUP)
                .HasForeignKey(e => e.GroupID);
        }
    }
}
