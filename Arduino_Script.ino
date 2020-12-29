// Define global variables to assign digital pins on Arduino (No PWM~)
int butPin1 = 7;  // Connect button switch to digital pin 7 (RIGHT)
int butPin2 = 8;  // Connect button switch to digital pin 8 (UP)
int butPin3 = 12; // Connect button switch to digital pin 12 (DOWN)
int butPin4 = 13; // Connect button switch to digital pin 13 (LEFT)

void setup() 
{ 
  // Initialize serial communication at 9600 bits per seconds
  Serial.begin(9600); 

  // Declare all 4 pins as input
  pinMode(butPin1, INPUT);
  pinMode(butPin2, INPUT); 
  pinMode(butPin3, INPUT);
  pinMode(butPin4, INPUT);

  // Set all 4 pins to ON
  digitalWrite(butPin1, HIGH);
  digitalWrite(butPin2, HIGH);
  digitalWrite(butPin3, HIGH);
  digitalWrite(butPin4, HIGH);
}

void loop() 
{
  // String A: Move right   String B: Move forward
  // String C: Move back    String D: Move left

  // Read the EMG input on analog pin 0 (A0):
  int sensorValue = analogRead(A0);

  // Conver the analog reading (0-1023) to voltage (0-5V)
  float voltage = sensorValue*(5.0/1023.0);
  
  // If right button is pressed, turn button off
  if (digitalRead(butPin1) == LOW)
  {
    // Send string using serial port
    Serial.println("A");
    delay(1);
  }

  // If forward button is pressed or 
  // if EMG analog signal exceeds Vo, turn button off
  if (digitalRead(butPin2) == LOW || voltage > 2.0)
  {
    // Send string using serial port
    Serial.println("B");
    delay(1);
  }

  // If backward button is pressed, turn button off
  if (digitalRead(butPin3) == LOW)
  {
    // Send string using serial port
    Serial.println("C");
    delay(1);
  }

  // If left button is pressed, turn button off
  if (digitalRead(butPin4) == LOW)
  {
    // Send string using serial port
    Serial.println("D");
    delay(1);
  }
}
