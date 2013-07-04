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

//******************************************
//csv_string with a smart constructor
//which makes an sdnf-string from
//a vector of strings with variable-vectors
//******************************************
class terms_to_dnf : public csv_string
{
public:
  terms_to_dnf(list<string> terms);
};
