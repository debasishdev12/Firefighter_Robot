/*  TRANSMITTER_SIDE <DEV>
                  _____________
      Reset    ---|1        28|---   A5                       
      0(RX)    ---|2        27|---   A4                 
      1(TX)    ---|3        26|---   A3                    ____________                                    ________________________________________
      2        ---|4        25|---   A2            En1  ---|1       16|---  Vcc                           |                                        |
      3(PWM)   ---|5        24|---   A1            In1  ---|2       15|---  In4                           |                                        |
      4        ---|6        23|---   A0            Out1 ---|3       14|---  Out4                          |                                        |
      VCC      ---|7        22|---   GND           Gnd  ---|4       13|---  Gnd                           |                                        |
      GND      ---|8        21|---   AREF          Gnd  ---|5       12|---  Gnd                           |________________________________________|
      Crystal  ---|9        20|---   AVCC          Out2 ---|6       11|---  Out3                             |   |   |   |          |   |   |   |
      Crystal  ---|10       19|---   13            In2  ---|7       10|---  In3                              |   |   |   |          |   |   |   |
      5(PWM)   ---|11       18|---   12        Battery  ---|8        9|---  En2                              |   |   |   |          |   |   |   |
      6(PWM)   ---|12       17|---   11(PWM)               ------------                                     Gnd Data NC Vcc        Vcc Gnd Gnd Ant
      7        ---|13       16|---   10(PWM)                  L293D                                                    
      8        ---|14       15|---   9 (PWM)                                                                             433Mhz Receiver   
                  -------------
                    atmega328
 */
#include<VirtualWire.h>    //header file for rf communication by rf module
#include "ServoTimer2.h"   //creating servo library

#define DEBUG      //to see in serial monitor just uncomment this line,otherwise comment this line

#define DEFAULT_ANGLE 1500  //default angle in microseconds for two servos
#define MAX_ANGLE 1700     //maximum angle in microseconds for two servos
#define MIN_ANGLE 1300      //minimum angle in microseconds for two servos

//creating variable for every elements like motors,pumps,sensors,servos,water level indicator
const int reverseLeftMotorA = 10;
const int reverseLeftMotorB = 2;
const int reverseRightMotorA = 4;
const int reverseRightMotorB = 5;
const int frontLeftMotorA = 6;
const int frontLeftMotorB = 7;
const int frontRightMotorA = 8;
const int frontRightMotorB = 9;
const int pumpMotor = 13;
const int rotationServo = 11;
const int upDownServo = 3;
//const int automaticMode = 0;
const int Receiver = 12;
const int flameFounder = A0;    //this is for fire sensor
const int waterLevel = A5;      //this is for water level indicator,if no water it goes high,if water it goes low

ServoTimer2 myServo1,myServo2;   //creating servo object
 
void setup()
{
  #ifdef DEBUG
  Serial.begin(9600);      //for serial communication with pc
  #endif
  
  //rf setup
  vw_set_ptt_inverted(true);
  vw_set_rx_pin(Receiver);
  vw_setup(4000);
  vw_rx_start();
  
  //define what pins are output and what pins are input
  pinMode(reverseLeftMotorA,OUTPUT);
  pinMode(reverseLeftMotorB,OUTPUT);
  pinMode(reverseRightMotorA,OUTPUT);
  pinMode(reverseRightMotorB,OUTPUT);
  pinMode(frontLeftMotorA,OUTPUT);
  pinMode(frontLeftMotorB,OUTPUT);
  pinMode(frontRightMotorA,OUTPUT);
  pinMode(frontRightMotorB,OUTPUT);
  pinMode(pumpMotor,OUTPUT);
  //pinMode(automaticMode,OUTPUT);
  pinMode(waterLevel,INPUT);
  pinMode(flameFounder,INPUT);
  
  //initially make all pin low
  digitalWrite(reverseLeftMotorA,LOW);
  digitalWrite(reverseLeftMotorB,LOW);
  digitalWrite(reverseRightMotorA,LOW);
  digitalWrite(reverseRightMotorB,LOW);
  digitalWrite(frontLeftMotorA,LOW);
  digitalWrite(frontLeftMotorB,LOW);
  digitalWrite(frontRightMotorA,LOW);
  digitalWrite(frontRightMotorB,LOW);
  digitalWrite(pumpMotor,LOW);
  //digitalWrite(automaticMode,LOW);
  myServo1.attach(rotationServo);          //attach the rotation servo to pin3
  myServo2.attach(upDownServo);            //attach the up down servo to pin11
  myServo1.write(DEFAULT_ANGLE);           //default angle of rotation servo in ms(90degree)
  myServo2.write(DEFAULT_ANGLE);           //default angle upp down servo in ms(90degree)
 }

