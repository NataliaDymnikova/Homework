#pragma once

namespace hash
{
	struct HashTable;
	// создание хэш таблицы.
	HashTable *createHashTable();
	// удаление хеш таблицы.
	void deleteHashTable(HashTable *hashTable);
	// добавление в хеш таблицу hashTable значения newElement.
	void insertToHashTable(HashTable *hashTable, ElementType newElement);
	// содержаение в хэш таблице значения element.
	bool exist(HashTable *hashTable, ElementType element);
	// удаление из хэш тыблицы значения element.
	void remove(HashTable *hashTable, ElementType element);
	// печать hash.
	void print(HashTable *hash);

}