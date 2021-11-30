#include <msp430.h> 
#define RedLED BIT6
#define GreenLED BIT0
#define ToggleLeds (P1OUT ^= RedLED|GreenLED)
#define Button BIT3
void main(void)
{
    BCSCTL2 |= DIVS_3;      // Divide SMCLK by 8
    WDTCTL = WDT_MDLY_32;   // Preset constant for 32ms
                            // 32 * 8 = 256
    IE1 |= WDTIE;           // Enable watchdog interrupt

    P1DIR = RedLED|GreenLED;// Prepare P1 outputs
    P1OUT = RedLED;
    _enable_interrupts();
    LPM1;                   // Enter low power mode
}
#pragma vector = WDT_VECTOR
__interrupt void WDT(void)
{
    // Toggle LEDs whenever the watchdog timer fires
     P1OUT = ToggleLeds;
}

