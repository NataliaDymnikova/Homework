#pragma once

typedef char ElementType;

struct ListElement;
struct Queue;

// создание очереди.
Queue *createQueue();
// добавление в конец элемента value в queue.
void enqueue(Queue *queue, ElementType value);
// возвращает значение в голове queue и удаление его.
ElementType dequeue(Queue *queue);
// удаление queue.
void deleteQueue(Queue *queue);
// удалениеu головы queue.
void deleteQueueElement(Queue *queue);

// печать queue.
void printQueue(Queue *queue);

