#include <Arduino.h>
#include <bwoahProtocol.h>

#define tempLimit 1.95
#define humLimit 3.95
#define coLimit 5.95
#define tvocLimit 7.95

// ~~~~~~
// float a = 2.0;
// float temp = (float)rand()/(float)(RAND_MAX) * a;
// between 0 and 2
// float hum = (float)rand()/(float)(RAND_MAX) * a + 2;
// between 2 and 4
// float co = (float)rand()/(float)(RAND_MAX) * a + 4;
// between 4 and 6
// float tvoc = (float)rand()/(float)(RAND_MAX) * a + 6;
// between 6 and 8
// ~~~~~~

// $#te-data-#hu-data-#co-data-#vo-data-% - FINAL MESSAGE TO BE SENT
// te-data-
// $ - start of the message
// # - start of a data stream
// te/hu/etc. - type of data transmited
// data - actual data
// "-" - separators

int testTemp(float parameter)
{
  if(parameter >= tempLimit)
  {
    return 1; // if out of bounds 
  }
  
  return 0;
}

int testHum(float parameter)
{
  if(parameter >= humLimit)
  {
    return 1; // if out of bounds 
  }
  
  return 0;
}

int testCO(float parameter)
{
  if(parameter >= coLimit)
  {
    return 1; // if out of bounds 
  }
  
  return 0;
}

int testTVOC(float parameter)
{
  if(parameter >= tvocLimit)
  {
    return 1; // if out of bounds 
  }
  
  return 0;
}

int testSharpRaise(float parameter, float margin)
{
  if(parameter >= margin)
  {
    return 1; // if out of bounds 
  }
  
  return 0;
}

void addParameter(String *message, String data, float measurement, int sharpRaise)
{
  *message += data;
  if(sharpRaise == 1)
  {
    *message += "!"; // if out of bounds
  }
  else
  {
    *message += "-"; // if normal
  }
  
  *message += String(measurement);
  *message += "-";
}

String addData(int data, float temp, float hum, float co, float tvoc)
{
  String dataToAdd = "#";
  switch (data)
  {
  case 1:
    addParameter(&dataToAdd, "te", temp, testSharpRaise(temp, tempLimit));
    break;
  case 2:
    addParameter(&dataToAdd, "hu", hum, testSharpRaise(hum, humLimit));
    break;
  case 3:
    addParameter(&dataToAdd, "co", co, testSharpRaise(co, coLimit));
    break;
  case 4:
    addParameter(&dataToAdd, "vo", tvoc, testSharpRaise(tvoc, tvocLimit));
    break;
  default:
    break;
  }
  return dataToAdd;
}

void writeData(float temp, float hum, float co, float tvoc)
{
  String dataToSend = "";
  dataToSend += "$";
  for (int i = 1; i < 5; i++)
  {
    dataToSend += addData(i,temp, hum, co, tvoc); 
  }
  dataToSend += "%";
  Serial.println(dataToSend);
}
