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

class expr
{
  enum {EXPR, VAR} type;
	string varname;
	enum {OR, AND, NOT, IN, OUT} optype;
	vector<expr> args;
public:
	expr(csv_string s);
	expr();
	void print();
	friend class gate_tree;
private:
	expr rec_expr(csv_string s);
};


