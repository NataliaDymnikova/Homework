#pragma once
typedef char *ElementType;

namespace list
{
	struct List;
	struct ListElement;
	typedef ListElement *Position;
	// содание пустого списка.
	List *create();
	// добавление значения value после position в list.
	void insert(List *list, ElementType value, Position position);
	// добавление значения value в голову list.
	void insertToHead(List *list, ElementType value);
	// удаление list.
	void removeList(List *list);
	// удление элемента после position в list.
	void remove(List *list, Position position);
	//  возарщает позицию элемента value в list.
	Position positionOfElement(List *list, ElementType value);
	// печать list. 
	void print(List *list);

	// возвращает первый элемент list.
	Position first(List *list);
	// возвращает последний элемент list.
	Position end(List *list);
	// возвращает позицию после position в list.
	Position next(List *list, Position position);
	// возвращает значение на позиции position в list.
	ElementType valueOnPosition(List *list, Position position);
	// возвращает содержится ли value в list. если сожержиться, то увеличивается на 1 numExist у той позиции.
	bool exist(List *list, ElementType value);
}