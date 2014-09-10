#include <stdio.h>
#include <iostream>
#include "stack.h"
#include "calculate.h"

using namespace std;

Stack *createPost()
{
	Stack *stack = create();
	char ch = 0;
	cout << "Enter example of postfix notation:" << endl;
	scanf("%c", &ch);
	while (ch != '\n')
	{
		if (ch >= '0' && ch <= '9')
			addElement(stack, ch - '0');
		else
			calculateTwoNumbers(stack, ch);
		scanf("%c", &ch);
		while (ch == ' ')
			scanf("%c", &ch);
	}
	cout << "result: " << valueHead(stack) << endl;

	return stack;
}

void calculateTwoNumbers(Stack *stack, char sign)
{
	int value1 = valueHead(stack);
	deleteElement(stack);
	int value2 = valueHead(stack);
	deleteElement(stack);

	int valueResult = 0;
	if (sign == '+')
		valueResult = value1 + value2; 
	else if (sign == '-')
		valueResult = value2 - value1; 
	else if (sign == '*')
		valueResult = value1 * value2; 
	else if (sign == '/')
		valueResult = value2 / value1; 
	addElement(stack, char(valueResult));
}

