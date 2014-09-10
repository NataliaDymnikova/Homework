/* Test is Ok - 
				2 - 3 1
				4 - 1 2 3 4
				4 - 1 1 1 1
				5 - 3 2 1 5 4

	Чтобы переключать между списками на массивах и спискам на ссылках, 
	нунжо в mergeSort.cpp и main.cpp закомментировать один namespace и 
	раскоменнтировать другой.
*/

#include "listInMassive.h"
#include "list.h"
#include "mergeSort.h"
#include <iostream>

using namespace std;
//using namespace list;
using namespace listInMassive;

int main()
{
	List *list = create();
	cout << "Eneter number elements:" << endl;
	int num = 0;
	cin >> num;
	cout << "Eneter " << num << " numbers:" << endl;	
	for (int i = 0; i < num; i++)
	{
		int element;
		cin >> element;
		addElementToHead(list, element);
	}
	
	list = mergeSort(list);
	print(list);
	deleteList(list);
	return 0;
}