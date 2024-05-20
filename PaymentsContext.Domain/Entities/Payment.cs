using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Domain.Entities;

public abstract class Payment
{
  public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Documents document, string payer, Address address, Email email)
  {
    Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
    PaidDate = paidDate;
    ExpireDate = expireDate;
    Total = total;
    TotalPaid = totalPaid;
    Document = document;
    Payer = payer;
    Address = address;
    Email = email;
  }

  public DateTime ExpireDate { get; private set; }
  public DateTime PaidDate { get; private set; }
  public Documents Document { get; private set; }
  public Email Email { get; private set; }
  public Address Address { get; private set; }
  public string Number { get; private set; } = string.Empty;
  public decimal Total { get; private set; }
  public decimal TotalPaid { get; private set; }
  public string Payer { get; private set; } = string.Empty;
}