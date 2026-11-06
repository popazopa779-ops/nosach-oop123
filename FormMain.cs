namespace SupplierCatalogAnalytics;

public partial class FormMain : Form
{
    private readonly CatalogService _service = new();
    private Mode _mode = Mode.UnionSorted;

    private enum Mode { Except, Intersect, UnionSorted, ConcatDistinct }

    public FormMain()
    {
        InitializeComponent();

        btnExcept.Click        += (s, e) => Show(Mode.Except);
        btnIntersect.Click     += (s, e) => Show(Mode.Intersect);
        btnUnionSorted.Click   += (s, e) => Show(Mode.UnionSorted);
        btnConcatDistinct.Click += (s, e) => Show(Mode.ConcatDistinct);
        btnApplySort.Click     += (s, e) => Show(Mode.UnionSorted); // сортировка относится к режиму Union

        Show(Mode.UnionSorted);
    }

    private void Show(Mode mode)
    {
        _mode = mode;

        // Запрос отложенный; ToList() физически выполняет его (и фиксирует результат для Count/Average).
        List<Product> result = mode switch
        {
            Mode.Except         => _service.GetExclusiveA().ToList(),
            Mode.Intersect      => _service.GetCommon().ToList(),
            Mode.UnionSorted    => _service.GetUnionSorted(rdbAsc.Checked).ToList(),
            Mode.ConcatDistinct => _service.GetConcatDistinct().ToList(),
            _ => new List<Product>()
        };

        dgvCatalog.DataSource = result;

        // Статистика через LINQ Count() и Average()
        int count = result.Count();
        decimal avg = result.Any() ? result.Average(p => p.Price) : 0m;
        lblStatus.Text = $"Режим: {ModeTitle(mode)}  |  Записей: {count}  |  Средняя стоимость: {avg:N2}";

        // Панель сортировки активна только в режиме Union + OrderBy
        grpSort.Enabled = true;
        Text = "Supplier Catalog Analytics - " + ModeTitle(mode);
    }

    private static string ModeTitle(Mode m) => m switch
    {
        Mode.Except => "Except (эксклюзив А)",
        Mode.Intersect => "Intersect (общие)",
        Mode.UnionSorted => "Union + OrderBy + ThenBy",
        Mode.ConcatDistinct => "Concat + Distinct",
        _ => ""
    };
}
