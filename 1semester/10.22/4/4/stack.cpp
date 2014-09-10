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

Stack *createStack()
{
	Stack *newStack = new Stack;
	newStack->head = NULL;
	return newStack;
}

void addElementStack(Stack *stack, ElementType value)
{
	ListElement *newListElement = new ListElement;
	newListElement->value = value;
	newListElement->next = stack->head;
	stack->head = newListElement;
}

ElementType valueHeadStack(Stack *stack)
{
	return stack->head->value;
}

void deleteStackElement(Stack *stack)
{
	if (stack == NULL || stack->head == NULL)
		return;
	ListElement *temp = stack->head;
	stack->head = stack->head->next;
	delete temp;
}

void deleteStack(Stack *stack)
{
	while (stack->head != NULL)
		deleteStackElement(stack);
	delete stack;
}

bool isEmptyStack(Stack *stack)
{
	return (stack->head == NULL);
}
