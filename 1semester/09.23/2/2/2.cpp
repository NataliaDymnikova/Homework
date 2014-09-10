/* test is Ok - 
          arraySize - 2: 1, 7; k - 3: 14, 0, 9
          arraySize - 10: 0, 1, 2, 4, 4, 7, 9, 14, 18, 18; k - 5: 5, 5, 1, 7, 1*/


#include <stdio.h>
#include <stdlib.h>

void swap(int swapOne, int swapTwo)
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
		return ;
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

		int swap = mas[left];
		mas[left] = mas[right];
		mas[right] = swap; 
		//swap(mas[left], mas[right]);

		left++;
		right--;
	}		
	qsort(mas, begin, right);
	qsort(mas, left, end);	
}


bool isKInMas(int mas[], int k, int left, int right)
{
	int center = (left + right) / 2;
	if (k == mas[center])
		return true;
	if (left < center && right > center)
	{
		if (k < mas[center])
			isKInMas(mas, k, left, center);
		else
			isKInMas(mas, k, center, right);
	}
	else if (k == mas[left] || k == mas[right])
		return true;
	else
		return false;
}


int main()
{
	int arraySize = 0;
	printf("Enter size array - ");
	scanf("%d", &arraySize);
	int *mas = new int[arraySize];
	for (int i = 0; i < arraySize; i++)
		mas[i] = rand() % 20;
	printMas(arraySize, mas);
	qsort(mas, 0, arraySize - 1);
	printMas(arraySize, mas);
	
	printf("Enter number k - ");
	int kSize = 0;
	scanf("%d", &kSize);
	for (int i = 0; i < kSize; i++)
	{
		int k = rand() % 20;
		if(isKInMas(mas, k, 0, arraySize))
			printf("%d - true\n", k);
		else
			printf("%d - false\n", k);
		
	}
	
	scanf("%*s");
	return 0;
}