using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.VisualBasic.PowerPacks;

namespace GatesGUI
{
  public enum lockType { singleIn, doubleInUpper, doubleInLower, singleOut };

  public class BaseGateView : Label
  {
    public List<LineView> Edges;    
    protected List<Shape> ChildShapes;
    public BaseGate Data;

    public GateLockView inLock1;
    public GateLockView inLock2;
    public GateLockView outLock;

    private List<BaseGateView> Parents;
    private List<BaseGateView> Children;

    protected GatesGuiForm homeForm;
    public bool isDragged;
    public int deltaX, deltaY;

    public BaseGateView(GatesGuiForm target) : base()
    {
      //fill the fields
      homeForm = target;
      Edges = new List<LineView>();
      ChildShapes = new List<Shape>();
      Parents = new List<BaseGateView>();
      Children = new List<BaseGateView>();
      isDragged = false;

      //adjust the view of label
      TextAlign = ContentAlignment.MiddleCenter;
      Font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
      AutoSize = false;
      Location = new Point(200, 200);
      Size = new Size(30, 30);
      BackColor = System.Drawing.Color.DodgerBlue;
      BorderStyle = BorderStyle.FixedSingle;
      Cursor = System.Windows.Forms.Cursors.Hand;

      //add canals and locks to canvas and label to form
      AddCanalsAndLocksToCanvas(target);
      target.WorkingArea.Controls.Add(this);

      //Subcribe to Event Handlers of a gate
      MouseDown += new MouseEventHandler(GateView_MouseDown);
      MouseDoubleClick += new MouseEventHandler(GateView_MouseDoubleClick);
      MouseUp += new MouseEventHandler(GateView_MouseUp);
      MouseMove += new MouseEventHandler(GateView_MouseMove);
    }

    protected virtual void AddCanalsAndLocksToCanvas(GatesGuiForm target) {}

    public List<BaseGateView> GetParents()
    {
      return Parents;
    }

    public List<BaseGateView> GetChildren()
    {
      return Children;
    }

    public void AddChild(BaseGateView gate)
    {
      Children.Add(gate);
    }

    public void DeleteChild(BaseGateView gate)
    {
      Children.Remove(gate);
    }

    public void AddParent(BaseGateView gate)
    {
      Parents.Add(gate);
    }

    public void DeleteParent(BaseGateView gate)
    {
      Parents.Remove(gate);
    }

    public void Shift(int shiftX, int shiftY)
    {
      LineShape canal;
      OvalShape canalLock;

      //1) Drag Label
      Location = new Point(Location.X + shiftX, Location.Y + shiftY);

      //2) Drag Binds
      foreach (LineView line in Edges)
        line.moveAttachedEnds(this, shiftX, shiftY);

      //3) Redraw controls
      homeForm.Refresh();

      //4) Drag Canals and Locks
      foreach (Shape shapeUnit in ChildShapes)
      {
        //Canals
        if (shapeUnit is LineShape)
        {
          canal = shapeUnit as LineShape;

          canal.X1 += shiftX;
          canal.X2 += shiftX;
          canal.Y1 += shiftY;
          canal.Y2 += shiftY;
        }

        //Locks
        else if (shapeUnit is OvalShape)
        {
          canalLock = shapeUnit as OvalShape;

          canalLock.Location = new System.Drawing.Point(canalLock.Location.X + shiftX, canalLock.Location.Y + shiftY);
        }
      }
    }

    //EVENT HANDLERS ----------------------------------------------------------------------------------------
    private void GateView_MouseDown(object sender, MouseEventArgs e)
    {
      isDragged = true;
      deltaX = e.Location.X;
      deltaY = e.Location.Y;
    }

    private void GateView_MouseMove(object sender, MouseEventArgs e)
    {
      if (isDragged && (Location.X + e.Location.X - deltaX > 0) && (Location.Y + e.Location.Y - deltaY > 0))
      {
        Shift(e.Location.X - deltaX, e.Location.Y - deltaY);
      }
    }

    private void GateView_MouseUp(object sender, MouseEventArgs e)
    {
      isDragged = false;
    }

    private void GateView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      Delete();
    }

    public void Delete()
    {
      //Clear Children and Parents lists
      Children.Clear();
      Parents.Clear();

      //detach shapes and dispose them
      foreach (Shape shapeUnit in ChildShapes)
      {
        homeForm.Canvas.Shapes.Remove(shapeUnit);
        shapeUnit.Dispose();
      }

      //Delete all binds for this gate, erase mem of them from neighbours
      LineView[] linesToDelete = new LineView[Edges.Count];
      Edges.CopyTo(linesToDelete, 0);

      foreach (LineView line in linesToDelete)
        line.Delete();

      //detach label from form and Scheme and dispose it
      homeForm.Controls.Remove(this);
      SchemeView.DeleteGate(this);
      this.Dispose();
    }

  }
}
