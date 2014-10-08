namespace GatesGUI
{
  partial class schemeSimulationResultsForm
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
      this.dataGrid = new System.Windows.Forms.DataGridView();
      this.NumberCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToOrderColumns = true;
      this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumberCol,
            this.ValueCol});
      this.dataGrid.Location = new System.Drawing.Point(12, 12);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(243, 260);
      this.dataGrid.TabIndex = 0;
      // 
      // NumberCol
      // 
      this.NumberCol.HeaderText = "Out-Gate Number";
      this.NumberCol.Name = "NumberCol";
      // 
      // ValueCol
      // 
      this.ValueCol.HeaderText = "Out-Gate Value";
      this.ValueCol.Name = "ValueCol";
      // 
      // schemeSimulationResultsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.AutoScrollMargin = new System.Drawing.Size(10, 10);
      this.ClientSize = new System.Drawing.Size(267, 284);
      this.Controls.Add(this.dataGrid);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "schemeSimulationResultsForm";
      this.Text = "schemeSimulationResultsForm";
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn NumberCol;
    private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;
  }
}
