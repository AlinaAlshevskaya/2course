#include "asmGenh.h"
#include "stdafx.h"
#include <string>

string Join(string str);

void AsmGen::CreateFile(char str[], int number)
{
	ofstream file(ASMFILE);
	string String;
	for (int i = 1; i < 127; i++) { String = String + str[i]; }
	string strInt = to_string(number);
	strInt = Join(strInt);

	if (file.is_open())
	{
		file ASMHEADER;

		file << "FILESTRING DB " << str << endl;
		file << "FILEINT DD " << number << endl;
		file << "INTSTR DD \"int:     \", 0" << endl << endl
			<< ".CODE\n" << endl
			<< "main PROC\n" << endl;

		string footer = "";
			footer += "invoke MessageBoxA, 0, ADDR FILESTRING, ADDR TEXT_MESSAGE, OK\n";
			footer += "mov eax,FILEINT ";
			footer += "add eax, 30h";
			footer += "mov INTSTR+6, eax";

		footer += "invoke MessageBoxA, 0, OFFSET INTSTR, ADDR TEXT_MESSAGE, OK\n";

		footer += "push - 1\n";
		footer += "call ExitProcess\n";
		footer += "main ENDP\n";
		footer += "end main\n";

		file << footer;
	}
	else
	{
		cout << "File not open" << endl;
	}
}

string Join(string str)
{
	string newStr = "";
	for (int i = 0; i < str.size(); i++)
	{
		newStr += str[i];
		if (i + 1 != str.size())
		{
			newStr += ", ";
		}
	}
	return newStr;
}