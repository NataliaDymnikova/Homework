/* Test is Ok - 
		1)	file = NULL;
		2)	aaa - 111
			ccc - 333
			eee - 222
			e - 101
			bbb - 444
*/

#include <stdio.h>
#include <iostream>
#include "list.h"
#include "mergeSort.h"

using namespace std;

int main()
{
	FILE *file = fopen("file.txt", "r");
	List *list = createList(file);
	if (headList(list) == NULL)
	{
		cout << "can't open the file" << endl;
		return 0;
	}
	fclose(file);
	
	print(list);
	bool whatDo = true;
	cout << "0 - sort name" << endl << "1 - sort telephone" << endl;
	cin >> whatDo;
	list = mergeSort(list, whatDo);
	print(list);
	
	removeList(list);
	printMemory();
	return 0;
}
