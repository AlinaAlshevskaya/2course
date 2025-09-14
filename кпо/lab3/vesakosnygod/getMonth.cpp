#include <string>
std::string getMonthName(int monthNumber) {
    std::string months[] = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
    return months[monthNumber - 1];
}
