UARTMotion&Buzzer - For Motion Sensor and Piezo Buzzer Component
UARTTemperature&RFID - For Temperature Sensor and RFID Component
UARTUltrasonic - For Ultrasonic Sensor Component

==============================CONNECTIONS==================================
ULTRASONIC SENSOR
1 Connect a wire from Ultrasonic Sensor +5V (2nd from the left) to Netduino’s 5V
2 Connect a wire from Ultrasonic Sensor GND (1st on the left) to Netduino’s GND
3 Connect a wire from Ultrasonic Sensor AN (5th from left) to Netduino’s A0

RFID AND TEMPERATURE SENSOR
1 Connect a wire from RFID Board +3.3V to Netduino's 5V and Temp Board +3.3 V to 
Netduino’s 3V3.
2 Connect a wire from RFID Board GND and Temp Board GND to Netduino’s GND
3 Connect a wire from RFID Board TX to Netduino’s D0 (UART1 RX).

UART
1 Connect a wire from UART Board TX0 to Netduino’s D2 (UART 2 RX)
2 Connect a wire from UART Board RX1 to Netduino’s D3 (UART 2 TX)
3 Connect a wire from Temp Board TMP36 to Netduino’s A0
4 Connect a wire from UART Board GND to Netduino's GND

MOTION SENSOR AND PIEZO BUZZER
1 Connect a wire from Piezo-Electric Board GND to Netduino’s GND
2 Connect a wire from Piezo-Electric Board BUZZER to Netduino’s D5
3 Connect a wire from Motion Sensor Board +3.3V to Netduino’s 3V3
4 Connect a wire from Motion Sensor Board GND to Netduino’s GND
5 Connect a wire from Motion Sensor Board OUTPUT to Netduino’s D1