using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic.PowerPacks;

namespace GatesGUI
{
  public class LineView : LineShape
  {
    public GateLockView gateLock1, gateLock2;

    GatesGuiForm homeForm;

    public LineView(GatesGuiForm target, GateLockView inGateLock1, GateLockView inGateLock2) : base()
    {
      homeForm = target;

      gateLock1 = inGateLock1;
      gateLock2 = inGateLock2;

      Name = "LineView1";
      Cursor = System.Windows.Forms.Cursors.Hand;
      X1 = gateLock1.Location.X + 10/2;
      X2 = gateLock2.Location.X + 10/2;
      Y1 = gateLock1.Location.Y + 10/2;
      Y2 = gateLock2.Location.Y + 10/2;
      BorderWidth = 1;

      homeForm.Canvas.Shapes.Add(this);

      MouseDoubleClick += new MouseEventHandler(LineView_DoubleClick);
    }

    public void moveAttachedEnds(BaseGateView inMovingGate, int deltaX, int deltaY)
    {
      if (inMovingGate == gateLock1.ownerGate)
      {
        X1 += deltaX;
        Y1 += deltaY;
      }
      else if (inMovingGate == gateLock2.ownerGate)
      {
        X2 += deltaX;
        Y2 += deltaY;
      }
      
    }

    private void LineView_DoubleClick(object sender, MouseEventArgs e)
    {
      Delete();
    }

    public void Delete()
    {
      SchemeView.DeleteLine(this);

      // [1]Parent -> [2]Child
      if (gateLock1.ownerGate.GetChildren().Contains(gateLock2.ownerGate))
      {
        if (gateLock1.ownerGate.GetChildren().Count == 1)
          gateLock1.SetFree();
        gateLock2.SetFree();
      }

      // [2]Parent -> [1]Child
      else if (gateLock1.ownerGate.GetParents().Contains(gateLock2.ownerGate))
      {
        gateLock1.SetFree();
        if (gateLock2.ownerGate.GetChildren().Count == 1)
          gateLock2.SetFree();
      }

      gateLock1.ownerGate.Edges.Remove(this);
      gateLock2.ownerGate.Edges.Remove(this);
      gateLock1.ownerGate.DeleteChild(gateLock2.ownerGate);
      gateLock1.ownerGate.DeleteParent(gateLock2.ownerGate);
      gateLock2.ownerGate.DeleteChild(gateLock1.ownerGate);
      gateLock2.ownerGate.DeleteParent(gateLock1.ownerGate);

      homeForm.Canvas.Shapes.Remove(this);

      homeForm.WorkingArea.Refresh();

      Dispose(true);
    }

  }




}
