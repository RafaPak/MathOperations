using System;
using System.IO;

namespace ProjetoTP1
{
    class Aluno
    {
        const int tamanhoClasse = 6;
        const int tamanhoRA = 5;
        const int tamanhoNota = 4;

        string classe, RA;
        double nota;

        public string Classe
        {
            get => classe;
            set
            {
                classe = value;
                if (classe.Length > tamanhoClasse)
                    classe = classe.Substring(0, tamanhoClasse);
                classe = classe.PadRight(tamanhoClasse);
            }
        }
        public string ra
        {
            get => RA;
            set
            {
                RA = value;
                if (RA.Length > tamanhoRA)
                    RA = RA.Substring(tamanhoNota+1, tamanhoRA);
            }
        }
        public double Nota
        {
            get => nota;
            set => nota = value;
        }
        public void Informacoes(StreamReader arquivo)
        {
            if (!arquivo.EndOfStream)
            {
                string linha = arquivo.ReadLine();
                classe = linha.Substring(0, tamanhoClasse);
                RA = linha.Substring(tamanhoClasse, tamanhoRA);
                nota = double.Parse(linha.Substring(tamanhoRA, tamanhoNota));
            }
        }
    }
}