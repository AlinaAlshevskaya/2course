# include<string>
#include "stdafx.h"

std::string getDateFromDayNumber(int dayNumber,bool year) {
    int daysInMonth[] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    if (year) {
        daysInMonth[1] = 29;
    }
    int month = 0;
    while (dayNumber > daysInMonth[month]) {
        dayNumber -= daysInMonth[month];
        month++;
    }
    return std::to_string(dayNumber) + " " + getMonthName(month + 1);
}