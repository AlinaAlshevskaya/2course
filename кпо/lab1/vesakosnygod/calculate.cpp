#include <iostream>
#include <stdlib.h>
#include <string>
#include "stdafx.h"
using namespace std;


int main() {
    setlocale(LC_ALL, "Russian");
    int day, month, year, byear, bday, bmonth, data, bthday;
    string sdata, sbthday, stryear,strmonth,strday;
    std::cout << "Введите дату в формате ДДММГГГГ: ";
    std::cin >> sdata;
    if (checkdate(sdata)==false) return 0;  
    for (int i = 4; i > 0; i--) {
        stryear += sdata[i];
    }
    if (checkmonthday(month, day, year, isLeapYear) == false) return 0;
   
    cout << "Введите дату дня рождения в формате ДДММГГГГ: ";
    cin >> sbthday;
    if (checkdate(sbthday) == false) return 0;
    bthday = std::stoi(sbthday);
    byear = year;
    bthday = bthday / 10000;
    bmonth = bthday % 100;
    bthday = bthday / 100;
    bday = bthday;
    if (checkmonthday(bmonth, bday, byear, isLeapYear) == false) return 0;


    if (isLeapYear(year)) {
        cout << "Введенный год " << year << " - високосный." << endl;
    }
    else {
        cout << "Введенный год " << year << " - не високосный." << endl;
    }

    int ordinalDay = dayOfYear(day, month, year);
    cout << "Порядковый номер введенного дня в году: " << ordinalDay << endl;
     int ordinalbthday= dayOfYear(bday, bmonth, byear);

     if (ordinalDay< ordinalbthday ) {
         int daysUntilBirthday = ordinalbthday - ordinalDay;
         cout << "До ближайшего дня вашего рождения осталось " << daysUntilBirthday << " дней." << endl;
     }
     else if ( ordinalDay> ordinalbthday) {
         int daysUntilBirthday = 365 - (ordinalDay-ordinalbthday);
         cout << "До ближайшего дня вашего рождения осталось " << daysUntilBirthday << " дней." << endl;
     }
     else cout << "День рождения сегодня";
  
    

    return 0;
}