void loop()
{
  uint8_t buflen = VW_MAX_MESSAGE_LEN;    //maximum character length received by the reciever
  uint8_t buf[VW_MAX_MESSAGE_LEN];        //character received in form of integar(8bit integer) array
  
  if(vw_get_message(buf,&buflen))        //passes two parameters,1st one is the character that is received by the receiver and
                                         //2nd one is the memory address of that character
  {
    //this loop just checks character stored in buffer 
    //and accordingto that character tell microcontroler
    //to whatto do?????..... 
    for(int i = 0;i < buflen; i++)      //check whether any character is missing or not?in case of received more than one character
     {
       if(buf[i] == 'F')  
       {
         //move forward
         moveForward();
         
         //in case of finding any fire during moving forward the robot will automatic stop and turn on the pump
         if(digitalRead(flameFounder) == LOW)
         {
          #ifdef DEBUG
           Serial.println("Flame Found !!!");
          #endif
           
          //automatic pump on
          brake();
          delay(500);
          pumpOn();
          while(digitalRead(flameFounder) == LOW);  //wait in this loop until the fire is vanished,do not listen anything
        } 
       }
       
       if(buf[i] == 'B')
       {
         //move backward
         moveBackward();
       }
       if(buf[i] == 'L')
       {
         //move left
         moveLeft();
       }
       if(buf[i] == 'R')
       {
         //move right
         moveRight();   
       }
       if(buf[i] == 'P')
       {
         pumpOn();
       }
       if(buf[i] == 'p')
       {
         //pump off
         pumpOff(); 
       }
       if(buf[i] == 'U')
       {
         //servo up
         servo1_Up();
       }
       if(buf[i] == 'D')
       {
         //servo down
         servo1_Down();
       }
       if(buf[i] == 'K')
       {
         //servo left
         servo2_Left();
       }
       if(buf[i] == 'J')
       {
         //servo right
         servo2_Right();
       }
  }
}
} 
 
//to move forward 4 wheels have to rotate in same direction . Thus, A terminal of
//evrey motor is high (5V) and B terminal of every motor is low (0V) . This makes 
//all the 4 motors rotate in same direction
void moveForward()
{
  digitalWrite(reverseLeftMotorA,HIGH);
  digitalWrite(reverseLeftMotorB,LOW);
  digitalWrite(reverseRightMotorA,HIGH);
  digitalWrite(reverseRightMotorB,LOW);
  
  digitalWrite(frontLeftMotorA,HIGH);
  digitalWrite(frontLeftMotorB,LOW);
  digitalWrite(frontRightMotorA,HIGH);
  digitalWrite(frontRightMotorB,LOW);
  
  #ifdef DEBUG
    Serial.println("Moving Forward");
  #endif
}

//moving backward is the opposite process of moving forward. For forward A terminal
//of every motor was HIGH and B terminal was LOW. But this time A terminal will be  
//LOW and B terminal will be HIGH

void moveBackward()
{
  digitalWrite(reverseLeftMotorA,LOW);
  digitalWrite(reverseLeftMotorB,HIGH);
  digitalWrite(reverseRightMotorA,LOW);
  digitalWrite(reverseRightMotorB,HIGH);
  
  digitalWrite(frontLeftMotorA,LOW);
  digitalWrite(frontLeftMotorB,HIGH);
  digitalWrite(frontRightMotorA,LOW);
  digitalWrite(frontRightMotorB,HIGH);
  
  #ifdef DEBUG
    Serial.println("Moving Backward");
  #endif
}

//for moving left the two wheels of right side have to rotate in forward direction
//and the two wheels of left side have to rotate in backward direction. So A and B
//terminal should be make LOW and HIGH to gain this type of configuration
void moveLeft()
{
  digitalWrite(reverseLeftMotorA,HIGH);
  digitalWrite(reverseLeftMotorB,LOW);
  digitalWrite(reverseRightMotorA,LOW);
  digitalWrite(reverseRightMotorB,HIGH);
  
  digitalWrite(frontLeftMotorA,HIGH);
  digitalWrite(frontLeftMotorB,LOW);
  digitalWrite(frontRightMotorA,LOW);
  digitalWrite(frontRightMotorB,HIGH);
  
  #ifdef DEBUG
    Serial.println("Moving Left");
  #endif
}

//moving right is just opposite of moving left. Just make the state of A and B terminal
//vice_versa the above one
void moveRight()
{
  digitalWrite(reverseLeftMotorA,LOW);
  digitalWrite(reverseLeftMotorB,HIGH);
  digitalWrite(reverseRightMotorA,HIGH);
  digitalWrite(reverseRightMotorB,LOW);
  
  digitalWrite(frontLeftMotorA,LOW);
  digitalWrite(frontLeftMotorB,HIGH);
  digitalWrite(frontRightMotorA,HIGH);
  digitalWrite(frontRightMotorB,LOW);
  
  #ifdef DEBUG
    Serial.println("Moving Right");
  #endif
}

