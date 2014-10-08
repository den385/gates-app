using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace GatesGUI
{
  public partial class TruthTableOutputForm : Form
  {
    public TruthTableOutputForm(List<int[]> combinations, List<int[]> results)
    {
      InitializeComponent();

      List<string> rowData = new List<string>();

      //filling table
      for (int i=0; i < combinations.Count; ++i)
      {
        string cell0 = "", cell1 = "";

        foreach (int digit in combinations[i])
          cell0 += digit.ToString();
        foreach (int digit in results[i])
          cell1 += digit.ToString();

        dataGridView1.Rows.Add(new object[] { cell0, cell1 });
      }



    }

    private void SaveTableButton_Click(object sender, System.EventArgs e)
    {
      int nOfVariables = (dataGridView1.Rows[0].Cells[0].Value as string).Length;
      int nOfFunctions = (dataGridView1.Rows[0].Cells[1].Value as string).Length;

      List<string> TruthTable = new List<string>();

      foreach (DataGridViewRow row in dataGridView1.Rows)
        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
        {
          string variables = row.Cells[0].Value as string;
          string functions = row.Cells[1].Value as string;
          TruthTable.Add(variables + " " + functions);
        }
      
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        System.IO.File.WriteAllLines(saveFileDialog1.FileName, TruthTable);
    }

    private void OkButton_Click(object sender, System.EventArgs e)
    {
      Close();
    }











  }
}
