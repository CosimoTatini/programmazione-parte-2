

using System;
using System.Collections.Generic;

public class Rettangolo
{
    public double Lunghezza { get; set; }
    public double Altezza { get; set; }
    public Rettangolo(double Lunghezza, double Altezza)
    {
        this.Lunghezza = Lunghezza;
        this.Altezza = Altezza;
    }
    public double CalcolaArea()
    {

        return Lunghezza * Altezza;


    }

    public double Perimetro()
    {

        return 2 * (Lunghezza + Altezza);
    }
}
public class Composta
{
    List<Rettangolo> rettangolos = new List<Rettangolo>();

    public void AddRekt(Rettangolo rettangolo)
    {

        rettangolos.Add(rettangolo);


    }
    public void RemoveRekt(Rettangolo rettangolo)
    {
        for (int i = 0; i < rettangolos.Count; i++)
        {
            if (rettangolo.Lunghezza == rettangolo.Altezza && rettangolos[i].Lunghezza == rettangolos[i].Altezza)
            {

                rettangolos.RemoveAt(i);

            }


        }

    }
    public void ModifyRektMeas(Rettangolo rettangolo, double newaltezza, double newlunghezza)
    {

        for (int i = 0; i < rettangolos.Count; i++)
        {

            if (rettangolos[i].Lunghezza == rettangolo.Lunghezza && rettangolos[i].Altezza == rettangolo.Altezza)
            {

                rettangolos[i].Altezza = newaltezza;
                rettangolos[i].Lunghezza = newlunghezza;

            }


        }


    }
    public double CalculateAreaTotale()
    {
        double sommaA = 0;
        foreach (Rettangolo rekt in rettangolos)
        {

            rekt.CalcolaArea();
            sommaA += rekt.CalcolaArea();

        }
        return sommaA;
    }
    public double CalculateTotPerimeter()
    
    { 
     double sommaP=0;
        foreach (Rettangolo rekt in rettangolos)
        {

            rekt.Perimetro();
            sommaP += rekt.Perimetro();


        }
        return sommaP;
    
    
    
    }
}
public class Program
{
    public static void Main()
    {
        Rettangolo rettangolo1 = new Rettangolo(10, 20);
        Rettangolo rettangolo2 = new Rettangolo(40, 50);
        Composta composta = new Composta();
        composta.AddRekt(rettangolo1);
        composta.AddRekt(rettangolo2);
        double Areatot = composta.CalculateAreaTotale();
        Console.WriteLine($"L'area totale della figura è : {Areatot}");
        double Totperimeter = composta.CalculateTotPerimeter();
        Console.WriteLine($"Il perimetro totale della figura è :{Totperimeter}");
        composta.RemoveRekt(rettangolo1);

        Rettangolo rettangolo3 = new Rettangolo(50, 60);
        composta.ModifyRektMeas(rettangolo2, rettangolo3.Altezza, rettangolo3.Lunghezza);

        Areatot = composta.CalculateAreaTotale();
        Console.WriteLine($"La nuova area dopo le modifiche è:{Areatot}");

        Totperimeter = composta.CalculateTotPerimeter();
        Console.WriteLine($"Il nuovo perimetro dopo le modifiche è:{Totperimeter}");






    }
}
