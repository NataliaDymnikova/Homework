#include "list.h"
#include <stdio.h>
#include <iostream>

using namespace std;
bool equals(ElementType a, ElementType b)
{
	return strcmp(a,b);
}

namespace list
{
	struct ListElement
	{
		char value[100];
		int numExist;
		ListElement *next;
	};

	struct List 
	{
		ListElement *head;
	};

	List *create()
	{
		List *result = new List;
		result->head = nullptr;
		return result;
	}

	void insert(List *list, ElementType value, Position position)
	{
		ListElement *newElement = new ListElement;
		strcpy(newElement->value, value);
		newElement->next = position->next;
		newElement->numExist = 1;
		position->next = newElement;
	}

	void insertToHead(List *list, char value[])
	{
		ListElement *newElement = new ListElement;
		strcpy(newElement->value, value);
		newElement->next = list->head;
		newElement->numExist = 1;
		list->head = newElement;
	}

	void removeList(List *list)
	{
		ListElement *position = list->head;
		while (position != nullptr)
		{
			ListElement *temp = position;
			position = position->next;
			delete temp;
		}
		delete list;
	}

	void remove(List *list, Position position)
	{
		if (position == nullptr) 
		{
			cout << "Error" << endl;
			return;
		}
		Position temp = position;
		if (position == list->head)
			list->head = list->head->next;
		else
		{
			position = list->head;
			while (position->next != temp)
				position = position->next;
			position->next = temp->next;
		}
		delete temp;
	}

	Position positionOfElement(List *list, ElementType value)
	{
		Position position = list->head;
		while (position != nullptr)
		{
			if (equals(position->value, value))
				return position;
			else
			{
				position = position->next;
			}
		}
		return nullptr;
	}


	bool exist(List *list, ElementType value)
	{
		ListElement *position = list->head;
		while (position != nullptr)
		{
			if (!equals(position->value, value))
			{
				position->numExist++;
				return true;
			}
			else
				position = position->next;
		}
		return false;
	}


	void print(List *list)
	{
  		Position positionTemp = list->head;
		while (positionTemp != nullptr)
  		{
			cout << positionTemp->value << " - " << positionTemp->numExist << "\n";
  			positionTemp = positionTemp->next;
  		}
	 }

	Position first(List *list)
	{
		return list->head;
	}

	Position end(List *list)
	{
		return nullptr;
	}
	Position next(List *list, Position position)
	{
		return position->next;
	}
	ElementType valueOnPosition(List *list, Position position)
	{
		return position->value;
	}
}