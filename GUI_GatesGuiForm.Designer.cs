namespace GatesGUI
{
    partial class GatesGuiForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GatesGuiForm));
          this.AndGateButton = new System.Windows.Forms.Button();
          this.OrGateButton = new System.Windows.Forms.Button();
          this.NotGateButton = new System.Windows.Forms.Button();
          this.InGateButton = new System.Windows.Forms.Button();
          this.OutGateButton = new System.Windows.Forms.Button();
          this.Canvas = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
          this.WorkingArea = new System.Windows.Forms.Panel();
          this.toolStrip1 = new System.Windows.Forms.ToolStrip();
          this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
          this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
          this.OrderButton = new System.Windows.Forms.ToolStripButton();
          this.SaveButton = new System.Windows.Forms.ToolStripButton();
          this.LoadButton = new System.Windows.Forms.ToolStripButton();
          this.ClearButton = new System.Windows.Forms.ToolStripButton();
          this.RunButton = new System.Windows.Forms.ToolStripButton();
          this.TableToSchemeButton = new System.Windows.Forms.ToolStripButton();
          this.createTruthTableButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
          this.WorkingArea.SuspendLayout();
          this.toolStrip1.SuspendLayout();
          this.SuspendLayout();
          // 
          // AndGateButton
          // 
          this.AndGateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.AndGateButton.BackColor = System.Drawing.Color.DodgerBlue;
          this.AndGateButton.Cursor = System.Windows.Forms.Cursors.Hand;
          this.AndGateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.AndGateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.AndGateButton.Location = new System.Drawing.Point(750, 41);
          this.AndGateButton.Name = "AndGateButton";
          this.AndGateButton.Size = new System.Drawing.Size(30, 30);
          this.AndGateButton.TabIndex = 0;
          this.AndGateButton.TabStop = false;
          this.AndGateButton.Text = "&&";
          this.AndGateButton.UseVisualStyleBackColor = false;
          this.AndGateButton.Click += new System.EventHandler(this.AndGateButton_Click);
          // 
          // OrGateButton
          // 
          this.OrGateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.OrGateButton.BackColor = System.Drawing.Color.DodgerBlue;
          this.OrGateButton.Cursor = System.Windows.Forms.Cursors.Hand;
          this.OrGateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.OrGateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.OrGateButton.Location = new System.Drawing.Point(750, 77);
          this.OrGateButton.Name = "OrGateButton";
          this.OrGateButton.Size = new System.Drawing.Size(30, 30);
          this.OrGateButton.TabIndex = 0;
          this.OrGateButton.TabStop = false;
          this.OrGateButton.Text = "|";
          this.OrGateButton.UseVisualStyleBackColor = false;
          this.OrGateButton.Click += new System.EventHandler(this.OrGateButton_Click);
          // 
          // NotGateButton
          // 
          this.NotGateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.NotGateButton.BackColor = System.Drawing.Color.DodgerBlue;
          this.NotGateButton.Cursor = System.Windows.Forms.Cursors.Hand;
          this.NotGateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.NotGateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.NotGateButton.Location = new System.Drawing.Point(750, 113);
          this.NotGateButton.Name = "NotGateButton";
          this.NotGateButton.Size = new System.Drawing.Size(30, 30);
          this.NotGateButton.TabIndex = 0;
          this.NotGateButton.TabStop = false;
          this.NotGateButton.Text = "¬";
          this.NotGateButton.UseVisualStyleBackColor = false;
          this.NotGateButton.Click += new System.EventHandler(this.NotGateButton_Click);
          // 
          // InGateButton
          // 
          this.InGateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.InGateButton.BackColor = System.Drawing.Color.DodgerBlue;
          this.InGateButton.Cursor = System.Windows.Forms.Cursors.Hand;
          this.InGateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.InGateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.InGateButton.Location = new System.Drawing.Point(750, 149);
          this.InGateButton.Name = "InGateButton";
          this.InGateButton.Size = new System.Drawing.Size(30, 30);
          this.InGateButton.TabIndex = 0;
          this.InGateButton.TabStop = false;
          this.InGateButton.Text = "v";
          this.InGateButton.UseVisualStyleBackColor = false;
          this.InGateButton.Click += new System.EventHandler(this.InGateButton_Click);
          // 
          // OutGateButton
          // 
          this.OutGateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.OutGateButton.BackColor = System.Drawing.Color.DodgerBlue;
          this.OutGateButton.Cursor = System.Windows.Forms.Cursors.Hand;
          this.OutGateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.OutGateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.OutGateButton.Location = new System.Drawing.Point(750, 185);
          this.OutGateButton.Name = "OutGateButton";
          this.OutGateButton.Size = new System.Drawing.Size(30, 30);
          this.OutGateButton.TabIndex = 0;
          this.OutGateButton.TabStop = false;
          this.OutGateButton.Text = "^";
          this.OutGateButton.UseVisualStyleBackColor = false;
          this.OutGateButton.Click += new System.EventHandler(this.OutGateButton_Click);
          // 
          // Canvas
          // 
          this.Canvas.Location = new System.Drawing.Point(0, 0);
          this.Canvas.Margin = new System.Windows.Forms.Padding(0);
          this.Canvas.Name = "Canvas";
          this.Canvas.Size = new System.Drawing.Size(730, 512);
          this.Canvas.TabIndex = 3;
          this.Canvas.TabStop = false;
          // 
          // WorkingArea
          // 
          this.WorkingArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.WorkingArea.AutoScroll = true;
          this.WorkingArea.AutoScrollMargin = new System.Drawing.Size(30, 30);
          this.WorkingArea.BackColor = System.Drawing.Color.White;
          this.WorkingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.WorkingArea.Controls.Add(this.Canvas);
          this.WorkingArea.Location = new System.Drawing.Point(12, 40);
          this.WorkingArea.Name = "WorkingArea";
          this.WorkingArea.Size = new System.Drawing.Size(732, 514);
          this.WorkingArea.TabIndex = 5;
          // 
          // toolStrip1
          // 
          this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
          this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
          this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrderButton,
            this.SaveButton,
            this.LoadButton,
            this.ClearButton,
            this.RunButton,
            this.TableToSchemeButton,
            this.createTruthTableButton});
          this.toolStrip1.Location = new System.Drawing.Point(0, 0);
          this.toolStrip1.Name = "toolStrip1";
          this.toolStrip1.Size = new System.Drawing.Size(792, 37);
          this.toolStrip1.Stretch = true;
          this.toolStrip1.TabIndex = 6;
          this.toolStrip1.Text = "toolStrip1";
          // 
          // openFileDialog1
          // 
          this.openFileDialog1.FileName = "GateScheme1.txt";
          // 
          // saveFileDialog1
          // 
          this.saveFileDialog1.FileName = "GateScheme1.txt";
          // 
          // OrderButton
          // 
          this.OrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.OrderButton.Image = global::GatesGUI.Properties.Resources.Order;
          this.OrderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.OrderButton.Name = "OrderButton";
          this.OrderButton.Size = new System.Drawing.Size(34, 34);
          this.OrderButton.Text = "Order";
          this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click);
          // 
          // SaveButton
          // 
          this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.SaveButton.Image = global::GatesGUI.Properties.Resources.Save;
          this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.SaveButton.Name = "SaveButton";
          this.SaveButton.Size = new System.Drawing.Size(34, 34);
          this.SaveButton.Text = "Save...";
          this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
          // 
          // LoadButton
          // 
          this.LoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.LoadButton.Image = global::GatesGUI.Properties.Resources.Load;
          this.LoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.LoadButton.Name = "LoadButton";
          this.LoadButton.Size = new System.Drawing.Size(34, 34);
          this.LoadButton.Text = "Load...";
          this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
          // 
          // ClearButton
          // 
          this.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.ClearButton.Image = global::GatesGUI.Properties.Resources.Clear;
          this.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.ClearButton.Name = "ClearButton";
          this.ClearButton.Size = new System.Drawing.Size(34, 34);
          this.ClearButton.Text = "Clear";
          this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
          // 
          // RunButton
          // 
          this.RunButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.RunButton.Image = global::GatesGUI.Properties.Resources.Run;
          this.RunButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.RunButton.Name = "RunButton";
          this.RunButton.Size = new System.Drawing.Size(34, 34);
          this.RunButton.Text = "Run";
          this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
          // 
          // TableToSchemeButton
          // 
          this.TableToSchemeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.TableToSchemeButton.Image = global::GatesGUI.Properties.Resources.CreateSchemeByTable;
          this.TableToSchemeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.TableToSchemeButton.Name = "TableToSchemeButton";
          this.TableToSchemeButton.Size = new System.Drawing.Size(34, 34);
          this.TableToSchemeButton.Text = "Create scheme by table";
          this.TableToSchemeButton.Click += new System.EventHandler(this.TableToSchemeButton_Click);
          // 
          // createTruthTableButton
          // 
          this.createTruthTableButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.createTruthTableButton.Image = global::GatesGUI.Properties.Resources.CreateTruthTable;
          this.createTruthTableButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.createTruthTableButton.Name = "createTruthTableButton";
          this.createTruthTableButton.Size = new System.Drawing.Size(34, 34);
          this.createTruthTableButton.Text = "Create truth table";
          this.createTruthTableButton.Click += new System.EventHandler(this.createTruthTableButton_Click);
          // 
          // toolStripButton1
          // 
          this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
          this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripButton1.Name = "toolStripButton1";
          this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
          this.toolStripButton1.Text = "toolStripButton1";
          // 
          // GatesGuiForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
          this.BackColor = System.Drawing.SystemColors.ControlLight;
          this.ClientSize = new System.Drawing.Size(792, 566);
          this.Controls.Add(this.toolStrip1);
          this.Controls.Add(this.WorkingArea);
          this.Controls.Add(this.OrGateButton);
          this.Controls.Add(this.AndGateButton);
          this.Controls.Add(this.NotGateButton);
          this.Controls.Add(this.InGateButton);
          this.Controls.Add(this.OutGateButton);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "GatesGuiForm";
          this.Text = "Form1";
          this.WorkingArea.ResumeLayout(false);
          this.toolStrip1.ResumeLayout(false);
          this.toolStrip1.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AndGateButton;
        private System.Windows.Forms.Button OrGateButton;
        private System.Windows.Forms.Button NotGateButton;
        private System.Windows.Forms.Button InGateButton;
        private System.Windows.Forms.Button OutGateButton;
        public Microsoft.VisualBasic.PowerPacks.ShapeContainer Canvas;
        public System.Windows.Forms.Panel WorkingArea;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton OrderButton;
  			private System.Windows.Forms.OpenFileDialog openFileDialog1;
				private System.Windows.Forms.SaveFileDialog saveFileDialog1;
				private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton LoadButton;
        private System.Windows.Forms.ToolStripButton ClearButton;
        private System.Windows.Forms.ToolStripButton RunButton;
        private System.Windows.Forms.ToolStripButton TableToSchemeButton;
        private System.Windows.Forms.ToolStripButton createTruthTableButton;

    }
}

