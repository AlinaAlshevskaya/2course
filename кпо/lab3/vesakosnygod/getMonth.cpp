#include <string>
std::string getMonthName(int monthNumber) {
    std::string months[] = { "������", "�������", "����", "������", "���", "����", "����", "������", "��������", "�������", "������", "�������" };
    return months[monthNumber - 1];
}
