#pragma once

typedef int ElementType;
struct ListElement;
typedef ListElement *Position;
struct List;

// создание списка.
List *createList(int number);

// добавление элемента value после position.
void addElement(List *list, ElementType value, Position position);

// добавление элемента value в голову list.
void addElementToHead(List *list, ElementType value);

// удаление элемента position в list.
void deleteElement(List *list, Position position);

// удвление всего list.
void deleteList(List *list);

// возвращает позицию эленмта value в list.
Position positionOfElement(List *list, ElementType value);

// возвращает head у list.
ListElement *head(List *list);

// возвращает next у element.
ListElement *next(ListElement *element);

// возвращает value у element.
ElementType value(ListElement *element);

// печать на экран list.
void print(List *list);

