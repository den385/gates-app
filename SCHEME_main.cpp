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

#include "gate_buffer.h"
#include "scheme.h"

void main(int argc, char* argv[])
{
  string s = "";

	while (s.compare("BEGIN") != 0)
		cin >> s;

	scheme* sch = new scheme();
	gate_buffer* buf = new gate_buffer(cin);

	//fill scheme sch
	for(int i=0;i<buf->size();i++) 
		sch->push( gate( buf->send() ) );

	//get a vector<int> v - vector of enter-gate values
	vector<int> v;
	for(int i=0;i<strlen(argv[1])-2;i++) v.push_back( (argv[1][i+2] - '0') );

	//print result
	vector<gate> vg( sch->calc(v) );
	for(int i=0;i<vg.size();i++)
		cout << vg[i].id << ": " << vg[i].val << "\n";

	delete sch;
	delete buf;
}
