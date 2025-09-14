.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
ExitProcess PROTO : DWORD
.STACK 4096

.CONST

.DATA

INT0	DWORD	34
STR1	DB	"Alina",0

.CODE
main PROC
START :
push - 1
call ExitProcess
main ENDP
end main
