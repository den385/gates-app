#include "stdafx.h"
#include "csv_string.h"

//1st constructor
csv_string::csv_string(string& str)
{
 s = str;
}
//2nd constructor
csv_string::csv_string(char* str)
{
 string s1(str);
 s = s1;
}
//returns the string content of csv_string
string& csv_string::to_string()
{
 return(s);
}
//returns a vector of csv_strings which are segments of s str. splitted up by c char.
vector<csv_string> csv_string::csv_split(char* seps)
{
  char* str = new char[s.size()];
	strcpy(str, s.c_str());
	char* token = strtok(str, seps);
	vector<csv_string> sv;
	
	while( token != NULL )
   { 
      sv.push_back(csv_string(token));
	  token = strtok(NULL, seps);
   }

	return(sv);
}
//returns a vector of strings which are segments of s str. splitted up by c char.
vector<string> csv_string::split(char* seps)
{
	vector<csv_string> csvec;
	csvec = this->csv_split(seps);
	vector<string> vec(csvec.size());
	for(unsigned int i=0;i<csvec.size();i++) vec[i] = csvec[i].to_string();
	return(vec);
}

//operator<< for csv_strings
ostream& operator<<(ostream& stream, csv_string& str)
{
	stream << str.to_string();
	return(stream);
}
