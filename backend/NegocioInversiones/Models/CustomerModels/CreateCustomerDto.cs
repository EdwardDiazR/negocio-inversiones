namespace NegocioInversiones.Models.CustomerModels
{
    public record CreateCustomerDto(
        string CustomerCivilId,
        int CustomerDocumentType,
        string CustomerFirstName,
        string ? CustomerMiddleName,
        string CustomerLastName,
        string ? CustomerSecondLastName,
        string CustomerEmail,
        string CustomerPhoneNumber,
        string? CustomerResidentialPhoneNumber,
        DateTime CustomerDob,
        string CustomerGender,
        string CustomerAddress,
        string CustomerCity,
        string CustomerCountry,
        double MonthlyIncome,
        string CustomerWorkPlace
        )
    {

    }
}
