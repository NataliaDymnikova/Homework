#include "list.h"
#include <iostream>

using namespace std;

bool equals(ElementType value1, ElementType value2)
{
	return (value1 == value2);
}

namespace list
{
	struct ListElement
	{
		ElementType value;
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

	Position createListElement(List *list, ElementType value)
	{
		ListElement *temp = new ListElement;
		temp->value = value;
		temp->next = nullptr;
		return temp;
	}

	void addElement(List *list, ElementType value, Position position)
	{
		ListElement *temp = new ListElement;
		temp->value = value;
		temp->next = position->next;
		position->next = temp;
	}

	void addElementToHead(List *list, ElementType value)
	{
		ListElement *temp = new ListElement;
		temp->value = value;
		temp->next = list->head;
		list->head = temp;
	}

	void deleteElement(List *list, Position position)
	{
		if (position == nullptr) 
			return;
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

	void deleteList(List *list)
	{
		if (list == nullptr)
			return;
		Position i = list->head;
		while (i != nullptr)
		{
			Position temp = i;
			i = i->next;
			delete temp;
		}
		delete list;
	}

	Position positionOfElement(List *list, ElementType value)
	{
		Position position = list->head;
		while (position != nullptr)
		{
			if (equals(position->value, value))
				return position;
			else
				position = position->next;
		}
		return nullptr;
	}

	ListElement *headListElement(List *list)
	{
		return list->head;
	}

	ListElement *nextListElement(ListElement *element)
	{
		return element->next;
	}

	ElementType valueListElement(List *list, ListElement *element)
	{
		return element->value;
	}

	void nextElementDoElement(List *list, Position temp, Position next)
	{
		if (next != nullptr)
			next->next = temp->next;
		temp->next = next;
	}

	void print(List *list)
	{
		if (list == nullptr || list->head == nullptr)
		{
			cout << "empty list" << endl;
			return;
		}
		Position temp = list->head;
		while (temp != nullptr)
		{
			cout << temp->value << " " ;
			temp = temp->next;
		}
		cout << endl;
	}	

	Position endOfList(List *list)
	{
		return nullptr;
	}

	int lengthList(List *list)
	{
		int i = 0;
		Position temp = headListElement(list);
		while (temp != NULL)
		{
			i++;
			temp = nextListElement(temp);
		}
		return i;
	}
}