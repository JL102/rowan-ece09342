#include <msp430.h>
#define RedLED BIT6
#define GreenLED BIT0
#define ToggleLeds (P1OUT ^= RedLED|GreenLED)
#define Button BIT3


void main(void)
{
  WDTCTL = WDTPW + WDTHOLD; // Stop WDT

  P1DIR |= GreenLED;
  P1OUT = 0;

  TACCTL0 = CCIE + // interrupt enable
            OUTMOD_3; // out mode
  TACCTL1 = CCIE +
            OUTMOD_3;

  TACCR0 = 62500; // 500,000 clock cycles / 8
  TACCR1 = 6250; // 1/10th
  TACTL = TASSEL_2 + // SMCLK
              MC_1 + // Up mode
              ID_3;  // Divide by 8

  TACCTL0 &=~CCIFG; // Clear interrupt flags
  TACCTL1 &=~CCIFG;

  _enable_interrupts(); // Enter LPM0 w/ interrupt
}

// Timer A0 interrupt service routine  - CCR0 vector
#pragma vector=TIMER0_A0_VECTOR
__interrupt void Timer_A (void)
{
    P1OUT = GreenLED; // Toggle LED
    TACCTL0 &=~CCIFG; // Clear IFG so the interrupt can continue
}
#pragma vector=TIMER0_A1_VECTOR
__interrupt void Timer_B (void)
{
    P1OUT &= ~GreenLED; // Toggle LED
    TACCTL1 &=~CCIFG; // Clear IFG so the interrupt can continue
}
