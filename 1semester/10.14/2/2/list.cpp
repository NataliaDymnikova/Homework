#include <stdio.h>
#include <iostream>
#include "list.h"

using namespace std;

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
	result->head = NULL;
	return result;
}

void insert(List *list, ElementType value)
{
	ListElement *listToPut = list->head;
	if (listToPut == NULL || value < listToPut->value)
	{
		insertToHead(list, value);
		return;
	}
	while (listToPut->next != NULL && value > listToPut->next->value)
		listToPut = listToPut->next;
	ListElement *newElement = new ListElement;
	newElement->value = value;
	newElement->next = listToPut->next;
	listToPut->next = newElement; 
}

void insertToHead(List *list, ElementType value)
{
	ListElement *newElement = new ListElement;
	newElement->value = value;
	newElement->next = list->head;
	list->head = newElement;
}

void remove(List *list, ElementType value)
{
	ListElement *listToPut = list->head;
	if (listToPut == NULL)
		return;
	if (value == listToPut->value)
	{	
		list->head = listToPut->next;
		delete listToPut;
		return;
	}
	while (listToPut->next != NULL && value != listToPut->next->value)
		listToPut = listToPut->next;
	if (listToPut->next == NULL)
	{
		cout << "Error! don't have this element" << endl;
		return;
	}
	ListElement *temp = listToPut->next;
	listToPut->next = temp->next;
	delete temp;
}

void print(List *list)
{
	ListElement *positionTemp = list->head;
	while(positionTemp != NULL)
	{
		cout << positionTemp->value << " ";
		positionTemp = positionTemp->next;
	}
	cout << endl;
}

void deleteListElement(ListElement *listElement)
{
	if (listElement->next != NULL)
		deleteListElement(listElement->next);
	delete listElement;
}

void deleteList(List *list)
{	
	if (list->head != NULL)
		deleteListElement(list->head);
	delete list;
}