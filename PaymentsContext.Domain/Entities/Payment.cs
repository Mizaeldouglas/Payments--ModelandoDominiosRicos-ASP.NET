namespace PaymentsContext.Domain.Entities;

public abstract class Payment
{
  public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string document, string payer, string address, string email)
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

  public string Number { get; private set; } = string.Empty;
  public DateTime PaidDate { get; private set; }
  public DateTime ExpireDate { get; private set; }
  public decimal Total { get; private set; }
  public decimal TotalPaid { get; private set; }
  public string Document { get; private set; } = string.Empty;
  public string Payer { get; private set; } = string.Empty;
  public string Address { get; private set; } = string.Empty;
  public string Email { get; private set; } = string.Empty;
}