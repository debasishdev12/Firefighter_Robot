//TRANSMITTER_SIDE <_by blackviper>

#include<VirtualWire.h>            //header file for rf module.

const int forward_backward = A1;    //for reading the y_axis reading of joystick 1(forward/backward)
const int left_right = A0;          //for reading the x_axis reading of joystick 1(left/right)
const int pump_up_down = A2;        //for reading the y_axis reading of joystick 2(up/down)
const int pump_left_right = A3;     //for reading the x_axis reading of joystick 2(left/right)
const int pump_on_off = 12;         //for on/off the pump read this pin
const int pump_on_off_led = 9;
const int led = 13;                 //indicate whether the remote is working or not
const int automaticmode_activate = 10;
const int automaticmode_activate_led = 6;
byte temp,atemp;                          //this helps to on/off condition of the pump

char *controller;                    //declare a variable that contains the charcter which will be sent by rf transmitter
void setup()
{
  //rf transmitter setup
  vw_set_ptt_inverted(true);
  vw_set_tx_pin(11);
  vw_setup(4000);
  //declare input pins....though all are analog pins and they are declared as input by defaults.but its just for safety 
  pinMode(forward_backward,INPUT);
  pinMode(left_right,INPUT);
  pinMode(pump_up_down,INPUT);
  pinMode(pump_left_right,INPUT);
  pinMode(pump_on_off,INPUT);
  pinMode(automaticmode_activate,INPUT);
  pinMode(pump_on_off_led,OUTPUT);
  pinMode(automaticmode_activate_led,OUTPUT);
  
  digitalWrite(pump_on_off,HIGH);    //declare as high impedance state to read the pump on/off pin
  digitalWrite(automaticmode_activate,HIGH);
  digitalWrite(pump_on_off_led,LOW);
  digitalWrite(automaticmode_activate_led,LOW);
  digitalWrite(led,LOW);            //at first make led pin low
  
  //at starting the light blink 10 times to make us understand that it is ready for work
  for(int i = 0;i < 6; i++)
  {
    digitalWrite(led,HIGH);
    delay(250);
    digitalWrite(led,LOW);
    delay(250);
  }
  digitalWrite(led,LOW); 
}

