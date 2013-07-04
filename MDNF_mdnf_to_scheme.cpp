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

#ifndef CSV_BUF_INCLUDED
#define CSV_BUF_INCLUDED
#include "csv_buffer.h"
#endif

#include "gate_tree.h"

void main(int argc, char* argv[])
{
  string flag = "";

	while (flag.compare("BEGIN") != 0)
		cin >> flag;

	csv_buffer* iobuf = new csv_buffer(cin);
	csv_string s("");
	gate_tree* t = new gate_tree();

	//build the whole tree with all out-gates	
	for(int i=0;i<iobuf->size();i++)
	{
		s = iobuf->send();
		expr* e = new expr(s);
		t->append(*e);
		delete e;
	}

	//transform tree to buffer and print it
	*iobuf = t->to_buf();

	cout << "BEGIN" << endl;
	iobuf->print();	
	cout << "END" << endl;

	//buf destructor is not necessary, cause buf points to the buffield of gate_tree
	//so that memory ocuppied by it is set free when tree destr is called
	delete t;
	delete iobuf;
}
