using PaymentsContext.Shared.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects;

public class Email : ValueObject
{
  public Email(string address)
  {
    Address = address;
  }
  public string Address { get; private set; } = string.Empty;
}
