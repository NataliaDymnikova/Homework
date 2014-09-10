#include <stdio.h>
#include "stack.h"

struct Stack
{
	ListElement *head;
};

struct ListElement
{
	ElementType value;
	ListElement *next;
};

Stack *create()
{
	Stack *newStack = new Stack;
	newStack->head = NULL;
	return newStack;
}

void addElement(Stack *stack, ElementType value)
{
	ListElement *newListElement = new ListElement;
	newListElement->value = value;
	newListElement->next = stack->head;
	stack->head = newListElement;
}

ElementType valueHead(Stack *stack)
{
	return stack->head->value;
}

void deleteElement(Stack *stack)
{
	if (stack->head == NULL)
		return;
	ListElement *temp = stack->head;
	stack->head = stack->head->next;
	delete temp;
}

void deleteStack(Stack *stack)
{
	while (stack->head != NULL)
		deleteElement(stack);
	delete stack;
}

bool isEmpty(Stack *stack)
{
	return (stack->head == NULL);
}
