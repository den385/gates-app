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

#ifndef CSV_BUF_INCLUDED
#define CSV_BUF_INCLUDED
#include "csv_buffer.h"
#endif

#ifndef EXPR_INCLUDED
#define EXPR_INCLUDED
#include "expr.h"
#endif

#include "base_gate.h"
#include <map>
//typedef cliext::map<string, base_gate*> mymap;

class gate_tree
{
  int curr_id;
	map<string, base_gate*> outs;
	map<string, base_gate*> ins;
	map<string, base_gate*> nots;
	csv_buffer tree_buf;
public:
	gate_tree();
	~gate_tree();
	void append(expr& ex);
	csv_buffer to_buf();
private:
	base_gate* rec_append(expr& ex);
	void rec_to_buf(base_gate* top);
	void rec_delete(base_gate* top);
};
