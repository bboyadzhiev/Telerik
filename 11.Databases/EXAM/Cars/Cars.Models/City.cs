namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        public City()
        {
            this.dealers = new HashSet<Dealer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        private ICollection<Dealer> dealers;

        public ICollection<Dealer> Dealers
        {
            get { return this.dealers; }
            set { this.dealers = value; }
        }
    }
}