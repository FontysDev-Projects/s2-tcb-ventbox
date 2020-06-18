#ifndef CO2Sensor
#define CO2Sensor

#include <Arduino.h>
#include <SoftwareSerial.h>

// Command HEX CODE
#define ReceiveStartByte 0x16
#define GetMesurmentsCommandHEX 0x01
#define CalibrateCommandCommandHEX 0x03
#define AutoCalCommandHEX 0x10
#define LastCommand lastCommand[2]

// Command Buffers Lenghts
#define GetMesurmentCommandLenght 4
#define CalibrateCommandLenght 6
#define AutoCalCommandLenght 10

// AutoCalibration Comand Specification Definitions
#define AutoCalibrationEnabled 0
#define AutoCalibrationDisabled 0x02
#define AutoCalDF2 4
#define AutoCalDF3 5
#define AutoCalDF4_1 6
#define AutoCalDF4_2 7
#define AutoCalDF5_1 8
#define AutoCalDF5_2 9

//
#define CheckSumConst 256
#define RecievedBytesMaxLenghts 8

class CO2
{
public:
    //Constructor
    CO2(uint8_t _pinRx, uint8_t _pinTx);
    //methods
    void init();
    int getMesurments();
    int calibrateSensor(uint16_t);
    int enableAutoCalibration(uint8_t calibrationCyclePeriod = 0x0F, uint16_t calibrationMinValue = 400, uint16_t calibrationMaxValue = 1500);
    int disableAutoCalibration();

private:
    //Fields
    SoftwareSerial *CO2_Serial;
    // Command Tables
    uint8_t _getMesurment[GetMesurmentCommandLenght] = {0x11, 0x01, 0x01, 0xED};
    uint8_t _calibrateSensor[CalibrateCommandLenght] = {0x11, 0x03, 0x03, 0, 0, 0};
    uint8_t _autoCalibarion[AutoCalCommandLenght] = {0x11, 0x07, 0x10, 0x64, 0, 0x0F, 0x01, 0x90, 0x64, 0};
    // Buffer for the received information
    byte recievedByte[RecievedBytesMaxLenghts];
    //methods
    int sendCommand(uint8_t *, uint8_t);
    void recieveData();
    int processData(uint8_t *);
};

#endif