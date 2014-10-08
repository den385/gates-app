#include "gate_tree.h"

//adds gates, extracted from the args, to the tree
//meanwhile checks if such gates already exist in tree
base_gate* gate_tree::rec_append(expr& ex)
{
  base_gate* gt = new base_gate();
	//gate will contain a varname string - name of var for VAR and string of expr for EXPR
	map<string, base_gate*> :: const_iterator Iter; Iter = nots.find(ex.varname/*string a la "~x1"*/);
	pair<string, base_gate*> newnot(ex.varname, gt);
	map<string, base_gate*> :: const_iterator Iter1; Iter1 = ins.find(ex.varname/*string a la "x1"*/);
	pair<string, base_gate*> newin(ex.varname, gt);
	switch (ex.optype)
	{
	case expr::AND: gt->id = curr_id; curr_id++; gt->type = '&'; gt->lgt = rec_append(ex.args[0]); gt->rgt = rec_append(ex.args[1]); break;
	case expr::OR: gt->id = curr_id; curr_id++; gt->type = '|';	gt->lgt = rec_append(ex.args[0]); gt->rgt = rec_append(ex.args[1]); break;
	case expr::NOT: if(Iter == nots.end()/*!exists*/) 
					{
						gt->id = curr_id; 
						curr_id++; 
						gt->type = '~'; 
						gt->lgt = rec_append(ex.args[0]); 
						gt->rgt = 0;
						nots.emplace(newnot); /*memorize*/
					}
					else gt = nots[ex.varname];/*reconnect to the memorized one*/ break;
	case expr::IN: 
					if(Iter1 == ins.end()/*!exists*/) 
					{
						gt->id = curr_id; 
						curr_id++; 
						gt->type = '>'; 
						gt->lgt = gt->rgt = 0; 
						ins.emplace(newin);/*memorize*/
					}
					else gt = ins[ex.varname];/*reconnect to the memorized one*/ break;
	}

	return(gt);
}
//puts the final result of rec_append`s recursion to vector of out-gates
void gate_tree::append(expr& ex)
{
	base_gate* gt = new base_gate();
	gt->id = curr_id; 
	curr_id++; 
	gt->type = '<'; 
	gt->lgt = rec_append(ex.args[0]); 
	gt->rgt = 0;

	pair<string, base_gate*> newout(ex.varname, gt);
	outs.emplace(newout);
}
//transforms part of gate_tree starting with top to csv_buffer
void gate_tree::rec_to_buf(base_gate* top)
{
	base_gate* tmp = new base_gate();

	if(top->flag == 0) 
	{
		tree_buf.push_back(top->to_csv_str());
		top->flag = 1;
	}
	if(top->lgt != 0)
	{
		tmp = top->lgt;
		this->rec_to_buf(tmp);
	}
	if(top->rgt != 0) 
	{
		tmp = top->rgt;
		this->rec_to_buf(tmp);
	}

}
//transforms gate_tree to csv_buffer
csv_buffer gate_tree::to_buf()
{
	map<string, base_gate*> :: const_iterator Iter;
	for(Iter=outs.begin();Iter!=outs.end();Iter++)
		this->rec_to_buf(Iter->second);
	return(tree_buf);
}
//empty constructor
gate_tree::gate_tree()
{
	curr_id = 1;
}
//recursive part of the destructor
void gate_tree::rec_delete(base_gate* top)
{
	base_gate* tmp;

	if(top->lgt != 0)
	{
		tmp = top->lgt;
		rec_delete(tmp);
	}
	if(top->rgt != 0) 
	{
		tmp = top->rgt;
		rec_delete(tmp);
	}
}
//destructor
gate_tree::~gate_tree()
{
	map<string, base_gate*> :: const_iterator Iter;
	for(Iter=outs.begin();Iter!=outs.end();Iter++)
		this->rec_delete(Iter->second);
}
