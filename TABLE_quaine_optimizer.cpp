#include "StdAfx.h"
#include "quaine_optimizer.h"
#include <algorithm>
using namespace std;

//метод верхнего уровня, руководит оптимизацией
list<string> quaine_optimizer::optimize(list<string> constituents)
{
  list<string> primary_implicants;
	
	primary_implicants = find_primary_implicants(constituents);
	primary_implicants = optimize_via_implicant_matrix(primary_implicants, constituents);	

	return primary_implicants;
}

//метод верхнего уровня, рекурсивная функция, формирующая список первичных импликант
list<string> quaine_optimizer::find_primary_implicants(list<string> constituents)
{
	list<string> primary_implicants, result;
	list<string>::iterator iter;
	vector<list<string> > chart;
	vector<list<string> >::iterator prev, next;
	string tmps;
	int n;
		
	//проверяем условие выхода из рекурсии
	if(constituents.empty()) return primary_implicants;

	//получаем новую таблицу сгруппированных конституент, очищаем конст-ты для новых данных
	chart = group_constituents(constituents);
	constituents.clear();

	//цикл по группам
	for(vector<list<string> >::iterator it = chart.begin(); it != chart.end(); ++it)
	{
		if( (*it).empty() ) continue;
		if( it != chart.begin() ) prev = it - 1;
		if( it != chart.end() ) next = it + 1;


		for(list<string>::iterator itc = (*it).begin(); itc != (*it).end(); ++itc)
		{
			//запоминаем размер вектора новых конституент, чтобы выяснить позже,
			n = constituents.size();
			
			if( it != chart.begin() )
				for(list<string>::iterator itp = (*prev).begin(); itp != (*prev).end(); ++itp)
				{
					tmps = combine_constituents(*itc, *itp);
					if(tmps != "")
						constituents.push_back(tmps);
				}

			if( it != chart.end() )
				if(next != chart.end())
					for(list<string>::iterator itn = (*next).begin(); itn != (*next).end(); ++itn)
					{
						tmps = combine_constituents(*itc, *itn);
						if(tmps != "")
							constituents.push_back(tmps);
					}

			//если склеиваний не было, пишем терм в primary_implicants
			if(n == constituents.size()) 
				primary_implicants.push_back(*itc);

		}//цикл по членам группы
	}//цикл по группам

	//убираем повторения - можно заменить на constituents.unique(), задав предикат
	for(list<string>::iterator i = constituents.begin(); i != constituents.end(); ++i)
		for(list<string>::iterator j = i; j != constituents.end(); ++j)
		{
			//если у нас остался один терм, нет смысла что-то делать
			if (constituents.size() == 1) continue;

			//нет оператора + для итератора списка, так что нельзя написать j = i + 1,
			//а написать j = ++i значило бы ненамеренно сдвинуть и итератор i,
			//так что приходится выкручиваться следующим образом
			if(j == i) j++;

			//в случае, если в нашем списке есть совпадения, удаляем более позднюю конституанту
			if( (*i) == (*j) )
			{
				constituents.erase( *(new list<string>::const_iterator(j)) );
				j = i;
			}
		}

	//рекурсия
	result = find_primary_implicants(constituents);

	for(iter = result.begin(); iter != result.end(); ++iter)
		primary_implicants.push_back(*iter);

	return primary_implicants;
}

//на основе полученных в find_primary_implicants() импликант строится матрица
//и по ней вычисляется совокупность простых импликант, соответствующая минимальной ДНФ 
list<string> quaine_optimizer::optimize_via_implicant_matrix(list<string> primary_implicants, list<string> constituents)
{
	vector<vector<int> > implicant_matrix;
	vector<int> row;
	list<string> new_primary_implicants;
		
	//создаём импликантную матрицу
	for(list<string>::iterator it = primary_implicants.begin(); it != primary_implicants.end(); ++it)
	{
		row.clear();
		row.push_back(-1); //для учёта нужных простых импликант

		for(list<string>::iterator it1 = constituents.begin(); it1 != constituents.end(); ++it1)
			row.push_back( absorbs(*it, *it1) );

		implicant_matrix.push_back(row);
	}

	//найдём ядро: hor_shift - номер столбца(#0 - для учёта, не берется), it - текущая строка
	//             ver_shift - номер строки, iter - текущий int-флаг
	for(unsigned int hor_shift = 1; hor_shift < row.size(); ++hor_shift)
	{
		vector<vector<int> >::iterator it;
		vector<int>::iterator iter;
		int n = 0, ver_shift;

		for(it = implicant_matrix.begin(); it != implicant_matrix.end(); ++it)
		{
			iter = (*it).begin() + hor_shift;
			if(*iter == 1) 	{ ++n; ver_shift = it - implicant_matrix.begin();}
		}

		if(n == 1) 
		{
			it = implicant_matrix.begin() + ver_shift;
			iter = (*it).begin();
			*iter = 1;
		}
	}

	//ищем покрытие (жолжно быть минимальным по числу и длине термов)
	int n_of_nonkernel_implicants = 0;
	while(!implicant_matrix_covered(implicant_matrix))
	{
		++n_of_nonkernel_implicants;
		try_cover_implicant_matrix(&implicant_matrix, n_of_nonkernel_implicants);
	}

	//выбираем и возвращаем только импликанты, входящие в покрытие
	for(vector<vector<int> >::iterator it = implicant_matrix.begin(); it != implicant_matrix.end(); ++it)
	{
		if( (*(*it).begin()) == 1)
		{
			list<string>::iterator iter = primary_implicants.begin();

			for(int i = 0; i < (it - implicant_matrix.begin()); ++i) iter++;
				
			new_primary_implicants.push_back(*iter);
		}
	}

	return new_primary_implicants;
}

