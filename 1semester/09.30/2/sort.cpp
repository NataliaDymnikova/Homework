#include <stdio.h>
#include <stdlib.h>

#include "sort.h"

void swap(int &swapOne, int &swapTwo)
{
	int swapSwap = swapOne;
	swapOne = swapTwo;
	swapTwo = swapSwap;
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

