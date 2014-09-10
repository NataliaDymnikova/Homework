#include <stdio.h>
#include <stdlib.h>


void printMas(int arraySize, int mas[])
{
	for (int i = 0; i < arraySize; i++)
		printf("%d, ", mas[i]);
	printf("\n");
}

int main()
{
	int mas[15] = {0};
	int arraySize = 15;
	for(int i = 0; i < arraySize; i++)
		mas[i] = rand() % 100;
	printMas(arraySize, mas);
	int left = 0;
	int right = arraySize - 1;
	int general = mas[0];
	
	while (left < right)
	{
		while (mas[left] < general)
			left++;
		while (mas[right] >= general)
			right--;
		if(left > right)
			break;
		int swap = mas[left];
		mas[left] = mas[right];
		mas[right] = swap;
		left++;
		right--;
	}		
	printMas(arraySize, mas);
	scanf("%*s");
	return 0;
}