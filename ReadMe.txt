Before starting to test you may want to follow these steps:
1. if you implement the functions on your arduino board you must
create some mock data for the others parameters that you are not measuring.

You can copy/paste from these:

~Declare them globally:

int temp; 
int hum; 
int co;  
int tvoc; 

~Into the loop:

  temp = rand() % 100 + 101;
  hum = rand() % 100 + 201;
  co = rand() % 100 + 301;
  tvoc = rand() % 100 + 401;

~~

Doing so the app will work under normal conditions.

2. You will have to update the path that I used to your file path in the C# App.

You will find it on the 100th line.


If you find any other bugs please let me know on WhatsApp. :)