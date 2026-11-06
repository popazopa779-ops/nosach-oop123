namespace SupplierCatalogAnalytics;

/// <summary>Сервис с исходными прайс-листами и LINQ-запросами над множествами.</summary>
public class CatalogService
{
    public List<Product> supplierA { get; } = new()
    {
        new Product(1,  "Смартфон X10",       "Смартфоны",   250000m, "Поставщик А"),
        new Product(2,  "Смартфон Z5",        "Смартфоны",   180000m, "Поставщик А"),
        new Product(3,  "Ноутбук ProBook 15", "Ноутбуки",    420000m, "Поставщик А"),
        new Product(4,  "Ноутбук AirLite",    "Ноутбуки",    380000m, "Поставщик А"),
        new Product(5,  "Наушники BassPro",   "Аксессуары",   25000m, "Поставщик А"),
        new Product(6,  "Мышь OptiClick",     "Аксессуары",    8000m, "Поставщик А"),
        new Product(7,  "Монитор View 27",    "Мониторы",    150000m, "Поставщик А"),
        new Product(8,  "Планшет TabMax",     "Планшеты",    210000m, "Поставщик А"),
    };

    public List<Product> supplierB { get; } = new()
    {
        new Product(101, "смартфон x10",       "смартфоны",   245000m, "Поставщик Б"), // дубликат (другой регистр)
        new Product(102, "Смартфон Nova 3",    "Смартфоны",   120000m, "Поставщик Б"),
        new Product(103, "Ноутбук AirLite",    "Ноутбуки",    375000m, "Поставщик Б"), // дубликат
        new Product(104, "Ноутбук GameForce",  "Ноутбуки",    560000m, "Поставщик Б"),
        new Product(105, "Мышь OptiClick",     "АКСЕССУАРЫ",    7500m, "Поставщик Б"), // дубликат
        new Product(106, "Клавиатура KeyMaster","Аксессуары",  15000m, "Поставщик Б"),
        new Product(107, "Монитор View 27",    "Мониторы",    155000m, "Поставщик Б"), // дубликат
        new Product(108, "Монитор Curve 32",   "Мониторы",    230000m, "Поставщик Б"),
    };

    /// <summary>1. Товары, которые есть у А, но отсутствуют у Б.</summary>
    public IEnumerable<Product> GetExclusiveA() => supplierA.Except(supplierB);

    /// <summary>2. Товары, которые поставляют оба контрагента.</summary>
    public IEnumerable<Product> GetCommon() => supplierA.Intersect(supplierB);

    /// <summary>3. Union без дубликатов; Category ↑/↓ (OrderBy), затем Price ↓ (ThenByDescending).</summary>
    public IEnumerable<Product> GetUnionSorted(bool categoryAscending)
    {
        var union = supplierA.Union(supplierB);

        var ordered = categoryAscending
            ? union.OrderBy(p => p.Category, StringComparer.CurrentCultureIgnoreCase)
            : union.OrderByDescending(p => p.Category, StringComparer.CurrentCultureIgnoreCase);

        // Внутри категории - по цене по убыванию. Именно ThenBy..., а не второй OrderBy!
        return ordered.ThenByDescending(p => p.Price);
    }

    /// <summary>4. Concat (простое склеивание) + Distinct (удаление дубликатов).</summary>
    public IEnumerable<Product> GetConcatDistinct() => supplierA.Concat(supplierB).Distinct();
}
