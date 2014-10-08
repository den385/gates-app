namespace GatesGUI
{
  partial class TruthTableInputForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.LoadTableButton = new System.Windows.Forms.Button();
      this.SubmitTruthTableButton = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.VariablesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FunctionsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
      this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VariablesColumn,
            this.FunctionsColumn});
      this.dataGridView1.Location = new System.Drawing.Point(12, 12);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(268, 242);
      this.dataGridView1.TabIndex = 0;
      // 
      // LoadTableButton
      // 
      this.LoadTableButton.Location = new System.Drawing.Point(14, 264);
      this.LoadTableButton.Name = "LoadTableButton";
      this.LoadTableButton.Size = new System.Drawing.Size(79, 23);
      this.LoadTableButton.TabIndex = 5;
      this.LoadTableButton.Text = "Load...";
      this.LoadTableButton.UseVisualStyleBackColor = true;
      this.LoadTableButton.Click += new System.EventHandler(this.LoadTableButton_Click);
      // 
      // SubmitTruthTableButton
      // 
      this.SubmitTruthTableButton.Location = new System.Drawing.Point(205, 264);
      this.SubmitTruthTableButton.Name = "SubmitTruthTableButton";
      this.SubmitTruthTableButton.Size = new System.Drawing.Size(75, 23);
      this.SubmitTruthTableButton.TabIndex = 6;
      this.SubmitTruthTableButton.Text = "Submit";
      this.SubmitTruthTableButton.UseVisualStyleBackColor = true;
      this.SubmitTruthTableButton.Click += new System.EventHandler(this.SubmitTruthTableButton_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // VariablesColumn
      // 
      this.VariablesColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      this.VariablesColumn.HeaderText = "Variables";
      this.VariablesColumn.MinimumWidth = 110;
      this.VariablesColumn.Name = "VariablesColumn";
      this.VariablesColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.VariablesColumn.Width = 110;
      // 
      // FunctionsColumn
      // 
      this.FunctionsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      this.FunctionsColumn.HeaderText = "Functions";
      this.FunctionsColumn.MinimumWidth = 110;
      this.FunctionsColumn.Name = "FunctionsColumn";
      this.FunctionsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.FunctionsColumn.Width = 110;
      // 
      // TruthTableInputForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(291, 299);
      this.Controls.Add(this.SubmitTruthTableButton);
      this.Controls.Add(this.LoadTableButton);
      this.Controls.Add(this.dataGridView1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TruthTableInputForm";
      this.Text = "TruthTableInputForm";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button LoadTableButton;
    private System.Windows.Forms.Button SubmitTruthTableButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.DataGridViewTextBoxColumn VariablesColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn FunctionsColumn;
  }
}
