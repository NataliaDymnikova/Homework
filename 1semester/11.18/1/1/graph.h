#pragma once

// считывает с файла массив country - массив стран, возвращает массив дорог.
int **create(int country[]);

// возаращает массив городов, значения которого являются страны, которым принадледат города.
void makeCountry(int country[], int **floydGraph, int numberCity, int city[]);

// вывод на консоль стран и городов ему принадлежащих.
void print(int city[], int country[], int numberCity);


