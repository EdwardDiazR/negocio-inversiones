using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace NegocioInversiones.Models.CustomerModels
{
    [Table("personal_customer")]
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string? MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }

        [Column("customer_civil_id")]
        public string CivilId { get; set; }

        [Column("customer_civil_id_type")]
        public int CustomerCivilIdType { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ResidentialPhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CustomerDob { get; set; }
        public double MonthlyIncome { get; set; }
        public string ? WorkPlace { get; set; }
        public int CustomerAge { get; set; }

        public string Gender{ get; set; }

        //Create a db with different status codes and description
        public int CustomerProfileStatus { get; set; }

        public DateTime LastTimeProfileUpdated { get; set; }
        public bool WorkPlaceVerified { get; set; }
        public bool IncomeVerified { get; set; }


    }
}
