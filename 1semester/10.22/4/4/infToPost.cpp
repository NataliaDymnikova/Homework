#include <iostream>
#include "stack.h"
#include "queue.h"
#include "infToPost.h"

using namespace std;


int opPreor(char sign)
{
	if (sign == '+' || sign == '-')
		return 1;
	if (sign == '*' || sign == '/')
		return 2;
	return 0;
}

void infToPost(Queue *queue)
{
	Stack *stack = createStack();
	cout << "Enter example of infix notation:" << endl;
	char ch = 0;
	scanf("%c", &ch);
	while (ch != '\n')
	{
		if (ch >= '0' && ch <= '9')
			enqueue(queue, ch);

		else if (ch == '+' || ch == '-' || ch == '/' || ch == '*')
		{
			while (!isEmptyStack(stack) && opPreor(ch) < opPreor(valueHeadStack(stack)))
			{
				enqueue(queue, valueHeadStack(stack));
				deleteStackElement(stack);
			}
			addElementStack(stack, ch);
		}

		else if (ch == '(')
			addElementStack(stack, ch);
		else if(ch == ')')
		{
			while (!isEmptyStack(stack) && valueHeadStack(stack) != '(')
			{
				enqueue(queue, valueHeadStack(stack));
				deleteStackElement(stack);
			}
			if (isEmptyStack(stack))
			{
				cout << "error. we want - (" << endl;
				return;
			}
			deleteStackElement(stack);
		}
		scanf("%c", &ch);
	}

	while (!isEmptyStack(stack))
	{
		enqueue(queue, valueHeadStack(stack));
		deleteStackElement(stack);
	}		
	deleteStack(stack);
}

