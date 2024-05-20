using Flunt.Validations;
using PaymentsContext.Shared.Entities;

namespace PaymentsContext.Domain.Entities;

public class Subscription : Entity
{
  private IList<Payment> _payments;
  public Subscription(DateTime? expireDate)
  {
    CreateDate = DateTime.Now;
    LastUpdateDate = DateTime.Now;
    ExpireDate = expireDate;
    Active = true;
    _payments = new List<Payment>();
  }

  public DateTime CreateDate { get; private set; }
  public DateTime LastUpdateDate { get; private set; }
  public DateTime? ExpireDate { get; private set; }

  public bool Active { get; private set; }

  public IReadOnlyCollection<Payment> Payments { get; private set; }

  public void AddPayment(Payment payment)
  {
    AddNotifications(new Contract<Subscription>()
      .Requires()
      .IsGreaterThan(payment.PaidDate, DateTime.Now, "Subscription.Payments", "A data do pagamento deve ser futura")
      .IsGreaterThan(payment.ExpireDate, DateTime.Now, "Subscription.Payments", "A data de expiração deve ser futura")
      .IsGreaterOrEqualsThan(payment.Total, 0, "Subscription.Payments", "O total deve ser maior que zero")
      .IsGreaterOrEqualsThan(payment.TotalPaid, payment.Total, "Subscription.Payments", "O valor pago é menor que o valor do pagamento")
      .IsNotNull(payment.Payer, "Subscription.Payments", "Pagador inválido")
      .IsNotNull(payment.Document, "Subscription.Payments", "Documento inválido")
      .IsNotNull(payment.Address, "Subscription.Payments", "Endereço inválido")
      .IsNotNull(payment.Email, "Subscription.Payments", "E-mail inválido")
    );
    _payments.Add(payment);
  }

  public void Activate()
  {
    Active = true;
    LastUpdateDate = DateTime.Now;
  }
  public void Inactivate()
  {
    Active = false;
    LastUpdateDate = DateTime.Now;
  }
}
