#include "FST.h"
 

void main()
{
	setlocale(LC_ALL, "russian");
	char stringline1[] = "OSW;SC";
	FST::FST fst1(
		stringline1, 
		7,
		FST::NODE(1,FST::RELATION('O',1)),
		FST::NODE(1,FST::RELATION('S',2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

		);

	if (FST::execute(fst1)) {
		cout << "������� " << fst1.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst1.chain << " ��� ����������" << endl;
	}

	char stringline2[] = "OSSSW;R;SSSC";
	FST::FST fst2(
		stringline2,
		7,
		FST::NODE(1, FST::RELATION('O', 1)),
		FST::NODE(1, FST::RELATION('S', 2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

	);

	if (FST::execute(fst2)) {
		cout << "������� " << fst2.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst2.chain << " ��� ����������" << endl;
	}

	char stringline3[] = "OSW;R;E;SSSSC";
	FST::FST fst3(
		stringline3,
		7,
		FST::NODE(1, FST::RELATION('O', 1)),
		FST::NODE(1, FST::RELATION('S', 2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

	);

	if (FST::execute(fst3)) {
		cout << "������� " << fst3.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst3.chain << " �� ����������" << endl;
	}


	char stringline4[] = "OSSSSSW;E;SC";
	FST::FST fst4(
		stringline4,
		7,
		FST::NODE(1, FST::RELATION('O', 1)),
		FST::NODE(1, FST::RELATION('S', 2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

	);

	if (FST::execute(fst4)) {
		cout << "������� " << fst4.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst4.chain << " �� ����������" << endl;
	}

	char stringline5[] = "OSSSSW;R;E;W;R;E;SSSSC";
	FST::FST fst5(
		stringline5,
		7,
		FST::NODE(1, FST::RELATION('O', 1)),
		FST::NODE(1, FST::RELATION('S', 2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

	);

	if (FST::execute(fst5)) {
		cout << "������� " << fst5.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst5.chain << " �� ����������" << endl;
	}

	char stringline6[] = "OSW;E;R;R;E;SC";
	FST::FST fst6(
		stringline6,
		7,
		FST::NODE(1, FST::RELATION('O', 1)),
		FST::NODE(1, FST::RELATION('S', 2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

	);

	if (FST::execute(fst6)) {
		cout << "������� " << fst6.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst6.chain << " �� ����������" << endl;
	}

	char stringline7[] = "OSSSSW;R;E;E;E;SSSSSSC";
	FST::FST fst7(
		stringline7,
		7,
		FST::NODE(1, FST::RELATION('O', 1)),
		FST::NODE(1, FST::RELATION('S', 2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

	);

	if (FST::execute(fst7)) {
		cout << "������� " << fst7.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst7.chain << " �� ����������" << endl;
	}

	char stringline8[] = "OW;SSC";
	FST::FST fst8(
		stringline8,
		7,
		FST::NODE(1, FST::RELATION('O', 1)),
		FST::NODE(1, FST::RELATION('S', 2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

	);

	if (FST::execute(fst8)) {
		cout << "������� " << fst8.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst8.chain << " �� ����������" << endl;
	}

	char stringline9[] = "OSW;Y;SSC";
	FST::FST fst9(
		stringline9,
		7,
		FST::NODE(1, FST::RELATION('O', 1)),
		FST::NODE(1, FST::RELATION('S', 2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

	);

	if (FST::execute(fst9)) {
		cout << "������� " << fst9.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst9.chain << " �� ����������" << endl;
	}

	char stringline10[] = "OSW;R;SS";
	FST::FST fst10(
		stringline10,
		7,
		FST::NODE(1, FST::RELATION('O', 1)),
		FST::NODE(1, FST::RELATION('S', 2)),
		FST::NODE(4, FST::RELATION('S', 2), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(1, FST::RELATION(';', 4)),
		FST::NODE(4, FST::RELATION('S', 5), FST::RELATION('E', 3), FST::RELATION('R', 3), FST::RELATION('W', 3)),
		FST::NODE(2, FST::RELATION('S', 5), FST::RELATION('C', 6)),
		FST::NODE()

	);

	if (FST::execute(fst10)) {
		cout << "������� " << fst10.chain << " ����������" << endl;
	}
	else {
		cout << "������� " << fst10.chain << " �� ����������" << endl;
	}
}