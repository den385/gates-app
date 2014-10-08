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
  public partial class schemeSimulationResultsForm : Form
  {
    public schemeSimulationResultsForm()
    {
      InitializeComponent();
    }

    public void setResults(int[] values)
    {
      int i = 0;

      foreach (int val in values)
        dataGrid.Rows.Add(new object[] {++i, val});
    }

  }
}
