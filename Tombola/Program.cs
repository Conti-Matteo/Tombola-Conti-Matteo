using System;
using System.Threading;
namespace Tombola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, x, y = 2;//dichiarazione variabile  
            Random ran = new Random();//dichiarazione variabile 
            bool[] v = new bool[90];//dichiarazione dell'array di 90 valori
            int car1v = 0, car2v = 0;//dichiarazione delle variabili per segnalare la tombola
            int[,] cart1 = new int[9, 3];//dichiarazione della matrice per la cartella 1
            int[,] cart2 = new int[9, 3];//dichiarazione della matrice per la cartella 2
            Console.WriteLine("Tabellone: ");//generazione del tabellone
            for (int i = 0; i < 9; i++)//ciclo di stampa della colonna del tabellone
            {
                x = 13;
                for (int j = 0; j < 10; j++)//ciclo di stampa della riga del tabellone
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("# ");
                    x += 3;//incremento della variabile x
                }
                y++;//incremento della variabile y
            }
            ccart1();//generazione dei numeri appartenenti alla cartella 1
            ccart2();//generazione dei numeri appartenenti alla cartella 2
            pcart1();//generazione della cartella 1
            pcart2();//generazione della cartella 2
            for (int i = 0; i < 90; i++)//ciclo di estrazione e controllo 
            {
                num = estrazione();
                x = coordx();
                y = coordy();
                for (int j = 0; j < 3; j++)//stampa del numero sul tabellone
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(num);
                    Thread.Sleep(500);
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(num);
                    Thread.Sleep(500);
                }
                hcart1();//controllo di un numero,eventuale tombola, cambio del colore dello sfondo nella cartella 1
                hcart2();//controllo di un numero,eventuale tombola, cambio del colore dello sfondo nella cartella 2
                Thread.Sleep(1000);
            }
            int estrazione()
            {
                int nume;//dichiarazione variabile 
                do//ciclo estrazione di un numero 
                {
                    nume = ran.Next(1, 91);
                } while (v[nume - 1] == true);//verifica che il numero non sia ancora uscito
                v[nume - 1] = true;//segna il numero estratto come estratto tramite un array
                return nume;
            }
            int coordx()
            {
                if (num / 10 == 0)//condizione che verifica se il numero ha 0 come decina
                {
                    x = 11 + (num % 10 * 3);//calcolo della x se la condizione è verificata
                }
                else
                {
                    if (num % 10 != 0)//condizione che verifica se il numero non ha 0 come decina
                    {
                        x = 11 + (num % 10 * 3 - 1);//calcolo della x se la condizione è verificata
                    }
                    else
                    {
                        x = 11 + num / (num / 10) * 3 - 1;//calcolo della x se la condizione non è verificata
                    }
                }
                return x;
            }
            int coordy()
            {
                if (num / 10 == 0)//condizione che verifica se il numero ha 0 come decina
                {
                    y = 2;//calcolo della y se la condizione è verificata
                }
                else
                {
                    if (num % 10 != 0)//condizione che verifica se il numero non ha 0 come decina
                    {
                        y = 2 + num / 10;//calcolo della y se la condizione è verificata
                    }
                    else
                    {
                        y = 1 + num / 10;//calcolo della y se la condizione non è verificata
                    }
                }
                return y;
            }
            int ccart1()//funzione di caricamento della matrice della prima cartella
            {
                bool[] cartv = new bool[90];//dichiarazione array di 90 elementi 
                int numr;//dichiarazione variabile 
                for (int k = 0; k < 3; k++)//ciclo che identifica le righe della cartella
                {
                    bool[] decv = new bool[10];//dichiarazione di un array di 10 elementi 
                    for (int j = 0; j < 5; j++)//ciclo che identifica i numeri da generare per ogni riga
                    {
                        do//ciclo che estrae il numero finchè non rispetta la condizione della cartella e della riga
                        {
                            numr = ran.Next(1, 91);//estrazione di un numero casuale tra 1 e 90
                        } 
                        while (cartv[numr - 1] == true || decv[numr / 10] == true);//verifica che il numero sia univoco nella cartella e che la decina sia univoca nella riga
                        cartv[numr - 1] = true;
                        decv[numr / 10] = true;
                        if (numr == 90)//condizione che sposta il 90 nella colona con decina 8
                        {
                            cart1[8, k] = 90;//assegnazione del valore 90 in caso di condizione verificata
                        }
                        else
                        {
                            cart1[numr / 10, k] = numr;//assegnazione del valore di numr in caso di condizione non verificata
                        }
                    }
                    for (int i = 0; i < 9; i++)//ciclo che imposta a false di tutti gli elementi dell'array 
                    {
                        decv[i] = false;//assegnazione di false 
                    }
                }
                return 0;
            }
            int ccart2()//funzione di caricamento della matrice della seconda cartella
            {

                bool[] cartv = new bool[90];//dichiarazione di un array di 90 elementi 
                int numr;//dichiarazione variabile 
                for (int k = 0; k < 3; k++)//ciclo che identifica le righe della cartella
                {
                    bool[] decv = new bool[10];//dichiarazione di un array di 10 elementi 
                    for (int j = 0; j < 5; j++)//ciclo che identifica i numeri da generare per ogni riga
                    {
                        do//ciclo che estrae il numero finchè non rispetta la condizione della cartella e della riga
                        {
                            numr = ran.Next(1, 91);
                            if (numr == 90)
                            {
                                j--;
                            }
                        } while (cartv[numr - 1] == true || decv[numr / 10] == true);//verifica che il numero sia univoco nella cartella e che la decina sia univoca nella riga
                        cartv[numr - 1] = true;
                        decv[numr / 10] = true;
                        if (numr == 90)//condizione che sposta il 90 nella colona con decina 8
                        {
                            cart2[8, k] = 90;//assegnazione del valore 90 in caso di condizione verificata
                        }
                        else
                        {
                            cart2[numr / 10, k] = numr;
                        }
                    }
                    for (int i = 0; i < 9; i++)//ciclo che imposta a false di tutti gli elementi dell'array 
                    {
                        decv[i] = false;//assegnazione di false 
                    }
                }
                return 0;
            }
            void pcart1()//funzione di stampa della prima cartella
            {
                x = 0;
                y = 12;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Cartella 1: ");
                y++;
                for (int i = 0; i < 5; i++)//ciclo che stampa le righe della cartella
                {
                    x = 0;
                    y++;
                    if (i % 2 == 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        for (int j = 0; j < 9; j++)//ciclo per scrivere i numeri o gli spazi 
                        {
                            if (cart1[j, i / 2 + i % 2] != 0)//condizione che verifica se è necessario stampare un numero o lo spazio
                            {
                                Console.Write($"{cart1[j, i / 2 + i % 2]} ");//stampa del numero 
                            }
                            else
                            {
                                if (j == 0)//condizione che verifica se il numero da stampare occupa 1 spazio
                                {
                                    Console.Write("  ");
                                }
                                else
                                {
                                    Console.Write("   ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            void pcart2()//funzione di stampa della seconda cartella
            {
                x = 30;
                y = 12;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Cartella 2: ");
                y++;
                for (int i = 0; i < 5; i++)
                {
                    x = 30;
                    y++;
                    if (i % 2 == 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        for (int j = 0; j < 9; j++)//ciclo per scrivere i numeri o gli spazi 
                        {
                            if (cart2[j, i / 2 + i % 2] != 0)//condizione che verifica se è necessario stampare un numero o lo spazio
                            {
                                Console.Write($"{cart2[j, i / 2 + i % 2]} ");
                            }
                            else
                            {
                                if (j == 0)//condizione che verifica se il numero da stampare occupa 1 spazio 
                                {
                                    Console.Write("  ");
                                }
                                else
                                {
                                    Console.Write("   ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            int hcart1()//funzione che evidenzia dei numeri estratti presenti nella cartella 1 e segnalazione di una vincita
            {
                x = 0;
                y = 14;
                for (int k = 0; k < 3; k++)//ciclo che identifica le righe della cartella
                {
                    for (int j = 0; j < 9; j++)//ciclo che identifica ogni numero presente o assente nella riga
                    {
                        if (cart1[j, k] == num)//condizione che verifica la presenza del numero estratto
                        {
                            if (j == 0)
                            {
                                x = 0;
                            }
                            else
                            {
                                x += j * 3 - 1;//calcolo della x in base alla decina  del numero
                            }
                            y += k * 2;//calcolo della y in base alla riga utilizzata
                            car1v++;
                            Console.SetCursorPosition(x, y);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write(num);
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (car1v == 15)
                            {
                                Console.SetCursorPosition(0, 20);
                                Console.Write("Il giocatore 1 ha fatto tombola");
                                Console.SetCursorPosition(1, 1);
                                Environment.Exit(1);
                            }
                        }
                    }
                }
                return car1v;
            }
            int hcart2()//funzione che evidenziazia dei numeri estratti presenti nella cartella 1 e segnalazione di vincita
            {
                x = 30;
                y = 14;
                for (int k = 0; k < 3; k++)//ciclo che identifica le righe della cartella
                {
                    for (int j = 0; j < 9; j++)//ciclo che identifica ogni numero presente o assente nella riga
                    {
                        if (cart2[j, k] == num)//condizione che verifica la presenza del numero estratto
                        {
                            if (j == 0)
                            {
                                x = 30;
                            }
                            else
                            {
                                x += j * 3 - 1;//calcolo della x in base alla decina  del numero
                            }
                            y += k * 2;//calcolo della y in base alla riga presa in considerazione
                            car2v++;
                            Console.SetCursorPosition(x, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write(num);
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (car2v == 15)
                            {
                                Console.SetCursorPosition(30, 20);
                                Console.Write("Il giocatore 2 ha fatto tombola");
                                Console.SetCursorPosition(1, 1);
                                Environment.Exit(1);//chiusura del programma
                            }
                        }
                    }
                }
                return car2v;
            }
        }
    }
}