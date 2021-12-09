## Embedded Systems Lab 5

### Q1

Question 1 required us to visualize the readings from a sensor. We used UART to send the values from a photoresistor to the computer, 
and we plotted the values from the UART terminal using Excel.

We tested that the photoresistor's resistance varies from around 2 kΩ to around 50 kΩ, and decided on a resistor value of 16 kΩ for our voltage divider. 
We connected the output of the voltage divider to pin P1.7, aka analog pin A7.

### Q2

Question 2 was similar to Question 1, but instead of one sensor, we needed to visualize the readings from two. To implement this, we first cleaned up
the code to make it easier to follow & minimize copy-pasted code. We sent both the temperature and light values over the same UART channel, delimited by a comma and space.

The voltage divider for the thermistor was 10k.
