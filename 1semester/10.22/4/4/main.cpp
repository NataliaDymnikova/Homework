/* Test is Ok - 
				1 + 2       -   1 2 +
				(1 + 2) * 3 -   1 2 + 3 *
				1 + 2 * 3   -   1 2 3 * +
				            -   Queue is empty.
*/

#include <iostream>
#include "stack.h"
#include "queue.h"
#include "infToPost.h"

using namespace std;

int main()
{
	Queue *queue = createQueue();
	infToPost(queue);
	printQueue(queue);
	deleteQueue(queue);
	return 0;
}