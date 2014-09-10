/* test is Ok - 
		   numbers: 6, 7
					0, 0
				   -3, 3
				   -5, 2
				   -2, 5
				   -6, -7

*/

#include <stdio.h>
#include <locale>

void printMas(bool mas[], int arraySize)
{
	for (int i = arraySize - 1; i >= 0; i--)
		printf("%d", mas[i]);
	printf("\n");
}

void decToBin(int dec, bool bin[], int arraySize)
{
	int mask = 1;
	bool isNat = true;
	if (dec < 0)
	{
		dec = -dec;
		isNat = false;
	}
	if (isNat)
		for (int i = 0; i < arraySize; i++)
		{
			bin[i] = dec & mask;
			mask = mask << 1;
		}
	else
		for (int i = 0; i < arraySize; i++)
		{
			bin[i] = !(dec & mask);
			mask = mask << 1;
		}
}

int binToDec(bool bin[], int arraySize)
{
	int dec = 0;
	int power = 1;
	if (!bin[arraySize - 1])
		for (int i = 0; i < arraySize - 1; i++)
		{
			dec += bin[i] * power;		
			power *= 2;
		}
	else
		for (int i = 0; i < arraySize - 1; i++)
		{
			dec += !bin[i] * power;		
			power *= 2;
		}
	if (bin[arraySize - 1])
		dec = -dec;
	return dec;
}

void sum(bool mas1[], bool mas2[], int arraySize, bool sumMas[])
{
	bool tmp = false;
	for (int i = 0; i < arraySize; i++)
	{
		if (mas1[i] && mas2[i])
		{
			sumMas[i] = tmp;
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
	if (tmp)
		sumMas[0] = !sumMas[0];
}

int main()
{
	int dec1 = 0;
	int dec2 = 0;
	int decSum = 0;
	printf("Enter 2 numbers: ");
	scanf("%d %d", &dec1, &dec2);
	bool bin1[sizeof(int) * 8] = {0};
	bool bin2[sizeof(int) * 8] = {0};
	bool binSumMas[sizeof(int) * 8] = {0};
	
	decToBin(dec1, bin1, sizeof(int) * 8);
	decToBin(dec2, bin2, sizeof(int) * 8);
	sum(bin1, bin2, sizeof(int) * 8, binSumMas);
	decSum = binToDec(binSumMas, sizeof(int) * 8);
	
	setlocale(LC_ALL, "Russian");
   
	printf("Перевод в двоичную систему\n%d = ", dec1);
	printMas(bin1, sizeof(int) * 8);
	printf("%d = ", dec2);
	printMas(bin2, sizeof(int) * 8);
	printf("Сумма в двоичной системе: ");
	printMas(binSumMas, sizeof(int) * 8);
	printf("Сумма в дестичной системе: %d\n", decSum);

	return 0;
}