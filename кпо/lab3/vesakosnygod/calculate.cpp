#include <iostream>
#include <stdlib.h>
#include <string>
#include "stdafx.h"
using namespace std;


int main() {
    setlocale(LC_ALL, "Russian");
    int day, month, year, byear, bday, bmonth, data, bthday;
    string sdata,stryear,strmonth,strday,strbday,strbdata,strbmonth,strbyear;
    std::cout << "Введите дату в формате ДДММГГГГ: ";
    std::cin >> sdata;
    if (checkdate(sdata)==false) return 0;  
    if (checkdate(sdata) == false) return 0;
    for (int i = 4; i <8; i++) {
        stryear += sdata[i];
    }
    year = std::stoi(stryear);
    for (int i = 2; i <4; i++) {
        strmonth += sdata[i];
    }
    month = std::stoi(strmonth);
    for (int i = 0; i <2; i++) {
        strday += sdata[i];
    }
    day = std::stoi(strday);

    if (checkmonthday(month, day, year, isLeapYear) == false) return 0;
    
   
    cout << "Введите дату дня рождения в формате ДДММГГГГ: ";
    cin >> strbdata;
    if (checkdate(strbdata) == false) return 0;
    if (checkdate(strbdata) == false) return 0;
    for (int i = 4; i < 8; i++) {
        strbyear += strbdata[i];
    }
    byear = std::stoi(strbyear);
    for (int i = 2; i < 4; i++) {
        strbmonth += strbdata[i];
    }
    bmonth = std::stoi(strbmonth);
    for (int i = 0; i < 2; i++) {
        strbday += strbdata[i];
    }
    bday = std::stoi(strbday);
    if (checkmonthday(bmonth, bday, byear, isLeapYear) == false) return 0;

    bool tfyear = isLeapYear(year);


    if (tfyear) {
        cout << "Введенный год " << year << " - високосный." << endl;
    }
    else {
        cout << "Введенный год " << year << " - не високосный." << endl;
    }
    cout << "Это месяц " << getMonthName(month) << endl;

    int ordinalDay = dayOfYear(day, month, year);
    cout << "Порядковый номер введенного дня в году: " << ordinalDay << endl;
     int ordinalbthday= dayOfYear(bday, bmonth, year);

     int dayNumber = 256; // День программиста
     std::cout << "День под номером " << dayNumber << " приходится на: " << getDateFromDayNumber(dayNumber,tfyear) << std::endl;


     if (tfyear) {
         if (ordinalDay < ordinalbthday) {
             int daysUntilBirthday = ordinalbthday - ordinalDay;
             cout << "До ближайшего дня вашего рождения осталось " << daysUntilBirthday << " дней." << endl;
         }
         else if (ordinalDay > ordinalbthday) {
             int daysUntilBirthday = 366 - (ordinalDay - ordinalbthday);
             cout << "До ближайшего дня вашего рождения осталось " << daysUntilBirthday << " дней." << endl;
         }
         else cout << "День рождения сегодня";
     } else
     {
         if (ordinalDay < ordinalbthday) {
             int daysUntilBirthday = ordinalbthday - ordinalDay;
             cout << "До ближайшего дня вашего рождения осталось " << daysUntilBirthday << " дней." << endl;
         }
         else if (ordinalDay > ordinalbthday) {
             int daysUntilBirthday = 365 - (ordinalDay - ordinalbthday);
             cout << "До ближайшего дня вашего рождения осталось " << daysUntilBirthday << " дней." << endl;
         }
         else cout << "День рождения сегодня";
     }

  
    

    return 0;
}