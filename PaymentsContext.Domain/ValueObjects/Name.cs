using Flunt.Validations;
using PaymentsContext.Shared.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects;

public class Name : ValueObject
{
  public Name(string firstName, string lastName)
  {
    FirstName = firstName;
    LastName = lastName;

    AddNotifications(new Contract<Name>()
      .Requires()
      .IsLowerThan(FirstName,40, "Name.FirstName", "Nome deve conter até 40 caracteres")
      .IsLowerThan(LastName,40, "Name.LastName", "Sobrenome deve conter até 40 caracteres")
      .IsGreaterThan(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres"));
  }

  public string FirstName { get; private set; }
  public string LastName { get; private set; }
}
