#include <iostream>

//для задания 21
int function(int x, int y) {
	return x * y;
}

void main()
{
	//константы
	const int n = 1;
	const int X = 9 + n;
	const int Y = 10 + n;
	const int Z = 11 + n;
	const float S = 1.0 + n;

	//задание 4
	//1 byte
	bool trushka = true;
	bool falshka = false;
	//задание 5
	//1 byte
	char familia = 'a';
	//задание 6
	char rusfamilia = 'а';
	//задание 7
	//2 byte
	wchar_t latinfam = L'A';
	//задание 8
	wchar_t rusfam = L'А';
	//задание 9
	//2 byte
	short plusX = X;
	//hex for x:A
	short minusX = -X;
	//hex for -x:FFFA

	//задание 10
	short maxsh = SHRT_MAX;
	//значение: 32767
	short minsh  = SHRT_MIN;
	//значение: -32768

	//задание 11
	//2 byte
	unsigned short maxunsh = USHRT_MAX;
	//значение : 65535
	unsigned short minunsh = 0;
	//значение : 0

	//task 12
	//4 byte
	int plusY = Y;
	//hex for pos_Y: B
	int minusY = -Y;
	//hex for neg_Y: FFFB

	//задание 13
	int maxint = INT_MAX;
	//значение:  2147483647

	int minint = INT_MIN;
	//значение: -2147483648  

	//задание 14
	//4 byte
	unsigned int maxuint = UINT_MAX;
	//значение: 4 294 967 295
	unsigned int minuint = 0;
	//значение:0

	//задание 15
	//4 byte
	long plusZ = Z;
	//hex for Z: C
	long minusZ = -Z;
	//hex for -Z: FFFC 

	//задание 16
	long longmax = LONG_MAX;
	//значение = 2147483647
	long longmin = LONG_MIN;
	//значение = -2147483648

	//задание 17
	//4 byte
	unsigned long ulongmax = ULONG_MAX;
	//значение: 4 294 967 295
	unsigned long ulongmin = 0;
	//значение: 0

	 //задание 18
	//4 byte
	float plusS = S;
	
	float minusS = -S;
	
	//задание 19
	//8 byte
	double forinf = 1;
	double infplus = forinf / 0;
	std::cout << infplus << std::endl;

	double infminus = -forinf / 0;
	std::cout << infminus << std::endl;

	double sqrtminus = sqrt(-forinf);
	std::cout << sqrtminus << std::endl;


	//задание 20
	char chr = 'a';
	//4 bytes
	char* ptr_chr = &chr + 3;

	wchar_t wchr = L'A';
	wchar_t* ptr_wchr = &wchr;

	short shrt = 75;
	short* ptr_shrt = &shrt;

	int intgr = 10;
	int* ptr_intgr = &intgr;

	float flt = 17.5;
	float* ptr_flt = &flt;

	double dbl = 25.123;
	double* ptr_dbl = &dbl;

	//задание 21
	int(*funcptr)(int, int);
	funcptr = function;

}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
