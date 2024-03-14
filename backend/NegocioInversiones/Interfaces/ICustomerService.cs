using NegocioInversiones.Models.CustomerModels;

namespace NegocioInversiones.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(CreateCustomerDto customerDto);
        Customer GetCustomerByCivilId(string CustomerId, int? CustomerIdType);
        Customer GetCustomerByCustomerId(int CustomerId);
    }
}
