#include <stdio.h>
#include <iostream>
#include "list.h"

int memoryElement = 0;
int memoryList = 0;

using namespace std;


#include <stdio.h>
#include <iostream>
#include "list.h"
#include "mergeSort.h"

using namespace std;

enum Element { name, telephone };

struct ElementType
{
	char name[20];
	int telephone;
};

struct ListElement
{
	ElementType value;
	ListElement *next;
	ListElement *previous;
};

struct List
{
	ListElement *head;
};

List *create()
{
	List *result = new List;
	memoryList++;
	result->head = NULL;
	return result;
}

List *createList(FILE *file)
{
	List *result = create();
	if (file == NULL)
		return result;
	ListElement *element = new ListElement;
	memoryElement++;
	result->head = element;
	element->previous = NULL;
	element->next = NULL;
	char ch = fgetc(file);
	while (ch != EOF)
	{
		int i = 0;
		while (ch != ' ')
		{
			element->value.name[i] = ch;
			i++;
			ch = fgetc(file);
		}
		element->value.name[i] = 0;	
		if (ch == ' ')
		{
			ch = fgetc(file);  // ch = '-'
			ch = fgetc(file);  // ch = ' '
		}
		else
		{
			cout << "error in file" << endl;
			return result;
		}
		fscanf(file, "%i", &element->value.telephone);
		element->next = NULL;
		ch = fgetc(file);
		if (ch == '\n')
			ch = fgetc(file);
		if (ch != EOF)
		{
			element->next = new ListElement;
			memoryElement++;
			element->next->previous = element;
			element = element->next;
			element->next = NULL;
		}
	}
	return result;
}

ListElement *headList(List *list)
{
	return list->head;
}

ListElement *nextListElement(ListElement *element)
{
	return element->next;
}

ListElement *previousListElement(ListElement *element)
{
	return element->previous;
}

ElementType valueListElement(ListElement *element)
{
	return element->value;
}

int telephoneListElement(ListElement *element)
{
	return element->value.telephone;
}

char *nameElement(ListElement *element)
{
	return element->value.name;
}

void nextElementDoElement(ListElement *element, ListElement *nextElement)
{
	element->next = nextElement;
}

void previousElementDoNULL(ListElement *element)
{
	element->previous = NULL;
}

List *makeList(ListElement *element)
{
	List *newList = new List;
	memoryList++;
	newList->head = element;
	return newList;
}


ListElement *doNextElement(ListElement *element, ListElement *next)
{
	ListElement *temp = next;
	element->next = temp;
	return element;
}

ListElement *doPreviousElement(ListElement *element, ListElement *previous)
{
	element->previous = previous;
	return element;
}

void print(List *list)
{
	if (list == NULL || list->head == NULL)
	{
		cout << "list is empty" << endl;
		return;
	}
	Position positionTemp = list->head;
	while(positionTemp != NULL)
	{
		cout << positionTemp->value.name << " - " << positionTemp->value.telephone << endl;
		positionTemp = positionTemp->next;
	}
	cout << endl;
}

void removeList(List *list)
{
	Position i = list->head;
	while (i != NULL)
	{
		Position temp = i;
		i = i->next;
		delete temp;
		memoryElement--;
	}
	deleteList(list);
}

void deleteList(List *list)
{
	delete list;
	memoryList--;
}

void printMemory()
{
	cout << "memoryList - " << memoryList << endl << "memoryElement - " << memoryElement << endl;
}

