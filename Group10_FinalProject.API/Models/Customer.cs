namespace Group10_FinalProject.API.Models;

public class Customer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Review { get; private set; }
    public int Rating { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Customer(Guid id, string name, string review, int rating, DateTime createdAt, DateTime? updatedAt = null)
    {
        Id = id;
        Name = name;
        Review = review;
        Rating = rating;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }


    public static Customer Create(string name, string review, int rating)
    {
        return new Customer(
            Guid.NewGuid(),
            name,
            review,
            rating,
            DateTime.Now
        );
    }

    public void Update(string name, string review, int rating)
    {
        Name = name;
        Review = review;
        Rating = rating;
        UpdatedAt = DateTime.Now;
    }
}
