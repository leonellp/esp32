#include <WiFi.h>
#include <HTTPClient.h>
#include <Arduino.h>
#include "HX711.h"

#define DT 19
#define SCK 18


const char* ssid = "Fundo";
const char* password = "p36058656";

float peso = 0;

HX711 escala;    // Relaciona a variável escala

// Variáveis ​​auxiliares para armazenar o estado de saída atual
String output26State = "off";
String output27State = "off";

// Atribuir variáveis ​​de saída aos pinos GPIO
const int output26 = 26;
const int output27 = 27;

// URL da API com o ID da Balança ja definida
String serverName = "https://192.168.0.114:5001/v1/esp/72640398-2c3c-4bed-bca7-842e0ba8389b";

// Variáveis resposável pelo timer de envio do peso para API
unsigned long lastTime = 0;
unsigned long timerDelay = 10000;

// Configurações do célula de carga e conexão com o WiFi
void setup() {
  escala.begin (DT, SCK);
  Serial.begin(115200); 
  pinMode(output26, OUTPUT);
  pinMode(output27, OUTPUT);
  digitalWrite(output26, LOW);
  digitalWrite(output27, LOW);

  WiFi.begin(ssid, password);
  Serial.println("Connecting");
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.println(".");
  }
  Serial.println("");
  Serial.print("Conectado ao Wifi com sucesso com o IP: ");
  Serial.println(WiFi.localIP());
 
  Serial.print("Leitura do Valor ADC:  ");
  Serial.println(escala.read());   // Aguarda até o dispositivo estar pronto
  Serial.println("Nao coloque nada na balanca!");
  Serial.println("Iniciando...");
  escala.set_scale(107.6909090909091);     // Substituir o valor encontrado para escala
  escala.tare(20);                // O peso é chamado de Tare.
  Serial.println("Insira o item para Pesar");
}

void loop() {
  //Envie uma solicitação HTTP POST a cada 5 minutos
  if ((millis() - lastTime) > timerDelay) {
    //Verifique o status da conexão WiFi
    if(WiFi.status()== WL_CONNECTED){
      HTTPClient http;

      // define a variável "peso" com o peso que está na balança
      peso = escala.get_units(20);
      Serial.print("Peso:");
      Serial.println(peso);
      // URL de envio dos dados para API
      String serverPath = serverName + "?peso=" + peso;

     // inicia o envio
      http.begin(serverPath.c_str());
      
      // Enviar solicitação HTTP GET de resposta do POST
      int httpResponseCode = http.POST(serverPath);

      // Print a resposta
      if (httpResponseCode>0) {
        Serial.print("HTTP Response code: ");
        Serial.println(httpResponseCode);
        
        String payload = http.getString();
        Serial.println(payload);
      }
      else {
        Serial.print("Error code: ");
        Serial.println(httpResponseCode);
      }
      // finaliza a requizição HTTP
      http.end();
    }
    else {
      Serial.println("WiFi Disconnected");
    }    
    lastTime = millis();
  }
}
