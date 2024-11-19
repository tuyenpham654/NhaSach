namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        public int ID { get; set; }

        public string TenKH { get; set; }

        public int? CMND { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string NgaySinh { get; set; }

        [StringLength(50)]
        public string NgayLap { get; set; }

        public string DiaChi { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }
    }
}
