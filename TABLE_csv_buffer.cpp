#include "stdafx.h"
#include "csv_buffer.h"

//does not set size for vector<string> buf, cause it`s unknown at this point
csv_buffer::csv_buffer(istream& stream)
{
  cursor = 0;
	string s;

	while( getline(stream, s) && s.compare("END") != 0 )
	{
		cursor++;
		if (s.length() > 0)
			buf.push_back(csv_string(s));
	}
	cursor = 0;
}
//sends 1 string from buf
csv_string csv_buffer::send()
{
	cursor++;
	if(cursor-1 < this->size()) return(buf[cursor-1]);
	else return(csv_string(""));
}
//move cursor 1 string back
void csv_buffer::goback()
{
 cursor--;
}
//returns number of strings in buffer
int csv_buffer::size()
{
 	return(buf.size());
}
//sets cursor=0
void csv_buffer::rewind()
{
	cursor = 0;
}
