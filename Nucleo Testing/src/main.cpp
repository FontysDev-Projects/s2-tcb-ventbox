#include <Arduino.h>
#include <f401reMap.h>

int count;
int logData = 1;
int temp;
int hum;
int co;
int tvoc;
int dataTime = 1000;
unsigned long previousMillis = 0;
void setup()
{
  Serial.begin(9600);
}
// $#te-data-#hu-data-#co-data-#vo-data-%
// te-data-
// $ - start of the message
// # - start of a data stream
// te/hu/etc. - type of data transmited
// data - actual data
// "-" - separators

void addParameter(String *message, String data, int measurement)
{
  *message += data;
  *message += '-';
  *message += measurement;
  *message += "-";
}

String addData(int data)
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

void writeData()
{
  String dataToSend = "$";
  for (int i = 1; i < 5; i++)
  {
    dataToSend += addData(i);
  }
  dataToSend += "%";
  Serial.println(dataToSend);
}

void loop()
{
  temp = rand() % 100 + 101;
  hum = rand() % 100 + 201;
  co = rand() % 100 + 301;
  tvoc = rand() % 100 + 401;

  if (millis() - previousMillis == 2000)
  {
    writeData();
    previousMillis = millis();
  }
}