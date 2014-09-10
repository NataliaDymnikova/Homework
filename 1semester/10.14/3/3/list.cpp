#include <stdio.h>
#include <iostream>
#include "list.h"

using namespace std;

typedef int ElementType;

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

List *createList(int number)
{
	if (number == 0)
		return create();
	List *result = create();
	addElementToHead(result, 0);
	ListElement *element = result->head;
	for (int i = 1; i < number; i++)
	{
		addElement(result, i, element);
		element = element->next;
	}
	element->next = result->head;
	return result;
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
	ListElement *newListElement = new ListElement;
	newListElement->value = value;
	newListElement->next = list->head;
	list->head = newListElement;
	Position temp = list->head;
	while (temp->next != nullptr)
		temp = temp->next;
	temp->next = list->head;
}

void deleteElement(List *list, Position position)
{
	Position tmp = list->head;
	while (tmp->next != position)
		tmp = tmp->next;
	position = tmp;

	if (position == nullptr) 
		return;
	Position temp = position->next;
	if (position->next == list->head)
	{
		Position temp2 = list->head;
		while (temp2->next != list->head)
			temp2 = temp2->next;
		temp2->next = list->head->next;
		list->head = list->head->next;
	}
	else
		position->next = position->next->next;
	delete temp;
}

void deleteList(List *list)
{
	Position i = list->head;
	if (i != nullptr)
	{
		while (i->next != list->head)
		{
			Position temp = i;
			i = i->next;
			delete temp;
		}
		delete i;
	}
	delete list;
}

Position positionOfElement(List *list, ElementType value)
{
	Position position = list->head;
	while (position->next != list->head)
	{
		if (position->value == value)
			return position;
		else
			position = position->next;
	}
	if (position->value == value)
		return position;
	return nullptr;
}

Position head(List *list)
{
	return list->head;
}

Position next(ListElement *element)
{
	return element->next;
}

ElementType value(ListElement *element)
{
	return element->value;
}

void print(List *list)
{
	if (list->head == nullptr)
	{
		cout << "list is empty" << endl;
		return;
	}
	Position temp = list->head;
	cout << temp->value + 1 << " ";
	temp = temp->next;
	while (temp != list->head)
	{
		cout << temp->value + 1 << " ";
		temp = temp->next;
	}
	cout << endl;
}
