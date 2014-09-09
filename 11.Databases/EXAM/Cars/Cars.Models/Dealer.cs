namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        public Dealer()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        private ICollection<Car> cars;

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}