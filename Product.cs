namespace SupplierCatalogAnalytics;

/// <summary>
/// Товар из прайс-листа поставщика.
/// Два товара считаются идентичными, если совпадают Name и Category (без учёта регистра).
/// </summary>
public class Product : IEquatable<Product>
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Category { get; private set; }
    public decimal Price { get; private set; }
    public string Supplier { get; private set; }

    public Product(int id, string name, string category, decimal price, string supplier)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        Supplier = supplier;
    }

    public bool Equals(Product? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase)
            && string.Equals(Category, other.Category, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj) => Equals(obj as Product);

    // Хэш обязан использовать те же поля и тот же регистронезависимый режим, что и Equals.
    public override int GetHashCode() =>
        HashCode.Combine(
            StringComparer.OrdinalIgnoreCase.GetHashCode(Name ?? string.Empty),
            StringComparer.OrdinalIgnoreCase.GetHashCode(Category ?? string.Empty));

    public override string ToString() => $"{Name} ({Category}) - {Price:N2} [{Supplier}]";
}
