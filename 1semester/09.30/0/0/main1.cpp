/* test is Ok - 
		   numbers: 6, 7
					0, 0
				   -3, 3
				   -5, 2
				   -2, 5
				   -6, -7

*/

#include <stdio.h>
#include <math.h>
#include <locale>

/* вывод массива на экран */
void printMas(bool mas[], int arraySize)
{
	bool isMasNull = true;
	for (int i = arraySize - 1; i >= 0; i--)
		if (mas[i] != 0 || !isMasNull)
		{
			printf("%d", mas[i]);
			isMasNull = false;
		}
	if (isMasNull)
		printf("0");
	printf("\n");
}

/* перевод из десятичной системы в двоичную */
void decToBin(int dec, bool bin[], int arraySize)
{
	int mask = 1;
	for (int i = 0; i < sizeof(int) * 8; i++)
	{
		bin[i] = dec & mask;
		mask = mask << 1;
	}
}

/* перевод из двоичной системы в десятичную */
int binToDec(bool bin[], int arraySize)
{
	int dec = 0;
	int power = 1;
	for (int i = 0; i < arraySize; i++)
	{
		dec += bin[i] * power;		
		power *= 2;
	}
	return dec;
}

/* сумма двух двоичных чисел */
void sum(bool mas1[], bool mas2[], int arraySize, bool sumMas[])
{
	bool tmp = false;
	for (int i = 0; i < arraySize; i++)
	{
		if (mas1[i] && mas2[i])
		{
			if (tmp)
				sumMas[i] = true;
			else
				sumMas[i] = false;
			tmp = true;
		}
		else if (mas1[i] || mas2[i])
			sumMas[i] = !tmp;
		else
		{
			sumMas[i] = tmp;
			tmp = false;
		}
	}
}

int main()
{
	setlocale(LC_ALL, "Russian");
   
	int dec1 = 0;
	int dec2 = 0;
	int decSum = 0;
	printf("Введите 2 числа: ");
	scanf("%d %d", &dec1, &dec2);
	
	bool bin1[sizeof(int) * 8] = {0};
	bool bin2[sizeof(int) * 8] = {0};
	bool binSumMas[sizeof(int) * 8] = {0};
	
	decToBin(dec1, bin1, sizeof(int) * 8);
	decToBin(dec2, bin2, sizeof(int) * 8);
	sum(bin1, bin2, sizeof(int) * 8, binSumMas);
	decSum = binToDec(binSumMas, sizeof(int) * 8);
	
	printf("Перевод в двоичную систему\n%d = ", dec1);
	printMas(bin1, sizeof(int) * 8);
	printf("%d = ", dec2);
	printMas(bin2, sizeof(int) * 8);
	printf("Сумма в двоичной системе: ");
	printMas(binSumMas, sizeof(int) * 8);
	printf("Сумма в дестичной системе: %d\n", decSum);


	return 0;
}