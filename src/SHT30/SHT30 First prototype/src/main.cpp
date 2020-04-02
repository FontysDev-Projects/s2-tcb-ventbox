#include <Arduino.h>
#include <Wire.h>

#include <SHTSensor.h>

SHTSensor SHTSENSE;

float humidity = 0;
float previousHumidity = 0;
float temperature = 0;
float previousTemperature = 0;
float humidityDifference = 0;
float temperatureDifference = 0;
unsigned long lastMillis = 0;

void setup()
{
  Serial.begin(9600);
  Serial.println("14CORE | Temperature & Humidity Test Code");
  delay(1000);
  Serial.println("Initializing..............");
  delay(4000);
  Wire.begin();
  delay(100);
  SHTSENSE.init();
}

void loop()
{
  SHTSENSE.readSample();
  humidity = SHTSENSE.getHumidity();
  temperature = SHTSENSE.getTemperature();
  humidityDifference = humidity - previousHumidity;
  temperatureDifference = temperature - previousTemperature;
  if (abs(humidityDifference) > 2)
  {
    Serial.print("  Relative humidity: ");
    Serial.print(humidity, 2);
    Serial.print("\n");
  }
  if (abs(temperatureDifference) > 1)
  {
    Serial.print("  Temperature:  ");
    Serial.print(temperature, 2);
    Serial.print("\n");
  }
  previousHumidity = humidity;
  previousTemperature = temperature;
  lastMillis = millis();
  delay(1000);
}