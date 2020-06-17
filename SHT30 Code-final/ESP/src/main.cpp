#include <SHT3x.h>
#include <math.h>

double temp;     //Current temperature reading
double hum;      //Current humidity reading
double prevTemp; //Temperature to compare against
double prevHum;  //Humidity to compare against
const double tempThreshold = 1;
const double humThreshold = 10;

unsigned long timer;

String message;

SHT3x Sensor;

void PrintData();

void setup()
{
  Serial.begin(19200);
  Sensor.Begin(); //Initialize the sensor
}

void loop()
{
  Sensor.UpdateData();
  temp = Sensor.GetTemperature();                                                    //Store the new temperature into the variable
  hum = Sensor.GetRelHumidity();                                                     //Same for the humidity
  if ((abs(temp - prevTemp) > tempThreshold) || (abs(hum - prevHum) > humThreshold)) //If there has been a sharp increase/decrease
  {
    PrintData();
  }
  if (millis() - timer > 10000) //Used to send the data every ten seconds
  {
    PrintData();
  }
}

void PrintData()
{
  message = "$te-";
  message += temp;
  message += "&hu-";
  message += hum;
  message += "%";
  Serial.println(message); //Sending the humidity protocol
  delay(500);
  prevTemp = temp; //Updating the temperature and humidity variables to compare against
  prevHum = hum;
  timer = millis(); //Reset the timer
}