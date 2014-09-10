#pragma once

struct List;
struct ListElement;
struct ElementType;
typedef ListElement *Position;

// создание списка.
List *create();
// создание списка из файла file.
List *createList(FILE *file);
// удаление списка list.
void removeList(List *list);

// голова списка list.
ListElement *headList(List *list);
// следующий элемент элемента element.
ListElement *nextListElement(ListElement *element);
// предыдущий элемент элемента element.
ListElement *previousListElement(ListElement *element);
// значение в элементе element.
ElementType valueListElement(ListElement *element);
// телефон element.
int telephoneListElement(ListElement *element);
// имя element.
char *nameElement(ListElement *element);

// сделать следующим элементом next.
ListElement *doNextElement(ListElement *element, ListElement *next);
// сделать предыдущим элементом previous.
ListElement *doPreviousElement(ListElement *element, ListElement *previous);

// сделать указатель на следующим элемент NULL. 
void nextElementDoElement(ListElement *element, ListElement *nextElement);
// сделать указатель на предыдущий элемент NULL.
void previousElementDoNULL(ListElement *element);
// сделать список с head element.
List *makeList(ListElement *element);

// печать списка list.
void print(List *list);

void deleteList(List *list);

void printMemory();
