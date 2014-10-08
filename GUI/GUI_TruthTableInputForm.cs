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
  public partial class TruthTableInputForm : Form
  {
    public List<string> TruthTable;

    public TruthTableInputForm()
    {
      InitializeComponent();
      DialogResult = System.Windows.Forms.DialogResult.Cancel;
    }

    private bool Verify(string[] Serialization)
    {
      char[] separator = {' '};
      string[] firstCortege = Serialization[0].Split(separator);
      List<string> unique = new List<string>();

      int nOfVariables = firstCortege[0].Length;
      int nOfFunctions = firstCortege[1].Length;
      bool result = true;

      foreach (string line in Serialization)
      {
        string[] currentCortege = line.Split(separator);
        int currentNOfVariables = currentCortege[0].Length;
        int currentNOfFunctions = currentCortege[1].Length;

        if (unique.Contains(currentCortege[0]))
          result = false;
        else
          unique.Add(currentCortege[0]);

        result = result && (currentCortege.Length == 2) && (currentNOfVariables == nOfVariables) && (currentNOfFunctions == nOfFunctions);
        
        foreach (char c in line)
          result = result && (c == '1' || c == '0' || c == ' ');
      }

      result = result && (unique.Count == System.Math.Pow(2, nOfVariables));

      return result;
    }


    private void LoadTableButton_Click(object sender, EventArgs e)
    {
      char[] separator = { ' ' };

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        string[] Serialization = System.IO.File.ReadAllLines(openFileDialog1.FileName);

        if (!Verify(Serialization))
          MessageBox.Show("Bad truth table from file. Loading canceled");
        else
        {
          foreach (string line in Serialization)
            if (line != "")
              dataGridView1.Rows.Add(new object[] { line.Split(separator)[0], line.Split(separator)[1] });
        }
      }

    }

    private void SubmitTruthTableButton_Click(object sender, EventArgs e)
    {
      if (dataGridView1.Rows[0].Cells[0].Value == null || dataGridView1.Rows[0].Cells[1].Value == null)
      {
        MessageBox.Show("Truth table is empty.");
        return;
      }

      List<string> unique = new List<string>();
      int nOfVariables = (dataGridView1.Rows[0].Cells[0].Value as string).Length;
      int nOfFunctions = (dataGridView1.Rows[0].Cells[1].Value as string).Length;
      bool result = true;
      bool[] useless0 = new bool[nOfFunctions];
      for (int i = 0; i < useless0.Length; ++i )
        useless0[i] = true;
      bool[] useless1 = new bool[nOfFunctions];
      for (int i = 0; i < useless1.Length; ++i)
        useless1[i] = true;
      bool notUseless = true;

      foreach (DataGridViewRow row in dataGridView1.Rows)
        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
        {
          string variables = row.Cells[0].Value as string;
          string functions = row.Cells[1].Value as string;

          if (unique.Contains(variables))
            result = false;
          else
            unique.Add(variables);

          for (int i = 0; i < useless0.Length; ++i)
            useless0[i] = useless0[i] && (functions[i] == '0');
          for (int i = 0; i < useless1.Length; ++i)
            useless1[i] = useless1[i] && (functions[i] == '1');

          result = result && (variables.Length == nOfVariables) && (functions.Length == nOfFunctions);

          foreach (char c in variables)
            result = result && (c == '1' || c == '0' || c == ' ');

          foreach (char c in functions)
            result = result && (c == '1' || c == '0' || c == ' ');
        }

      for (int i = 0; i < useless0.Length; ++i)
        notUseless = notUseless && !useless0[i] && !useless1[i];
      
      result = result && (unique.Count == System.Math.Pow(2, nOfVariables)) && notUseless;

      if (!result)
      {
        if (notUseless)
          MessageBox.Show("Truth table incorrect.");
        else /*useless*/
        {
          string answer = "";
          for (int i = 0; i < useless0.Length; ++i)
            if (useless0[i] || useless1[i])
              answer += i.ToString() + " ";          
          
          MessageBox.Show("Truth table contains useless functions. Numbers of this functions are: " + answer);
        }
        return;
      }
      else
      {
        TruthTable = new List<string>();

        foreach (DataGridViewRow row in dataGridView1.Rows)
          if (row.Cells[0].Value != null && row.Cells[1].Value != null)
          {
            string variables = row.Cells[0].Value as string;
            string functions = row.Cells[1].Value as string;
            TruthTable.Add(variables + " " + functions);
          }

        DialogResult = System.Windows.Forms.DialogResult.OK;
        Close();
        return;
      }

    }











  }
}
