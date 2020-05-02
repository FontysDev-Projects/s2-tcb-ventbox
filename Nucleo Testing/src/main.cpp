#include <Arduino.h>
#include "iAQcore.h"
#include "Wire.h"

bool readAlready = false;

int logData = 1;
int dataTime = 1000;
unsigned long previousMillis = 0;

uint16_t count, temp, hum, co, tvoc;
iAQcore myCore;

void setup()
{
  Serial.begin(9600);
  Wire.setSDA(14); 
  Wire.setSCL(15); 
  Wire.begin();
  myCore.begin();
}
// $#te-data-#hu-data-#co-data-#vo-data-%
// te-data-
// $ - start of the message
// # - start of a data stream
// te/hu/etc. - type of data transmited
// data - actual data
// "-" - separators

void readTVOC()
{
  if(!readAlready)
  {
    myCore.read(NULL, NULL, NULL, &tvoc);
    readAlready = true;
  }
}

void addParameter(String *message, String data, uint16_t measurement)    //builds components of message
{
  *message += data;
  *message += '-';
  *message += measurement;
  *message += "-";
}

String addData(uint16_t data)  //adds components to message
{
  String dataToAdd = "#";
  switch (data)
  {
  case 1:
    addParameter(&dataToAdd, "te", temp);
    break;
  case 2:
    addParameter(&dataToAdd, "hu", hum);
    break;
  case 3:
    addParameter(&dataToAdd, "co", co);
    break;
  case 4:
    addParameter(&dataToAdd, "vo", tvoc);
    break;
  default:
    break;
  }
  return dataToAdd;
}

void writeData()  //prints message on monitor
{
  String dataToSend = "$";
  for (int i = 1; i < 5; i++)
  {
    dataToSend += addData(i);
  }
  dataToSend += "%";
  Serial.println(dataToSend);
  readAlready = false;
}

void loop()   //generates data for components of message
{
  temp = rand() % 100 + 101;
  hum = rand() % 100 + 201;
  co = rand() % 100 + 301;
  readTVOC();

  if (millis() - previousMillis == 2000)
  {
    writeData();
    previousMillis = millis();
  }
}