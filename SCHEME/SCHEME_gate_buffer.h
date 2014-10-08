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

#include "csv_buffer.h"

//*********************************************************
//csv_buffer + method to define levels of gates in buffer
//           + method to sort buffer by levels of gates      
//*********************************************************
class gate_buffer : public csv_buffer
{
public:
  gate_buffer(istream& stream) : csv_buffer(stream) {this->define_levels(); this->UDsort();}
private:
	void define_levels();
	void UDsort();
};
