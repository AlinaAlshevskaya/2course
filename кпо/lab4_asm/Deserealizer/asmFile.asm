.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA

OK			EQU	0
TEXT_MESSAGE		DB "SE_Asm04", 0
HW			DD ?

FILESTRING DB <ûS
FILEINT DD 1268329984
INTSTR DD "int:     ", 0

.CODE

main PROC

invoke MessageBoxA, 0, ADDR FILESTRING, ADDR TEXT_MESSAGE, OK
mov eax,FILEINT add eax, 30hmov INTSTR+6, eaxinvoke MessageBoxA, 0, OFFSET INTSTR, ADDR TEXT_MESSAGE, OK
push - 1
call ExitProcess
main ENDP
end main
