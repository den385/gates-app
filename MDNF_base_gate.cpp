#include "base_gate.h"

//base_gate constructor
base_gate::base_gate(int gate_id, char gate_type)
{
  id = gate_id;
	type = gate_type;
	flag = 0;
}	
//empty base_gate constructor
base_gate::base_gate()
{
	flag = 0;
}
//create csv_string based on gate`s fields
csv_string base_gate::to_csv_str()
{
	string s;
	
	if((this->lgt == 0) && (this->rgt == 0)) s = to_string((long long) this->id) + " 0" + " 0 " + this->type;
	else if(this->lgt == 0) s = to_string((long long) this->id) + " 0 " + to_string((long long) this->rgt->id) + " " + this->type;
	else if(this->rgt == 0) s = to_string((long long) this->id) + " " + to_string((long long) this->lgt->id) + " 0 " + this->type;
	else s = to_string((long long) this->id) + " " + to_string((long long) this->lgt->id) + " " + to_string((long long) this->rgt->id) + " " + this->type;
	return(csv_string(s));
}
