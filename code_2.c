#include <REG51.h>

unsigned char a, b; // Declare global variables

void main() {
    IE = 0x82;   // Enable Timer 0 interrupt (EA = 1, ET0 = 1)
    TMOD = 0x01; // Timer 0 in Mode 1 (16-bit timer)
    TH0 = 0x00;  // Load initial values
    TL0 = 0x00;
    TR0 = 1;     // Start Timer 0

    while (1) {
        P0 = 0x00;  // Reset P0 in the main loop to see ISR effect
    }
}

void timer0_ISR(void) interrupt 1 { 
    b = 0x05;   // Assign value to b
    a = 0x01;   // Assign value to a
    P0 = 0xFF;  // Set all bits of Port 0 high
}