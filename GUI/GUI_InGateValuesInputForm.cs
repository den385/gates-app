using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GatesGUI
{
  public partial class InGateValuesInputForm : Form
  {
    public InGateValuesInputForm()
    {
      this.Visible = false;
      InitializeComponent();
      DynamicallyInitialize();
    }

    public void OkButton_Click(object sender, EventArgs e)
    {
      DialogResult = System.Windows.Forms.DialogResult.OK;
      Close();
    }

    public int[] RetrieveDigits()
    {
      int i;
      int[] inDigits = new int[Scheme.GetInGatesNumber()];

      // get values foreach groupbox
      Control[] groupBoxes = Controls.Find("groupBox", true);
      i = 0;

      foreach (GroupBox groupBox in groupBoxes)
      {
        RadioButton radioButton0 = groupBox.Controls.Find("radioButton0", true)[0] as RadioButton;

        inDigits[i] = (radioButton0.Checked ? 0 : 1);
          
        ++i;
      }

      return inDigits;
    }


    public void DynamicallyInitialize()
    {
      int i = 0;

      int labelInitX = 30, labelInitY = 30;
      int labelWidth = 70, labelHeight = 20;
      int groupBoxInitX = 120, groupBoxInitY = 10;
      int groupBoxWidth = 120, groupBoxHeight = 50;
      int radioButton0InitX = 30, radioButton0InitY = 20;
      int radioButton0Width = 85, radioButton0Height = 17;
      int radioButton1InitX = 70, radioButton1InitY = 20;
      int radioButton1Width = 85, radioButton1Height = 17;
      int shiftY = 50;

        // create labels and radiobuttons for each in-gate
      foreach (BaseGate gate in Scheme.GatesScheme[0])
      {
        Label newLabel = new Label();
        newLabel.Location = new Point(labelInitX, labelInitY + i * shiftY);
        newLabel.Size = new Size(labelWidth, labelHeight);
        newLabel.Text = "In-gate #" + (i + 1).ToString();
        newLabel.Name = "label" + (i + 1).ToString();

        GroupBox newGroupBox = new GroupBox();
        newGroupBox.Location = new System.Drawing.Point(groupBoxInitX, groupBoxInitY + i * shiftY);
        newGroupBox.Name = "groupBox";
        newGroupBox.Size = new System.Drawing.Size(groupBoxWidth, groupBoxHeight);
        newGroupBox.TabIndex = 0;
        newGroupBox.TabStop = false;

        RadioButton newRadioButton0 = new RadioButton();
        newRadioButton0.AutoSize = true;
        newRadioButton0.Location = new System.Drawing.Point(radioButton0InitX, radioButton0InitY);
        newRadioButton0.Name = "radioButton0";
        newRadioButton0.Size = new System.Drawing.Size(radioButton0Width, radioButton0Height);
        newRadioButton0.TabIndex = 0;
        newRadioButton0.TabStop = true;
        newRadioButton0.Text = "0";
        newRadioButton0.UseVisualStyleBackColor = true;
        newRadioButton0.Checked = true;
        newRadioButton0.AutoCheck = true;

        RadioButton newRadioButton1 = new RadioButton();
        newRadioButton1.AutoSize = true;
        newRadioButton1.Location = new System.Drawing.Point(radioButton1InitX, radioButton1InitY);
        newRadioButton1.Name = "radioButton1";
        newRadioButton1.Size = new System.Drawing.Size(radioButton1Width, radioButton1Height);
        newRadioButton1.TabIndex = 1;
        newRadioButton1.TabStop = true;
        newRadioButton1.Text = "1";
        newRadioButton1.UseVisualStyleBackColor = true;
        newRadioButton1.Checked = false;
        newRadioButton1.AutoCheck = true;

        newGroupBox.Controls.Add(newRadioButton0);
        newGroupBox.Controls.Add(newRadioButton1);
        Controls.Add(newLabel);
        Controls.Add(newGroupBox);

        ++i;
      }// foreach ends

      Button OkButton = new Button();
      if (i > 4)
        OkButton.Location = new System.Drawing.Point((groupBoxInitX + labelInitX) / 2, (i + 1) * shiftY - 15);
      else
        OkButton.Location = new System.Drawing.Point(85, 300);
      OkButton.Text = "Accept";
      OkButton.Name = "OkButton";
      OkButton.Click += new System.EventHandler(OkButton_Click);

      DialogResult = DialogResult.None;
      Controls.Add(OkButton);
    }



  }// class ends
}// NS ends
