## Embedded Systems Lab 5

### Q2

Question 2 is present in Q2.c. To compile it for the MSP430, create a new CCS project in Code Composer Studio ("with main.c"), and replace the contents of main.c with Q2.c.

This code creates a software PWM via the `__delay_cycles` method. It toggles the green LED on the TI LaunchPad board. 
Since `__delay_cycles` requires a constant integer and cannot use variables, the period and duty cycles are defined in `#define` statements at the top of the file. 
Since the desired period is 500 ms, and we know that the SMCLK operates at 1 MHz, we must multiply 1 million Hz with 0.5 seconds to achieve the desired cycle count of 500,000.

### Q3

Question 3 is present in Q3.c. To compile it for the MSP430, create a new CCS project in Code Composer Studio ("with main.c"), and replace the contents of main.c with Q3.c.

This code creates a hardware PWM via the MSP430's timer module. It has two interrupts defined: One to turn off the LED when the counter reaches TACCR1,
and one to turn off the LED when the counter reaches TACCR0.

To get our desired timing, we must first select the maximum clock divider of 8 so that the counter effectively operates at 1/8 MHz or 125 kHz. 
We must once again multiply the frequency by 0.5 seconds to get 62,500 "cycles", which gives us our TACCR0. 
TACCR1 is simply TACCR0 times the duty cycle, or 6,250.
