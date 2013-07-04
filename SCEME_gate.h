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
class gate
{
  int lvl, dep1, dep2; 
	char type;
public:
	int id, val;
	gate(int gate_id, int gate_lvl, char gate_type, int gate_dep1, int gate_dep2);
	gate();
	gate(csv_string& s);
	friend class scheme;
};
