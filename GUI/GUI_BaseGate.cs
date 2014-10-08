using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GatesGUI
{
  public enum gateType
  {
    andGate, orGate, notGate, inGate, outGate
  }

  public class BaseGate
  {
    public int Level;
    public List<BaseGate> Parents;
    public List<BaseGate> Children;
    public BaseGateView View;
    public gateType type;
  	public int id;

    public BaseGate(BaseGateView gate)
    {
      Parents = new List<BaseGate>();
      Children = new List<BaseGate>();

			id = Scheme.IdCounter;
			++Scheme.IdCounter;

      Level = -1;
      View = gate;
      gate.Data = this;

      if (gate is AndGateView)
        type = gateType.andGate;
      if (gate is OrGateView)
        type = gateType.orGate;
      if (gate is NotGateView)
        type = gateType.notGate;
      if (gate is InGateView)
        type = gateType.inGate;
      if (gate is OutGateView)
        type = gateType.outGate;
    }

		public string Serialize()
		{
			string result = "";

			result += id.ToString() + " ";

			foreach (BaseGate parent in Parents)
				result += parent.id + " ";

			if (Parents.Count == 1)
				result += "0 ";
  		else if (Parents.Count == 0)
				result += "0 0 ";

      if (type == gateType.andGate)
        result += "&";
      if (type == gateType.orGate)
        result += "|";
      if (type == gateType.notGate)
        result += "~";
      if (type == gateType.inGate)
        result += ">";
      if (type == gateType.outGate)
        result += "<";

			return result;
		}

    public bool IsTotallyIntegrated()
    {
      if (type == gateType.andGate || type == gateType.orGate)
        return (Parents.Count == 2 && Children.Count >= 1);

      else if (type == gateType.notGate)
        return (Parents.Count == 1 && Children.Count >= 1);

      else if (type == gateType.inGate)
        return (Parents.Count == 0 && Children.Count >= 1);

      else if (type == gateType.outGate)
        return (Parents.Count == 1 && Children.Count == 0);

      else
        return false;
    }



  }

  //     public BaseGate(string line)
  //     {
  //       // TODO construct gate and GateView by string
  // 
  //       Parents = new List<BaseGate>();
  //       Children = new List<BaseGate>();
  // 
  //       id = Scheme.IdCounter;
  //       ++Scheme.IdCounter;
  // 
  //       Level = -1;
  //       View = gate;
  //       gate.Data = this;
  // 
  //       if (gate is AndGateView)
  //         type = gateType.andGate;
  //       if (gate is OrGateView)
  //         type = gateType.orGate;
  //       if (gate is NotGateView)
  //         type = gateType.notGate;
  //       if (gate is InGateView)
  //         type = gateType.inGate;
  //       if (gate is OutGateView)
  //         type = gateType.outGate;
  //    }



  //       List<BaseGateView> parents = gate.GetParents();
  //       List<BaseGateView> children = gate.GetChildren();
  // 
  //       foreach (BaseGateView parentGateView in parents)
  //       {
  //         Parents
  //       }
  // 
  //       foreach (BaseGateView childGateView in children)
  //       {
  // 
  //       }
  // 
  //       //Parents = 
  //       //Children = 






//DESCENDANT GATES CLASSES DRAFT
//   public class AndGate : BaseGate
//   {
//     public BaseGate Parent1;
//     public BaseGate Parent2;
//     public List<BaseGate> Children;
//     public AndGateView View;
// 
//     public AndGate(AndGateView gate)
//     {
//       View = gate;
// 
//       foreach(Shape shapeUnit in gate.ChildShapes)
//       {
// 
//       }
// 
// 
// 
//     }
//   }
// 
//   public class OrGate : BaseGate
//   {
//     public BaseGate Parent1;
//     public BaseGate Parent2;
//     public List<BaseGate> Children;
//     public OrGateView View;
// 
//     public OrGate(OrGateView gate)
//     {
// 
//     }
//   }
// 
//   public class NotGate : BaseGate
//   {
//     public BaseGate Parent;
//     public List<BaseGate> Children;
//     public NotGateView View;
// 
//     public NotGate(NotGateView gate)
//     {
// 
//     }
//   }
// 
//   public class InGate : BaseGate
//   {
//     public List<BaseGate> Children;
//     public InGateView View;
// 
//     public InGate(InGateView gate)
//     {
// 
//     }
//   }
// 
//   public class OutGate : BaseGate
//   {
//     public BaseGate Parent;
//     public OutGateView View;
// 
//     public OutGate(OutGateView gate)
//     {
// 
//     }
//   }





}
