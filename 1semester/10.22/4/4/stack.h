#pragma once

typedef char ElementType;

struct Stack;
struct ListElement;

// создание стека.
Stack *createStack();
// добавление элемента value в stack.
void addElementStack(Stack *stack, ElementType value);
// значение в голове stack.
ElementType valueHeadStack(Stack *stack);
// удаление элемента stack.
void deleteStackElement(Stack *stack);
// удаление всего stack.
void deleteStack(Stack *stack);
// пустой ли stack.
bool isEmptyStack(Stack *stack);
