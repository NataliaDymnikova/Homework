#pragma once

// поиск длинны листа list.
int lengthList(List *list);
// сортировка слиянием листа list. 
// если value = true, то сортировка по имени, иначе по телефону.
List *mergeSort(List *list, bool value);
// проверка больше ли первое, чем второе.
bool isFirstMax(ListElement *first, ListElement *second, bool valueIsTelephone);