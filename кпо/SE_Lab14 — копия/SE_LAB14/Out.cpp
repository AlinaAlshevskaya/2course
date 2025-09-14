#include "stdafx.h"

namespace Out {

	OUT getOut(wchar_t outFile[])
	{
		OUT out = INITOUT;

		out.stream = new ofstream(outFile);

		if (!out.stream)
			throw ERROR_THROW(112);

		return out;
	};

	void WriteOut(wchar_t outFile[], In::IN in) {

		ofstream file_out(outFile);

		if (!file_out.is_open()) {
			throw ERROR_THROW(113);
		}

		file_out << in.text << endl;
		file_out.close();
	}

	void WriteError(OUT out, Error::ERROR error) {
		*out.stream << "Errors" << endl;
		*out.stream << "Error " << error.id << " " << error.message << endl;
		if (error.inext.line != -1) {
			*out.stream << "Ошибка " << error.id << " " << error.message << " в строке " << error.inext.line << " колонке " << error.inext.col << endl;
		}

	}
	void Close(OUT out) {
		out.stream->close();
		delete out.stream;
	}

}