// -- main 
#include "stdafx.h"
#include "Auxil.h"
#include <iostream>
#include <iomanip> 
#include <time.h>
#include "Salesman.h"
#include <tchar.h>
#define SPACE(n) std::setw(n)<<" "
#define N 5
int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");
    int d[N * N + 1], r[N];
    d[0] = INF;    d[1] = 2;     d[2] = 22;    d[3] = INF;   d[4] = 1;
    d[5] = 1;     d[6] = INF;   d[7] = 16;    d[8] = 67;    d[9] = 83;
    d[10] = 3;    d[11] = 3;    d[12] = INF;  d[13] = 86;   d[14] = 50;
    d[15] = 18;   d[16] = 57;   d[17] = 4;    d[18] = INF;  d[19] = 3;
    d[20] = 92;   d[21] = 67;   d[22] = 52;   d[23] = 14;   d[24] = INF;

    auxil::start();
    /*for (int i = 0; i <= N * N; i++) d[i] = auxil::iget(10, 100);*/
    std::cout << std::endl << "-- Задача коммивояжера -- \n";

    //clock_t t1, t2;
    //for (int i = 7; i <= N; i++)
    //{
    //  /*  t1 = clock();*/
    //    salesman(i, (int*)d, r);
    //  /*  t2 = clock();*/
    //    /*std::cout << std::endl << SPACE(7) << std::setw(2) << i
    //        << SPACE(15) << std::setw(5) << (t2 - t1);*/
    //}
    salesman(5, (int*)d, r);
    for (int i = 0; i < N; i++) {
        std::cout << r[i]+1;
        std::cout << "  ";
        
    }
    std::cout<<std::endl;
    std::cout << std::endl;
    system("pause");
    return 0;
}
