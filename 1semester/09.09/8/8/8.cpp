#include <stdio.h>
#include <string.h>

int main()
{
	char s1[1000] = {0};
	char s2[1000] = {0};
	int numberStringSame = 0;
	bool isStringSame = true;
	printf("Enter S1 - ");
	scanf("%s", s1);
	printf("\nEnter S2 - ");
	scanf("%s", s2);
for (int i = 0; i <= strlen(s1) - strlen(s2); i++) {
		isStringSame = true;
		for (int j = 0; j < strlen(s2); j++) {
			if (s2[j] != s1[i + j]) {
				isStringSame = false;
				break;
			}
		}
		if (isStringSame)
			numberStringSame++;
	}
	printf("\nthe number of times, when S2 is in S1 - %d\n", numberStringSame);
	return 0;
}



