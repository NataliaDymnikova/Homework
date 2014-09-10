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
		ListElement *root;
	};

	Tree *create()
	{
		Tree *tree = new Tree;
		tree->root = nullptr;
		return tree;
	}

	void removeAllElement(ListElement *treeElement)
	{
		if (treeElement == nullptr)
			return;

		ListElement *tempRight = treeElement->right;
		ListElement *tempLeft = treeElement->left;
		removeAllElement(tempRight);
		removeAllElement(tempLeft);
		delete treeElement;
	}

	void remove(Tree *tree)
	{
		removeAllElement(tree->root);
		delete tree;
	}
	
	void addElement(Tree *tree, ElementType value)
	{
		ListElement *temp = tree->root;
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
			tree->root = newElement;
			return;
		}
		if (value > temp->value)
			temp->right = newElement;
		else
			temp->left = newElement;
	}

	bool existElement(Tree *tree, ElementType value)
	{
		ListElement *temp = tree->root;
		while (temp != nullptr)
		{
			if (value == temp->value)
				return true;
			if (value > temp->value)
				temp = temp->right;
			else
				temp = temp->left;
		}
		return false;
	}

	void printElementLeft(Tree *tree, ListElement *treeElement)
	{
		if (treeElement == nullptr)
			return;
		printElementLeft(tree, treeElement->left);
		cout << treeElement->value << " ";
		printElementLeft(tree, treeElement->right);
	}

	void printElementRight(Tree *tree, ListElement *treeElement)
	{
		if (treeElement == nullptr)
			return;
		printElementRight(tree, treeElement->right);
		cout << treeElement->value << " ";
		printElementRight(tree, treeElement->left);
	}

	void print(Tree *tree, bool isPrintIsLeft)
	{
		if (tree->root == nullptr)
			cout << "Tree is empty" << endl;
		else if (isPrintIsLeft)
			printElementLeft(tree, tree->root);
		else
			printElementRight(tree, tree->root);
		cout << endl;
	}

	void deleteElement(Tree *tree, ElementType value)
	{
		ListElement *temp = tree->root;
		ListElement *tempPrevious = temp;	
		while (temp != nullptr)
		{
			if (value == temp->value)
				break;
			tempPrevious = temp;
			if (value > temp->value)
				temp = temp->right;
			else
				temp = temp->left;
		}
		if (temp == nullptr)
		{
			cout << "can't delete - element is not exist" <<endl;
			return;
		}
		
		// удаляем корень.
		if (temp == tree->root)
		{
			ListElement *deleteList = tree->root;
			ListElement *deleteTemp = deleteList->left;
			if (deleteTemp == nullptr)
				tree->root = temp->right;
			else
			{
				if (deleteTemp->right == nullptr)
				{
					tree->root->left->right = tree->root->right;
					tree->root = tree->root->left;
				}
				else
				{
					while (deleteTemp->right->right != nullptr)
						deleteTemp = deleteTemp->right;
					deleteTemp->right->right = tree->root->right;
					tree->root = deleteTemp->right;
					deleteTemp->right = deleteTemp->right->left;
					tree->root->left = temp->left;
				}
			}
			delete deleteList;
			return;
		}
		
		temp = tempPrevious;
		
		// если удаляем слева.
		if(temp->left != nullptr)
		{
			if (temp->left->value == value)
			{
				ListElement *deleteList = temp->left;
				ListElement *deleteTemp = deleteList->left;
				if (deleteTemp == nullptr)
					temp->left = temp->left->right;
				else
				{
					if (deleteTemp->right == nullptr)
					{
						temp->left->left->right = temp->left->right;
						temp->left = temp->left->left;
					}
					else
					{
						while (deleteTemp->right->right != nullptr)
							deleteTemp = deleteTemp->right;
						ListElement *tempRight = deleteTemp->right;
						ListElement *tempLeft = deleteTemp->right->left;
					
						tempRight->right = temp->left->right;
						tempRight->left = temp->left->left;
						deleteTemp->right = tempLeft;
						temp->left = tempRight;
					}
				}
				delete deleteList;
				return;
			}
		}

		// если удаляем справа.
		if(temp->right != nullptr)
		{
			if (temp->right->value == value)
			{
				ListElement *deleteList = temp->right;
				ListElement *deleteTemp = deleteList->left;
				if (deleteTemp == nullptr)
					temp->right = deleteList->right;
				else
				{
					if (deleteTemp->right == nullptr)
					{
						temp->right->left->right = temp->right->right;
						temp->right = temp->right->left;
					}
					else
					{
						while (deleteTemp->right->right != nullptr)
							deleteTemp = deleteTemp->right;
						ListElement *tempRight = deleteTemp->right;
						ListElement *tempLeft = deleteTemp->right->left;
				
						tempRight->right = temp->right->right;
						tempRight->left = temp->right->left;
						deleteTemp->right = tempLeft;
						temp->right = tempRight;
					}
				}
				delete deleteList;
			}
		}
	}	
}