/* Test is Ok - 
			3 =	1 2 +
			2 =	3 1 -
			8 =	2 4 *
			2 =	6 3 /
			2 =	1 3 + 2 -      
			9 =	9 6 - 1 2 + *  
			125 = 5 5 5 *
*/

#include <iostream>
#include "stack.h"
#include "calculate.h"

using namespace std;

int main()
{
	Stack *stack = createPost();
	//cout << "result: " << calculate(stack) << endl;
	deleteStack(stack);
	return 0;
}