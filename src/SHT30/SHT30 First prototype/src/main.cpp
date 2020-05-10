#include <Arduino.h>
#include <Wire.h>

#include <SHTSensor.h>
#include <bwoahProtocol.h>

SHTSensor SHTSENSE;

float hum = 0;
float temp = 0;
int co;
int tvoc;

int humidityThreshold = 2;
int temperatureThreshold = 1;

float prevHum = 0;
float prevTemp = 0;

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
  temDif = temp - prevTemp;
  if (abs(humDif) > humidityThreshold)
  {
    writeData(temp, hum, co, tvoc);
    prevHum = hum;
  }
  if (abs(temDif) > temperatureThreshold)
  {
    writeData(temp, hum, co, tvoc);
    prevTemp = temp;
  }
  delay(1000);
}
