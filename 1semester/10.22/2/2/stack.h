#pragma once

typedef int ElementType;

struct Stack;
struct ListElement;

// создание стека.
Stack *create();
// добавление элемента value в stack.
void addElement(Stack *stack, ElementType value);
// значение в голове stack.
ElementType valueHead(Stack *stack);
// удаление элемента stack.
void deleteElement(Stack *stack);
// удаление всего stack.
void deleteStack(Stack *stack);
// пустой ли stack.
bool isEmpty(Stack *stack);
