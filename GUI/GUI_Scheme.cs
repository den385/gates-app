using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace GatesGUI
{
  public static class Scheme
  {
    public static List<BaseGate>[] GatesScheme;
    public static List<BaseGate> FreeGates;
  	public static int IdCounter;
    private static GatesGuiForm homeForm;

    static Scheme()
    {
      FreeGates = new List<BaseGate>();
      GatesScheme = new List<BaseGate>[1];
		}

    public static void Initialize(GatesGuiForm inhomeForm)
    {
      if (homeForm == null)
        homeForm = inhomeForm;
    }

    public static void Synchronize(List<BaseGateView> inGates)
    {
      // 1) Project all GateViews to FreeGates

			IdCounter = 1;
      GatesScheme = new List<BaseGate>[SchemeView.Size() + 1];
      FreeGates.Clear();
      foreach (BaseGateView gateView in inGates)
          FreeGates.Add(new BaseGate(gateView));

      // 2) Establish connections

      //Set Children and Parents connections
      foreach (BaseGate gate in FreeGates)
      {
        foreach (BaseGateView child in gate.View.GetChildren())
          gate.Children.Add(child.Data);
        foreach (BaseGateView parent in gate.View.GetParents())
          gate.Parents.Add(parent.Data);
      }

      // 3) Fill Scheme

      FillGatesScheme();
    }

    // Defines levels for all the FreeGates
    private static void FillGatesScheme()
    {
      List<BaseGate> freeChildren = new List<BaseGate>();
      freeChildren.Clear();

      BaseGate[] freeGatesCopy = new BaseGate[FreeGates.Count];
      FreeGates.CopyTo(freeGatesCopy);

      // Fill 0-level of GatesScheme

      GatesScheme[0] = new List<BaseGate>();
      foreach (BaseGate gate in freeGatesCopy)
        if (gate.type == gateType.inGate)
        {
          FreeGates.Remove(gate);
          GatesScheme[0].Add(gate);
          gate.Level = 0;

          foreach (BaseGate childGate in gate.Children)
            if (!freeChildren.Contains(childGate))
              freeChildren.Add(childGate);
        }

      // Fill GatesScheme
      if (freeChildren.Count > 0)
        GatesScheme[1] = new List<BaseGate>();
      int CurrentLevel = 1;
      List<BaseGate> iterationChildren = new List<BaseGate>();

      while (freeChildren.Count != 0)
      {
        iterationChildren.Clear();
        foreach (BaseGate child in freeChildren)
          iterationChildren.Add(child);
        
        foreach (BaseGate child in iterationChildren)
        {
          bool parentsOk = true;

          foreach (BaseGate parent in child.Parents)
            parentsOk = parentsOk && parent.Level >= 0 && parent.Level < CurrentLevel;

          if (parentsOk)
          {
            foreach (BaseGate grandChild in child.Children)
              if (!freeChildren.Contains(grandChild))
                freeChildren.Add(grandChild);

            freeChildren.Remove(child);
            FreeGates.Remove(child);
            GatesScheme[CurrentLevel].Add(child);
            child.Level = CurrentLevel;
          }
        }// foreach end

        ++CurrentLevel;
        GatesScheme[CurrentLevel] = new List<BaseGate>();


      }// while end

    }

    public static bool Verify()
    {
      int Level = 0;
      bool schemeCorrect = (FreeGates.Count == 0);
      
      if (schemeCorrect)
        while (GatesScheme[Level] != null && GatesScheme[Level].Count != 0 && schemeCorrect)
        {
          foreach (BaseGate gate in GatesScheme[Level])
            schemeCorrect = schemeCorrect && gate.IsTotallyIntegrated();
        
          ++Level;
        }

      return schemeCorrect;
    }

		public static void SaveToFile(string FileName)
		{
			List<string> Serialization = Serialize();

			System.IO.File.WriteAllLines(FileName, Serialization);
		}

    // Load random scheme (no verification)
		public static void LoadFromFile(string FileName, bool clear)
		{
      string[] Serialization = System.IO.File.ReadAllLines(FileName);

      Deserialize(Serialization, clear);
		}

    // Serialize random scheme (no verification)
		public static List<string> Serialize()
		{
			int Level = 0;
			List<string> result = new List<string>();

      // Serialize integrated gates
			while (GatesScheme[Level] != null && GatesScheme[Level].Count != 0)
			{
				foreach (BaseGate gate in GatesScheme[Level])
					result.Add(gate.Serialize());

				++Level;
			}

      // Serialize free gates
      foreach (BaseGate gate in FreeGates)
        result.Add(gate.Serialize());

			return result;
		}

    public static void Deserialize(string[] Serialization, bool clear)
    {
      BaseGateView gate;

      // Create gates
      BaseGateView[] createdGates = new BaseGateView[Serialization.GetLength(0) + 1];
      int[] dependence1 = new int[Serialization.GetLength(0) + 1];
      int[] dependence2 = new int[Serialization.GetLength(0) + 1];

      foreach (string line in Serialization)
      {
        char[] separators = new char[] { ' ' };
        string[] splittedLine = line.Split(separators);

        int id;
        Int32.TryParse(splittedLine[0], out id);
        Int32.TryParse(splittedLine[1], out dependence1[id]);
        Int32.TryParse(splittedLine[2], out dependence2[id]);

        if (splittedLine[3].Equals("&"))
          gate = new AndGateView(homeForm);
        else if (splittedLine[3].Equals("|"))
          gate = new OrGateView(homeForm);
        else if (splittedLine[3].Equals("~"))
          gate = new NotGateView(homeForm);
        else if (splittedLine[3].Equals(">"))
          gate = new InGateView(homeForm);
        else
          gate = new OutGateView(homeForm);

        createdGates[id] = gate;
        SchemeView.AddGate(gate);
      }

      // Create binds
      for (int i = 0; i < createdGates.GetLength(0); ++i)
        if (createdGates[i] != null)
        {
          if (dependence1[i] != 0)
            SchemeView.CreateLine(createdGates[i].inLock1, createdGates[dependence1[i]].outLock);
          if (dependence2[i] != 0)
            SchemeView.CreateLine(createdGates[i].inLock2, createdGates[dependence2[i]].outLock);
        }

      // Order scheme
      if (clear)
        SchemeView.Clear();

      SchemeView.Order();
    }

    public static int[] Simulate(int[] inGateValuesVector)
    {
      List<string> serializationInfo = Scheme.Serialize();

      //TODO: redirect execution to local path
      string executableName = "scheme.exe";
      string executableParameter = "-v";
      foreach (int a in inGateValuesVector)
        executableParameter += a.ToString();

      // Specify a set of values that are used when starting a process
      ProcessStartInfo processStartInfo = new ProcessStartInfo(executableName, executableParameter);
      processStartInfo.UseShellExecute = false;
      processStartInfo.ErrorDialog = false;

      // Set the redirecting properties to true
      processStartInfo.RedirectStandardError = true;
      processStartInfo.RedirectStandardInput = true;
      processStartInfo.RedirectStandardOutput = true;

      // Start the process
      Process process = new Process();
      process.StartInfo = processStartInfo;
      bool processStarted = process.Start();

      // Capture the input/output/error streams
      // For giving input, we need to write the input string in the input stream. 
      StreamWriter inputWriter = process.StandardInput;
      StreamReader outputReader = process.StandardOutput;
      StreamReader errorReader = process.StandardError;

      // Write to scheme.exe STDIN
      string s = "";
      inputWriter.WriteLine("BEGIN");
      foreach (string str in serializationInfo)
        inputWriter.WriteLine(str);
      inputWriter.WriteLine("END");

      // Read from scheme.exe STDOUT
      List<string> sResult = new List<string>();
      while (s == "")
        s = outputReader.ReadLine();

      while (s != "" && s != null)
      {
        sResult.Add(s);
        s = outputReader.ReadLine();
      }

      // Parse strings of sResult
      char[] separators = new char[] { ' ' };
      int[] result = new int[sResult.Count];
      int i = 0;
      foreach (string line in sResult)
      {
        string[] splittedLine = line.Split(separators);
        Int32.TryParse(splittedLine[1], out result[i]);
        ++i;
      }

      // Wait for the associated process to exit. 
      // Blocks the current thread of execution until the process has exited.
      process.WaitForExit();

      return result;
    }

    // TODO: not safe - suppose the scheme exists and is synced
    public static int GetOutGatesNumber()
    {
      int Level = 0, nOuts = 0;

      while (GatesScheme[Level] != null && GatesScheme[Level].Count != 0)
      {
        foreach (BaseGate gate in Scheme.GatesScheme[Level])
          nOuts += (gate.type == gateType.outGate ? 1 : 0);

        ++Level;
      }

      return nOuts;
    }

    public static int GetInGatesNumber()
    {
      if (GatesScheme[0] != null)
        return GatesScheme[0].Count;
      else
        return 0;
    }

    public static void BuildByTable(List<string> table)
    {
      string executableName = "table_to_mdnf.exe";
      string executableParameter = "";

      // Specify a set of values that are used when starting a process
      ProcessStartInfo processStartInfo = new ProcessStartInfo(executableName, executableParameter);
      processStartInfo.UseShellExecute = false;
      processStartInfo.ErrorDialog = false;

      // Set the redirecting properties to true
      processStartInfo.RedirectStandardError = true;
      processStartInfo.RedirectStandardInput = true;
      processStartInfo.RedirectStandardOutput = true;

      // Start the process
      Process process = new Process();
      process.StartInfo = processStartInfo;
      bool processStarted = process.Start();

      // Capture the input/output/error streams
      // For giving input, we need to write the input string in the input stream. 
      StreamWriter inputWriter = process.StandardInput;
      StreamReader outputReader = process.StandardOutput;
      StreamReader errorReader = process.StandardError;

      // Write to scheme.exe STDIN
      string s = "";
      inputWriter.WriteLine("BEGIN");
      foreach (string str in table)
        inputWriter.WriteLine(str);
      inputWriter.WriteLine("END");

      // Read from scheme.exe STDOUT
      List<string> sResult = new List<string>();
      while (s == "")
        s = outputReader.ReadLine();

      while (s != "" && s != null && s!="END")
      {
        if (s != "BEGIN")
          sResult.Add(s);
        s = outputReader.ReadLine();
      }

      // Wait for the associated process to exit. 
      // Blocks the current thread of execution until the process has exited.
      process.WaitForExit();

      //--------------------------------------------------------------------------------------
      //--------------------------------------------------------------------------------------
      //-------------------------------------------------------------------------------------- 

      string executableName1 = "mdnf_to_scheme.exe";
      string executableParameter1 = "";

      // Specify a set of values that are used when starting a process
      ProcessStartInfo processStartInfo1 = new ProcessStartInfo(executableName1, executableParameter1);
      processStartInfo1.UseShellExecute = false;
      processStartInfo1.ErrorDialog = false;

      // Set the redirecting properties to true
      processStartInfo1.RedirectStandardError = true;
      processStartInfo1.RedirectStandardInput = true;
      processStartInfo1.RedirectStandardOutput = true;

      // Start the process
      Process process1 = new Process();
      process1.StartInfo = processStartInfo1;
      bool processStarted1 = process1.Start();

      // Capture the input/output/error streams
      // For giving input, we need to write the input string in the input stream. 
      StreamWriter inputWriter1 = process1.StandardInput;
      StreamReader outputReader1 = process1.StandardOutput;
      StreamReader errorReader1 = process1.StandardError;

      // Write to scheme.exe STDIN
      string s1 = "";
      inputWriter1.WriteLine("BEGIN");
      foreach (string str in sResult)
        inputWriter1.WriteLine(str);
      inputWriter1.WriteLine("END");

      // Read from scheme.exe STDOUT
      List<string> sResult1 = new List<string>();
      while (s1 == "" || s1 == "BEGIN")
        s1 = outputReader1.ReadLine();

      while (s1 != "" && s1 != null && s1 != "END")
      {
        sResult1.Add(s1);
        s1 = outputReader1.ReadLine();
      }

      // Wait for the associated process to exit. 
      // Blocks the current thread of execution until the process has exited.
      process1.WaitForExit();

      string[] Serialization = sResult1.ToArray();
      Deserialize(Serialization, false);
    }


  }

}
