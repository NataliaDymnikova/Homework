#include <iostream>
#include "stack.h"
#include "balance.h"

using namespace std;

bool isBalance(Stack *stack)
{
	char ch = 0;
	scanf("%c", &ch);
	while (ch != '\n')
	{
		if (ch == '(' || ch == '{' || ch == '[')
			addElement(stack, ch);
		else if (ch == ')')
			if (valueHead(stack) == '(')
				deleteElement(stack);
			else
				return false;
		else if ( ch == '}') 
			if (valueHead(stack) == '{')
				deleteElement(stack);
			else
				return false;
		else if (ch == ']')
			if (valueHead(stack) == '[')
				deleteElement(stack);
			else
				return false;
		scanf("%c", &ch);
	}
	return isEmpty(stack);
}
