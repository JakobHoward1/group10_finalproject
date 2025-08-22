namespace Group10_FinalProject.API.Models;

public class MenuItem
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Category { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private MenuItem(Guid id, string name, string category, decimal price, DateTime createdAt, DateTime? updatedAt = null)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }


    public static MenuItem Create(string name, string category, decimal price)
    {
        return new MenuItem(
            Guid.NewGuid(),
            name,
            category,
            price,
            DateTime.Now
        );
    }


    public void Update(string name, string category, decimal price)
    {
        Name = name;
        Category = category;
        Price = price;
        UpdatedAt = DateTime.Now;
    }
}
