namespace Lkvitai.Warehouse.Service.Domain;

// Represents a product in the warehouse domain
public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Product(Guid id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.", nameof(amount));
        Quantity += amount;
    }

    public void RemoveStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.", nameof(amount));
        if (amount > Quantity)
            throw new InvalidOperationException("Insufficient stock.");
        Quantity -= amount;
    }
}
