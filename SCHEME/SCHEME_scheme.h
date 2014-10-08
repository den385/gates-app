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

#include "gate.h"

//**********************************
//a scheme
//**********************************
class scheme
{
  vector<list<gate> > sch;
public:
	scheme();
	vector<gate> calc(vector<int>& v);
	int find(int id);
	void push(gate& gt);
};
