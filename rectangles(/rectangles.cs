//Implementare un programma che gestisce un insieme di figure composte da rettangoli. 
//Creare classi per i rettangoli e le figure composte, con metodi per aggiungere, rimuovere, modificare rettangoli e calcolare l'area e il perimetro delle figure composte.


using System.Security.Cryptography.X509Certificates;

public class Rettangolo
{
    public double Lunghezza { get; set; }
    public double Altezza { get; set; }
    public Rettangolo(double Lunghezza, double Altezza)
    {
        Lunghezza = Lunghezza;
        Altezza = Altezza;
    }
    public double Area(double lunghezza, double Altezza)
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
      for(int i = 0; i< rettangolos.Count; i++) 
      {
            if (rettangolo.Lunghezza == rettangolo.Altezza && rettangolos[i].Lunghezza ==rettangolos[i].Altezza )
            {

                rettangolos.RemoveAt(i);

            }
         
        
      }

    }
    public void ModifyRektMeas(Rettangolo rettangolo, double newaltezza, int newlunghezza)
    {
      
     for (int i = 0;i< rettangolos.Count;i++) 
     { 
        
       if (rettangolos[i].Lunghezza==rettangolo.Lunghezza && rettangolos[i].Altezza == rettangolo.Altezza) 
       {

                rettangolos[i].Altezza = newaltezza;
                rettangolos[i].Lunghezza= newlunghezza;
            
       } 
       
        
     }


    }
    public double CalculateAreaTotale() 
    {
      double somma = 0;
     foreach( Rettangolo rekt in rettangolos ) 
     {

      rekt.Area();
      somma += rekt.Area();  
        
     }
     return somma;
    }
}
