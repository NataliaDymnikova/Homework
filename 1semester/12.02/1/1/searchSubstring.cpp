#include "searchSubstring.h"
#include <math.h>
#include <string.h>


int hashFunction(char line[], int prime, int size)
{
	int result = 0;
	for (int i = 0; i < size; i++)
		result += line[i] * (int)pow((double)prime, (size - i - 1));
	return result;
}

void copyText(char text[], char partOfText[], int begin, int size)
{
	for (int i = 0; i < size; i++)
		partOfText[i] = text[begin + i];
}

int sizeLine(char line[])
{
	int i = 0;
	for (i = 0; line[i] != 0; i++);
	return i;
}

bool isEqual(char line[], char partOfText[], int size)
{
	for (int i = 0; i < size; i++)
		if (line[i] != partOfText[i])
		return false;
	return true;
}

int searchSubstring(char text[], char line[])
{
	int prime = 7;
	int size = sizeLine(line);
	int hashLine = hashFunction(line, prime, size);
	int primeInPowerSize = (int)pow((double)prime, size);
	char *partOfText = new char[size];
	copyText(text, partOfText, 0, size);
	int hashText = hashFunction(partOfText, prime, size);
	for (int i = 0; i < sizeLine(text) - size; i++)	
	{
		if (hashLine == hashText)
			if(isEqual(line, partOfText, size))
				return i;
		hashText = hashText * prime - primeInPowerSize * partOfText[0] + text[i + size];
		copyText(text, partOfText, i + 1, size);
	}
	return -1;
	delete[] partOfText;
	return 0;
}