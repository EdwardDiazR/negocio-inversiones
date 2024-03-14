namespace NegocioInversiones.Models.CustomerModels
{
    public record UpdateCustomerDto(int CustomerId, 
        string CustomerFirstName, 
        string CustomerMiddleName,
        string CustomerLastName,
        string CustomerSecondLastName)
    {
    }
}
