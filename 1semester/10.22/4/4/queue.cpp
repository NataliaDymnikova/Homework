#include <stdio.h>
#include "queue.h"
#include <iostream>

using namespace std;


struct Queue
{
	ListElement *head;
	ListElement *last;
};

struct ListElement
{
	ElementType value;
	ListElement *next;
};

Queue *createQueue()
{
	Queue *newQueue = new Queue;
	newQueue->head = NULL;
	newQueue->last = NULL;
	return newQueue;
}

void enqueue(Queue *queue, ElementType value)
{
	ListElement *newListElement = new ListElement;
	newListElement->value = value;
	newListElement->next = NULL;
	if (queue->head == NULL)
	{
		queue->last = newListElement;
		queue->head = queue->last;
		return;
	}
	queue->last->next = newListElement;
	queue->last = newListElement; 
}

void deleteQueueElement(Queue *queue)
{
	if (queue == NULL || queue->head == NULL)
		return;
	ListElement *temp = queue->head;
	queue->head = queue->head->next;
	delete temp;
}
	
ElementType dequeue(Queue *queue)
{
	if (queue->head == NULL)
		return -1;
	ElementType value = queue->head->value;
	deleteQueueElement(queue);
	return value;
}

void deleteQueue(Queue *queue)
{
	while (queue->head != NULL)
		deleteQueueElement(queue);
	delete queue;	
}

void printQueue(Queue *queue)
{
	if (queue->head == NULL)
	{
		cout << "Queue is empty" << endl;
		return;
	}
	ListElement *temp = queue->head;
	while (temp != NULL)
	{
		cout << temp->value << " ";
		temp = temp->next;
	}
	cout << endl;

}

	