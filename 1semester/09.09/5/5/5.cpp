#include <stdio.h>
#include <stdlib.h>

void per(int mas[], int left, int right)
{
	int n = (right - left) / 2;
	int elmas = 0;
	for(int i = 0; i <= n; i++) {
		elmas = mas[left + i];
		mas[left + i] = mas[right - i];
		mas[right - i] = elmas;
	}
}

int main()
{
	int m = 0;
	int n = 0;
	printf("Enter the numbers m and n. Please, do m + n < 1000: ");
	scanf("%d %d", &m, &n);
	int lengthMas = m + n;
	int *mas = new int[lengthMas];

	for(int i = 0; i < lengthMas; i++) 
		mas[i] = rand();

	for(int i = 0; i < lengthMas; i++) 
		printf("%d, ", mas[i]);

	printf("\n");
	per(mas, 0, m-1);
	per(mas, m, lengthMas-1);
	per(mas, 0, lengthMas-1);

	for(int i = 0; i < lengthMas; i++) 
		printf("%d, ", mas[i]);

	printf("\n");
	delete[] mas;
	return 0;
}
