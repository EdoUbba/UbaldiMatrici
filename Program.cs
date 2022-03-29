using System;
using AS2122_3G_INF_UbaldiEdoardo_MatriciDll;

const int MIN_VALUE_MAT = -100;
const int MAX_VALUE_MAT = 75;

static void Main(string[] args)
{
    Console.WriteLine("Inserisci la dimensione della matrice quadrata");
    int matSize = Convert.ToInt32(Console.ReadLine());

    // definizione e istanziazione matrice in base alle dimensioni indicate dall'utente
    int[,] mat = new int[matSize, matSize];

    // carica la matrice quadrata mat di una dimensione generica con numeri casuali come indicati 
    CaricaMatrice(ref mat);

    // visualizza la matrice
    StampaMatrice(mat);

    // conta valori nella matrice
    Console.WriteLine("Inserire il numero per cui desidera cercare il numero di occorrenze");
    int numero = Convert.ToInt32(Console.ReadLine());

    int nValori = ContaValore(mat, numero);
    Console.WriteLine($"Dentro la matrice ci sono {nValori} elementi con valore {numero}");

    int min = 0, max = 0;
    double medio = 0;

    // calcola il valore medio (ritornato) e il min e max della matrice
    medio = CalcolaMinMaxMedio(mat, ref min, ref max);
    Console.WriteLine("Il valore massimo è " + max);
    Console.WriteLine("Il valore minimo è " + min);
    Console.WriteLine("Il valore medio della matrice è " + medio);

    // inverte i valori della prima colonna della matrice con l'ultima
    InvertiColonne(ref mat);
    // visualizza la matrice
    StampaMatrice(mat);

    // stampa la cornice della matrice in senso orario a partire da [0,0]
    StampaCornice(mat);
}


/// <summary>
/// Carica i valori casuali nella matrice
/// </summary>
/// <param name="mat"></param>
static void CaricaMatrice(ref int[,] mat)
{
    Random numRand = new Random();
    int matSize = mat.GetUpperBound(0) + 1;
    for (int c = 0; c < matSize; c++)
    {
        for (int d = 0; d < matSize; d++)
        {
            mat[c, d] = numRand.Next(MIN_VALUE_MAT, MAX_VALUE_MAT);
        }
    }
}

/// <summary>
/// Stampa la cornice della matrice da [0,0] in senso orario
/// </summary>
/// <param name="mat"></param>
static void StampaCornice(int[,] mat)
{
    int matSize = mat.GetUpperBound(0) + 1;
    for (int y = 0; y < matSize; y++)
    {
        Console.WriteLine(mat[y, matSize]);
    }
    for (int u = 0; u < matSize; u++)
    {
        Console.WriteLine(mat[matSize, u]);
    }
    for (int v = 0; v < matSize; v++)
    {
        Console.WriteLine(mat[v, matSize]);
    }
    for (int l = 0; l < matSize; l++)
    {
        Console.WriteLine(mat[matSize, l]);
    }
}

/// <summary>
/// inverte i valori della prima colonna della matrice con l'ultima
/// </summary>
/// <param name="mat"></param>
/// <returns></returns>
static void InvertiColonne(ref int[,] mat)
{
    int matSize = mat.GetUpperBound(0) + 1;
    int temp;
    for (int p = 0; p < matSize; p++)
    {
        temp = mat[p, 0];
        mat[p, 0] = mat[p, matSize - 1];
        mat[p, matSize - 1] = temp;
    }
}


/// <summary>
/// Stampa la matrice
/// </summary>
/// <param name="mat"></param>
static void StampaMatrice(int[,] mat)
{
    int matSize = mat.GetUpperBound(0) + 1;
    for (int y = 0; y < matSize; y++)
    {
        for (int u = 0; u < matSize; u++)
        {
            Console.WriteLine(mat[y, u]);
        }
    }
}

/// <summary>
/// Cerca il valore passato nella matrice e restituisce il numero di occorrenze
/// </summary>
/// <param name="mat"></param>
/// <param name="valoreDaCercare"></param>
/// <returns></returns>
static int ContaValore(int[,] mat, int valoreDaCercare)
{
    int cont = 0;
    int matSize = mat.GetUpperBound(0) + 1;
    for (int y = 0; y < matSize; y++)
    {
        for (int u = 0; u < matSize; u++)
        {
            valoreDaCercare = mat[y, u];
            if (mat[y, u] == valoreDaCercare)
            {
                cont++;
            }
        }
    }
    return cont;
}


/// <summary>
/// Calcola il valore minimo, massimo e medio (ritornato) dei valori inseriti nella matrice
/// </summary>
/// <param name="mat"></param>
/// <param name="min"></param>
/// <param name="max"></param>
static double CalcolaMinMaxMedio(int[,] mat, ref int min, ref int max)
{
    max = MIN_VALUE_MAT;
    min = MAX_VALUE_MAT;
    double somma = 0, media = 0;
    int matSize = mat.GetUpperBound(0) + 1;
    for (int y = 0; y < matSize; y++)
    {
        for (int u = 0; u < matSize; u++)
        {
            if (mat[y, u] > max)
            {
                max = mat[y, u];
            }
            if (mat[y, u] < min)
            {
                min = mat[y, u];
            }
            somma = somma + mat[y, u];
        }
        media = somma / mat.Length;
    }
    return media;
}