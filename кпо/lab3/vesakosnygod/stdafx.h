#pragma once
#include <iostream>
#include <string>

bool checkdate(std::string);
bool isLeapYear(int);
int dayOfYear(int, int, int);
bool checkmonthday(int, int, int, bool(int));
std::string getMonthName (int);
std::string  getDateFromDayNumber(int,bool);
