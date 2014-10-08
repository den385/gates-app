namespace GatesGUI
{
  partial class TruthTableOutputForm
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
      this.SaveTableButton = new System.Windows.Forms.Button();
      this.OkButton = new System.Windows.Forms.Button();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
      // SaveTableButton
      // 
      this.SaveTableButton.Location = new System.Drawing.Point(14, 264);
      this.SaveTableButton.Name = "SaveTableButton";
      this.SaveTableButton.Size = new System.Drawing.Size(79, 23);
      this.SaveTableButton.TabIndex = 5;
      this.SaveTableButton.Text = "Save...";
      this.SaveTableButton.UseVisualStyleBackColor = true;
      this.SaveTableButton.Click += new System.EventHandler(this.SaveTableButton_Click);
      // 
      // OkButton
      // 
      this.OkButton.Location = new System.Drawing.Point(205, 264);
      this.OkButton.Name = "OkButton";
      this.OkButton.Size = new System.Drawing.Size(75, 23);
      this.OkButton.TabIndex = 6;
      this.OkButton.Text = "Ok";
      this.OkButton.UseVisualStyleBackColor = true;
      this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // VariablesColumn
      // 
      this.VariablesColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      this.VariablesColumn.HeaderText = "Variables";
      this.VariablesColumn.MinimumWidth = 110;
      this.VariablesColumn.Name = "VariablesColumn";
      this.VariablesColumn.ReadOnly = true;
      this.VariablesColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.VariablesColumn.Width = 110;
      // 
      // FunctionsColumn
      // 
      this.FunctionsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      this.FunctionsColumn.HeaderText = "Functions";
      this.FunctionsColumn.MinimumWidth = 110;
      this.FunctionsColumn.Name = "FunctionsColumn";
      this.FunctionsColumn.ReadOnly = true;
      this.FunctionsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.FunctionsColumn.Width = 110;
      // 
      // TruthTableOutputForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(291, 299);
      this.Controls.Add(this.OkButton);
      this.Controls.Add(this.SaveTableButton);
      this.Controls.Add(this.dataGridView1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TruthTableOutputForm";
      this.Text = "TruthTableOutputForm";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button SaveTableButton;
    private System.Windows.Forms.Button OkButton;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.DataGridViewTextBoxColumn VariablesColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn FunctionsColumn;
  }
}
