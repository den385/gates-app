#include "gate.h"

//gate constructor
gate::gate(int gate_id, int gate_lvl, char gate_type, int gate_dep1, int gate_dep2)
{
  id = gate_id;
	val = -1;
	lvl = gate_lvl;
	dep1 = gate_dep1;
	dep2 = gate_dep2;
	type = gate_type;
}	
//empty constructor
gate::gate()
{

}
//constructor by csv_string
gate::gate(csv_string& s)
{
	vector<string> data(s.split(" "));
	id = stoi(data[0]);
	val = -1;
	lvl = stoi(data[4]);
	type = data[3].c_str()[0];
	dep1 = stoi(data[1]);
	dep2 = stoi(data[2]);
}
