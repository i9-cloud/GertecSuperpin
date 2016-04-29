# GertecSuperpin #
Helper .net de conexão com o superpin da Gertec


### COMANDOS DO PIN ###
1. **BACKSPACE** Apaga o caracter anterior à posição atual do cursor e retrocede o cursor juntamente com todos os caracteres subsequentes.
2. **LIMPA DISPLAY** Apaga todo o display e coloca o cursor na posição inicial (linha 1, coluna 1).
3. **HOME** Coloca o cursor na posição inicial linha 1, coluna 1.
4. **ATIVA CURSOR** Torna o cursor visível.
5. **CURSOR PISCANTE** Transforma o cursor em um bloco piscante.
6. **APAGA CURSOR** O cursor fica invisível porém pode ser movimentado livremente.
7. **CURSOR NORMAL** Coloca o cursor na forma de um traço na parte inferior do caracter.
8. **POSICIONA CURSOR** Move o cursor para a posição especificada nos dois bytes subsequentes que são respectivamente linha e coluna.<br />
  Linha: 1 a 2 inclusive<br />
  Coluna: 1 a 16 inclusive<br />
Valores fora das faixas acima tornam o comando sem efeito.<br />
9. **CARACTERES ESPECIAIS** Programa caracteres especias no display.
10. **BEEP** Emite um sinal sonoro com duração de 200 ms.
11. **HABILITA CARTÃO** Habilita a leitura e transmissão dos dados contidos em um cartão
magnético.
12. **DESABILITA CARTÃO** Inibe a leitura de cartão magnético.
13. **HABILITA TECLADO** Habilita a transmissão das teclas digitadas.
14. **DESABILITA TECLADO** Inibe a transmissão das teclas digitadas.
15. **HAB. ECO DO TECLADO** Mostra as teclas digitadas no display.
16. **DESAB. ECO DO TECLADO** Não mostra as teclas digitadas no display.
19. **HABILITA LOOPBACK** Habilita a transmissão (eco) dos caracteres recebidos pela porta serial.
18. **DESABILITA LOOPBACK** Desabilita o eco dos caracteres recebidos pela porta serial. 


### Tabela de Comandos ###

|Comando|CÓDIGO (HEX / DEC)|
|---|---|
|Backspace|08 / 008
|Limpa display (Form Feed)|0C / 012
|Home|0B / 011
|Ativa cursor|11 / 017
|Cursor piscante|12 / 018
|Apaga cursor|13 / 019
|Beep|14 / 020
|Cursor normal|15 / 021
|Habilita cartão|80 / 128
|Desabilita cartão|81 / 129
|Habilita teclado|82 / 130
|Desabilita teclado|83 / 131 
|Posiciona o cursor|84 / 132
|Habilita eco do teclado|85 / 133
|Desabilita eco do teclado|86 / 134
|Caracteres especiais|87 / 135
|Habilita loopback|88 / 136
|Desabilita loopback|89 / 137 

