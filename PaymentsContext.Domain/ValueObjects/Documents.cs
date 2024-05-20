using Flunt.Validations;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Shared.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects;

public class Documents : ValueObject
{
  public Documents(string number, EDocumentType type)
  {
    Number = number;
    Type = type;
    
    AddNotifications(new Contract<Documents>()
      .Requires()
      .IsTrue(Validate(),"Document.Number", "Documento inválido"));
  }
  public string Number { get; private set; } = string.Empty;
  public EDocumentType Type { get; set; }

  private bool Validate()
  {
    if (Type == EDocumentType.CPF && Number.Length == 11)
      return true;
    if (Type == EDocumentType.CNPJ && Number.Length == 14)
      return true;
    

    return false;
  }

}
