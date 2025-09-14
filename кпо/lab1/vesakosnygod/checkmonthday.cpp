#include "stdafx.h"

#include <iostream>
using namespace std;
bool checkmonthday(int month, int day, int year, bool isLeapYear(int) ){
    if (month < 0 || month>12) {
        std::cout << "Неверно введено месяц\n";
        return false;
    }
    int daysInMonth[] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    if (isLeapYear(year)) {
        daysInMonth[1] = 29;
    }
    if (day<0 || day>daysInMonth[month - 1]) {
        std::cout << "Неверно введено число\n";
        return false;
    }
    return true;
}

