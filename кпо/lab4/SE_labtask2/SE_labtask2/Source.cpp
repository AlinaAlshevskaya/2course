#include <iostream>
#include <string>

// Определение псевдонимов типов данных
typedef unsigned int AccountNumberType ;
typedef  std::string DepositType ;
typedef  float BalanceType;
typedef std::string DateType;
typedef std::string OwnerType;
typedef float SmsNotificationType;
typedef float InternetBankingType;

struct BankAccount {
    AccountNumberType accountNumber; // Номер счета
    DepositType depositType;   // Тип вклада
    BalanceType balance;            // Баланс
    DateType openingDate;   // Дата открытия
    OwnerType owner;         // Владелец
    SmsNotificationType smsNotification=10.0;      // Подключение смс оповещения
    InternetBankingType internetBanking=20.0;      // Подключение интернет-банкинга

};
    bool operator >= (BankAccount smsNotificationType1,BankAccount BalanceType) {
        return (smsNotificationType1.smsNotification > BalanceType.balance );
    }

    
    bool operator <= (BankAccount InternetBankingType1, BankAccount BalanceType) {
        return (InternetBankingType1.internetBanking < BalanceType.balance);
    }

  
    int operator + (BankAccount BalanceType1, BankAccount BalanceType2) {
        return (BalanceType1.balance + BalanceType2.balance);
    }

int main() {
    setlocale(LC_ALL, "Russian");
    BankAccount myAccount1;
    myAccount1.balance = 1000.0;
    BankAccount myAccount2;
    myAccount2.balance = 2000.0;
    if (myAccount1 >= myAccount1) { std::cout << "Подключить функцию смс оповещения нельзя" <<std:: endl; } else{ std::cout << "Подключить функцию смс оповещения можно" << std::endl; }
    if (myAccount1 <= myAccount1) { std::cout << "Подключить функцию интернет-банкинга можно" <<std::endl; }
    else { std::cout << "Подключить функцию интернет-банкинга нельзя" << std::endl; }
    std::cout << myAccount1 + myAccount2 << std::endl;
    

    return 0;
}