#include <Arduino.h>
#include <Wire.h>

#include <SHTSensor.h>

SHTSensor SHTSENSE;

float hum = 0;
float temp = 0;
int co;
int tvoc;

float prevHum = 0;
float prevTem = 0;

float humDif = 0;
float temDif = 0;

void addParameter(String *message, String data, int measurement);
String addData(int data);
void writeData();

void setup()
{
  Serial.begin(9600);
  Serial.println("Initializing SHT30 Temperature and Humidity sensor");
  delay(1000);
  Wire.begin();
  delay(100);
  SHTSENSE.init();
}

void loop()
{
  SHTSENSE.readSample();
  hum = SHTSENSE.getHumidity();
  temp = SHTSENSE.getTemperature();
  co = rand() % 100 + 301;
  tvoc = rand() % 100 + 401;
  humDif = hum - prevHum;
  temDif = temp - prevTem;
  if (abs(humDif) > 2)
  {
    writeData();
    prevHum = hum;
  }
  if (abs(temDif) > 1)
  {
    writeData();
    prevTem = temp;
  }
  delay(1000);
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

void addParameter(String *message, String data, int measurement)
{
  *message += data;
  *message += '-';
  *message += measurement;
  *message += "-";
}
