namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANNER")]
    public partial class BANNER
    {
        public int ID { get; set; }

        public string HinhBN { get; set; }

        public string Noidung { get; set; }

        public bool? TinhTrang { get; set; }
    }
}
