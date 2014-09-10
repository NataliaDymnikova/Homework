/* Test is Ok - 
				aaa 
				aaa bbb
				aaa aaa bbb aaa
				a b c d e
*/
#include "list.h"
#include "hash.h"
#include <stdio.h>

using namespace list;
using namespace hash;



int main()
{
	FILE *file = fopen("file.in", "r");
	HashTable *hashTable = createHashTable();
	int i = 0;
	char word[100] = {'\0'};
	char ch = fgetc(file);
	while (ch != '\n')
	{
		if (ch != ' ')
		{
			word[i] = ch;
			i++;
		}
		else if (i != 0)
		{
			insertToHashTable(hashTable, word);
			for (int j = 0; j < i; j++)
				word[j] = '\0';
			i = 0;
		}
		ch = fgetc(file);
	}
	if (i != 0)
		insertToHashTable(hashTable, word);
	print(hashTable);
	fclose(file);
	return 0;
}