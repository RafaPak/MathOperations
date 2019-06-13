using System;

public class Somatoria
{
  double soma;
  int quantosValoresForamSomados;

  public Somatoria()
  {
    soma = 0;
    quantosValoresForamSomados = 0;
  }

  public double Valor
  {
    get { return soma; }
  }

  public int Quantos
  {
    get { return quantosValoresForamSomados;  }
  }

  public void Somar(double valorASerSomado)
  {
    soma += valorASerSomado;
    quantosValoresForamSomados++;  // incrementa em 1
  }

  public double MediaAritmetica
  {
    get
    {
      if (quantosValoresForamSomados <= 0)
        throw new Exception("Divisão por zero!");

      return soma / quantosValoresForamSomados;
    }
  }
}
