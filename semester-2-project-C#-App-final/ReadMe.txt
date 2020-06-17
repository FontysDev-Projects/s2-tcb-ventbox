To implement the protocol on your Nucleo board follow the steps below:

1. Add "bwoahProtocol.h" and "bwoahProtocol.cpp" to your src folder

2. Create some simulated data for the parameters that you are NOT measuring
	You can do that like this:
	2.1 You have in the "bwoahProtocol.cpp" on line 9 some examples that you can use
	2.2 Add them into your main.cpp file declared globally

3. Try and follow the example as shown in Nucleo Testing example 
	~ you will need 2 millis timers
	~ you may want to use a return type of method for updating the values

PS In the "bwoahProtocol.cpp" on line 4 you will find the limits for the parameters - modify it to match your measurments

Other new stuff:
	~ In the C# App you can see the sum of the parameters, confirming that we can make use of the values
	~ bwoahProtocol library - easier to implement
	~ Now you can see which parameter is out of bounds - it will be red colored (C# App)

!!As always update the path in the C# to your path!!

Don't hesitate to message me on WhatsApp or on Discord if you have questions! :) 
