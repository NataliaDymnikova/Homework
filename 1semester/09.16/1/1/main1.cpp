#include <stdio.h>

int fibonacheRecursion(int number)
{
	if (number <= 1)
		return 1;
	return fibonacheRecursion(number - 1) + fibonacheRecursion(number - 2);
}

void fibonacheIterative(int number)
{
	int fibonPrevious = 0;
	int fibonBeforePrevious = 1;
	int fibon = 0;
	for (int i = 0; i <= number; i++)
	{
		fibon = fibonPrevious + fibonBeforePrevious;
		printf("%d, ", fibon);
		fibonBeforePrevious = fibonPrevious;
		fibonPrevious = fibon;
	}
}


int main()
{
	int num = 0;
	int whatFivonache = 1;
	while (whatFivonache != 0)
	{
		printf("0 - exit \n1 - Fibonache recursion \n2 - Fibonache iterative\n");
		scanf("%d", &whatFivonache);
		if (whatFivonache == 1 || whatFivonache == 2)
		{
			printf("Enter number for Fibonache: ");
			scanf("%d", &num);
			if (whatFivonache == 1)
				for (int i = 0; i <= num; i++)
					printf("%d, ", fibonacheRecursion(i));

			if (whatFivonache == 2)
				fibonacheIterative(num);

			printf("\n");
		}
	}
	return 0;
}