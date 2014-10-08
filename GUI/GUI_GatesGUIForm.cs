using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace GatesGUI
{
  public partial class GatesGuiForm : Form
  {
    public GatesGuiForm()
    {
      SchemeView.Initialize(this);
      Scheme.Initialize(this);

      InitializeComponent();
    }

    private void AndGateButton_Click(object sender, EventArgs e)
    {
      AndGateView andGateRepr = new AndGateView(this);
      SchemeView.AddGate(andGateRepr);
    }

    private void OrGateButton_Click(object sender, EventArgs e)
    {
      OrGateView orGateRepr = new OrGateView(this);
      SchemeView.AddGate(orGateRepr);
    }

    private void NotGateButton_Click(object sender, EventArgs e)
    {
      NotGateView notGateRepr = new NotGateView(this);
      SchemeView.AddGate(notGateRepr);
    }

    private void InGateButton_Click(object sender, EventArgs e)
    {
      InGateView inGateRepr = new InGateView(this);
      SchemeView.AddGate(inGateRepr);
    }

    private void OutGateButton_Click(object sender, EventArgs e)
    {
      OutGateView outGateRepr = new OutGateView(this);
      SchemeView.AddGate(outGateRepr);
    }

    private void OrderButton_Click(object sender, EventArgs e)
    {
      SchemeView.Order();
    }

  	private void SaveButton_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
        SchemeView.Save(saveFileDialog1.FileName);
			}
		}

    private void LoadButton_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        SchemeView.Load(openFileDialog1.FileName);
      }
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
      SchemeView.Clear();
    }

    private void RunButton_Click(object sender, EventArgs e)
    {
      // if scheme is ok and digits were inputted, retrieve them

      //SchemeView.Synchronize();
      SchemeView.Order();
      int[] inGateValuesVector = new int[Scheme.GetInGatesNumber()];
      int[] outGateValuesVector = new int[Scheme.GetOutGatesNumber()];

      if (!Scheme.Verify() || Scheme.GetInGatesNumber() == 0)
      {
        MessageBox.Show("Scheme is not correct. Check for unbinded locks.");
        return;      
      }

      // TODO: it`s not obvious which in-value corresponds to which gate
      InGateValuesInputForm valuesDialog = new InGateValuesInputForm();
      valuesDialog.ShowDialog();

      if (valuesDialog.DialogResult != DialogResult.OK)
      {
        MessageBox.Show("You canceled scheme running.");
        return;  
      }
        
      inGateValuesVector = valuesDialog.RetrieveDigits();
      valuesDialog.Dispose();
      
      // give scheme to STDIN of scheme_sim.exe
      outGateValuesVector = Scheme.Simulate(inGateValuesVector);

      //Show the results
      // TODO: it`s not obvious which result corresponds to which gate
      schemeSimulationResultsForm resultsDialog = new schemeSimulationResultsForm();
      resultsDialog.setResults(outGateValuesVector);
      resultsDialog.ShowDialog();

    }

    private void TableToSchemeButton_Click(object sender, EventArgs e)
    {
      TruthTableInputForm tableInputDlg = new TruthTableInputForm();

      if (tableInputDlg.ShowDialog() == DialogResult.OK)
      {
        Scheme.BuildByTable(tableInputDlg.TruthTable);
      }
    }

    private void createTruthTableButton_Click(object sender, EventArgs e)
    {
      SchemeView.Order();
      int cortegeLength = Scheme.GetInGatesNumber();
      int tableLength = (int)System.Math.Pow(2, cortegeLength);
      List<int[]> combinations = new List<int[]>();
      List<int[]> results = new List<int[]>();

      if(cortegeLength == 0)
      {
        MessageBox.Show("Incorrect scheme.");
        return;
      }

      //generate all variables combinations
      for (int i = 0; i < tableLength; ++i)
      {
        int n = i;
        string s = "";

        while (s.Length < cortegeLength)
        {
          s += (n%2).ToString();
          n /= 2;
        }

        char[] chars = s.ToCharArray();
        chars = chars.Reverse().ToArray();
        int[] cortege = new int[cortegeLength];
        for (int j = 0; j < cortegeLength; ++j)
          cortege[j] = chars[j] - '0';

        combinations.Add(cortege);
      }

      //simulate
      foreach(int[] combination in combinations)
        results.Add(Scheme.Simulate(combination));

      TruthTableOutputForm tableOutputDlg = new TruthTableOutputForm(combinations, results);
      tableOutputDlg.ShowDialog();

    }

  }
}
