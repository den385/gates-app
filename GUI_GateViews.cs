using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.VisualBasic.PowerPacks;

namespace GatesGUI
{

  public class AndGateView : BaseGateView
  {
    public AndGateView(GatesGuiForm target) : base(target)
    {
      Text = "&&";
    }

    protected override void AddCanalsAndLocksToCanvas(GatesGuiForm target)
    {
      int HScroll = homeForm.WorkingArea.HorizontalScroll.Value;
      int VScroll = homeForm.WorkingArea.VerticalScroll.Value;

      LineShape firstInCanal = new LineShape(Location.X + HScroll, Location.Y + Size.Height * 1 / 4 + VScroll, Location.X - 7 + HScroll, Location.Y + Size.Height * 1 / 4 + VScroll);
      inLock1 = new GateLockView(this, lockType.doubleInUpper, target, Location.X - 7 - 10 + HScroll, Location.Y + Size.Height * 1 / 4 - 10 / 2 + VScroll);

      LineShape secondInCanal = new LineShape(Location.X + HScroll, Location.Y + Size.Height * 3 / 4 + VScroll, Location.X - 7 + HScroll, Location.Y + Size.Height * 3 / 4 + VScroll);
      inLock2 = new GateLockView(this, lockType.doubleInLower, target, Location.X - 7 - 10 + HScroll, Location.Y + Size.Height * 3 / 4 - 10 / 2 + VScroll);

      LineShape outCanal = new LineShape(Location.X + Size.Width + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll, Location.X + Size.Width + 7 + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll);
      outLock = new GateLockView(this, lockType.singleOut, target, Location.X + Size.Width + 7 + HScroll, Location.Y + Size.Height * 1 / 2 - 10 / 2 + VScroll);

      homeForm.Canvas.Shapes.AddRange(new Shape[] { firstInCanal, secondInCanal, outCanal, inLock1, inLock2, outLock });
      ChildShapes.AddRange(new Shape[] { firstInCanal, secondInCanal, outCanal, inLock1, inLock2, outLock });  
    }
  }

  public class OrGateView : BaseGateView
  {
    public OrGateView(GatesGuiForm target) : base(target)
    {
      Text = "|";
    }

    protected override void AddCanalsAndLocksToCanvas(GatesGuiForm target)
    {
      int HScroll = homeForm.WorkingArea.HorizontalScroll.Value;
      int VScroll = homeForm.WorkingArea.VerticalScroll.Value;

      LineShape firstInCanal = new LineShape(Location.X + HScroll, Location.Y + Size.Height * 1 / 4 + VScroll, Location.X - 7 + HScroll, Location.Y + Size.Height * 1 / 4 + VScroll);
      inLock1 = new GateLockView(this, lockType.doubleInUpper, target, Location.X - 7 - 10 + HScroll, Location.Y + Size.Height * 1 / 4 - 10 / 2 + VScroll);

      LineShape secondInCanal = new LineShape(Location.X + HScroll, Location.Y + Size.Height * 3 / 4 + VScroll, Location.X - 7 + HScroll, Location.Y + Size.Height * 3 / 4 + VScroll);
      inLock2 = new GateLockView(this, lockType.doubleInLower, target, Location.X - 7 - 10 + HScroll, Location.Y + Size.Height * 3 / 4 - 10 / 2 + VScroll);

      LineShape outCanal = new LineShape(Location.X + Size.Width + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll, Location.X + Size.Width + 7 + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll);
      outLock = new GateLockView(this, lockType.singleOut, target, Location.X + Size.Width + 7 + HScroll, Location.Y + Size.Height * 1 / 2 - 10 / 2 + VScroll);

      homeForm.Canvas.Shapes.AddRange(new Shape[] { firstInCanal, secondInCanal, outCanal, inLock1, inLock2, outLock });
      ChildShapes.AddRange(new Shape[] { firstInCanal, secondInCanal, outCanal, inLock1, inLock2, outLock });   
    }
  }

  public class NotGateView : BaseGateView
  {
    public NotGateView(GatesGuiForm target) : base(target)
    {
      Text = "¬";
    }

    protected override void AddCanalsAndLocksToCanvas(GatesGuiForm target)
    {
      int HScroll = homeForm.WorkingArea.HorizontalScroll.Value;
      int VScroll = homeForm.WorkingArea.VerticalScroll.Value;

      LineShape inCanal = new LineShape(Location.X + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll, Location.X - 7 + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll);
      inLock1 = new GateLockView(this, lockType.singleIn, target, Location.X - 7 - 10 + HScroll, Location.Y + Size.Height * 1 / 2 - 10 / 2 + VScroll);

      LineShape outCanal = new LineShape(Location.X + Size.Width + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll, Location.X + Size.Width + 7 + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll);
      outLock = new GateLockView(this, lockType.singleOut, target, Location.X + Size.Width + 7 + HScroll, Location.Y + Size.Height * 1 / 2 - 10 / 2 + VScroll);

      homeForm.Canvas.Shapes.AddRange(new Shape[] { inCanal, outCanal, inLock1, outLock });
      ChildShapes.AddRange(new Shape[] { inCanal, outCanal, inLock1, outLock });
    }
  }

  public class InGateView : BaseGateView
  {
    public InGateView(GatesGuiForm target) : base(target)
    {
      Text = "v";
    }

    protected override void AddCanalsAndLocksToCanvas(GatesGuiForm target)
    {
      int HScroll = homeForm.WorkingArea.HorizontalScroll.Value;
      int VScroll = homeForm.WorkingArea.VerticalScroll.Value;

      LineShape outCanal = new LineShape(Location.X + Size.Width + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll, Location.X + Size.Width + 7 + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll);
      outLock = new GateLockView(this, lockType.singleOut, target, Location.X + Size.Width + 7 + HScroll, Location.Y + Size.Height * 1 / 2 - 10 / 2 + VScroll);

      homeForm.Canvas.Shapes.AddRange(new Shape[] { outCanal, outLock });
      ChildShapes.AddRange(new Shape[] { outCanal, outLock });
    }
  }

  public class OutGateView : BaseGateView
  {
    public OutGateView(GatesGuiForm target) : base(target)
    {
      Text = "^";
    }

    protected override void AddCanalsAndLocksToCanvas(GatesGuiForm target)
    {
      int HScroll = homeForm.WorkingArea.HorizontalScroll.Value;
      int VScroll = homeForm.WorkingArea.VerticalScroll.Value;

      LineShape inCanal = new LineShape(Location.X + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll, Location.X - 7 + HScroll, Location.Y + Size.Height * 1 / 2 + VScroll);
      inLock1 = new GateLockView(this, lockType.singleIn, target, Location.X - 7 - 10 + HScroll, Location.Y + Size.Height * 1 / 2 - 10 / 2 + VScroll);

      homeForm.Canvas.Shapes.AddRange(new Shape[] { inCanal, inLock1 });
      ChildShapes.AddRange(new Shape[] { inCanal, inLock1 });
    }
  }


}
