#pragma once
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

#include "csv_string.h"

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
	 void rewind();
	 csv_buffer(istream&);
};
