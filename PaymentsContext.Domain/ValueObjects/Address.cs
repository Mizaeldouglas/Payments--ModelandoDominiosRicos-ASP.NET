using Flunt.Validations;
using PaymentsContext.Shared.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects;

public class Address : ValueObject
{
  public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
  {
    Street = street;
    Number = number;
    Neighborhood = neighborhood;
    City = city;
    State = state;
    Country = country;
    ZipCode = zipCode;
    
    AddNotifications(new Contract<Address>()
      .Requires()
      .IsNotNullOrEmpty(Street, "Address.Street", "Rua inválida")
      .IsNotNullOrEmpty(Number, "Address.Number", "Número inválido")
      .IsNotNullOrEmpty(Neighborhood, "Address.Neighborhood", "Bairro inválido")
      .IsNotNullOrEmpty(City, "Address.City", "Cidade inválida")
      .IsNotNullOrEmpty(State, "Address.State", "Estado inválido")
      .IsNotNullOrEmpty(Country, "Address.Country", "País inválido")
      .IsNotNullOrEmpty(ZipCode, "Address.ZipCode", "CEP inválido")
      .IsLowerThan(Street.Length, 40, "Address.Street", "Rua deve conter até 40 caracteres")
      .IsGreaterThan(Number.Length, 1, "Address.Number", "Número deve conter pelo menos 1 caractere")
      .IsLowerThan(Neighborhood.Length, 40, "Address.Neighborhood", "Bairro deve conter até 40 caracteres")
      .IsLowerThan(City.Length, 40, "Address.City", "Cidade deve conter até 40 caracteres")
      .IsLowerThan(State.Length, 40, "Address.State", "Estado deve conter até 40 caracteres")
      .IsLowerThan(Country.Length, 40, "Address.Country", "País deve conter até 40 caracteres")
      .IsLowerThan(ZipCode.Length, 9, "Address.ZipCode", "CEP deve conter até 9 caracteres"));
  }

  public string Street { get; private set; }
  public string Number { get; private set; }
  public string Neighborhood { get; private set; }
  public string City { get; private set; }
  public string State { get; private set; } 
  public string Country { get; private set; } 
  public string ZipCode { get; private set; }
}
