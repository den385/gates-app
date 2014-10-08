using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic.PowerPacks;

namespace GatesGUI
{
  public class GateLockView : OvalShape
  {
    public BaseGateView ownerGate;
    public lockType type;

    public GateLockView(BaseGateView inOwnerGate, lockType inType, GatesGuiForm target, int X, int Y) : base()
    {
      ownerGate = inOwnerGate;
      type = inType;

      Cursor = Cursors.Hand;
      BackStyle = BackStyle.Opaque;
      BackColor = Color.Firebrick;
      Location = new Point(X, Y);
      Name = Name + "_ovalShape1";
      Size = new Size(10, 10);
      Click += new EventHandler(SchemeView.GateView_LockSelected);
    }

    public void SetBusy()
    {
      BackColor = Color.IndianRed;
    }

    public void SetFree()
    {
      BackColor = Color.Firebrick;
    }

    public bool Free()
    {
      int count = 0;

      foreach (LineView line in ownerGate.Edges)
        if (line.gateLock1 == this || line.gateLock2 == this)
          ++count;

      if (count > 0)
        return false;
      else
        return true;
    }

  }

}
