namespace EXON.SubModel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MTAQuizDbContext : DbContext
    {
        public MTAQuizDbContext()
            : base("name=MTA_QUIZ_1")
        {
        }

        public virtual DbSet<ANSWER> ANSWERS { get; set; }
        public virtual DbSet<ANSWERS_TEMP> ANSWERS_TEMP { get; set; }
        public virtual DbSet<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }
        public virtual DbSet<ANSWERSHEET_SPEAKING> ANSWERSHEET_SPEAKING { get; set; }
        public virtual DbSet<ANSWERSHEET_WRITING> ANSWERSHEET_WRITING { get; set; }
        public virtual DbSet<ANSWERSHEET> ANSWERSHEETS { get; set; }
        public virtual DbSet<BAGOFTEST> BAGOFTESTS { get; set; }
        public virtual DbSet<CONTESTANTPAUSE> CONTESTANTPAUSEs { get; set; }
        public virtual DbSet<CONTESTANT> CONTESTANTS { get; set; }
        public virtual DbSet<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }
        public virtual DbSet<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }
        public virtual DbSet<CONTEST> CONTESTS { get; set; }
        public virtual DbSet<DIVISION_SHIFTS> DIVISION_SHIFTS { get; set; }
        public virtual DbSet<DIVISIONSHIFT_SUPERVISOR> DIVISIONSHIFT_SUPERVISOR { get; set; }
        public virtual DbSet<DIVSIONSHIFT_PAUSE> DIVSIONSHIFT_PAUSE { get; set; }
        public virtual DbSet<EXAMINATIONCOUNCIL_POSITIONS> EXAMINATIONCOUNCIL_POSITIONS { get; set; }
        public virtual DbSet<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }
        public virtual DbSet<FINGERPRINT> FINGERPRINTS { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<POSITION> POSITIONS { get; set; }
        public virtual DbSet<QUESTION> QUESTIONS { get; set; }
        public virtual DbSet<QUESTIONS_TEMP> QUESTIONS_TEMP { get; set; }
        public virtual DbSet<ROOMDIAGRAM> ROOMDIAGRAMS { get; set; }
        public virtual DbSet<ROOMTEST> ROOMTESTS { get; set; }
        public virtual DbSet<SCHEDULE> SCHEDULES { get; set; }
        public virtual DbSet<SHIFT> SHIFTS { get; set; }
        public virtual DbSet<SHIFTSPAUSE> SHIFTSPAUSEs { get; set; }
        public virtual DbSet<SPEAKING_TEACHER> SPEAKING_TEACHER { get; set; }
        public virtual DbSet<STAFF> STAFFS { get; set; }
        public virtual DbSet<STAFFS_POSITIONS> STAFFS_POSITIONS { get; set; }
        public virtual DbSet<SUBJECT> SUBJECTS { get; set; }
        public virtual DbSet<SUBQUESTION> SUBQUESTIONS { get; set; }
        public virtual DbSet<SUBQUESTIONS_TEMP> SUBQUESTIONS_TEMP { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TEST_DETAILS> TEST_DETAILS { get; set; }
        public virtual DbSet<TESTNUMBER> TESTNUMBERs { get; set; }
        public virtual DbSet<TEST> TESTS { get; set; }
        public virtual DbSet<VIOLATION> VIOLATIONS { get; set; }
        public virtual DbSet<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }
        public virtual DbSet<WRITING_TEACHER> WRITING_TEACHER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ANSWERSHEET_SPEAKING>()
                .HasMany(e => e.SPEAKING_TEACHER)
                .WithRequired(e => e.ANSWERSHEET_SPEAKING)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ANSWERSHEET>()
                .HasMany(e => e.ANSWERSHEET_DETAILS)
                .WithRequired(e => e.ANSWERSHEET)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BAGOFTEST>()
                .HasMany(e => e.TESTS)
                .WithRequired(e => e.BAGOFTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTESTANT>()
                .Property(e => e.ContestantCode)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANT>()
                .Property(e => e.IdentityCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANT>()
                .Property(e => e.StudentCode)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANT>()
                .HasMany(e => e.CONTESTANTS_SHIFTS)
                .WithRequired(e => e.CONTESTANT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTESTANT>()
                .HasMany(e => e.FINGERPRINTS)
                .WithRequired(e => e.CONTESTANT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTESTANTS_SHIFTS>()
                .HasMany(e => e.VIOLATIONS_CONTESTANTS)
                .WithRequired(e => e.CONTESTANTS_SHIFTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTESTANTS_TESTS>()
                .HasMany(e => e.ANSWERSHEETS)
                .WithRequired(e => e.CONTESTANTS_TESTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTEST>()
                .Property(e => e.SchoolYear)
                .IsUnicode(false);

            modelBuilder.Entity<CONTEST>()
                .HasMany(e => e.LOCATIONS)
                .WithRequired(e => e.CONTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIVISION_SHIFTS>()
                .HasMany(e => e.BAGOFTESTS)
                .WithRequired(e => e.DIVISION_SHIFTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIVISION_SHIFTS>()
                .HasMany(e => e.CONTESTANTS_SHIFTS)
                .WithRequired(e => e.DIVISION_SHIFTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EXAMINATIONCOUNCIL_POSITIONS>()
                .Property(e => e.ExaminationCouncil_PositionCode)
                .IsUnicode(false);

            modelBuilder.Entity<EXAMINATIONCOUNCIL_STAFFS>()
                .HasMany(e => e.DIVISIONSHIFT_SUPERVISOR)
                .WithOptional(e => e.EXAMINATIONCOUNCIL_STAFFS)
                .HasForeignKey(e => e.SupervisorID);

            modelBuilder.Entity<LOCATION>()
                .HasMany(e => e.ROOMTESTS)
                .WithRequired(e => e.LOCATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.PositionCode)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .HasMany(e => e.STAFFS_POSITIONS)
                .WithRequired(e => e.POSITION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUESTION>()
                .HasMany(e => e.SUBQUESTIONS)
                .WithRequired(e => e.QUESTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUESTION>()
                .HasMany(e => e.TEST_DETAILS)
                .WithRequired(e => e.QUESTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROOMDIAGRAM>()
                .Property(e => e.ComputerCode)
                .IsUnicode(false);

            modelBuilder.Entity<ROOMDIAGRAM>()
                .Property(e => e.ClientIP)
                .IsUnicode(false);

            modelBuilder.Entity<ROOMTEST>()
                .HasMany(e => e.DIVISION_SHIFTS)
                .WithRequired(e => e.ROOMTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SCHEDULE>()
                .HasMany(e => e.CONTESTANTS_SHIFTS)
                .WithRequired(e => e.SCHEDULE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SHIFT>()
                .HasMany(e => e.DIVISION_SHIFTS)
                .WithRequired(e => e.SHIFT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.IdentityCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.SPEAKING_TEACHER)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.TeacherID);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.STAFFS_POSITIONS)
                .WithRequired(e => e.STAFF)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.WRITING_TEACHER)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.TeacherID);

            modelBuilder.Entity<SUBJECT>()
                .Property(e => e.SubjectCode)
                .IsUnicode(false);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.SCHEDULES)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.TESTS)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBQUESTION>()
                .HasMany(e => e.ANSWERS)
                .WithRequired(e => e.SUBQUESTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBQUESTION>()
                .HasMany(e => e.ANSWERSHEET_DETAILS)
                .WithRequired(e => e.SUBQUESTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEST_DETAILS>()
                .Property(e => e.RandomAnswer)
                .IsUnicode(false);

            modelBuilder.Entity<TEST>()
                .HasMany(e => e.CONTESTANTS_TESTS)
                .WithRequired(e => e.TEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEST>()
                .HasMany(e => e.TEST_DETAILS)
                .WithRequired(e => e.TEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VIOLATION>()
                .HasMany(e => e.VIOLATIONS_CONTESTANTS)
                .WithRequired(e => e.VIOLATION)
                .WillCascadeOnDelete(false);
        }
    }
}
