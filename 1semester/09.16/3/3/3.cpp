#include <stdio.h>


void printMas(int arraySize, int mas[])
{
	for (int i = 0; i < arraySize; i++)
		printf("%d, ", mas[i]);
	printf("\n");
}

void bubbleSort(int arraySize, int mas[])
{
	for (int i = 0; i < arraySize; i++)
		for (int j = 0; j < arraySize - 1; j++)
			if (mas[j + 1] < mas[j])
			{
				int swap = mas[j];
				mas[j] = mas[j + 1];
				mas[j + 1] = swap;
		}
	printMas(arraySize, mas);
}

void countSort(int arraySize, int mas[], int begin, int end)
{
	int *dopMas = new int[end - begin + 1];
	for (int i = 0; i < end - begin + 1; i++)
		dopMas[i] = 0;
	for (int i = 0; i < arraySize; i++)
		dopMas[mas[i] - begin]++;
	int j = 0;
	for (int i = 0; i < end - begin + 1; i++)
	{
		while(dopMas[i] > 0)
		{
			mas[j] = i + begin;
			j++;
			dopMas[i]--;
		}
	}
	printMas(arraySize, mas);
	delete[] dopMas;
}

int main()
{
	int arraySize = 0;
	int whatDo = 1;
	while(whatDo != 0)
	{
		printf("0 - exit\n1 - buble sort\n2 - count sort\n");
		scanf("%d", &whatDo);
		if (whatDo != 0)
		{
			printf("Enter number elements: ");
			scanf("%d", &arraySize);
			int *mas = new int[arraySize];
			printf("Enter array: ");
			for (int i = 0; i < arraySize; i++)
				scanf("%d", &mas[i]);
	
			if(whatDo == 1)
			{
				printf("Buble sort: ");
				bubbleSort(arraySize, mas);
			}
			else if(whatDo == 2)
			{
				int begin = 0;
				int end = 0;
				printf("Enter begin and end - ");
				scanf("%d %d", &begin, &end);
				printf("Count sort: ");
				countSort(arraySize, mas, begin, end);
			}
			delete[] mas;
		}
	}	
	return 0;
}