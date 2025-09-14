#pragma once
class Serealizer
{
public:
	void Serialize(char str[], int number);

private:
	const char* FILENAME = "bin.bin";
};