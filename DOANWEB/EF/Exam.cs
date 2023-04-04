namespace DOANWEB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exam")]
    public partial class Exam
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(200)]
        public string QuestionList { get; set; }

        [StringLength(200)]
        public string AnswerList { get; set; }

        public int ProductID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int TotalScore { get; set; }

        public int Time { get; set; }

        public int TotalQuestion { get; set; }

        [StringLength(1)]
        public string Type { get; set; }

        public bool Status { get; set; }

        public string QuestionEssay { get; set; }

        [StringLength(3000)]
        public string UserList { get; set; }

        [StringLength(200)]
        public string ScoreList { get; set; }
    }
}
