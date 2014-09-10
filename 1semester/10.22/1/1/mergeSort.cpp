#include <stdio.h>
#include <string.h>
#include "list.h"
#include "mergeSort.h"

int lengthList(List *list)
{
	int i = 0;
	Position temp = headList(list);
	while (temp != NULL)
	{
		i++;
		temp = nextListElement(temp);
	}
	return i;
}

bool isFirstMax(ListElement *first, ListElement *second, bool valueIsTelephone)
{
	if (valueIsTelephone)
		return telephoneListElement(first) > telephoneListElement(second);
	char *name1 = nameElement(first);
	char *name2 = nameElement(second);
	return (strcmp(name1, name2) > 0);
}

List *mergeSort(List *list, bool value)
{
	int length = lengthList(list);
	if (length <= 1)
		return list;
	
	// разбиение листа на два.
	List *leftListTemp = makeList(headList(list));
	ListElement *temp = headList(leftListTemp);	
	for (int i = 0; i < length / 2 - 1; i++)
		temp = nextListElement(temp);
	List *rightListTemp = makeList(nextListElement(temp));
	nextElementDoElement(temp, NULL);
	previousElementDoNULL(headList(rightListTemp));
	
	List *leftList = mergeSort(leftListTemp, value);
	List *rightList = mergeSort(rightListTemp, value);
	
	deleteList(list);
	
	// создание нового листа из двух частей. само слияние.
	ListElement *right = headList(rightList);
	ListElement *left = headList(leftList);
	ListElement *res = NULL;
	ListElement *resultNext = NULL;
	while (left != NULL && right != NULL)
	{
		if (isFirstMax(left, right, value))
		{
			if (res == NULL)
			{
				res = right;
				right = nextListElement(right);
				continue;
			}
			res = doNextElement(res, right);
			resultNext = nextListElement(res);
			resultNext = doPreviousElement(resultNext, res);
			res = resultNext;
			right = nextListElement(right);
		}
		else
		{		
			if (res == NULL)
			{
				res = left;
				left = nextListElement(left);
				continue;
			}

			res = doNextElement(res, left);
			resultNext = nextListElement(res);
			resultNext = doPreviousElement(resultNext, res);
			res = resultNext;
			left = nextListElement(left);
		}
	}

	while (left != NULL)
	{
		doNextElement(res, left);
		resultNext = nextListElement(res);
		doPreviousElement(resultNext, res);
		res = resultNext;
		left = nextListElement(left);
	}
	while (right != NULL)
	{
		doNextElement(res, right);
		resultNext = nextListElement(res);
		doPreviousElement(resultNext, res);
		res = resultNext;
		right = nextListElement(right);
	}
	
	while (previousListElement(res) != NULL)
		res = previousListElement(res);
	List *result = makeList(res);

	deleteList(leftListTemp);
	deleteList(rightListTemp);
		
	return result;
}
