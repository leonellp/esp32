# **SISTEMA DE MONITORAMENTO DE ESTOQUE**
#### Projeto de Trabalho de Conclusão de Curso

Este projeto está sendo desenvolvido como Trabalho de Conclusão de Curso para o curso de ***Automação Industrial*** ministrado pela ***Faculdade de Tecnologia Prefeito Hirant Sanazar (**Fatec Osasco**)***

**Tecnologias utilizados:**

**-Hardware:**
- Microcontrolador ESP 32;
- Módulo conversor hx711;
- Balaça digital.

**-Software:**
- C# ASP .NET Core 3.1 [API];
- Angular 11 [FRONTEND];
- PostgreSQL [BANCO DE DADOS];
- C++ [MICROCONTROLADOR ESP32].
 
Este projeto consiste em um sistema de monitoramento de estoque. A balança digital fica no estoque a baixo do produto que deseja monitorar. Essa balança envia a informação do peso total do produto para o módulo conversor HX711 para que o ESP32 possa realizar a leitura e enviar esse dado para a API. Essa informação é processada e caso haja uma alteração na quantidade de produtos é armazenado essa alteração no seu respectivo histórico. Deixando também disponível para o usuário essa informação de forma praticamente imediata.

Pelo microcontrolador ter um módulo WiFi, essas informções são transmitidas todas pela Nuvem, sendo assim possível ter acesso ao estado do estoque por qualquer dispositivo com acesso a Internet.
