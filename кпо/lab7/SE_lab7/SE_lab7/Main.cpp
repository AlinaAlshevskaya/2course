#include <iostream>
#include "Call.h"
using namespace std;
using namespace call;

namespace call {
	int _cdecl cdec(int a, int b, int c) {
		return a + b + c;
	}
	int  _stdcall cstd(int& a, int b, int c) {
		return a * b * c;
	}
	int _fastcall csft(int a, int b, int c, int d) {
		return a + b + c + d;
	}
}

void main()
{
	int a = cdec(10, 20, 30);
	int d = 5;
	int S = cstd(d, 15, 20);
	int g = csft(2, 4, 8, 10);
}