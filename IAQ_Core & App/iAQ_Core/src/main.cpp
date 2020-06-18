#include <Arduino.h>
#include <Wire.h>
#include <iAQcore.h>


iAQcore myCore;


uint16_t co2;           //unisgned integer, holds the CO2 readings (= carbon dioxide reading, in ppm)
uint16_t stat;          //unisgned integer, holds the status readings (0x00 = ok, 0x10 = core is warming up, 0x01 = busy, 0x80 = error)
uint32_t resistance;    //unisgned integer, holds the Resistance value of the core (in Ohms)
uint16_t tvoc;          //unisgned integer, holds the VOC readings (= Total Volatile Organic Compounds, in ppb)


const int DELAY = 1000;                     //delay time
unsigned long int millisRead = 0;           //holds current millis() value  
unsigned long int millisDifference = 0;     //holds 0 (at start of code)or previous millis() value


void printData()
{
  Serial.print("CO2 Reading: ");        Serial.print(co2);          Serial.print(" ppm,  ");
  Serial.print("Status Reading: 0x");   Serial.print(stat, HEX);    Serial.print(",  ");
  Serial.print("Resistance reading: "); Serial.print(resistance);   Serial.print(" Ohms,  ");
  Serial.print("TVOC Reading: ");       Serial.print(tvoc);         Serial.print(" ppb");
  Serial.println();
}


void setup() {
  Serial.begin(9600);   //Set serial baudrate
  Wire.setSDA(14); 
  Wire.setSCL(15); 
  Wire.begin();
  myCore.begin();       //Initiate iAQcore library
  Serial.println("\t\t\t\t\t\t~~~iAQ_Core~~~");
  Serial.println("\t\t\t\t\tversion: 1.0, April 12 2020");
  Serial.println("");
}


void loop() {
  millisRead = millis();    //read millis
  if ((millisRead - millisDifference) > DELAY)    //millis loop, if one second (or specified delay) has passed, do this...
  {
    myCore.read(&co2, &stat, &resistance, &tvoc); //reads bytes from the voc sensor, if a specific section (i.e. status) does not need to be read, leave that parameter out (= NULL)
    printData();                                  //prints all the read data
    millisDifference = millisRead;                //reset the millis loop
  }
}