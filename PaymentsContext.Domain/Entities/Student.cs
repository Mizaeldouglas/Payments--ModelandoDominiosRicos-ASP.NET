namespace PaymentsContext.Domain.Entities;

public class Student
{

  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Document { get; set; }
  public string Email { get; set; }

  public List<Subscription> subscriptions { get; set; }
}