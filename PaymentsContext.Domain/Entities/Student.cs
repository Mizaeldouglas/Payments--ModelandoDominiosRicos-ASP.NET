using Flunt.Validations;
using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Shared.Entities;

namespace PaymentsContext.Domain.Entities;

public class Student : Entity
{
    private IList<Subscription> _subscription;
    private IList<string> _notifications;

    public Student(Name name, Documents document, Email email)
    {
        Name = name;
        Document = document;
        Email = email;
        _subscription = new List<Subscription>();
        AddNotifications(name, document, email);
    }

    public Name Name { get; private set; }
    public Documents Document { get; set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions
    {
        get { return _subscription.ToArray(); }
    }


    public void Addsubscription(Subscription subscription)
    {
        var hasSubscriptionActive = false;
        
        foreach (var sub in _subscription)
        {
            if (sub.Active)
                hasSubscriptionActive = true;
        }
        AddNotifications(new Contract<Student>()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa"));

        // if (hasSubscriptionActive)
        //     AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
        
    }
}