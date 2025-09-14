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
		cout << "Цепочка " << fst1.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst1.chain << " ене распознана" << endl;
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
		cout << "Цепочка " << fst2.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst2.chain << " ене распознана" << endl;
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
		cout << "Цепочка " << fst3.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst3.chain << " не распознана" << endl;
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
		cout << "Цепочка " << fst4.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst4.chain << " не распознана" << endl;
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
		cout << "Цепочка " << fst5.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst5.chain << " не распознана" << endl;
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
		cout << "Цепочка " << fst6.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst6.chain << " не распознана" << endl;
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
		cout << "Цепочка " << fst7.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst7.chain << " не распознана" << endl;
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
		cout << "Цепочка " << fst8.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst8.chain << " не распознана" << endl;
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
		cout << "Цепочка " << fst9.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst9.chain << " не распознана" << endl;
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
		cout << "Цепочка " << fst10.chain << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst10.chain << " не распознана" << endl;
	}
}