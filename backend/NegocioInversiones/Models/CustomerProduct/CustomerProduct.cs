using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegocioInversiones.Models.CustomerProduct
{
    [Table("customer_product")]
    public class CustomerProduct
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }
        [Column("product_type_id")]
        public int ProductType { get; set; }

        [Column("product_customer_id")]
        public int CustomerId { get; set; }
    }
}
