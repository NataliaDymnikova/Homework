#pragma once

typedef int ElementType;
//typedef int Position;

namespace listInMassive
{
	typedef int Position;
	struct List;
	
	// создание списка.
	List *create();
	// создание элемента списка со значением value;
	Position createListElement(List *list, ElementType value);
	// добавление элемента value после position.
	void addElement(List *list, ElementType value, Position position);
	// добавление элемента value в голову list. 
	void addElementToHead(List *list, ElementType value);
	// удаление элемента после position.
	void deleteElement(List *list, Position position);
	// удвление всего list.
	void deleteList(List *list);
	// возвраает позицию эленмта value в list.
	Position positionOfElement(List *list, ElementType value);
	// возвращает head у list.
	Position headListElement(List *list);
	// возвращает next у element.
	Position nextListElement(Position element);
	// возвращает value у element.
	ElementType valueListElement(List *list, Position element);
	// сделать следующий элемент после temp элементом next.
	void nextElementDoElement(List *list, Position temp, Position next);
	// печать list.
	void print(List *list);
	// возвращает list->last - длинну списка.
	int last(List *list);
	// эелемент, обозначащий конец списка.
	Position endOfList(List *list);	
	// возвращает количество элементов list.
	int lengthList(List *list);
}