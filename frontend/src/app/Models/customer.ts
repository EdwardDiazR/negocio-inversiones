export interface Customer {
  id:number
  civilId: string;
  customerCivilIdType: number;
  firstName: string;
  middleName: string;
  lastName: string;
  secondLastName: string;
  email: string;
 gender: string;
 customerDob: Date;
  phoneNumber: string;
  residentialPhoneNumber: string;
  address: string;
  city: string;
  country: string;
  monthlyIncome: number;
  workPlace: string;
  customerProfileStatus:number;
  incomeVerified:boolean
}

export interface CreateCustomerDto {
  CustomerCivilId: string;
  CustomerDocumentType: number;
  CustomerFirstName: string;
  CustomerMiddleName: string;
  CustomerLastName: string;
  CustomerSecondLastName: string;
  CustomerEmail: string;
  CustomerGender: string;
  CustomerDob: Date;
  CustomerPhoneNumber: string;
  CustomerResidentialPhoneNumber: string;
  CustomerAddress: string;
  CustomerCity: string;
  CustomerCountry: string;
  monthlyIncome: number;
  CustomerWorkPlace: string;
}
