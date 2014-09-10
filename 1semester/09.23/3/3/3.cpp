/* test is Ok - 
          arraySize - 5, mas - 1, 2 ,3, 4, 5
          arraySize - 5, mas - 1, 2, 3, 4, 4
*/


#include <stdio.h>
#include <stdlib.h>

void swap(int &swapOne, int &swapTwo)
{
	int swapSwap = swapOne;
	swapOne = swapTwo;
	swapTwo = swapSwap;
}

void printMas(int arraySize, int mas[])
{
	for (int i = 0; i < arraySize; i++)
		printf("%d, ", mas[i]);
	printf("\n");
}

void qsort(int mas[], int begin, int end)
{
	int general = 0;
	int i = 0;
	for (i = 0; i < end - begin && mas[begin + i] == mas[begin]; i++) ;
	
	if (mas[begin] == mas[begin + i])
		return;
	else if (mas[begin] < mas[begin + i])
		general = mas[begin + i];
	else
		general = mas[begin];
	
	int left = begin;
	int right = end;

	while (left < right)
	{
		while (mas[left] < general)
			left++;
		while (mas[right] >= general)
			right--;
		if (left >= right)
			break;
		swap(mas[left], mas[right]);

		left++;
		right--;
	}		
	qsort(mas, begin, right);
	qsort(mas, left, end);	
}

int oftenElement(int arraySize, int mas[])
{
	int number = 1;
	int maxNum = 0;
	int maxElement = mas[0];
	for (int i = 1; i < arraySize; i++)
	{
		if (mas[i - 1] == mas[i])
			number++;
		else
			number = 1;
		
		if (number > maxNum)
		{
			maxElement = mas[i - 1];
			maxNum = number;
		}
	}
	return maxElement;
}

int main()
{
	int arraySize = 0;
	int whatDo = 0;
	printf("Enter size array - ");
	scanf("%d", &arraySize);
	int *mas = new int[arraySize];
	printf("1 - random\n2 - you enter\n");
	scanf("%d", &whatDo);
	if (whatDo == 1)
	{
		for (int i = 0; i < arraySize; i++)
			mas[i] = rand() % 10;
		printMas(arraySize, mas);
	}
	if (whatDo == 2)
	{
		printf("Enter massive: ");
		for (int i = 0; i < arraySize; i++)
			scanf("%d", &mas[i]);
	}
	qsort(mas, 0, arraySize - 1);
	printMas(arraySize, mas);
	
	printf("element - %d\n", oftenElement(arraySize, mas));
	
	scanf("%*s");
	delete[] mas;
	return 0;
}