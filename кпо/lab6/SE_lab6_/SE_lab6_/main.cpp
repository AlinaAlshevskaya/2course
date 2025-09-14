#include "D://Documents/êïî/lab6/SE_lab6_/SE_lab6L/dict.h"
#pragma comment(lib, "D:\\Documents\\êïî\\lab6\\SE_lab6_\\Debug\\SE_lab6L.lib")
#include <iostream>
#include "Header.h"
#include <Windows.h>
using namespace std;

int main()
{
    setlocale(LC_ALL, "Russian");
    try {
#ifdef TEST_CREATE_01
        Instance test1 = Create("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX", 5);
#endif
#ifdef TEST_CREATE_02
        Instance test2 = Create((char*)"test", 100000000000);
#endif
#ifdef TEST_ADDENTRY_03
        Instance test3 = Create((char*)"test", 0);
        Entry en_test3 = { 1,"xxxxxx" };
        AddEntry(test3, en_test3);
#endif
#ifdef TEST_ADDENTRY_04 
        Instance test4 = Create((char*)"test", 2);
        Entry en_test4 = { 1,"xxxxxx" };
        AddEntry(test4, en_test4);
        AddEntry(test4, en_test4);
#endif
#ifdef TEST_GETENTRY_05
        Instance test5 = Create((char*)"test", 1);
        Entry en_test5 = { 1,"xxxxxx" };
        AddEntry(test5, en_test5);
        GetEntry(test5, 2);
#endif
#ifdef TEST_DELENTRY_06
        Instance test6 = Create((char*)"test", 1);
        Entry en_test6 = { 1,"xxxxxx" };
        AddEntry(test6, en_test6);
        DelEntry(test6, 2);
#endif
#ifdef TEST_UPDENTRY_07
        Instance test7 = Create((char*)"TEST", 5);
        Entry test_e7 = { 1,"xxxxxxxxx" }, test_upd_e7 = { 2,"zzzzzzzz" };
        AddEntry(test7, test_e7);
        UpdEntry(test7, 3, test_upd_e7);
#endif
#ifdef TEST_UPDENTRY_08
        Instance test8 = Create((char*)"TEST", 5);
        Entry test_e8 = { 1,"xxxxxxxxx" }, test_upd_e8 = { 1,"zzzzzzzz" };
        AddEntry(test8, test_e8);
        UpdEntry(test8, 1, test_upd_e8);
#endif
#ifdef TEST_DICTIONARY
        Instance d1 = Create("Teachers", 7);//creating dictionary
        //filling int with elements
        Entry e1 = { 1,"Beloded" }, e2 = { 2,"Smelov" }, e3 = { 3,"Shiman" }, e4 = { 4,"Narkevich" },
            e5 = { 5,"Chaikovskiy" }, e6 = { 6,"Urbanovich" }, e7 = { 7,"Tul'ev" };
        //add elements
        AddEntry(d1, e1);
        AddEntry(d1, e2);
        AddEntry(d1, e3);
        AddEntry(d1, e4);
        AddEntry(d1, e5);
        AddEntry(d1, e6);
        AddEntry(d1, e7);
        DelEntry(d1, 2);
        UpdEntry(d1, 4, { 12,"Shilov" });
        Print(d1);
        //dictionary for stusents
        Instance d2 = Create("Students", 7);
        Entry f1 = { 1,"Ivanov" }, f2 = { 2,"Petrov" }, f3 = { 3,"Sidorov" }, f4 = { 4,"Pupkin" },
            f5 = { 5,"Sergeev" }, f6 = { 6,"Fedorov" }, f7 = { 7,"Kozlov" };
        //filling with elements
        AddEntry(d2, f1);
        AddEntry(d2, f2);
        AddEntry(d2, f3);
        AddEntry(d2, f4);
        AddEntry(d2, f5);
        AddEntry(d2, f6);
        AddEntry(d2, f7);
        Print(d2);
#endif
    }
    catch (char* e) {
        cout << e << endl;
    }
}