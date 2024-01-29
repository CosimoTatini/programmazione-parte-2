//Implementare un programma che gestisce un insieme di figure composte da rettangoli. 
//Creare classi per i rettangoli e le figure composte, con metodi per aggiungere, rimuovere, modificare rettangoli e calcolare l'area e il perimetro delle figure composte.


public class Rettangolo
{
    public double Lunghezza { get; set; }
    public double Altezza { get; set; }
    public Rettangolo(double Lunghezza, double Altezza)
    {
        Lunghezza = Lunghezza;
        Altezza = Altezza;
    }
    public double AreaTotale(double lunghezza, double Altezza)
    {

        return lunghezza * Altezza;


    }

    public double PerimetroTotale()
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
    public void ModifyRektMeas(Rettangolo rettangolo)
    {
      for (int i = 0;i<rettangolos.Count;i++)
      {

       

      }



    }
}
