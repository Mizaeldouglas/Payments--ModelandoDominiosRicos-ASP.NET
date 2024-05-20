using PaymentsContext.Domain.Enums;
using PaymentsContext.Shared.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects;

public class Documents : ValueObject
{
  public Documents(string number, EDocumentType type)
  {
    Number = number;
    Type = type;
  }
  public string Number { get; private set; } = string.Empty;
  public EDocumentType Type { get; set; }


}
