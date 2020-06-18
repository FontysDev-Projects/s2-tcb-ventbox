#ifndef ERROR_HANDLER
#define ERROR_HANDLER

#include <String.h>

#define INVALID_INPUT -1
#define INVALID_HEAD_FRAME -2
#define INVALID_COMMAND_FRAME -3
#define INVALID_CHECKSUM_FRAME -4
#define UNKNOWN_ERROR -5
#define ToString(a) ({                   \
    char Msg[22] = "The CO2 value is: "; \
    itoa(a, Msg + 18, 10);               \
    Msg; })

char *ErrorHandler(int);

#endif