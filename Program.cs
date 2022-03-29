using System;
using ClassMatrice;

static void Main(string[] args)
{
    ClassMatrice matrice = new ClassMatrice();
    Console.WriteLine("Inserisci la dimensione della matrice quadrata");
    int matSize = Convert.ToInt32(Console.ReadLine());

    // definizione e istanziazione matrice in base alle dimensioni indicate dall'utente
    int[,] mat = new int[matSize, matSize];

    // carica la matrice quadrata mat di una dimensione generica con numeri casuali come indicati 
    matrice.CaricaMatrice(ref mat);

    // visualizza la matrice
    matrice.StampaMatrice(mat);

    // conta valori nella matrice
    Console.WriteLine("Inserire il numero per cui desidera cercare il numero di occorrenze");
    int numero = Convert.ToInt32(Console.ReadLine());

    int nValori = matrice.ContaValore(mat, numero);
    Console.WriteLine($"Dentro la matrice ci sono {nValori} elementi con valore {numero}");

    int min = 0, max = 0;
    double medio = 0;

    // calcola il valore medio (ritornato) e il min e max della matrice
    medio = matrice.CalcolaMinMaxMedio(mat, ref min, ref max);
    Console.WriteLine("Il valore massimo è " + max);
    Console.WriteLine("Il valore minimo è " + min);
    Console.WriteLine("Il valore medio della matrice è " + medio);

    // inverte i valori della prima colonna della matrice con l'ultima
    matrice.InvertiColonne(ref mat);
    // visualizza la matrice
    matrice.StampaMatrice(mat);

    // stampa la cornice della matrice in senso orario a partire da [0,0]
    matrice.StampaCornice(mat);
}