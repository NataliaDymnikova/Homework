#include "list.h"
#include "hash.h"

using namespace list;

const int b = 10;

int hashFunction(ElementType newElement)
{
	int number = 0;
	int i = 0;
	while (newElement[i] != '\0')	
	{
		number += newElement[i] * i;
		i++;
	}
	return number % b;
}

namespace hash
{
	struct HashTable
	{
		List *bucket[b];
	};

	HashTable *createHashTable()
	{
		HashTable *hashTable = new HashTable;
		for (int i = 0; i < b; i++)
			hashTable->bucket[i] = create();
		return hashTable;
	}

	void deleteHashTable(HashTable *hashTable)
	{
		for (int i = 0; i < b; i++)
		{
			removeList(hashTable->bucket[i]);
		}
		delete hashTable;
	}

	void insertToHashTable(HashTable *hashTable, ElementType newElement)
	{
		if (exist(hashTable->bucket[hashFunction(newElement)], newElement))
			return;
		insertToHead(hashTable->bucket[hashFunction(newElement)], newElement);
	}

	bool exist(HashTable *hashTable, ElementType element)
	{
		return exist(hashTable->bucket[hashFunction(element)], element);
	}

	void remove(HashTable *hashTable, ElementType element)
	{
		remove(hashTable->bucket[hashFunction(element)], positionOfElement(hashTable->bucket[hashFunction(element)], element));
	}
	
	void print(HashTable *hash)
	{
		for (int i = 0; i < b; i++)
			print(hash->bucket[i]);
	}
}