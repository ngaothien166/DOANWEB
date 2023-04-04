namespace DOANWEB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public int ParentID { get; set; }

        public int DisplayOder { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CareateBy { get; set; }

        public DateTime? ModifieDate { get; set; }

        [StringLength(50)]
        public string ModifieBy { get; set; }

        public bool Status { get; set; }

        public bool ShowOnHome { get; set; }
    }
}
