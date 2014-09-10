/* Test is Ok - 
				add - 1, 2, 5, 3, 4, 1, 2
				delete - 1, 5, 2, 2, 6, 1, 4, 3, 1
				print always.
*/

#include <stdio.h>
#include <iostream>
#include "list.h"

using namespace std;


int main()
{
	List *list = create();
	int whatDo = -1;
	while (whatDo)
	{
		cout << "0 - exit" << endl 
			<< "1 - add number" << endl 
			<< "2 - delete number" << endl 
			<< "3 - print" << endl;
		cin >> whatDo;
		if (whatDo == 1)
		{
			int newNum = 0;
			cout << "Enter number for add - " << endl;
			cin >> newNum;
			insert(list, newNum);
		}
		if (whatDo == 2)
		{
			int deleteNum = 0;
			cout << "Enter number for delete - " << endl;
			cin >> deleteNum;
			remove(list, deleteNum);
		}
		if (whatDo == 3)
		{
			print(list);
		}
		//print(list);
	}
	deleteList(list);
//	print(list);
	return 0;
}