#include <stdio.h>
#include <iostream>
#include "counting.h"
#include "list.h"

using namespace std;

int removeListWhenElementMoreOne(List *list, int numberDie)
{
	ListElement *positionTemp = head(list);
	if (head(list) == nullptr)
		return -2;
	while (next(positionTemp) != positionTemp)
	{
		for (int i = 0; i < numberDie - 1; i++)
			positionTemp = next(positionTemp);
		Position positionBeforeDelete = positionTemp;
		if (next(next(positionTemp)) == positionTemp)
		{
			positionTemp = next(positionTemp);
			deleteElement(list, next(positionTemp));
			print(list);
			break;
		}
		positionTemp = (next(positionTemp));
		deleteElement(list, positionBeforeDelete);
		print(list);
	}
	return value(positionTemp);
}

