#include "stdafx.h"
#include "asmGenh.h"

void main()
{
	setlocale(LC_ALL, "ru");
	char str[127] ;
	int number;

	Desearealizer des;
	des.Deserialize(str, &number);

	cout << str << " " << number << endl;

	AsmGen AG;
	AG.CreateFile(str, number);
}