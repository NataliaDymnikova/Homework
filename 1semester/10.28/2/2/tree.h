#pragma once

typedef int ElementType;

namespace tree
{
	struct ListElement;
	struct Tree;

	// создание пустого списка.
	Tree *create();
	// удаление дерева tree.
	void remove(Tree *tree);
	// добавление элемента value в tree.
	void addElement(Tree *tree, ElementType value);
	// проверка содержится ли элемент value в tree.
	bool existElement(Tree *tree, ElementType value);
	// печать tree от меньшего к большему при isPrintIsLeft = true, и иначе при isPrintIsLeft = false.
	void print(Tree *tree, bool isPrintIsLeft);
	// удаление элемента value из дерева tree.
	void deleteElement(Tree *tree, ElementType value);
}