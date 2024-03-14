using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegocioInversiones.Models.Request
{
    [Table("request")]
    public class Request
    {
        [Column("request_id")]
        [Key]
        public long Id { get; set; }

        [Column("request_type")]
        public int Type { get; set; }

        [Column("request_date")]
        public DateTime Date { get; set; }
        [Column("request_customer_id")]
        public int CustomerId { get; set; }
    }
}
