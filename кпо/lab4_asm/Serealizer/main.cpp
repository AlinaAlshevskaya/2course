#include "stdafx.h"
#include "Serealizer.h"

using namespace std;
int indexNumIn(char arr[]);

void main()
{
	setlocale(LC_ALL, "ru");
	Serealizer serealizer;
	char str[127];
	
	char inputint[30];
    int Int;


	cout << "Введите строку( максимально 127 символов) ";
	cin.getline(str, 127);

	cout << "Введите число типа int: ";
	cin.getline(inputint, 30);


	Int = stoi(inputint + indexNumIn(inputint), NULL, 10); 

	cout << str << " " << Int << endl;

	serealizer.Serialize(str, Int);
}

int indexNumIn(char arr[])
{
	int i = 0;
	for (; i < strlen(arr); i++)
	{
		if (
			(arr[i] >= '0' && arr[i] <= '9') ||
			arr[i] == '-' || arr[i] == '+'
			)
		{
			return i;
		}
	}
	return -1;
}