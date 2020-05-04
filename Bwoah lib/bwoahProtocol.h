#ifndef bwoahProtocol_h
#define bwoahProtocol_h

#include <Arduino.h>

int testTemp(float parameter);
int testHum(float parameter);
int testCO(float parameter);
int testTVOC(float parameter);
int testSharpRaise(float parameter, float margin);
void addParameter(String *message, String data, float measurement, int sharpRaise);
String addData(int data, float temp, float hum, float co, float tvoc);
void writeData(float temp, float hum, float co, float tvoc);

#endif