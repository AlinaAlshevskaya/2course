#include <iostream>
#include <string>

extern "C" {

	int strToint(int n, char c,...) {
		int result = 0;
		char* pointer = &c;
		
		for (short i = 0; i < n; i++) {
			//if (!isdigit(*pointer)) {
			//	return 0;
			//}
			result += *pointer - '0';
			pointer+=4;
		}
		return result;
	}

	int cmpChr(char a, char b) {
		if (a == b) {
			return 0;
		}
		if (a < b) {
			return -1;
		}
		if (a > b) {
			return 1;
		}
	}
	void Out_int(int num) {
	
		std::cout << "Int output: ";
		std::cout <<num<< std::endl;
	}
	void Out_char(char chr) {
		std::cout << chr << std::endl;
	}
	void Out_bool(bool logic) {
		std::cout << logic << std::endl;
	}

}

