namespace DOANWEB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public decimal Price { get; set; }

        public decimal PromotionPrice { get; set; }

        public bool IncludeVAT { get; set; }

        public int Quantity { get; set; }

        public int CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CareateBy { get; set; }

        public DateTime? ModifieDate { get; set; }

        [StringLength(50)]
        public string ModifieBy { get; set; }

        [StringLength(250)]
        public string MetaKey { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(50)]
        public string LinkVideo { get; set; }

        [StringLength(250)]
        public string ListType { get; set; }

        [StringLength(3000)]
        public string ListFile { get; set; }
    }
}
