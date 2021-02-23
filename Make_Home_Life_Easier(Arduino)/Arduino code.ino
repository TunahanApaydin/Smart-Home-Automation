#include <Servo.h>
Servo servoM;
int servoPin = 3;
int ldrPin = A0;
int ldrPin1 = A1;
int ldrPin2 = A2;
int lm35Pin1 = A8;
int lm35Pin2 = A7;
int in3 = 31;
int in4 = 33;
int dcmotor = 2;
int dcmotor1 = 13;
int pirPin = 48;
int ledPin = 9;
int ledPin1 = 5;
int ledPin2 = 8;
int ledPin3 = 30;
int buzzerPin = 50;
int buzzerPin2 = 10;
int firePin = 24;
char value="";
boolean state = false;
boolean state2 = false;
boolean state3 = false;
boolean state4 = false;
boolean state5 = false;
boolean state6 = false;
boolean state7 = false;
boolean state8 = false;
int fireValue= 0;
int pirValue = 0;
float lm35Value = 0;
float lm35Value2 = 0;
int ldrValue = 0;
int ldrValue1 = 0;
int ldrValue2 = 0;
float temperature = 0.0;
float temperature2 = 0.0;
int parseValue = 0;
int parseValue2 = 0;
int parseValue3 = 0;
int parseValue4 = 0;
int parseValue5 = 0;
int parseValue6 = 0;
int parseValue7 = 0;
int turn = 0;
int servoangle = 1;
String sendValue = "t";
String sendValue2 = "T";

void setup() {
  pinMode(pirPin , INPUT);
  pinMode(firePin , INPUT);
  pinMode(lm35Pin1 , INPUT);
  pinMode(dcmotor , OUTPUT);
  pinMode(dcmotor1 , OUTPUT);
  pinMode(in3 , OUTPUT);
  pinMode(in4 , OUTPUT);
  pinMode(ldrPin , INPUT);
  pinMode(ldrPin1 , INPUT);
  pinMode(ldrPin2 , INPUT);
  pinMode(ledPin , OUTPUT);
  pinMode(ledPin1 , OUTPUT);
  pinMode(ledPin2 , OUTPUT);
  pinMode(buzzerPin , OUTPUT);
  pinMode(buzzerPin2 , OUTPUT);
  analogReference(INTERNAL1V1);
  servoM.attach(servoPin);
  Serial.begin(9600);
}

void loop() {

  if(state){ 
    if(parseValue == 1){
      pirValue = digitalRead(pirPin);
      if(pirValue == HIGH){
        Serial.print(1);
      }
    if(pirValue==1){
      delay(100);
      state=false;
    }
   }
  }

  if(state2){
    if(parseValue2 == 2){
      servoM.write(179);
      delay(15);
      state2 = false; 
  }
    if(parseValue2 == 3){
      servoM.write(0);
      delay(15);
      state2 = false;
  }
 }

 if(state3){
  fireValue = digitalRead(firePin);
    if(fireValue == 0){
      Serial.print(2);
      delay(500);
    }
    else if(fireValue != 0 ){
      Serial.print(3);
      delay(500);
    }

  lm35Value = analogRead(lm35Pin1);
  temperature = lm35Value / 9.31;
  sendValue += temperature;
  Serial.print(sendValue);
  sendValue = "t";
  delay(1000);

  lm35Value2 = analogRead(lm35Pin2);
  temperature2 = lm35Value2 / 9.31;
  sendValue2 += temperature2;
  Serial.print(sendValue2);
  sendValue2 = "T";
  delay(1000);
  
  ldrValue = analogRead(ldrPin);
  if(ldrValue < 200){
    Serial.print('L');
    delay(30);
  }
  else{
    Serial.print('H');
    delay(30);
  }
  ldrValue1 = analogRead(A1);
  if(ldrValue1 < 200){
    Serial.print('C');
    delay(30);
  }
  else{
    Serial.print("H2");
    delay(30);
  }
  ldrValue2 = analogRead(A2);
  if(ldrValue2 < 200){
    Serial.print('K');
    delay(30);
  }
  else{
    Serial.print("H3");
    delay(30);
  }
 }

 if(state4){
  digitalWrite(in3 , LOW);
  if(parseValue3 == 1){
    analogWrite(dcmotor , 90);
  }
  else if(parseValue3 == 2){
    analogWrite(dcmotor , 110);
  }
  else if(parseValue3 == 3){
    analogWrite(dcmotor , 150);
  }
  else{
    analogWrite(dcmotor , 0); 
  }
  state4 = false;
 }

 if(state5){
  digitalWrite(in4 , LOW);
  if(parseValue4 == 1){
    analogWrite(dcmotor1 , 90);
  }
  if(parseValue4 == 2){
    analogWrite(dcmotor1 , 110);
  }
  if(parseValue4 == 3){
    analogWrite(dcmotor1 , 150);
  }
  if(parseValue4 == 0){
    analogWrite(dcmotor1 , 0); 
  }
  state5 = false;
 }

 if(state6){
  analogWrite(ledPin , parseValue5);
  state6 = false;
 }
 if(state7){
  analogWrite(ledPin1 , parseValue6);
  state7 = false;
 }
 if(state8){
  analogWrite(ledPin2 , parseValue7);
  state8 = false;
 }
  
 switch(value){
    case 'R':
    digitalWrite(buzzerPin , HIGH);
    break;
    case 'S':
    digitalWrite(buzzerPin ,LOW);
    break;
    case 'F':
    digitalWrite(buzzerPin2 , HIGH);
    break;
    case 'E':
    digitalWrite(buzzerPin2 ,LOW);
    break;
  }
 value = "";  
}

void serialEvent(){
  while(Serial.available()){
     value = char(Serial.read());
    if(value == '#'){
      parseValue = Serial.parseInt();
      state = true;
     }
    if(value == '*'){
      parseValue2 = Serial.parseInt();
      state2 = true;
    }
    if(value == '%'){
      state3 = true;
    }
    if(value == '&'){
      parseValue3 = Serial.parseInt();
      state4 = true;
    }
    if(value == '$'){
      parseValue4 = Serial.parseInt();
      state5 = true;
    }
    if(value == 'L'){
      parseValue5 = Serial.parseInt();
      state6 = true;
    }
    if(value == 'C'){
      parseValue6 = Serial.parseInt();
      state7 = true;
    }
    if(value == 'K'){
      parseValue7 = Serial.parseInt();
      state8 = true;
    }
  }
}
