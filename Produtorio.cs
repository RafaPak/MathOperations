using System;

public class Produtorio
{
    double produto;
    int quantosValoresForamMultiplicados;

    public Produtorio()
    {
        produto = 1;
        quantosValoresForamMultiplicados = 0;
    }

    public void Multiplicar(double valorASerMultiplicado)
    {
        produto *= valorASerMultiplicado;
        quantosValoresForamMultiplicados++;
    }

    public double Valor
    {
        get => produto;
    }

    public double MediaGeometrica
    {
        get
        {
          if (quantosValoresForamMultiplicados == 0)
            throw new Exception("Impossível calcular média");

          return Math.Pow(produto, 
                   1 / quantosValoresForamMultiplicados);
  
        }
    }
}
