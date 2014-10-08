#include "stdafx.h"
#include "terms_to_dnf.h"
using namespace std;

terms_to_dnf::terms_to_dnf(list<string> terms) : csv_string("")
{
  string s1 = "";
	
	for(list<string>::iterator it = terms.begin(); it != terms.end(); ++it)
	{
		s1 = s1 + '(';

		//номер переменной
		int i = 0, flag = 0;

		for(string::iterator iter = (*it).begin(); iter != (*it).end(); ++iter)
		{
			if(iter == (*it).begin()) flag = 1;

			if(flag == 1)
 				switch (*iter)
			  {
 					case '1': s1 = s1 + 'x' + ::to_string((long long) i); flag = 0; break;
 					case '0': s1 = s1 + "(~x" + ::to_string((long long) i) + ')'; flag = 0; break;
 					case '*': break;
				}
			else
				switch (*iter)
			  {
 					case '1': s1 = s1 + "&x" + ::to_string((long long) i); flag = 0; break;
 					case '0': s1 = s1 + "&(~x" + ::to_string((long long) i) + ')'; flag = 0; break;
 					case '*': if(s1.empty()) flag = 1; break;
				}	

			++i;
		}

		s1 = s1 + ")|";
	}

	s1.resize(s1.size()-1);
	s = s1;
}
