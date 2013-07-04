#include "gate_buffer.h"

// Return whether first element is greater than the second, for gate_buffer
bool UDgreater (csv_string s1, csv_string s2)
{
  int s1_lvl = stoi( (s1.split(" "))[4] );
	int s2_lvl = stoi( (s2.split(" "))[4] );
	return (s1_lvl < s2_lvl);
}

//add levels to csv_strings in buffer: 1) calc.level; 2) add level
void gate_buffer::define_levels()
{
	vector<set<int> > layers;
	int n_defined = 0;
	vector<int> flags(this->size(), 0);

	//while not all csv_strings were rewritten	
	while(n_defined < this->size())
	{
		for(int i=0;i<this->size();i++)
		{
			//the string is enter-gate and wasn`t rewritten yet (flags[i]!=1)
			if( (buf[i].to_string().find(">", 0) != string::npos) && (flags[i] != 1) )
			{				
				if(layers.empty()) layers.push_back( set<int>() );
				layers[0].insert( stoi((buf[i].split(" "))[0]) );
				n_defined++;
				flags[i] = 1;
				//write lvl = 0 to the end of the string
				buf[i] = csv_string(buf[i].to_string() + " 0");
			}
			
			//the string is dependent-gate and wasn`t rewritten yet
			else if(flags[i] != 1)
			{
				int dep1 = stoi((buf[i].split(" "))[1]);				
			  int dep2 = stoi((buf[i].split(" "))[2]);
			  int dep1_l = -1; 
				int dep2_l = -1;

				if(dep1==0) dep1_l=0;
				if(dep2==0) dep2_l=0;

			  for(unsigned int j=0;j<layers.size();j++)
			  {
				  if ( layers[j].find(dep1) != layers[j].end() ) dep1_l = j;
				  if ( layers[j].find(dep2) != layers[j].end() ) dep2_l = j;
				}

				if ((dep1_l>=0) && (dep2_l>=0)) 
				{
					int tmp_lvl = -2;

					tmp_lvl = max(dep1_l, dep2_l) + 1;
					
					if(layers.size()<tmp_lvl+1) 
						layers.push_back( set<int>() );
				  
					layers[tmp_lvl].insert( stoi((buf[i].split(" "))[0]) );
				  n_defined++;
				  flags[i] = 1;
					buf[i] = csv_string(buf[i].to_string() + " " + to_string((long long)tmp_lvl));
				}
				
			}//else ends 

		}//for ends

	}//while ends

}
//sort buffer of csv_strings by levels, uses algorithm 'sort' from <alorithms>
void gate_buffer::UDsort()
{
	sort(buf.begin(), buf.end(), UDgreater);
}
