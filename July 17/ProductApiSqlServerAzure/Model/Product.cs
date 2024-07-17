using System.ComponentModel.DataAnnotations;

namespace ProductApiSqlServerAzure.Model
{
    public class Product
    { 


        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string? ProductImage { get; set; }
    }
}
