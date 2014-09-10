#include <stdio.h>
#include <string.h>
#include "listInMassive.h"
#include "list.h"
#include "mergeSort.h"

//using namespace list;
using namespace listInMassive;


bool isFirstMax(Position first, Position second, List *listFirst, List *listSecond)
{
	return (valueListElement(listFirst, first) > valueListElement(listSecond, second));
}

List *mergeSort(List *list)
{
	int length = lengthList(list);
	if (length <= 1)
		return list;
	
	// разбиение листа на два.
	List *leftListTemp = create();
	addElementToHead(leftListTemp, valueListElement(list, headListElement(list)));
	Position tempLeft = headListElement(list);
	Position tempHeadLeft = headListElement(leftListTemp);
	Position temp = headListElement(list);	

	for (int i = 0; i < length / 2 - 1 && nextListElement(tempLeft) != endOfList(list); i++)
	{
		tempLeft = nextListElement(tempLeft);
		addElement(leftListTemp, valueListElement(list, tempLeft), tempHeadLeft);
		tempHeadLeft = nextListElement(tempHeadLeft);
		temp = nextListElement(temp);
	}

	List *rightListTemp = create();
	addElementToHead(rightListTemp, valueListElement(list, nextListElement(temp)));
	Position tempRight = nextListElement(temp);	
	Position tempHeadRight = headListElement(rightListTemp);
	
	while (nextListElement(tempRight) != endOfList(list))
	{
		tempRight = nextListElement(tempRight);
		addElement(rightListTemp, valueListElement(list, tempRight), tempHeadRight);
		tempHeadRight = nextListElement(tempHeadRight);
	}

	List *leftList = mergeSort(leftListTemp);
	List *rightList = mergeSort(rightListTemp);
	
	// создание нового листа из двух частей. само слияние.
	List *result = create();
	Position right = headListElement(rightList);
	Position left = headListElement(leftList);
	Position res = endOfList(result);
	//Position resultNext = endOfList(list);
	Position headRes = endOfList(result);
//	Position headResult = endOfList(result);
	while (left != endOfList(leftList) && right != endOfList(rightList))
	{
		if (isFirstMax(left, right, leftList, rightList))
		{
			if (res == endOfList(result))
			{
				addElementToHead(result, valueListElement(rightList, right));
				res = headListElement(result);
				right = nextListElement(right);
				continue;
			}
			addElement(result, valueListElement(rightList, right), res);
			res = nextListElement(res);
			right = nextListElement(right);
		}
		else
		{		
			if (res == endOfList(result))
			{
				addElementToHead(result, valueListElement(leftList, left));
				res = headListElement(result);
				left = nextListElement(left);
				continue;
			}
			addElement(result, valueListElement(leftList, left), res);
			res = nextListElement(res);
			left = nextListElement(left);
		}
	}

	while (left != endOfList(leftList))
	{
		addElement(result, valueListElement(leftList, left), res);
		res = nextListElement(res);
		left = nextListElement(left);
	}
	while (right != endOfList(rightList))
	{
		addElement(result, valueListElement(rightList, right), res);
		res = nextListElement(res);
		right = nextListElement(right);
	}

	deleteList(leftList);	
	deleteList(rightList);
	
	deleteList(list);	
	return result;
}
