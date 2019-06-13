using System;
using System.Collections.Generic;
class Matematica
  {
    int numeroInteiro;

            public Matematica(int valorDesejado)
            {
              numeroInteiro = valorDesejado;
            }

            public double Fatorial()
            {
              var produtos = new Produtorio();
              var contador = new Contador(1, numeroInteiro, 1);
              while (contador.Prosseguir)
              {
                produtos.Multiplicar(contador.Valor);
                contador.Contar();
              }

              return produtos.Valor;
            }

            public string Divisores()
            {
              string lista = ""; // inicia variável string com cadeia vazia

              int metadeNumero = numeroInteiro / 2;
              var possivelDivisor = new Contador(2, metadeNumero, 1);

              while (possivelDivisor.Prosseguir)
              {
                int quociente = numeroInteiro / possivelDivisor.Valor;
                int resto = numeroInteiro - quociente * possivelDivisor.Valor;
                if (resto == 0)
                  lista = lista + possivelDivisor.Valor + ", ";
                possivelDivisor.Contar(); // gera próximo potencial divisor
              }
              return "1, " + lista + numeroInteiro; // concatena inteiros sem conversão para string
            }

            public int MDC(int outroValor)
            {
              int dividendo = numeroInteiro;
              int divisor = outroValor;
              int resto = 0;
              do
              {
                int quociente = dividendo / divisor;
                resto = dividendo - quociente * divisor;

                dividendo = divisor; // repetimos com novos valores
                divisor = resto;
              }
              while (resto != 0);

              return dividendo;
            }

            public bool EhPalindromo()
            {
              int aux = 0, numero = numeroInteiro;
              while (numero > 0)
              {
                int quociente = numero / 10;
                int resto = numero - quociente * 10;
                aux = aux * 10 + resto;
                numero = quociente;
              }
              return aux == numeroInteiro;
            }

          public int SomaDosDigitos()   // exercício 31
          {
            var soma = new Somatoria();
            int oNumero = numeroInteiro;
            while (oNumero > 0)
            {
              int quociente = oNumero / 10;
              int resto = oNumero - 10 * quociente; // resto --> dígito separado
              soma.Somar(resto);   // soma.Valor acumula a soma de cada dígito separado
              oNumero = quociente; // o numero original ficou com um digito a menos
            }

            return (int) soma.Valor;
          }

          public double Elevado(double a)   // exercício 32
          {
            int x = numeroInteiro;
            var prod = new Produtorio();

            var cont = new Contador(1, x, 1);
            while (cont.Prosseguir)
            {
              prod.Multiplicar(a);
              cont.Contar();
            }

            return prod.Valor;
          }

          public int SomaDivisores()  // exercício 33
          {
            var soma = new Somatoria();
            soma.Somar(1 + numeroInteiro);
            var cont = new Contador(2, numeroInteiro / 2, 1);
            while (cont.Prosseguir)
            {
              int resto = numeroInteiro % cont.Valor;  // calcula resto de divisão inteira
              if (resto == 0)           // houve divisão exata
                soma.Somar(cont.Valor); // o divisor é acumulado na soma

              cont.Contar(); // gera próximo possível divisor 
            }
            return (int) soma.Valor;
          }

          public bool EhPerfeito()  // exercício 34
          {
            return (SomaDivisores() == 2 * numeroInteiro);
          }

          public bool EhPrimo()
          {
            return (SomaDivisores() == 1 + numeroInteiro);
          }

          public bool EhPrimo(bool maisRapido)  // método sobrecarregado
          {
            if (numeroInteiro == 2)
              return true;

            if (numeroInteiro % 2 == 0)   // número é par?
              return false;               // não é primo

            int resto = 1;
            var possivelDivisor = new Contador(3, numeroInteiro / 2, 2);
            while (resto != 0 && possivelDivisor.Prosseguir)
            {
              resto = numeroInteiro % possivelDivisor.Valor;

              possivelDivisor.Contar();
            }

            return resto != 0;
 
          }

          public double Cosseno(double anguloEmGraus)
          {
            // convertemos angulo em graus para medida em radianos
            double x = anguloEmGraus * Math.PI / 180;
            int sinal = 1;
            var soma = new Somatoria();
            var i = new Contador(0, 2 * numeroInteiro, 2);
            while (i.Prosseguir)
            {
              var meuMat = new Matematica(i.Valor);

              double potenciaDeX = meuMat.Elevado(x);

              double fat = meuMat.Fatorial();

              double umTermo = potenciaDeX / fat;

              soma.Somar(sinal*umTermo);
              sinal = -sinal;
              i.Contar();
            }

            return soma.Valor;
          }
    

        public string ParaBinario()
        {
                int bit = 0;
                string binario = "";
                while (numeroInteiro >= 2)
                {
                    if (numeroInteiro % 2 == 1)
                        bit = 1;
                    binario = bit + binario;
                    numeroInteiro = numeroInteiro / 2;
                    bit = 0;
                }
                binario = numeroInteiro + binario;
                return binario;

        }

    private int somadosdivisores(int valor)
    {
        int i = 1;
        int soma = 0;
        while (i < valor)
        {
            if (valor % i == 0)
                soma += i;
            i++;
        }
        return soma;
    }

    public double ConstanteDePrimosGemeos()
        {
                double produto = 1, fator = 1;
                bool gemeo = true;
                var contador = new Contador(3, numeroInteiro, 2);
                while (contador.Prosseguir)
                {
                    if (somadosdivisores(contador.Valor) == 1)
                    {
                        if (gemeo)
                        {
                            fator = (contador.Valor * (contador.Valor - 2.0f)) / ((contador.Valor - 1.0f) * (contador.Valor - 1.0f));
                            produto *= fator;
                        }
                        gemeo = true;
                    }
                    else
                        gemeo = false;
                    contador.Contar();
                }
                return produto;
        }
        public List<int> Fibonacci()
        {
            int numter = numeroInteiro;
            List<int> seqFibo = new List<int>();
            int atualValor = 1;
            int proximaParcela = 0;
            int parcelaAnterior = 0;
            while (seqFibo.Count < numter)
            {
                seqFibo.Add(atualValor);
                proximaParcela = parcelaAnterior;
                parcelaAnterior = atualValor;
                atualValor = proximaParcela + parcelaAnterior;
            }
            return seqFibo;
        }

        public double Catalan()
        {
            bool sinal = false;
            var contador = new Contador(3, numeroInteiro * 2 + 3, 2);
            double resultado = 1;
            while (contador.Prosseguir)
            {
                if (sinal)
                    resultado += 1.0F / (contador.Valor * contador.Valor);
                else
                    resultado -= 1.0F / (contador.Valor * contador.Valor);
                contador.Contar();
                sinal = !sinal;
            }
            return resultado;
        }

  public List<string> Amigos()
  {
       int nummax = numeroInteiro;
       List<string> amigos = new List<string>();
       int x = 2;
       while (x < nummax)
       {
            var matA = new Matematica(x);
            int sd = (matA.SomaDivisores());
            sd -= x;
            var MatB = new Matematica(sd);
            int sd2 = MatB.SomaDivisores();
            sd2 -= sd;
            if (x == sd2 && x != sd && sd - x > 0)
                amigos.Add($"{Convert.ToString(x)} e {Convert.ToString(sd)}");
            x++;
       }
       if (amigos.Count == 0)
           amigos.Add("Não há números amigos nesse intervalo!");
       return amigos;
  }
}