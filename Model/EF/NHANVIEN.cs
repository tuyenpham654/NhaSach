namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        public int MaNV { get; set; }

        public string TenNV { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        public int? SDT { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }
    }
}
