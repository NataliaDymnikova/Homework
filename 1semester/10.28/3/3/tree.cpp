#include "tree.h"
#include <iostream>

using namespace std;

namespace tree
{
	struct ListElement
	{
		ElementType value;
		ListElement *right;
		ListElement *left;
	};

	struct Tree
	{
		ListElement *route;
	};

	Tree *create()
	{
		Tree *tree = new Tree;
		tree->route = nullptr;
		return tree;
	}

	void createInFileElement(FILE *file, ListElement *element, bool isLeft)
	{
		char ch = fgetc(file); //  '(' или цифра
		ListElement *newElement = new ListElement;
		newElement->left = nullptr;
		newElement->right = nullptr;
		if (ch == '(')
		{
			ch = fgetc(file);  // ' '
			ch = fgetc(file);  // операция
			newElement->value = int(ch);
			ch = fgetc(file);  // ' '
			createInFileElement(file, newElement, true);
			createInFileElement(file, newElement, false);
		}
		else
		{
			ungetc(ch, file);
			ElementType value = 0;
			fscanf(file, "%i", &value);
			newElement->value = value;
			ch = fgetc(file);  // ' '
		}
		if (!isLeft)
		{
			ch = fgetc(file);  // ' ) '
			ch = fgetc(file);  // ' '
		}

		if (isLeft)
			element->left = newElement;
		else
			element->right = newElement;
	}

	void createInFile(Tree *tree)
	{	
		FILE *file = fopen("file.in", "r");

		char ch = fgetc(file);  // '('
		ch = fgetc(file);  // ' '
		ch = fgetc(file);  // операция
		int value = int(ch);
		addElement(tree, value);
		ch = fgetc(file);  // ' '
		createInFileElement(file, tree->route, true);
		createInFileElement(file, tree->route, false);

		fclose(file);
	}

	void removeElement(Tree *tree, ListElement *treeElement)
	{
		if (treeElement == nullptr)
			return;

		ListElement *tempRight = treeElement->right;
		ListElement *tempLeft = treeElement->left;
		if (tempLeft != nullptr && tempLeft->left == nullptr && tempLeft->right == nullptr)
		{
			delete tempLeft;
			treeElement->left = nullptr;
		}
		else
			removeElement(tree, tempLeft);
		
		if (tempRight != nullptr && tempRight->left == nullptr && tempRight->right == nullptr)
		{
			delete tempRight;
			treeElement->right = nullptr;		
		}
		else
			removeElement(tree, tempRight);
	}

	void remove(Tree *tree)
	{
		while (tree->route->left != nullptr || tree->route->right != nullptr)
			removeElement(tree, tree->route);
		delete tree->route;
		delete tree;
	}
	
	void addElement(Tree *tree, ElementType value)
	{
		ListElement *temp = tree->route;
		ListElement *tempPrevious = temp;	
		while (temp != nullptr)
		{
			tempPrevious = temp;
			if (value == temp->value)
			{
				cout << "this element exist\n";
				return;
			}
			if (value > temp->value)
				temp = temp->right;
			else
				temp = temp->left;
		}
		temp = tempPrevious;
		ListElement *newElement = new ListElement;
		newElement->value = value;
		newElement->right = nullptr;
		newElement->left = nullptr;
		if (temp == nullptr)
		{
			tree->route = newElement;
			return;
		}
		if (value > temp->value)
			temp->right = newElement;
		else
			temp->left = newElement;
	} 

	void printElement(Tree *tree, ListElement *treeElement)
	{
		if (treeElement == nullptr)
			return;
		if ((treeElement->value == '+' || treeElement->value == '-' || 
			treeElement->value == '*' || treeElement->value == '/') && treeElement != tree->route)
			cout << "( ";
		printElement(tree, treeElement->left);
		if (treeElement->left == nullptr || treeElement->right == nullptr)
			cout << treeElement->value << "";
		else
			if (treeElement->value == '+')
				cout << " + ";
			else if (treeElement->value == '-')
				cout << " - ";
			else if (treeElement->value == '*')
				cout << " * ";
			else if (treeElement->value == '/')
				cout << " / ";
		printElement(tree, treeElement->right);
		if ((treeElement->value == '+' || treeElement->value == '-' || 
			treeElement->value == '*' || treeElement->value == '/') && treeElement != tree->route)
			cout << " )";
	}

	void print(Tree *tree)
	{
		if (tree->route == nullptr)
			cout << "Tree is empty" << endl;
		printElement(tree, tree->route);
		cout << endl;
	}

	ListElement *route(Tree *tree)
	{
		return tree->route;
	}

	ListElement *right(ListElement *element)
	{
		return element->right;
	}
	ListElement *left(ListElement *element)
	{
		return element->left;
	}
	ElementType value(ListElement *element)
	{
		return element->value;
	}

}
