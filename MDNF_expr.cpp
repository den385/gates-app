#include "expr.h"
#include <stdio.h>

//recursive function used in constructor
expr expr::rec_expr(csv_string s)
{
  string brackets, types;
	int n = 0;
	int flag = 0;
	int j = 0;
	expr* ex = new expr();

	//while delimeter is not found
	while(flag == 0)
	{
		//fill brackets and types for further analysis
		for(int i=0; i<s.size();i++)
		{
			switch ( (s.to_string())[i] )
			{
			case '(': n++; brackets = brackets + to_string((long long) n); types = types + 'b'; break;
			case ')': n--; brackets = brackets + to_string((long long) n); types = types + 'b'; break;
			case '~': case '&': case'|': brackets = brackets + to_string((long long) n); types = types + 'o'; break;
			case '0': case '1': case '2': case '3': case '4':
			case '5': case '6': case '7': case '8': case '9': 
			case 'x': brackets = brackets + to_string((long long) n); types = types + 'v'; break;
			}
		}
	
		//find separator || trim brackets
		for(j=0;j<s.size();j++)	
		{
			if ( (brackets[j] == '0') && (types[j] == 'o')) 
				break;
			else if ( (brackets[j] == '0') && (types[j] == 'v') )
				if(types.find("o") == types.npos)
					break;
		}
		if(j < s.size()) flag = 1;
		else 
		{
				csv_string tmp = csv_string( s.to_string().substr(1, s.size()-2) );
				s = tmp;
				brackets.clear();
				types.clear();
		}
	}
	
	//fill in fields and do recursion
	//varname contains name of a var for VAR and expression-string for EXPR
	ex->varname = s.to_string();
	switch ( (s.to_string())[j] )
	{
	case '&': ex->type = EXPR; ex->optype = AND; ex->args.push_back( rec_expr(s.sep(j)[0]) ); ex->args.push_back( rec_expr(s.sep(j)[1]) ); break;
	case '~': ex->type = EXPR; ex->optype = NOT; ex->args.push_back( rec_expr(s.sep(j)[1]) ); break;
	case '|': ex->type = EXPR; ex->optype = OR; ex->args.push_back( rec_expr(s.sep(j)[0]) ); ex->args.push_back( rec_expr(s.sep(j)[1]) ); break; 
	case 'x': ex->type = VAR; ex->optype = IN; break;
	}

	return(*ex);
}
//constructor by csv_string
expr::expr(csv_string s)
{
	string out_str;
	out_str = (s.csv_split(" "))[0].to_string();
	s = (s.csv_split(" "))[2];
	//building an expr with out_str string
	varname = out_str;
	type = VAR;
	optype = OUT;
	args.push_back(rec_expr(s));
}
//blank c-r
expr::expr()
{

}
//prints expr parameters to cout
void expr::print()
{
	cout << type << " " << optype << endl;
	if((type == EXPR)&&(optype != NOT)) 
	{	
		args[0].print();
		cout << endl;
		args[1].print();
		cout << endl;
	}
	else if((type == EXPR)&&(optype == NOT))
	{
		args[0].print();
		cout << endl;
	}
	else cout << varname << endl;
}
