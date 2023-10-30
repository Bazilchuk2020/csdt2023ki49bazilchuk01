#include <Wire.h>

#include <LiquidCrystal_I2C.h> 

#include <NewPing.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);

const int trig = 2;

const int echo = 3; 

int duration = 0;

int distance = 0;
int buzzer = A0;

int i;

void setup()

{

  //ultrasonic sensor

  pinMode(trig , OUTPUT);

  pinMode(echo , INPUT);
  pinMode(buzzer, OUTPUT);
  //LEDS

  for (i = 4; i <= 13; i++) {

    pinMode(i, OUTPUT);

  }

  //LCD display
   
  lcd.begin();

  lcd.backlight();

  Serial.begin(9600);

}

void loop()

{

  digitalWrite(trig , HIGH);

  delayMicroseconds(1000);

  digitalWrite(trig , LOW);

  duration = pulseIn(echo , HIGH);

  distance = (duration / 2) / 29.1 ;

  Serial.println(distance);

  lcd.clear();

  lcd.setCursor(0,0);

  lcd.print("Distance: "); 

  lcd.print(distance);

  lcd.print("CM"); 

  delay(500);

  if (distance >= 30) {
  for (int i = 10; i <= 13; i++) {
    digitalWrite(i, LOW); // Вимкнути всі лампи
  }
} else if (distance >= 25) {
  for (int i = 10; i <= 13; i++) {
    digitalWrite(i, LOW); // Вимкнути всі лампи
  }
  digitalWrite(13, HIGH); // Увімкнути лампу на піні 13
} else if (distance >= 20) {
  for (int i = 10; i <= 13; i++) {
    digitalWrite(i, LOW); // Вимкнути всі лампи
  }
  digitalWrite(13, HIGH); // Увімкнути лампу на піні 13
  digitalWrite(12, HIGH); // Увімкнути лампу на піні 12
} else if (distance >= 15) {
  for (int i = 10; i <= 13; i++) {
    digitalWrite(i, LOW); // Вимкнути всі лампи
  }
  digitalWrite(13, HIGH); // Увімкнути лампу на піні 13
  digitalWrite(12, HIGH); // Увімкнути лампу на піні 12
  digitalWrite(11, HIGH); // Увімкнути лампу на піні 11
} else if (distance >= 10) {
  for (int i = 10; i <= 13; i++) {
    digitalWrite(i, HIGH); // Увімкнути всі лампи
  }
}


 if ( distance <= 10 )
  {
    for (int k = 0; k < 10; k++) { // Повторіть це 10 разів (можете змінити кількість)
    for (int i = 10; i <= 13; i++) {
      digitalWrite(i, HIGH); // Увімкнути лампу з піна 10 до піна 13
    }
    delay(10); // Затримка 100 мс
    for (int i = 10; i <= 13; i++) {
      digitalWrite(i, LOW); // Вимкнути лампу з піна 10 до піна 13
    }
    delay(5); // Затримка 100 мс
  }
    for (int i = 0; i < 80; i++) {  
digitalWrite(buzzer, HIGH);     
delay(1);   
digitalWrite(buzzer, LOW);   
delay(1);  
}  
delay(10);  
for (int j = 0; j < 100; j++) {  
digitalWrite(buzzer, HIGH);   
delay(1); // delay 2ms   
digitalWrite(buzzer, LOW);   
delay(1);  
}  
delay(5); 
} 

}