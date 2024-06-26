using Flunt.Notifications;

namespace PaymentsContext.Shared.Entities;

public abstract class Entity : Notifiable<Notification>
{
  public Guid Id { get; private set; }

  protected Entity()
  {
    Id = Guid.NewGuid();
  }
}
