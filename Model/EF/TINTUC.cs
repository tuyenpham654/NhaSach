namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINTUC")]
    public partial class TINTUC
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string LoaiTinTuc { get; set; }

        public string TenTinTuc { get; set; }

        public string NoiDung { get; set; }

        public string Hinh { get; set; }
    }
}
