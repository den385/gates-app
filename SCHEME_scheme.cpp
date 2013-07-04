#include "scheme.h"

//inline functions for calc method
inline int max(int a, int b)
{
  return ((a)>(b) ? (a) : (b));
}
inline int min(int a, int b)
{
	return ((a)<(b) ? (a) : (b));
}
inline int not(int a)
{
	return (1-a);
}

//empty constructor
scheme::scheme()
{

}
//push a gate gt into scheme`s level lvl
void scheme::push(gate& gt)
{
	while(sch.size() < (gt.lvl + 1)) sch.push_back( list<gate>() );
	sch[gt.lvl].push_back(gt);
}
//returns #id gate`s value
int scheme::find(int id)
{
	gate g;
	for( int i = (sch.size()-1); i>=0; i-- )
	{
		list<gate>::iterator Iter;
        for( Iter = sch[i].begin( ); Iter != sch[i].end( ); Iter++ )
			if ((*Iter).id == id) g = *Iter;
	}
	
	return(g.val);
}
//calculates the scheme
vector<gate> scheme::calc(vector<int>& v)
{
	list<gate>::iterator LIter;
	vector<int>::iterator VIter = v.begin();
	vector<gate> vg; 

	for( LIter = sch[0].begin(); LIter != sch[0].end(); LIter++ )
	{
		(*LIter).val = (*VIter); 
		VIter++;
	}

	for(int i=1;i<sch.size();i++)
	{
		for( LIter = sch[i].begin(); LIter != sch[i].end(); LIter++ )
		{
			//here smth happens with current gate - (*LIter)
			int d1 = (*this).find((*LIter).dep1);
			int d2 = -1;
			if((*LIter).dep2 != 0) d2 = (*this).find((*LIter).dep2);
			
			//cout << (*LIter).id << " " << d1 << " " << d2 << endl;

			switch ((*LIter).type)
			{
			case '&': (*LIter).val = min(d1, d2); break;
		    case '|': (*LIter).val = max(d1, d2); break;
			case '~': (*LIter).val = not(d1); break;	
			case '<': (*LIter).val = d1; vg.push_back(*LIter); break;
			default : (*LIter).val = -1; break;
	        }
		}
    }

	return(vg);
}
