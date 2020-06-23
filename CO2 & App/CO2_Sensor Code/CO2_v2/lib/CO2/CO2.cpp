#include <CO2.h>
#include <ErrorHandler.h>

CO2 ::CO2(uint8_t _pinRx, uint8_t _pinTx)
{
    CO2_Serial = new SoftwareSerial(_pinRx, _pinTx);
    CO2_Serial->begin(9600);
}
void CO2 ::init()
{

    // this->getMesurments();
    // this->calibrateSensor(400);
    // this->disableAutoCalibration();
}

int CO2 ::getMesurments()
{
    // Sends the command to the sensor and receives data back
    return sendCommand(_getMesurment, GetMesurmentCommandLenght);
}

int CO2 ::calibrateSensor(uint16_t calibrationValue)
{
    uint8_t CheckSum = 0;
    // Make sure the input is in bounds
    if (calibrationValue < 400 || calibrationValue > 1500)
        return -1;

    // Configures the command anda calculates the CheckSum
    for (int i = 0; i < 5; i++)
    {
        if (i == 3)
            _calibrateSensor[i] = calibrationValue;
        if (i == 4)
            _calibrateSensor[i] = calibrationValue >> 8;

        CheckSum += _calibrateSensor[i];
    }
    _calibrateSensor[5] = CheckSumConst - CheckSum;

    // Sends the command to the sensor and receives data back
    return sendCommand(_calibrateSensor, CalibrateCommandLenght);
}

int CO2 ::enableAutoCalibration(uint8_t calibrationCyclePeriod = 0x0F, uint16_t calibrationMinValue = 400, uint16_t calibrationMaxValue = 1500)
{
    if (calibrationCyclePeriod <= 0)
        return -1;
    if (calibrationMinValue < 400)
        return -1;
    if (calibrationMaxValue > 1500)
        return -1;

    uint8_t CheckSum = 0;
    // Configures the command anda calculates the CheckSum
    for (int i = 0; i < AutoCalCommandLenght - 1; i++)
    {
        switch (i)
        {
        case AutoCalDF2:
            _autoCalibarion[i] = AutoCalibrationEnabled;
            break;
        case AutoCalDF3:
            _autoCalibarion[i] = calibrationCyclePeriod;
            break;
        case AutoCalDF4_1:
            _autoCalibarion[i] = (uint8_t)calibrationMinValue;
            break;
        case AutoCalDF4_2:
            _autoCalibarion[i] = (uint8_t)(calibrationMinValue >> 8);
            break;
        case AutoCalDF5_1:
            _autoCalibarion[i] = (uint8_t)calibrationMaxValue;
            break;
        case AutoCalDF5_2:
            _autoCalibarion[i] = (uint8_t)(calibrationMaxValue >> 8);
            break;
        }

        CheckSum += _autoCalibarion[i];
    }

    _autoCalibarion[AutoCalCommandLenght - 1] = CheckSumConst - CheckSum;

    // Sends the command to the sensor and receives data back
    return sendCommand(_autoCalibarion, AutoCalCommandLenght);
}

int CO2 ::disableAutoCalibration()
{
    uint8_t CheckSum = 0;
    // Configures the command anda calculates the CheckSum
    for (int i = 0; i < AutoCalCommandLenght - 1; i++)
    {
        if (i == AutoCalDF2)
            _autoCalibarion[AutoCalDF2] = AutoCalibrationDisabled;

        CheckSum += _autoCalibarion[i];
    }
    _autoCalibarion[AutoCalCommandLenght - 1] = CheckSumConst - CheckSum;

    // Sends the command to the sensor and receives data back
    return sendCommand(_autoCalibarion, AutoCalCommandLenght);
}

// Sends the command to the sensor and receives data back
int CO2 ::sendCommand(uint8_t *command, uint8_t commandLenght)
{
    // Write to the sensor
    CO2_Serial->write(command, commandLenght);
    // Wait 500 microseconds
    delayMicroseconds(500);
    // Buffer data
    recieveData();
    // Process the buffered data and returns
    return processData(command);
}

void CO2 ::recieveData()
{
    while (CO2_Serial->available() > 0)
    {
        for (int i = 0; i < 8; i++)
        {
            recievedByte[i] = CO2_Serial->read();
            // Serial.print(recievedByte[i], HEX);
            // Serial.print(" ");
        }
        // Serial.print('\n');
    }
}

//Checks for corupted data
int CO2 ::processData(uint8_t *lastCommand)
{
    uint8_t CheckSum = 0;
    if (recievedByte[0] != ReceiveStartByte)
        return -2;

    if (recievedByte[2] != lastCommand[2])
        return -3;

    for (int i = 0; i < recievedByte[1] + 2; i++)
    {
        CheckSum += recievedByte[i];
    }
    CheckSum = CheckSumConst - CheckSum;

    if (CheckSum != recievedByte[recievedByte[1] + 2])
        return -4;

    if (LastCommand == GetMesurmentsCommandHEX)
        return recievedByte[3] * 256 + recievedByte[4];
    if (LastCommand == CalibrateCommandCommandHEX)
        return 0;
    if (LastCommand == AutoCalCommandHEX)
        return 0;
    else
        return -5;
}

char *ErrorHandler(int inputIndex)
{
    switch (inputIndex)
    {
    case INVALID_INPUT:
        return "Error: Invalid Parameter Input!";

    case INVALID_HEAD_FRAME:
        return "Error: Received Head Frame Is Invalid!";

    case INVALID_COMMAND_FRAME:
        return "Error: Received Command Frame Is Invalid!";

    case INVALID_CHECKSUM_FRAME:
        return "Error: Received CheckSum Is Invalid!";

    case UNKNOWN_ERROR:
        return "Error: Unknown Error!";

    default:
        if (inputIndex > 0)
            return ToString(inputIndex);
        else
            return "It is okey";
    }
    // return "NULL";
}