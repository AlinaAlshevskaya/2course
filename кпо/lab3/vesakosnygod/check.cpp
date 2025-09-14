#include "stdafx.h"

#include <iostream>
#include <string>
using namespace std;
bool checkdate(string date) {
    if (date.size()!=8) {
        std::cout << "Проверьте количесво введённых символов \n";
        return false;
    }
    for (int i = 0; i < 8; i++) {
        if (date[i] < '0' || date[i]>'9') {
            cout << "Не все введенные символы цифры";
            return false;
        }
    }
    return true;

}