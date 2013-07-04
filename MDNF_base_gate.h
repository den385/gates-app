#ifndef STD_LIBS_INCLUDED
#define STD_LIBS_INCLUDED

#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <list>
#include <string>
#include <vector>
#include <set>
#include <iostream>
#include <algorithm>
using namespace std;

#endif

#ifndef CSV_STR_INCLUDED
#define CSV_STR_INCLUDED
#include "csv_string.h"
#endif


//**********************************
//a gate
//**********************************
class base_gate
{
  base_gate* rgt;
	base_gate* lgt;
	int id;
	char type;
	int flag;
public:
	base_gate(int gate_id, char gate_type);
	base_gate();	
	csv_string to_csv_str();
	friend class gate_tree;
};
