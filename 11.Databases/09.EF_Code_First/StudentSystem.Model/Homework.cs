namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Homeworks")]
    public class Homework
    {
        [Key, Column("HomeworkID")]
        public int HomeworkID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Column("Content")]
        public string Content { get; set; }

        [Required]
        [Column("TimeSent")]
        public DateTime TimeSent { get; set; }

        [Column("Course"), ForeignKey("Course")]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        [Column("Student"), ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}