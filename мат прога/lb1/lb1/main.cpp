#include "stdafx.h"
#include "Auxil.h"                            
#include <iostream>
#include <ctime>
#include <locale>
#include <Windows.h>
#include <tchar.h>

#define  CYCLE  10000000

int fib(int n) {
	if (n <= 1) return n;
	return fib(n - 1) + fib(n - 2);
}

int _tmain(int argc, _TCHAR* argv[])
{

	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0;

	setlocale(LC_ALL, "rus");

	auxil::start();                          
	t1 = clock();                            
	int fib(int n);
	fib(45);
	t2 = clock();                            


	std::cout << std::endl << "���������� ������:         " << CYCLE;
	std::cout << std::endl << "������� �������� (int):    " << av1 / CYCLE;
	std::cout << std::endl << "������� �������� (double): " << av2 / CYCLE;
	std::cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
	std::cout << std::endl << "                  (���):   "
		<< ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;
	system("pause");

	return 0;
}