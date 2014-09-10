#pragma once

typedef int ElementType;

struct List;
struct ListElement;
//typedef ListElement *Position;

// создание списка.
List *create();
// добавление нового элемента value в список list.
void insert(List *list, ElementType value);
// добавление нового элемента value в начало списка list.
void insertToHead(List *list, ElementType value);
// удаление элемента из списка list со значением value.
void remove(List *list, ElementType value);
// печать списка list.
void print(List *list);
// удаление списка list.
void deleteList(List *list);
// рекурсивное удаление всех элементов.
void deleteListElement(ListElement *listElement);

