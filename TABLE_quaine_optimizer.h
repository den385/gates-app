#pragma once
#include <vector>
#include <string>
#include <list>
using namespace std;

class quaine_optimizer
{
public:
  quaine_optimizer(void);

	static list<string> optimize(list<string> constituents);

	static list<string> find_primary_implicants(list<string> constituents);
	static list<string> optimize_via_implicant_matrix(list<string> primary_implicants, list<string> constituents);

	static vector<list<string> > group_constituents (list<string> constituents);
	static string combine_constituents(string source, string another);
	static bool absorbs(string implicant, string term);
	static bool try_cover_implicant_matrix(vector<vector<int> >* implicant_matrix, int n_of_nonkernel_implicants);

	static int count_unities(string binary);
	static bool implicant_matrix_covered(vector<vector<int> > implicant_matrix);
};

