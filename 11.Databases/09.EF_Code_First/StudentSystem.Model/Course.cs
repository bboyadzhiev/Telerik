namespace StudentSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Courses")]
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }

        [Key, Column("CourseID")]
        public int CourseID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Column("Description")]
        public string Description { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Column("Materials")]
        public string Materials { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }
    }
}