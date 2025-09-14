#include "Varfuncr.h"

int ivarparm(int a, ...)
{
	int* p = &a;
	int product = 1;
	p++;
	for (int i =0; i <= a; i++)
		product *= *(p + i);
	return product;
}

int svarparm(short b, ...)
{
	int* p = (int*)(&b);
	int product = 1;
	p++;
	for (short i = 0; i <= b; i++)
		product *= *(p + i);
	return product;
}

double fvarparm(float c, ...) {
	double* p = (double*)(&c);
	double sum =0;
	int i = 0;
	while (p[i] != (double)FLT_MAX) {
		sum+= *(p + i);
		i++;
	}
	return sum;
}

double dvarparm(double d, ...) {
	double* p = &d;
	double sum = 0;
	int i = 0;
	while (p[i] != DBL_MAX) {
		sum += *(p + i);
		i++;
	}
	return sum;
}