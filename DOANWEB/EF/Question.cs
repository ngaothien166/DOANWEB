namespace DOANWEB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        public int ID { get; set; }

        [StringLength(3000)]
        public string Name { get; set; }

        public string Content { get; set; }

        [StringLength(3000)]
        public string Answer { get; set; }

        [StringLength(1)]
        public string Type { get; set; }

        public int ProductID { get; set; }

        public bool Status { get; set; }
    }
}
