#include <Arduino.h>

#include <bwoahProtocol.h>

#include <CO2.h>
#include <ErrorHandler.h>

#define RX_PIN PIND5
#define TX_PIN PIND4

typedef enum PROGRAM_STATE
{
  IDLE,
  DATA_TRANSFERING,
  SENSOR_CALIBRATION,

} PROGRAM_STATE;

typedef enum DATA_PROCESSING_STATE
{
  DATA_FETCHING,
  DATA_PREPARATION,
  DATA_SEDNDING

} DATA_PROCESSING_STATE;

PROGRAM_STATE ProgramState = SENSOR_CALIBRATION;
DATA_PROCESSING_STATE DataProcessingState = DATA_FETCHING;

CO2 co2Sensor(RX_PIN, TX_PIN);

int CO2_Levels = 0;

void setup()
{
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("---Start!---");
  // co2Sensor.init();
}

void loop()
{
  delay(100); // simulates doing something else

  CO2_Levels = co2Sensor.getMesurments();
  writeData(100, 100, CO2_Levels, 100);
}

// switch (ProgramState)
// {
// case IDLE:
//   // ProgramState = SENSOR_CALIBRATION;
//   break;
// case DATA_TRANSFERING:
//   // Serial.print("The CO2 value is: ");
//   // Serial.print(co2Sensor.getMesurments());
//   // Serial.print('\n');
//   // ProgramState = IDLE;

//   switch (DataProcessingState)
//     // {
//     // case DATA_FETCHING:
//     //   // fetch data from the sensors
//     //   CO2_Levels = co2Sensor.getMesurments();
//     //   break;
//     // case DATA_PREPARATION:
//     //   // Format data, and prepare it for sending throught the Zigbee

//     //   break;
//     // case DATA_SEDNDING:
//     //   // Send the formated data to the server(C# App)
//     //   break;
//     // }
//     CO2_Levels = co2Sensor.getMesurments();

//   writeData(100, 100, CO2_Levels, 100);

//   break;
// case SENSOR_CALIBRATION:
//   // calibrating sequense for the sensors
//   if (co2Sensor.calibrateSensor(400) == 0)
//     Serial.println("Sensor calibrated!");
//   else
//     Serial.println("Sensor calibration failed!");

//   ProgramState = DATA_TRANSFERING;
//   break;
// }
// Serial.println(ErrorHandler(co2Sensor.getMesurments()));
// Serial.print("The CO2 value is: ");
// Serial.print(co2Sensor.getMesurments());
// Serial.print('\n');

// delay(5000);

// // read data

// // interup to send

// //