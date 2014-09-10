#pragma once

typedef int ElementType;

namespace tree
{
	struct ListElement;
	struct Tree;
	// создание пустого дерева.
	Tree *create();
	// удаление tree.
	void remove(Tree *tree);
	// добавление элемента value в tree.
	void addElement(Tree *tree, ElementType value);
	// печать tree.
	void print(Tree *tree);
	// создание tree из файла.
	void createInFile(Tree *tree);
	// возвращает голову tree.
	ListElement *route(Tree *tree);
	// возвращает правого ребенка у element.
	ListElement *right(ListElement *element);
	// возвращает левого ребенка у element.
	ListElement *left(ListElement *element);
	// возвращает значение element.
	ElementType value(ListElement *element);
}