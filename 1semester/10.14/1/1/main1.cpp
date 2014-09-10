/* test is Ok when I press- 
							1 - name - ddd, telephone - 444
							2 - name - aaa
							2 - name - zzz
							3 - telephone - 111
							3 - telephone - 0
							4
*/

#include <stdio.h>
#include <iostream>

using namespace std;

struct List
{
	char name[100][20];
	int telephone[100];
	int last;
};

// создание списка и считывание первых элементов из файла
void create(FILE *file, List *list)
{
	list->last = 0;
	for (int i = 0; i < 100; i++)
	{
		for (int j = 0; j < 20; j++)
			list->name[i][j] = 0;
		list->telephone[i] = 0;
	}
	if (file == NULL)
	{
		cout << "can't open file" << endl;
		return;
	}
	int amount = 0;
	fscanf(file, "%d", &amount);
	while (list->last < amount)
	{
		fscanf(file, "%s", &list->name[list->last]);
		fscanf(file, "%d", &list->telephone[list->last]);
		list->last++;
	}
}

//  добавление нового элемента в список
void addNewElement(List *list)
{
	cout << "enter name" << endl;
	cin >> list->name[list->last];
	
	cout << "enter telephone" << endl;
	cin >> list->telephone[list->last];
	list->last++;
}

// печать списка
void print(List *list)
{
	//cout << list->last << endl;
	for (int i = 0; i < list->last; i++)
	{
		cout << list->name[i] << " " << list->telephone[i] << endl;
	}
}

// поиск телефона по имени, возвращение номера номера телефона
int searchTelephone(List *list, char name[])
{
	for (int i = 0; i < list->last; i++)
		if (!strcmp(list->name[i], name))
			return i;
	return -1;
}

// поиск имени по телефону, возвращение номера имени 
int searchName(List *list, int telephone)
{
	for (int i = 0; i < list->last; i++)
		if (list->telephone[i] == telephone)
			return i;
	return -1;
}

// сохрание списк в файл
void saveToFile(FILE *file, List *list)
{
	fprintf( file, "%i\n", list->last);
	for (int i = 0; i < list->last; i++)
	{
		fprintf( file, "%s\n%d\n", list->name[i], list->telephone[i]);
	}
}

// удаление списка
void deleteList(List *list)
{
	/*
		delete[] list->name[i];
	}
	delete[] list->telephone;*/
	delete list;
}

int main()
{
	FILE *file = fopen("in.txt", "r");
	List *list = new List;
	create(file, list);
	if (file != NULL)
		fclose(file);
	int whatDo = -1;
  	while (whatDo)
	{
		print(list);	
		cout << "0 - exit" << endl << "1 - add name and telephone" << endl << "2 - search telephone on name" << endl << 
			"3 - search name  on telephone" << endl << "4 - save to file" << endl;
		cin >> whatDo;
		if (whatDo == 1)
			addNewElement(list); 
		if (whatDo == 2)
		{
			char name[20] = {0};
			cout << "Enter name" << endl;
			cin >> name;
			int numberTelephone = searchTelephone(list, name); 
			if (numberTelephone == -1)
				cout << "Don't have this name" << endl << endl;
			else
				cout << "telephone - " << list->telephone[numberTelephone] << endl << endl;
		}
		if (whatDo == 3)
		{
			int telephone = 0;
			cout << "Enter telephone" << endl;
			cin >> telephone;
			int numberName = searchName(list, telephone); 
			if (numberName == -1)
				cout << "Don't have this telephone" << endl << endl;
			else
				cout << "name - " << list->name[numberName] << endl << endl;
		}
		if (whatDo == 4)
		{
			file = fopen("in.txt", "w");
			if (file == NULL)
			{
				cout << "can't open file" << endl;
				continue;
			}
			saveToFile(file, list);
			fclose(file);
		}
	}
	
	deleteList(list);
	return 0;
}