void loop()
{
  int forward_backward_variable = analogRead(forward_backward) - 512;    //at middle position joystick reading is 0,at down(0-512) = -512 & at up(1023-512) = 511
  int left_right_variable = analogRead(left_right) - 512;                //just make understand that stick down is negative number and stick up is positive number
  int pump_up_down_variable = analogRead(pump_up_down) - 512;            //same technique is applied to all the joystick readings
  int pump_left_right_variable = analogRead(pump_left_right) - 512;
  digitalWrite(led,LOW);                                                 //if no instrcution are sent,the led be in idel state(OFF)
  
  if(forward_backward_variable > 300)                                    //for safety the threshold value is assumed 300.no effect of fluctuation of joystick reading
  {
    controller = "F";                                                    //for moving forward sent "F" as a string character.   
    vw_send((uint8_t*)controller, 1);                                    //this function tells us that we send the value of controller variable and its length is 1
    digitalWrite(led,!digitalRead(led));                                 //after sending every character led blinks to ensure us that data has been sent
  }
  
  if(forward_backward_variable < -300)                                   //for safety the threshold value is assumed -300.no effect of fluctuation of joystick reading
  {
    controller = "B";                                                    //for moving backward sent "B" as a string character.   
    vw_send((uint8_t*)controller, 1);                                    //this function tells us that we send the value of controller variable and its length is 1
    digitalWrite(led,!digitalRead(led));                                 //after sending every character led blinks to ensure us that data has been sent
  }  
  
  if(left_right_variable < -300)                                         //for safety the threshold value is assumed -300.no effect of fluctuation of joystick reading
  {
    controller = "L";                                                    //for moving left sent "L" as a string character.  
    vw_send((uint8_t*)controller, 1);                                    //this function tells us that we send the value of controller variable and its length is 1
    digitalWrite(led,!digitalRead(led));                                 //after sending every character led blinks to ensure us that data has been sent
  }
  
  if(left_right_variable > 300)                                          //for safety the threshold value is assumed 300.no effect of fluctuation of joystick reading
  {
    controller = "R";                                                    //for moving right sent "R" as a string character.
    vw_send((uint8_t*)controller, 1);                                    //this function tells us that we send the value of controller variable and its length is 1
    digitalWrite(led,!digitalRead(led));                                 //after sending every character led blinks to ensure us that data has been sent
  }

  if(pump_up_down_variable < -300)                                       //for safety the threshold value is assumed -300.no effect of fluctuation of joystick reading
  {
    controller = "U";                                                    //for moving the water pipe up sent "U" as a string character.
    vw_send((uint8_t*)controller, 1);                                    //this function tells us that we send the value of controller variable and its length is 1
    digitalWrite(led,!digitalRead(led));                                 //after sending every character led blinks to ensure us that data has been sent
  }
  
  if(pump_up_down_variable > 300)                                       //for safety the threshold value is assumed 300.no effect of fluctuation of joystick reading
  {
    controller = "D";                                                   //for moving the water pipe down sent "D" as a string character.
    vw_send((uint8_t*)controller, 1);                                   //this function tells us that we send the value of controller variable and its length is 1
    digitalWrite(led,!digitalRead(led));                                //after sending every character led blinks to ensure us that data has been sent
  }
  
  if(pump_left_right_variable > 300)                                    //for safety the threshold value is assumed 300.no effect of fluctuation of joystick reading
  {
    controller = "J";                                                   //for moving the water pipe right sent "J" as a string character.
    vw_send((uint8_t*)controller, 1);                                   //this function tells us that we send the value of controller variable and its length is 1
    digitalWrite(led,!digitalRead(led));                                //after sending every character led blinks to ensure us that data has been sent
  }  
  if(pump_left_right_variable < -300)                                   //for safety the threshold value is assumed -300.no effect of fluctuation of joystick reading
  {
    controller = "K";                                                   //for moving the water pipe left sent "J" as a string character.
    vw_send((uint8_t*)controller, 1);                                   //this function tells us that we send the value of controller variable and its length is 1
    digitalWrite(led,!digitalRead(led));                                //after sending every character led blinks to ensure us that data has been sent 
  } 
  
 //here temp variable plays an important role to make the 
 //logic more efficient.At first temp is 0 and the pin
 //attached to the pump is also HIGH.but if the switch is 
 //toggled then that pin would be LOW and the temp variable 
 //is 0.so first if statement will work and send "P" as a 
 //character which in turn just on the pump on robot side.
 //after this temp will be 1 so that next if statement 
 //can be used and logically be correct.......... if temp 
 //variable is not used then remote will always send "P" or
 //"p" character from its being started and no other character
 //can be sent over rf transmitter....and in the robot the 
 //pump will always be on state.or will always be on off state... 
 //not a single character can not be sent for other instruction
 
  if(temp == 0 && digitalRead(pump_on_off) == LOW)                      
  {
    digitalWrite(pump_on_off_led,HIGH);
    controller = "P";    //pump on
    vw_send((uint8_t*)controller, 1);
    temp = 1;
    digitalWrite(led,!digitalRead(led));
  }
  if(temp == 1 && digitalRead(pump_on_off) == HIGH)
  {
    digitalWrite(pump_on_off_led,LOW);
    controller = "p";    //pump off 
    vw_send((uint8_t*)controller, 1);
    temp = 0;
    digitalWrite(led,!digitalRead(led));
  }
  
  if(atemp == 0 && digitalRead(automaticmode_activate) == LOW)                      
  {
    digitalWrite(automaticmode_activate_led,HIGH);
    controller = "A";    //automatic on
    vw_send((uint8_t*)controller, 1);
    atemp = 1;
    digitalWrite(led,!digitalRead(led));
  }
  if(atemp == 1 && digitalRead(automaticmode_activate) == HIGH)
  {
    digitalWrite(automaticmode_activate_led,LOW);
    controller = "a";    //automatic off 
    vw_send((uint8_t*)controller, 1);
    atemp = 0;
    digitalWrite(led,!digitalRead(led));
  }
//  if(forward_backward_variable < 300 || forward_backward_variable > -300 || left_right_variable > -300 || left_right_variable < 300)
//  {
//    controller = "S";    //stop 
//    vw_send((uint8_t*)controller, 1);
//  }
}