//группирует конституенты по признаку количества единиц
vector<list<string> > quaine_optimizer::group_constituents (list<string> constituents)
{
	vector<list<string> > chart;
	int i, n;

	if(constituents.empty()) return chart;

	n = (*constituents.begin()).size();
	chart.resize(n+1);

	for(list<string>::iterator it = constituents.begin(); it != constituents.end(); ++it)
	{
		i = count_unities(*it);
		
		chart[i].push_back(*it);
	}

	return chart;
}

//пытается склеить строки source и another
//в случае успеха возвращает склеенную строку, иначе - пустую
string quaine_optimizer::combine_constituents(string source, string another)
{
	int diffs = 0;
	string::iterator it1 = source.begin();
	string::iterator it2 = another.begin();
	string::iterator tmp = source.end();

	for(; it1 != source.end(); ++it1, ++it2)
		if(*it1 != *it2) { diffs++;	tmp = it1;}

	if(diffs == 1) { *tmp = '*'; return source;}

	return "";
}

//возвращает 1, если implicant поглощает term, иначе - 0
bool quaine_optimizer::absorbs(string implicant, string term)
{
	string::iterator it1, it2;

	for(it1 = implicant.begin(), it2 = term.begin(); it1 != implicant.end(); ++it1, ++it2)
		if( !((*it1 == *it2) || (*it1 == '*')) ) return 0;

	return 1;
}

//рекурсивно пытаемся покрыть матрицу ядром + n_of_nonkernel_implicants внеядерными импликантами
bool quaine_optimizer::try_cover_implicant_matrix(vector<vector<int> >* implicant_matrix, int n_of_nonkernel_implicants)
{	
	vector<vector<int> > new_implicant_matrix = *implicant_matrix;

		//перебираем все возможные покрытия +1-м элементом, число необходимых "свободных" импликант >= 1
		for(vector<vector<int> >::iterator it = new_implicant_matrix.begin(); it != new_implicant_matrix.end(); ++it)
		{
			//добавляем в покрытие +1 импликанту, далее проверяем покрытость в базовом и рекурсивном случаях
			(*(*it).begin()) = 1;

			//окончание рекурсии: если ищется лишь 1 "свободная" импликанта, не вызываем новую try_cover_implicant_matrix
			if(n_of_nonkernel_implicants == 1)
			{
				if( implicant_matrix_covered(new_implicant_matrix) )
					break;
			}
			
			//продолжение рекурсии
			else 
			{
				try_cover_implicant_matrix(&new_implicant_matrix, n_of_nonkernel_implicants - 1);
				if( implicant_matrix_covered(new_implicant_matrix) )
					break;
			}

			//данная импликанта при добавлении не создала полного покрытия, убираем её и продолжаем перебор
			(*(*it).begin()) = 0;
		}

	//проверяем, создано ли покрытие, возвращаем результат
	if( implicant_matrix_covered(new_implicant_matrix) ) 
	{
		*implicant_matrix = new_implicant_matrix;
		return 1;
	}
	return 0;
}

//считает число единиц в строке
int quaine_optimizer::count_unities(string binary)
{
	//i=-1, чтобы сработал верно первый find()
	//n=-1, потому что иначе мы делаем n++ 1 лишний раз
	int i = -1, n = -1;

	do
	{
		i = binary.find('1', i+1);
		n++;
	}
	while(i != string::npos);

	return n;
}

//возвращает 1 если покрытие полно и 0 иначе
bool quaine_optimizer::implicant_matrix_covered(vector<vector<int> > implicant_matrix)
{
	vector<int> row;
	int n = 0;

	row.insert(row.begin(), (*implicant_matrix.begin()).size() - 1, 0);

	//проверяем, полно ли покрытие термов импликантами из ядра
	for(vector<vector<int> >::iterator it = implicant_matrix.begin(); it != implicant_matrix.end(); ++it)
	{
		if( (*(*it).begin()) != 1 ) continue; //если данная импликанта не из ядра, пропускаем её

		for(unsigned int hor_shift = 1; hor_shift <= row.size(); ++hor_shift)
			if( *((*it).begin() + hor_shift) == 1) row[hor_shift - 1] = 1;
	}

	for(vector<int>::iterator it = row.begin(); it != row.end(); ++it)
		if((*it) == 1) ++n;

	if(n == row.size()) return 1;
	else return 0;
}
