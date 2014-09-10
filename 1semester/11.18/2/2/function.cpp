#include "function.h"
#include <math.h>

int factorial(int number)
{
	if (number <= 1)
		return 1;
	return number * factorial(number - 1);
}

int bijection(int powerOne, int powerTwo)
{
	if (powerOne != powerTwo)
		return 0;
	return factorial(powerOne);
}

int surjection(int powerOne, int powerTwo)
{
	if (powerTwo > powerOne)
		return 0;
	int numberSurjecttion = 0;
	for (int i = 0; i < powerTwo; i++)
		if (i % 2 == 0)
			numberSurjecttion += pow(double(powerTwo - i), powerOne) * factorial(powerTwo) / factorial(powerTwo - i) / factorial(i);
		else
			numberSurjecttion -= pow(double(powerTwo - i), powerOne) * factorial(powerTwo) / factorial(powerTwo - i) / factorial(i);
	return numberSurjecttion;
}

int injection(int powerOne, int powerTwo)
{
	if (powerOne > powerTwo)
		return 0;
	return (factorial(powerTwo) / factorial(powerTwo - powerOne));
}

