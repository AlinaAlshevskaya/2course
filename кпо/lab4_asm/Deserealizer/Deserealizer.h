#pragma once
#include <string>
class Desearealizer
{
public:
	void Deserialize(char str[], int* number);

private:
	const char* FILENAME = "../Serealizer/bin.bin";
};    
