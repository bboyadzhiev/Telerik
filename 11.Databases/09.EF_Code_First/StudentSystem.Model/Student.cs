namespace StudentSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Students")]
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        [Key, Column("CourseID")]
        public int StudentID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Age")]
        public int Age { get; set; }

        [Column("Number")]
        public int Number { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}