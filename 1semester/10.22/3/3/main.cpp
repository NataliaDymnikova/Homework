/* Test is Ok - 
				false - (
				true  - ()
				false - ([)]
				true  - ([])
				true  - {}[]()[({})]
*/

#include <iostream>
#include "stack.h"
#include "balance.h"

using namespace std;

int main()
{
	Stack *stack = create();
	if (isBalance(stack))
		cout << "balance is true" << endl;
	else
		cout << "balance is false" << endl;
	deleteStack(stack);
	return 0;
}