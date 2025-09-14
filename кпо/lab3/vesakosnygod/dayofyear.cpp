#include "stdafx.h"

int dayOfYear(int day, int month, int year) {
    int daysInMonth[] = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    if (isLeapYear(year)) { 
        daysInMonth[2] = 29;
    }
    int ordinalDay = 0;
    for (int i = 1; i < month; ++i) {
        ordinalDay += daysInMonth[i];
    }
    ordinalDay += day;
    return ordinalDay;
}