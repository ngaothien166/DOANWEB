using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DOANWEB.EF
{
    public partial class MyData : DbContext
    {
        public MyData()
            : base("name=MyData")
        {
        }

        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.QuestionList)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.AnswerList)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.ScoreList)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CareateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ModifieBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.LinkVideo)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ListType)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.CareateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.ModifieBy)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.ResultQuiz)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.StartDateQuiz)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.StartTimeQuiz)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.FinishTimeQuiz)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.StartTimeEssay)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.FinishTimeEssay)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Score)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CareateBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifieBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ProductList)
                .IsUnicode(false);
        }
    }
}
