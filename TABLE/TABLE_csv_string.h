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

//******************************
//string with split method
//******************************
class csv_string
{
protected:
  string s;
public:
	csv_string(string& str);
	csv_string(char* str);     
	vector<csv_string> csv_split(char* seps);
	vector<string> split(char* seps);
	string& to_string();
};

extern ostream& operator<<(ostream& stream, csv_string& str);
