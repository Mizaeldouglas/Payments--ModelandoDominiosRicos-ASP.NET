using PaymentsContext.Shared.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects;

public class Name : ValueObject
{
  public Name(string firstName, string lastName)
  {
    FirstName = firstName;
    LastName = lastName;
    
    if (string.IsNullOrEmpty(FirstName))
    {
      AddNotification("Name.FirstName", "Nome inválido");
    }
  }

  public string FirstName { get; private set; } = string.Empty;
  public string LastName { get; private set; } = string.Empty;
}