//stop all motors need a low signal of all the terminals.so make LOW both A and B terminal
void brake()
{
  digitalWrite(reverseLeftMotorA,LOW);
  digitalWrite(reverseLeftMotorB,LOW);
  digitalWrite(reverseRightMotorA,LOW);
  digitalWrite(reverseRightMotorB,LOW);
  
  digitalWrite(frontLeftMotorA,LOW);
  digitalWrite(frontLeftMotorB,LOW);
  digitalWrite(frontRightMotorA,LOW);
  digitalWrite(frontRightMotorB,LOW);
  
  #ifdef DEBUG
    Serial.println("Brake");
  #endif
}

void pumpOn()
{
  //check whether the pump is filled or not
  //read the water level indicator circuit
  //LOW means => have water 
  //if filled then, on pump
//  if(digitalRead(waterLevel) == LOW)
//  {
    digitalWrite(pumpMotor,HIGH);
    
    #ifdef DEBUG
     Serial.println("Water Tank Filled and Pump On");
    #endif
//  }
//  //if empty then, can not start pump
//  //HIGH means => no water
//  else if(digitalRead(waterLevel) == HIGH)
//  {
//    digitalWrite(pumpMotor,LOW);
//    
//    #ifdef DEBUG
//      Serial.println("Water Tank Empty and Pump can not start");
//    #endif
//  }
}

void pumpOff()
{
  digitalWrite(pumpMotor,LOW);
  #ifdef DEBUG
    Serial.println("Pump Off");
  #endif
}

//in case of showing automatic feature this function is designed
void automaticMode()
{
  pumpOn();                    //if flame sensor will find fire the robot goes to automatic mode 
  automaticServoMode();      
  #ifdef DEBUG
     Serial.print("Automatic Mode activated");
  #endif
}

//in case of giving water up and down,left and right two servo motors are used just providing a 
//two degree of freedom (2DOF) water pipe.
void servo1_Up()
{
  unsigned int currentAngle = myServo1.read();          //this line reads the current angle of servo motor.
  unsigned int updateAngle = currentAngle + 10;         //we want to increase 10 steps with the current angle after receiving every character from remote
  if(updateAngle > MAX_ANGLE) updateAngle = MAX_ANGLE;  //we want to keep the servo in a limit,whenever crossing the limit we force to keep it in a max range
  myServo1.write(updateAngle);                          //update the angle to get the desired position
  #ifdef DEBUG
     Serial.print("Servo_1 angle(UP) : ");
     Serial.println(updateAngle);
  #endif
}
void servo1_Down()
{
  unsigned int currentAngle = myServo1.read();         //this line reads the current angle of servo motor.
  unsigned int updateAngle = currentAngle - 10;        //we want to decrease 10 steps with the current angle after receiving every character from remote
  if(updateAngle < MIN_ANGLE) updateAngle = MIN_ANGLE; //we want to keep the servo in a limit,whenever crossing the limit we force to keep it in a min range
  myServo1.write(updateAngle);                         //update the angle to get the desired position
  #ifdef DEBUG  
     Serial.print("Servo_1 angle(DOWN) : ");
     Serial.println(updateAngle);
  #endif
}
void servo2_Left()
{
  unsigned int currentAngle = myServo2.read();         //this line reads the current angle of servo motor.
  unsigned int updateAngle = currentAngle + 10;        //we want to increase 10 steps with the current angle after receiving every character from remote
  if(updateAngle > MAX_ANGLE) updateAngle = MAX_ANGLE; //we want to keep the servo in a limit,whenever crossing the limit we force to keep it in a max range
  myServo2.write(updateAngle);                         //update the angle to get the desired position
  delay(50);
  #ifdef DEBUG
     Serial.print("Servo_2 angle(LEFT) : ");
     Serial.println(updateAngle);
  #endif
}
void servo2_Right()
{
  unsigned int currentAngle = myServo2.read();          //this line reads the current angle of servo motor.
  unsigned int updateAngle = currentAngle - 10;         //we want to increase 10 steps with the current angle after receiving every character from remote 
  if(updateAngle < MIN_ANGLE) updateAngle = MIN_ANGLE;  //we want to keep the servo in a limit,whenever crossing the limit we force to keep it in a max range
  myServo2.write(updateAngle);                          //update the angle to get the desired position
  delay(50);
  
  #ifdef DEBUG
     Serial.print("Servo_2 angle(RIGHT) : ");
     Serial.println(updateAngle);
  #endif
}

//in automatic mode the water pipe is moving automatically by this method..
//every loop is repeated for 42 times after a little bit calculation to 
//keep the motor between MAX and MIN range 
void automaticServoMode()
{
  for(int i = 0;i < 42;i++){
  servo1_Up();
  servo2_Left();
  }
  delay(2);
  for(int i = 0;i < 42;i++){
  servo2_Right();
  }
  delay(2);
  for(int i = 0;i < 42;i++){
  servo2_Right();
  }
  delay(2);
  for(int i = 0;i < 42;i++){
  servo1_Down();
  servo2_Left();
  }
  delay(2);
  for(int i = 0;i < 42;i++){
  servo1_Up();
  servo2_Left();
  }
  delay(2);
}


