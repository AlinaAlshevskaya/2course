#include "stdafx.h"

namespace Log
{
	LOG getlog(wchar_t logfile[])
	{
		LOG log;

		log.stream = new ofstream;
		log.stream->open(logfile);

		if (!log.stream->is_open())
			throw ERROR_THROW(112);


		wcscpy_s(log.logfile, logfile);

		return log;
	};


	void WriteLine(LOG log, char* c, ...)
	{
		char** p = &c;

		while (*p != "")
		{
			(*log.stream) << *p;
			*p ++;
		}
		*log.stream << endl;
	};


	void WriteLine(LOG log, wchar_t* c, ...)
	{
		wchar_t** p = &c;
		char buffer[64];

		while (*p != L"")
		{
			wcstombs(buffer, *p, sizeof(buffer));
			(*log.stream) << buffer;
			*p ++ ;
		}
	};


	void WriteLog(LOG log)
	{
		char buffer[PARM_MAX_SIZE];

		time_t rawtime;
		struct tm* timeinfo;

		time(&rawtime);
		timeinfo = localtime(&rawtime);

		strftime(buffer, PARM_MAX_SIZE, "Дата: %d.%m.%y %H:%M:%S", timeinfo);
		(*log.stream) << "\n--—- Протокол ——--\n" << buffer << "\n";
	};


	void WriteParm(LOG log, Parm::PARM parm)
	{
		char inInfo[PARM_MAX_SIZE];
		char outInfo[PARM_MAX_SIZE];
		char logInfo[PARM_MAX_SIZE];

		wcstombs(inInfo, parm.in, sizeof(inInfo));
		wcstombs(outInfo, parm.out, sizeof(outInfo));
		wcstombs(logInfo, parm.log, sizeof(logInfo));

		(*log.stream) << "--—- Параметры ——--\n"
			<< " -in: \t" << inInfo << "\n"
			<< " -out:\t" << outInfo << "\n"
			<< " -log:\t" << logInfo << "\n";
	};


	void WriteIn(LOG log, In::IN in)
	{
		(*log.stream) << "--—- Исходные данные ——-- \n"
			<< "Кол-во символов:\t" << in.size << "\n"
			<< "Кол-во строк:   \t" << in.lines << "\n"
			<< "Пропущенно:     \t" << in.ignor << "\n";
	};


	void WriteError(LOG log, Error::ERROR error)
	{
		*log.stream << "Errors"<<endl;
		*log.stream << "Error" << error.id << error.message << endl;
		if (error.inext.line != -1) {
			*log.stream << "Ошибка " << error.id << " " << error.message << "в строке " << error.inext.line << " в колонке " << error.inext.col << endl;
		}

	};


	void Close(LOG log)
	{
		log.stream->close();
		delete log.stream;
	}
};