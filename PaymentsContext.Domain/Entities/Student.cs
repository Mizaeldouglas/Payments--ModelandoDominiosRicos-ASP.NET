using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Shared.Entities;

namespace PaymentsContext.Domain.Entities;

public class Student : Entity
{
  private IList<Subscription> _subscription;
  public Student(Name name, Documents document, Email email)
  {
    Name = name;
    Document = document;
    Email = email;
    _subscription = new List<Subscription>();
  }

  public Name Name { get; private set; }
  public Documents Document { get; set; }
  public Email Email { get; private set; }
  public Address Address { get; private set; }
  public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscription.ToArray(); } }


  public void Addsubscription(Subscription subscription)
  {
    // se tiver uma assinatura ativa , cancela

    //cancela todas as outras assinatura, e coloca esta como principal
    foreach (var sub in Subscriptions)
    {
      sub.Inactivate();
    }
    _subscription.Add(subscription);
  }
}
