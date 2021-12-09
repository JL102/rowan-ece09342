#include <msp430g2553.h>

volatile long adcValue;
char result[100];
volatile long sample[100];

void ConfigureAdc_light();
void ConfigureAdc_therm();
long int getAdcValue(void);

void send_character(char c);
void send_int(int thingy);
void uart_init(void);
void ConfigClocks(void);
void strreverse(char* begin, char* end);
void itoa(int value, char* str, int base);
void port_init();

void main(void)
{
    WDTCTL = WDTPW + WDTHOLD; // Stop watchdog timer

    port_init();

    ConfigClocks();
    uart_init();

    _delay_cycles(5);                // Wait for ADC Ref to settle

    while(1){
        _delay_cycles(200000);                  // Delay

        // Get ADC value for light sensor
        ConfigureAdc_light();
        adcValue = getAdcValue();
        send_int(adcValue);

        // Delimit values with a comma and space
        send_character(',');
        send_character(' ');

        // Get ADC value for thermistor
        ConfigureAdc_therm();
        adcValue = getAdcValue();
        send_int(adcValue);

        send_character('\n');
        send_character('\r');
    }
}

void send_int(int thingy) {
    itoa(thingy, result,10);               // String version of adc value
    int acount = 0;
    while(result[acount]!='\0') {
        send_character( result[acount++] );                   //Transmit the received data.
    }
}

long int getAdcValue (void) {
    __delay_cycles(1000);
    ADC10CTL0 |= ENC + ADC10SC +MSC;        // Converter Enable, Sampling/conversion start
    while((ADC10CTL0 & ADC10IFG) == 0);     // check the Flag, while its low just wait
    long int adcValue = ADC10MEM;                // read the converted data into a variable
    ADC10CTL0 &= ~ADC10IFG;                 // clear the flag
    return adcValue;
}

// Configure ADC
void ConfigureAdc_light (void) {
    ADC10CTL0 &= (~ ENC );
    ADC10CTL1 = INCH_7 + ADC10DIV_0;           // Pin A7
    ADC10CTL0 = SREF_0 | ADC10SHT_3 | ADC10ON; //Vref+, Vss, 64 ATD clocks per sample, internal references, turn ADCON
    __delay_cycles(5);                         //wait for adc Ref to settle
    ADC10CTL0 |= ENC| ADC10SC;                //converter Enable, Sampling/Conversion start, multiple sample/conversion operations
}

void ConfigureAdc_therm(void) {
    ADC10CTL0 &= (~ ENC );
    ADC10CTL1 = INCH_6 + ADC10DIV_0;            // Pin A6
    ADC10CTL0 = SREF_0 | ADC10SHT_3 | ADC10ON;  //Vref+, Vss, 64 ATD clocks per sample, internal references, turn ADCON
    __delay_cycles(5);                          //wait for adc Ref to settle
    ADC10CTL0 |= ENC| ADC10SC;                 //converter Enable, Sampling/Conversion start, multiple sample/conversion operations
}

// Send a character to the UART buffer
void send_character( char c ) {
    //Wait Unitl the UART transmitter is ready before sending another character
    while((IFG2 & UCA0TXIFG)==0);
    UCA0TXBUF = c;
}

void uart_init(void){
    UCA0CTL1 |= UCSWRST;                     //Disable the UART state machine
    UCA0CTL1 |= UCSSEL_3;                    //Select SMCLK as the baud rate generator source
    UCA0BR1 =0;
    UCA0BR0 = 104;                           //Produce a 9,600 Baud UART rate
    UCA0MCTL = 0x02;                         //Chooa propriately from Table 15-4 in User Guide
    UCA0CTL1 &= ~UCSWRST;                    //Enable the UART state naching
    IE2 |= UCA0RXIE;                         //Enable the UART receiver Interrupt
}

void ConfigClocks(void) {
    BCSCTL1 = CALBC1_1MHZ;                     // Set range
    DCOCTL = CALDCO_1MHZ;                      // Set DCO step + modulation
    BCSCTL3 |= LFXT1S_2;                       // LFXT1 = VLO
    IFG1 &= ~OFIFG;                            // Clear OSCFault flag
    BCSCTL2 = 0;                               // MCLK = DCO = SMCLK
 }


// Function to reverse the order of the ASCII char array elements
void strreverse(char* begin, char* end) {
    char aux;
    while(end>begin)
        aux=*end, *end--=*begin, *begin++=aux;
}

void itoa(int value, char* str, int base) {  //Function to convert the signed int to an ASCII char array
    static char num[] = "0123456789abcdefghijklmnopqrstuvwxyz";
    char* wstr=str;
    int sign;

    // Validate that base is between 2 and 35 (inlcusive)
    if (base<2 || base>35){
        *wstr='\0';
        return;
    }

    // Get magnitude and th value
    sign=value;
    if (sign < 0)
        value = -value;

    do // Perform interger-to-string conversion.
        *wstr++ = num[value%base]; //create the next number in converse by taking the modolus
    while(value/=base);  // stop when you get  a 0 for the quotient

    if(sign<0) //attch sign character, if needed
        *wstr++='-';
    *wstr='\0'; //Attach a null character at end of char array. The string is in revers order at this point
    strreverse(str,wstr-1); // Reverse string
}

void port_init(){
    P1SEL |= BIT1 + BIT2;            // select non-GPIO  usage for Pins 1 and 2
    P1SEL2 |= BIT1 + BIT2;           // Select UART usage of Pins 1 and 2
}

