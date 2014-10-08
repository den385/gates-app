// table_to_mdnf.cpp : Defines the entry point for the console application.
// the input is redirected: <data1.txt >output.txt
// this is a part of the diploma project by

#include "stdafx.h"
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
#include "csv_buffer.h"
#include "terms_to_dnf.h"
#include "quaine_optimizer.h"

void _tmain(int argc, _TCHAR* argv[])
{
  string flag = "";

	while (flag.compare("BEGIN") != 0)
		cin >> flag;

	//буфер теперь хранит весь ввод (таблицу истинности), а строка s - первую строку
	csv_buffer buf(cin);
	csv_string s(buf.send()); 

	//n -число переменных, k - число функций, constituents - вектор конституент единицы
	int n = (s.split(" "))[0].size();
	int k = (s.split(" "))[1].size();
	list<string> constituents;
	list<list<string> > bin_functions_primaries;
	string ts0, ts1;

	//внешний цикл - по числу функций, внутренний - по длине буфера
	//в этом случае не придётся использовать 2х-мерный масив строк
	for(int i = 0; i < k; ++i)
	{
		for(int j = 0; j < buf.size(); j++)
		{
			//ts0 - значения переменных в j-й строке буфера, ts1 - значения функции
			ts0 = (s.split(" "))[0];
			ts1 = (s.split(" "))[1];

			//определяем, является ли ts0 конституентой 1 для i-й переменной 
			if( ts1[i] == '1' ) 
				constituents.push_back( (s.split(" "))[0] );
		  
			s = buf.send();
		}

		//обрабатываем конституенты единицы для i-й переменной, добавляем конституенты в хранилище
 		constituents = quaine_optimizer::optimize(constituents);
		bin_functions_primaries.push_back(constituents);

		//очищаем конституенты, перематываем буфер, берём первую строку для работы со следующей переменной
		constituents.clear();
		buf.rewind();
		s = buf.send();
	}//конец обработки буфера, на этот момент мы имеем по списку первичных импликант на переменную

	//Вывод
	int i = 0;
	cout << "BEGIN" << endl;
	for(list<list<string> >::iterator it = bin_functions_primaries.begin(); it != bin_functions_primaries.end(); ++it)
	{
		terms_to_dnf s_expr(*it);
		cout << 'y' << to_string((long long) i) << " = " << s_expr << endl;

		++i;
	}
	cout << "END" << endl;

}
