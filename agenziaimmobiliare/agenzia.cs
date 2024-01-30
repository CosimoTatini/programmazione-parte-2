using System;
using System.Collections.Generic;
using System.Linq;

public class Immobile
{
    protected string indirizzo;
    protected string codice;
    protected string CAP;
    protected double superficie;

    public Immobile(string codice, string indirizzo, string CAP, double superficie)
    {
        this.codice = codice;
        this.indirizzo = indirizzo;
        this.CAP = CAP;
        this.superficie = superficie;
    }

    public override string ToString()
    {
        return $"Codice:{codice}, Indirizzo:{indirizzo}, CAP:{CAP}, Superficie:{superficie}";
    }
}

public class Box : Immobile
{
    public Box(string codice, string indirizzo, string CAP, double superficie)
        : base(codice, indirizzo, CAP, superficie)
    {
    }
}

public class Appartamento : Immobile
{
    private int numerovani;
    private int numerobagni;

    public Appartamento(string codice, string indirizzo, string CAP, double superficie, int numerovani, int numerobagni)
        : base(codice, indirizzo, CAP, superficie)
    {
        this.numerovani = numerovani;
        this.numerobagni = numerobagni;
    }

    public override string ToString()
    {
        return base.ToString() + $", Numero Vani:{numerovani}, Numero Bagni:{numerobagni}";
    }
}

public class Villa : Immobile
{
    private double dimensionegiardino;

    public Villa(string codice, string indirizzo, string CAP, double superficie, double dimensionegiardino)
        : base(codice, indirizzo, CAP, superficie)
    {
        this.dimensionegiardino = dimensionegiardino;
    }

    public override string ToString()
    {
        return base.ToString() + $", Dimensione Giardino:{dimensionegiardino}";
    }
}

public class AgenziaImmobiliare
{
    private List<Immobile> listaImmobili;

    public AgenziaImmobiliare()
    {
        listaImmobili = new List<Immobile>();
    }

    public void AggiungiImmobile(Immobile immobile)
    {
        listaImmobili.Add(immobile);
    }

    public List<Immobile> RicercaImmobile(string key)
    {
        return listaImmobili.Where(immobile => immobile.ToString().Contains(key)).ToList();
    }
}

class Program
{
    static void Main()
    {
        AgenziaImmobiliare agenzia = new AgenziaImmobiliare();

        agenzia.AggiungiImmobile(new Box("B001", "Via Roma 123", "00100", 25.5));
        agenzia.AggiungiImmobile(new Appartamento("A002", "Corso Vittorio Emanuele 45", "00200", 100.0, 3, 2));
        agenzia.AggiungiImmobile(new Villa("V003", "Piazza San Marco 10", "00300", 150.0, 200.0));

        string chiaveRicerca = "A002";
        List<Immobile> risultati = agenzia.RicercaImmobile(chiaveRicerca);

        Console.WriteLine($"Risultati della ricerca per chiave '{chiaveRicerca}':");
        foreach (var immobile in risultati)
        {
            Console.WriteLine(immobile);
        }
    }
}
