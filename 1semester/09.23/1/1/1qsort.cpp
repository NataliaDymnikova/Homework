/* test is Ok - 
          arraySize - 5, mas - 1, 2 ,3, 4, 5
          arraySize - 5, mas - 5, 4, 3, 2, 1
          arraySize - 5, mas - 2, 1, 3, 5, 4
		  arraySize - 5, mas - 1, 1, 1, 1, 1
		  arraySize - 15, mas - 2, 1, 4, 3, 1, 5, 6, 7,8, 2, 2 */

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

void insertion(int mas[], int begin, int end)
{
	for (int i = 1 + begin; i <= end; i++)
		for (int j = i; j > begin; j--)
			if (mas[j] < mas[j - 1])
				swap(mas[j], mas[j - 1]);
	
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
	
	if (end - begin < 10)
		insertion(mas, begin, end);
	else
	{

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
}

int main()
{
	int arraySize = 0;
	printf("Enter size array - ");
	scanf("%d", &arraySize);
	int *mas = new int[arraySize];
	printf("\nEnter array - ");
	for(int i = 0; i < arraySize; i++)
		scanf("%d", &mas[i]);
	
	qsort(mas, 0, arraySize - 1);
	printMas(arraySize, mas);
	
	scanf("%*s");
	delete[] mas;
	return 0;
}