/* Test is Ok - 
				number - 5, numManDie - 1
				number - 5, numManDie - 7
				number - 1, numManDie - 3
				number - 10, numManDie - 3
*/

#include <stdio.h>
#include <iostream>
#include "list.h"
#include "counting.h"

using namespace std;

int main()
{
	int number = 0;
	cout << "enter number all man - ";
	cin >> number;

	int numManDie = 0;
	cout << "enter number man, who die - ";
	cin >> numManDie;

	List *list = createList(number);
	print(list);
	cout << "the good position - " << removeListWhenElementMoreOne(list, numManDie) + 1 << endl;
	deleteList(list);
	return 0;
}