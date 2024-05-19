namespace PaymentsContext.Domain.Entities;

public class Student
{
  private IList<Subscription> _subscription;
  public Student(string firstName, string lastName, string document, string email)
  {
    FirstName = firstName;
    LastName = lastName;
    Document = document;
    Email = email;
    _subscription = new List<Subscription>();
  }

  public string FirstName { get; private set; } = string.Empty;
  public string LastName { get; private set; } = string.Empty;
  public string Document { get; private set; } = string.Empty;
  public string Email { get; private set; } = string.Empty;
  public string Address { get; private set; } = string.Empty;
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
