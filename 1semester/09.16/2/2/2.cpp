#include <stdio.h>

int degree(int num, int deg)
{
	int result = 1;
	for (int i = 0; i < deg; i++)
		result *= num;
	return result;
}

//int degreefast(int num, int deg)
//{
//	int result = num;
//	int i = deg;
//	while (i > 1)
//	{
//		if (i % 2 == 1) 
//		{
//			result *= num;
//			i /= 2;
//		}
//		else
//		{
//			result *= result;
//			i /= 2;
//		} 
//	}
//	return result;
//}


int degreefast(int num, int deg)
{
	if (deg > 1)
	{
		if (deg % 2 == 0)
			return degreefast(num * num, deg / 2);
		else
			return num * degreefast(num, deg - 1);
	}
	else
		return num;
}


int main()
{
	int num = 0;
	int deg = 0;
	int whatDo = 1;
	while (whatDo != 0)
	{
		printf("0 - exit \n1 - degree \n2 - fast degree \n3 - degree and fast degree \n");
		scanf("%d", &whatDo);
		if (whatDo != 0)
		{
			printf("Enter number and degree: ");
			scanf("%d %d", &num, &deg);
			if (whatDo == 1)
				printf("result degree - %d\n", degree(num, deg));
			else if (whatDo == 2)
				printf("result fast degree - %d\n", degreefast(num, deg));
			else if (whatDo == 3)
				printf("result degree and fast degree - %d, %d\n\n", degree(num, deg), degreefast(num, deg));
		}
	}
	return 0;
}