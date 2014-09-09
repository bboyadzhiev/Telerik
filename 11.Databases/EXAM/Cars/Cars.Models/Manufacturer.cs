namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        private ICollection<Car> cars;

        public virtual ICollection<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }
    }
}