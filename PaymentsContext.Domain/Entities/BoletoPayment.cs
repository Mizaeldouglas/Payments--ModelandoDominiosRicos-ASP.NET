using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Domain.Entities;

public class BoletoPayment : Payment
{
  public BoletoPayment(string barCode, string boletoNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Documents document, string payer, Address address, Email email) : base(paidDate, expireDate, total, totalPaid, document, payer, address, email)
  {
    BarCode = barCode;
    BoletoNumber = boletoNumber;
  }

  public string BarCode { get; private set; } = string.Empty;
  public string BoletoNumber { get; private set; } = string.Empty;
}
