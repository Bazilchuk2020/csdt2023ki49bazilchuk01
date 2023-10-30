
String string1="";
String string2="";
String space = " ";

void setup() {
Serial.begin(9600);
}

void loop() {
  if(Serial.available()){
  string1= Serial.readString();
   string2= Serial.readString();

Serial.print(string1+space+string2);

  }

  
}