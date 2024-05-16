using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShopAPI.Models
{
    public class CustomerDetail
    {

        [Key]
        public int CustomerID { get; set; }
        
        public byte[] HashPasswordKey { get; set; }

        public byte[] Password { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

    }
}
