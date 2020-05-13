#include <Arduino.h>
#include <f401reMap.h>
#include <bwoahProtocol.h> 
#include <iostream>

float a = 2.0;
// simulated data
float temp = (float)rand()/(float)(RAND_MAX) * a;
float hum = (float)rand()/(float)(RAND_MAX) * a + 2;
float co = (float)rand()/(float)(RAND_MAX) * a + 4;
float tvoc = (float)rand()/(float)(RAND_MAX) * a + 6;

//
String dataIncoming = "";
int readNow = 0;
//



unsigned long sendDataTime = 5000; // timer for sending data 
unsigned long previousMillisForSending = 0;

unsigned long showDataTime = 1000; // timer for reading the data
unsigned long previousMillisForShowing = 0;

unsigned long readDataTime = 100; // timer for reading the data
unsigned long previousMillisForReading = 0;

void setup()
{
  Serial.begin(9600);
  writeData(temp, hum, co, tvoc);
}
// $#te-data-#hu-data-#co-data-#vo-data-%
// te-data-
// $ - start of the message
// # - start of a data stream
// te/hu/etc. - type of data transmited
// can be '!' in case it is out of bounds or '-' in case it is normal
// data - actual data
// "-" - separators
void loop()
{
  if (millis() - previousMillisForSending == sendDataTime)
  {
    // sending the normal data
    writeData(temp, hum, co, tvoc);
    previousMillisForSending = millis(); // resetting the timer
  }
  if (millis() - previousMillisForShowing == showDataTime)
  {
    //reading the data from sensors
    // simulated data
    temp = (float)rand()/(float)(RAND_MAX) * a;
    hum = (float)rand()/(float)(RAND_MAX) * a + 2;
    co = (float)rand()/(float)(RAND_MAX) * a + 4;
    tvoc = (float)rand()/(float)(RAND_MAX) * a + 6;
    
    

    if(testTemp(temp) || testHum(hum) || testCO(co) || testTVOC(tvoc))
    {
      // if it is a sharp increase - out of bounds - sends the data
      writeData(temp, hum, co, tvoc);
      previousMillisForSending = millis(); // resetting the timer for sending data
    }
    // data read from simulated sensors
    // printLimits();
    Serial.print("Temperature: ");
    Serial.print(temp);
    Serial.print("   Humidity: ");
    Serial.print(hum);
    Serial.print("   CO2: ");
    Serial.print(co);
    Serial.print("   TVOC: ");
    Serial.println(tvoc);
    previousMillisForShowing = millis(); // resetting the timer
  }

  
    while(Serial.available())
    {
      char inChar = (char)Serial.read();

      if(inChar == '(')
      {
        dataIncoming = Serial.readStringUntil(')');
      }
      
      modifyParamThreshold(getParamNameThreshold(dataIncoming), getParamValueThreshold(dataIncoming)); 
      
      dataIncoming = "";
    }
    
  
  
}