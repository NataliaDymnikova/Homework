#include <stdio.h>

int main()
{
	FILE *file;
	if ((file = fopen("in.txt", "r")) == NULL)
	{
		printf("bad!!!");
		return 0;
	}

	int num = 0;
	char ch = 0;
	bool isNew = true;
	while ((ch = fgetc(file)) != EOF)
	{
		if (ch == '\n')
		{
			isNew = true;
			continue;
		}

		if (isNew)
		{
			if (ch != ' ' && ch != '\t' && ch != '\n')
			{
				num++;
				isNew = false;
			}
		}

	}
	printf("In file %d srting\n", num);

	fclose(file);
	return 0;
}