#include "Deserealizer.h"
#include "stdafx.h"

void Desearealizer::Deserialize(char str[], int* number)
{
	ifstream file(FILENAME, ios::binary);
	if (file.is_open())
	{
		file.read(reinterpret_cast<char*>(str), sizeof(char)*127);
		file.read(reinterpret_cast<char*>(number), sizeof(int));
		file.close();
	}
	else
	{
		cout << "File not open" << endl;
	}
}