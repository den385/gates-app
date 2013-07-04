using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.PowerPacks;


namespace GatesGUI
{

  public static class SchemeView
  {
    private static List<BaseGateView> Gates;
    private static List<LineView> Lines;
    private static Bind SelectedLocks;

    private static GatesGuiForm homeForm = null;

    static SchemeView()
    {
      Gates = new List<BaseGateView>();
      Lines = new List<LineView>();
      SelectedLocks = new Bind();
    }

    public static void Initialize(GatesGuiForm inhomeForm)
    {
      if (homeForm == null)
        homeForm = inhomeForm;
    }

    public static void GateView_LockSelected(object sender, EventArgs e)
    {
      GateLockView inLock = sender as GateLockView;
      SelectedLocks.Push(inLock);

      if (SelectedLocks.Full())
      {
        CreateLine(SelectedLocks.first, SelectedLocks.second);
        SelectedLocks.Flush();
      }
           
    }

    public static void CreateLine(GateLockView lock1, GateLockView lock2)
    {
      LineView line = new LineView(homeForm, lock1, lock2);

      homeForm.WorkingArea.Refresh();

      lock1.ownerGate.Edges.Add(line);
      lock2.ownerGate.Edges.Add(line);

      // 1 -> 2
      if (lock1.type == lockType.singleOut)
      {
        lock1.ownerGate.AddChild(lock2.ownerGate);
        lock2.ownerGate.AddParent(lock1.ownerGate);
      }
      // 2 -> 1
      else if (lock2.type == lockType.singleOut)
      {
        lock1.ownerGate.AddParent(lock2.ownerGate);
        lock2.ownerGate.AddChild(lock1.ownerGate);
      }

      lock1.SetBusy();
      lock2.SetBusy();

      AddLine(line);
    }


    //2-> ... ->1
    public static bool FirstDescendsFromSecond(BaseGateView gate1, BaseGateView gate2)
    {
      List<BaseGateView> gate1Parents = gate1.GetParents();

      // Recursion base: if gates are neighbours
      if (gate1Parents.Contains(gate2))
        return true;

      // Recursion step
      else
        foreach (BaseGateView gate1Parent in gate1Parents)
        {
          if ( FirstDescendsFromSecond(gate1Parent, gate2) )
            return true;
        }

      // if are not connected
      return false;
    }

    //1-> ... ->2
    public static bool SecondDescendsFromFirst(BaseGateView gate1, BaseGateView gate2)
    {
      List<BaseGateView> gate1Children = gate1.GetChildren();

      // Recursion base: if gates are neighbours
      if (gate1Children.Contains(gate2))
        return true;

      // Recursion step
      else
        foreach (BaseGateView gate1Child in gate1Children)
        {
          if ( SecondDescendsFromFirst(gate1Child, gate2) )
            return true;
        }

      // if are not connected
      return false;
    }


    public static void AddGate(BaseGateView inGate)
    {
      Gates.Add(inGate);
    }

    public static void DeleteGate(BaseGateView inGate)
    {
      Gates.Remove(inGate);
    }

    public static void AddLine(LineView inLine)
    {
      Lines.Add(inLine);
    }

    public static void DeleteLine(LineView inLine)
    {
      Lines.Remove(inLine);
    }

    public static int Size()
    {
      return Gates.Count;
    }

    public static void Synchronize()
    {
      Scheme.Synchronize(Gates);
    }

    public static void Order()
    {
      Synchronize();

      int initX = 20, initY = 20;
      int Level = 0;
      int stepX = 80, stepY = 40;
      int X = initX, Y = initY;
      int maxY = initY;

      while (Scheme.GatesScheme[Level] != null && Scheme.GatesScheme[Level].Count != 0)
      {
        foreach (BaseGate gate in Scheme.GatesScheme[Level])
        {
          //Relocate the gate
          gate.View.Shift(X - gate.View.Location.X, Y - gate.View.Location.Y);
          Y += stepY;
          maxY = (Y > maxY ? Y : maxY);
        }

        ++Level;
        X += stepX;
        Y = initY;
      }

    }

    public static void Clear()
    {
      BaseGateView[] gateArray = new BaseGateView[Gates.Count];
      Gates.CopyTo(gateArray);

      foreach (BaseGateView gate in gateArray)
        gate.Delete();
    }

    public static void Save(string FileName)
    {
      Scheme.Synchronize(Gates);
      Scheme.SaveToFile(FileName);
    }

    public static void Load(string FileName)
    {
      Scheme.LoadFromFile(FileName, false);
    }

    //TODO: macro-gates, wrap-unwrap ops on gates

    //TODO: dragging gates from GateCreation buttons, no fixed-point-spawn

    //TODO: determine why binds are drawn above gates
  }








}



//decomment if binds are drawn upon locks
//         foreach (BaseGateView gateUnit in Gates)
//         {
//           homeForm.Controls.Remove(gateUnit);
//           homeForm.Controls.Add(gateUnit);
//         }
