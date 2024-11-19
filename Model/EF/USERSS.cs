namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERSS")]
    public partial class USERSS
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        public int? GroupID { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public virtual USERGROUP USERGROUP { get; set; }
    }
}
