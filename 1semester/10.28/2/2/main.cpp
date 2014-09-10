/* Test is Ok - 
			add element - 4 2 3 1 6 5,
			print min to max, max to min,
			exist - 2 - yes
			delete - 2,
			exist - 2 - no,
			delete - 2 - can't delete.
*/

#include <iostream>
#include "tree.h"

using namespace std;
using namespace tree;

int main()
{
	Tree *tree = create();
	int whatDo = -1;
	while (whatDo != 0)
	{
		cout << endl << "0 - exit" << endl << "1 - add element" << endl << "2 - delete element" 
			        << endl << "3 - exist element" << endl << "4 - print" << endl;
		cin >> whatDo;
		if (whatDo == 1)
		{
			ElementType value = 0;
			cout << "Eneter number to add:" << endl;
			cin >> value;
			addElement(tree, value);
		}
		if (whatDo == 2)
		{
			ElementType value = 0;
			cout << "Eneter number to delete:" << endl;
			cin >> value;
			deleteElement(tree, value);
		}
		if (whatDo == 3)
		{
			ElementType value = 0;
			cout << "Eneter number to exist:" << endl;
			cin >> value;
			if (existElement(tree, value))
				cout << value << " - is exist" << endl;
			else
				cout << value << " - is not exist" << endl;	
		}
		if (whatDo == 4)
		{
			bool isMinToMaxPrint = true;
			cout << "0 - max to min" << endl << "1 - min to max" << endl;
			cin >> isMinToMaxPrint;
			print(tree, isMinToMaxPrint);
		}
	}
	remove(tree);
	return 0;
}