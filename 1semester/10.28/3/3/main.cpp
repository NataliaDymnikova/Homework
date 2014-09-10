/* Test is Ok - 
			( + 1 1 )  =  2
			( + ( * 4 5 ) 1 )  =  21
			( - ( * 4 5 ) ( + 6 7 ) )  =  7


*/

#include "tree.h"
#include <iostream>
#include <stdio.h>
#include "math.h"

using namespace std;
using namespace tree;

int main()
{
	Tree *tree = create();

	createInFile(tree);
	print(tree);

	cout << math(tree) << "\n";
	remove(tree);
	return 0;
}
