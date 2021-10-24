#include <Arduino.h>
#include "HX711.h"
#define DT 19
#define SCK 18

float offset = 0; //variável para guardar o valor bruto de offset

HX711 escala;    // Relaciona a variável escala
 
void setup() {
  escala.begin (DT, SCK);
  Serial.begin(9600);
  Serial.print("Leitura do Valor ADC:  ");
  Serial.println(escala.read());   // Aguada até o dispositivo estar pronto
  Serial.println("Nao coloque nada na balanca!");
  Serial.println("Iniciando...");
  escala.set_scale(121.8757352941176);     // Substituir o valor encontrado para escala
  escala.tare(20);                // O peso é chamado de Tare.
  Serial.println("Insira o item para Pesar");
}
 
void loop() {
  Serial.print("Valor da Leitura:  ");
  Serial.println(escala.get_units(20), 3);  // Retorna peso descontada a tara
  delay(100);
}
