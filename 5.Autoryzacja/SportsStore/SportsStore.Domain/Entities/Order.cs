using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public ICollection<CartLine> Lines { get; set; }
        public bool Shipped { get; set; }
        [Required(ErrorMessage = "Proszę wprowadzić imię i nazwisko")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić przynajmniej pierwszą linię z adresem")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Proszę wprowadzić nazwę miasta")]
        public string City { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Proszę wprowadzić nazwę kraju")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
