using Flunt.Validations;
using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Shared.Entities;

namespace PaymentsContext.Domain.Entities;

public abstract class Payment : Entity
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
    AddNotifications(new Contract<Payment>()
      .Requires()
      .IsGreaterThan(PaidDate, DateTime.Now, "Payment.PaidDate", "A data do pagamento deve ser futura")
      .IsGreaterThan(ExpireDate, DateTime.Now, "Payment.ExpireDate", "A data de expiração deve ser futura")
      .IsGreaterOrEqualsThan(Total, 0, "Payment.Total", "O total deve ser maior que zero")
      .IsGreaterOrEqualsThan(TotalPaid, Total, "Payment.TotalPaid", "O valor pago é menor que o valor do pagamento")
      .IsNotNullOrEmpty(Payer, "Payment.Payer", "Pagador inválido")
      );
  }

  public DateTime ExpireDate { get; private set; }
  public DateTime PaidDate { get; private set; }
  public Documents Document { get; private set; }
  public Email Email { get; private set; }
  public Address Address { get; private set; }
  public string Number { get; private set; }
  public decimal Total { get; private set; }
  public decimal TotalPaid { get; private set; }
  public string Payer { get; private set; }
}