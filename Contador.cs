using System;

public class Contador
{
  protected int 
    cont, 
    valorInicial, 
    valorFinal, 
    passo;

	public Contador(int i, int f, int p)
	{
    if (p <= 0)  // passo negativo gera loop!!! -0.5 
       throw new Exception("Incremento inválido!");

    valorInicial = cont = i;
    valorFinal = f;
    passo = p;
	}

  public void Contar()
  {
    if (Prosseguir)
      cont = cont + passo;
  }

  public bool Prosseguir
  {
    get
    {
      return cont <= valorFinal;
    }
  }

  public int Valor
  {
    get { return cont; }      //  Console.WriteLine(meuContador.Valor);
    // set { cont = value; }      meuContador.Valor = 10;
  }
}
