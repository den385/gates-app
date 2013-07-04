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

//****************************************
//a buffer of csv_strings with a cursor
//****************************************
class csv_buffer
{ 
protected:
  vector<csv_string> buf;
	int cursor;
public:
	 csv_string send();
	 void goback();
	 int size();
	 csv_buffer(istream&);
	 csv_buffer(csv_buffer* b);
	 csv_buffer();
	 void rewind();
	 csv_buffer push_back(csv_string s);
	 csv_buffer& operator=(csv_buffer& buffer);
	 void print();
};
