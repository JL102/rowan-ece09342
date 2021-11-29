#include <msp430.h> 
#define RedLED BIT6
#define GreenLED BIT0
#define period 500000 // 1 MHz * 0.5 seconds
#define timeOn period / 10
#define timeOff period - timeOn


/**
 * main.c
 */
int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    P1DIR = GreenLED; // enable green LED

    while(1) {
        P1OUT = GreenLED;
        __delay_cycles(timeOn);
        P1OUT = 0;
        __delay_cycles(timeOff);
    }
}

