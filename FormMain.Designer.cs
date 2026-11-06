namespace SupplierCatalogAnalytics;

partial class FormMain
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgvCatalog = new DataGridView();
        colName = new DataGridViewTextBoxColumn();
        colCategory = new DataGridViewTextBoxColumn();
        colPrice = new DataGridViewTextBoxColumn();
        colSupplier = new DataGridViewTextBoxColumn();
        pnlOps = new FlowLayoutPanel();
        btnExcept = new Button();
        btnIntersect = new Button();
        btnUnionSorted = new Button();
        btnConcatDistinct = new Button();
        grpSort = new GroupBox();
        rdbAsc = new RadioButton();
        rdbDesc = new RadioButton();
        btnApplySort = new Button();
        statusStrip1 = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();

        ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
        pnlOps.SuspendLayout();
        grpSort.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();

        // dgvCatalog
        dgvCatalog.AllowUserToAddRows = false;
        dgvCatalog.AllowUserToDeleteRows = false;
        dgvCatalog.AutoGenerateColumns = false;
        dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCatalog.Columns.AddRange(new DataGridViewColumn[] { colName, colCategory, colPrice, colSupplier });
        dgvCatalog.Dock = DockStyle.Fill;
        dgvCatalog.Name = "dgvCatalog";
        dgvCatalog.ReadOnly = true;
        dgvCatalog.RowHeadersVisible = false;
        dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        colName.DataPropertyName = "Name";     colName.HeaderText = "Название";  colName.Name = "colName";
        colCategory.DataPropertyName = "Category"; colCategory.HeaderText = "Категория"; colCategory.Name = "colCategory";
        colPrice.DataPropertyName = "Price";   colPrice.HeaderText = "Цена";     colPrice.Name = "colPrice";
        colPrice.DefaultCellStyle.Format = "N2";
        colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colSupplier.DataPropertyName = "Supplier"; colSupplier.HeaderText = "Поставщик"; colSupplier.Name = "colSupplier";

        // pnlOps
        pnlOps.Dock = DockStyle.Top;
        pnlOps.Height = 90;
        pnlOps.Padding = new Padding(6);
        pnlOps.WrapContents = true;
        pnlOps.Controls.AddRange(new Control[] { btnExcept, btnIntersect, btnUnionSorted, btnConcatDistinct, grpSort });

        btnExcept.Name = "btnExcept";               btnExcept.Text = "Except (только А)";            btnExcept.Size = new Size(150, 34);
        btnIntersect.Name = "btnIntersect";         btnIntersect.Text = "Intersect (общие)";         btnIntersect.Size = new Size(150, 34);
        btnUnionSorted.Name = "btnUnionSorted";     btnUnionSorted.Text = "Union + сортировка";      btnUnionSorted.Size = new Size(160, 34);
        btnConcatDistinct.Name = "btnConcatDistinct"; btnConcatDistinct.Text = "Concat + Distinct";  btnConcatDistinct.Size = new Size(150, 34);

        // grpSort
        grpSort.Name = "grpSort";
        grpSort.Text = "Сортировка по категории";
        grpSort.Size = new Size(380, 52);
        grpSort.Controls.AddRange(new Control[] { rdbAsc, rdbDesc, btnApplySort });

        rdbAsc.Name = "rdbAsc";   rdbAsc.Text = "По возр.";  rdbAsc.Checked = true; rdbAsc.Location = new Point(8, 20);  rdbAsc.AutoSize = true;
        rdbDesc.Name = "rdbDesc"; rdbDesc.Text = "По убыв."; rdbDesc.Location = new Point(100, 20); rdbDesc.AutoSize = true;
        btnApplySort.Name = "btnApplySort"; btnApplySort.Text = "Применить"; btnApplySort.Location = new Point(200, 16); btnApplySort.Size = new Size(110, 28);

        // statusStrip1
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
        lblStatus.Name = "lblStatus";

        // FormMain
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 520);
        Controls.Add(dgvCatalog);   // Fill добавляется первым
        Controls.Add(pnlOps);
        Controls.Add(statusStrip1);
        MinimumSize = new Size(760, 400);
        Name = "FormMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Supplier Catalog Analytics";

        ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
        pnlOps.ResumeLayout(false);
        grpSort.ResumeLayout(false);
        grpSort.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private DataGridView dgvCatalog;
    private DataGridViewTextBoxColumn colName, colCategory, colPrice, colSupplier;
    private FlowLayoutPanel pnlOps;
    private Button btnExcept, btnIntersect, btnUnionSorted, btnConcatDistinct, btnApplySort;
    private GroupBox grpSort;
    private RadioButton rdbAsc, rdbDesc;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatus;
}
