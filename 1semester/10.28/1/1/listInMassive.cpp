#include "listInMassive.h"
#include <iostream>

using namespace std;

namespace listInMassive
{
	bool equals(ElementType value1, ElementType value2)
	{
		return (value1 == value2);
	}

	struct List
	{
		int last;
		ElementType value[100];
	};

	List *create()
	{
		List *result = new List;
		for (int i = 0; i < 100; i++)
			result->value[i] = -1;
		result->last = 0;
		return result;
	}

	Position createListElement(List *list, ElementType value)
	{
		list->value[0] = value;
	//	list->last++;
		return 0;
	}
	
	void addElement(List *list, ElementType value, Position position)
	{
		if (position == list->last)
		{
			list->value[position] = value;
			list->last++;
			return;
		}

		ElementType tempElementPrev = list->value[1];
		ElementType tempElement = tempElementPrev;
		for (int i = position + 1; i < list->last - 1; i++)
		{
			tempElement = list->value[i+1];
			list->value[i+1] = tempElementPrev;
			tempElementPrev = tempElement;
		}
		list->value[list->last] = tempElement;
			
		list->value[position + 1] = value;
		list->last++;
	}

	void addElementToHead(List *list, ElementType value)
	{
		for (int i = list->last; i > 0; i--)
			list->value[i] = list->value[i - 1];
		list->value[0] = value;
		list->last++;
	}

	void deleteElement(List *list, Position position)
	{
		if (position >= list->last) 
			return;
		if (list->last == 0)
			return;

		for (int i = position; i < list->last - 1; i++)
			list->value[i] = list->value[i+1];
		list->value[list->last - 1] = -1;
		list->last--;
	}

	void deleteList(List *list)
	{
		delete list;
	}

	Position positionOfElement(List *list, ElementType value)
	{
		for (int i = 0; i < list->last; i++)
			if (equals(value, list->value[i]))
				return i;
		return -1;
	}

	Position headListElement(List *list)
	{
		return 0;
	}

	Position nextListElement(Position element)
	{
		return element + 1;
	}
	
	ElementType valueListElement(List *list, Position element)
	{
		return list->value[element];
	}

	void nextElementDoElement(List *list, Position temp, Position next)
	{
		if (next >= list->last)
		{
			list->last = temp + 1;
		}
		else
			list->value[temp + 1] = next;
	}

	void print(List *list)
	{
		if (list == nullptr || list->last == 0)
		{
			cout << "empty list" << endl;
			return;
		}
		for (int i = 0; i < list->last; i++)
			cout << list->value[i] << " " ;
		cout << endl;
	}	

	int last(List *list)
	{
		return list->last;
	}

	Position endOfList(List *list)
	{
		if (list == nullptr)
			return 0;
		return list->last;
	}

	int lengthList(List *list)
	{
		return last(list);
	}
}

