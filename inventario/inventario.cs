using System;
using System.Collections.Generic;

public class Oggetto
{
    public string Nome { get; set; }
    public double Peso { get; set; }

    public Oggetto(string nome, double peso)
    {
        Nome = nome;
        Peso = peso;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Peso: {Peso}";
    }
}

public class Consumabile : Oggetto
{
    public int NumeroUsi { get; set; }

    public Consumabile(string nome, double peso, int numeroUsi) : base(nome, peso)
    {
        NumeroUsi = numeroUsi;
    }

    public void Usa()
    {
        if (NumeroUsi > 0)
        {
            Console.WriteLine($"Il consumabile {Nome} è stato usato. Usi rimasti: {NumeroUsi}");
            NumeroUsi--;
        }
        else
        {
            Console.WriteLine($"Il consumabile {Nome} è esaurito");
        }
    }
}

public enum TipoEquipaggiabile
{
    Arma,
    Armatura
}

public class Equipaggiabile : Oggetto
{
    public TipoEquipaggiabile Tipo { get; set; }
    public int Danno { get; set; }
    public int Difesa { get; set; }

    public Equipaggiabile(string nome, double peso, int dannoOuDifesa, TipoEquipaggiabile tipo) : base(nome, peso)
    {
        Tipo = tipo;

        if (tipo == TipoEquipaggiabile.Arma)
        {
            Danno = dannoOuDifesa;
        }
        else if (tipo == TipoEquipaggiabile.Armatura)
        {
            Difesa = dannoOuDifesa;
        }
        else
        {
            throw new ArgumentException("Tipo Equipaggiabile non valido.");
        }
    }

    public void Equipaggia(inventarioGiocatore inventario)
    {
        inventario.inventario.Add(this);
        Console.WriteLine($"Oggetto {Nome} equipaggiato con successo!");
    }
}

public class inventarioGiocatore
{
    public List<Oggetto> inventario { get; set; } = new List<Oggetto>();

    public void RaccogliOggetto(Oggetto oggetto)
    {
        inventario.Add(oggetto);
        Console.WriteLine($"Oggetto {oggetto.Nome} è stato raccolto");
    }

    public void ButtaOggetto(Oggetto oggetto)
    {
        inventario.Remove(oggetto);
        Console.WriteLine($"Oggetto {oggetto.Nome} è stato rimosso");
    }

    public void UsaConsumabile(Consumabile consumabile)
    {
        if (consumabile != null && consumabile is Consumabile)
        {
            consumabile.Usa();
            Console.WriteLine($"Consumabile {consumabile.Nome} è stato usato");
        }
        else
        {
            Console.WriteLine("L'oggetto selezionato non è un consumabile");
        }
    }

    public void EquipaggiaEquigiabbile(Equipaggiabile equigiabbile)
    {
        if (equigiabbile != null && equigiabbile is Equipaggiabile)
        {
            equigiabbile.Equipaggia(this);
        }
    }

    public void Stampainventario()
    {
        Console.WriteLine("Inventario:");
        foreach (var oggetto in inventario)
        {
            Console.WriteLine(oggetto);
        }
    }

    public void Stampaequipaggiati()
    {
        Console.WriteLine("Equipaggiato:");
        foreach (var equipaggiabile in inventario)
        {
            if (equipaggiabile is Equipaggiabile)
            {
                Console.WriteLine(equipaggiabile);
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        inventarioGiocatore inventario = new inventarioGiocatore();

        while (true)
        {
            Console.WriteLine("Seleziona un'azione:");
            Console.WriteLine("1. Raccogli Oggetto");
            Console.WriteLine("2. Butta Oggetto");
            Console.WriteLine("3. Usa Consumabile");
            Console.WriteLine("4. Equipaggia Equipaggiabile");
            Console.WriteLine("5. Stampa Inventario");
            Console.WriteLine("0. Esci");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Inserisci il nome dell'oggetto:");
                        string nomeOggetto = Console.ReadLine();
                        Console.WriteLine("Inserisci il peso dell'oggetto:");
                        double pesoOggetto;
                        if (double.TryParse(Console.ReadLine(), out pesoOggetto))
                        {
                            inventario.RaccogliOggetto(new Oggetto(nomeOggetto, pesoOggetto));
                        }
                        else
                        {
                            Console.WriteLine("Peso non valido.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il nome dell'oggetto da buttare:");
                        string nomeOggettoDaButtare = Console.ReadLine();
                        var oggettoDaButtare = inventario.inventario.Find(o => o.Nome == nomeOggettoDaButtare);
                        if (oggettoDaButtare != null)
                        {
                            inventario.ButtaOggetto(oggettoDaButtare);
                        }
                        else
                        {
                            Console.WriteLine("Oggetto non trovato.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Inserisci il nome del consumabile da usare:");
                        string nomeConsumabile = Console.ReadLine();
                        var consumabileDaUsare = inventario.inventario.Find(o => o.Nome == nomeConsumabile && o is Consumabile) as Consumabile;
                        if (consumabileDaUsare != null)
                        {
                            inventario.UsaConsumabile(consumabileDaUsare);
                        }
                        else
                        {
                            Console.WriteLine("Consumabile non trovato.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Inserisci il nome dell'equipaggiabile da equipaggiare:");
                        string nomeEquipaggiabile = Console.ReadLine();
                        var equipaggiabileDaEquipaggiare = inventario.inventario.Find(o => o.Nome == nomeEquipaggiabile && o is Equipaggiabile) as Equipaggiabile;
                        if (equipaggiabileDaEquipaggiare != null)
                        {
                            inventario.EquipaggiaEquigiabbile(equipaggiabileDaEquipaggiare);
                        }
                        else
                        {
                            Console.WriteLine("Equipaggiabile non trovato.");
                        }
                        break;
                    case 5:
                        inventario.Stampainventario();
                        inventario.Stampaequipaggiati();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Inserisci un numero valido.");
            }
        }
    }
}
