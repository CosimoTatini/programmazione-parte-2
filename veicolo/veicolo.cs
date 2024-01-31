using System;

// Definizione della classe base Veicolo
class Veicolo
{
    // Proprietà comuni
    public string Marca { get; set; }
    public string Modello { get; set; }

    // Metodo Descrizione che restituisce informazioni di base
    public virtual string Descrizione()
    {
        return $"Veicolo: {Marca} {Modello}";
    }
}

// Sottoclasse Auto che eredita dalla classe Veicolo
class Auto : Veicolo
{
    // Proprietà specifiche per Auto
    public int NumeroPorte { get; set; }

    // Override del metodo Descrizione per implementare in modo specifico per Auto
    public override string Descrizione()
    {
        return $"Auto: {Marca} {Modello}, Numero Porte: {NumeroPorte}";
    }
}

// Sottoclasse Moto che eredita dalla classe Veicolo
class Moto : Veicolo
{
    // Proprietà specifiche per Moto
    public bool HaCasco { get; set; }

    // Override del metodo Descrizione per implementare in modo specifico per Moto
    public override string Descrizione()
    {
        string cascoInfo = HaCasco ? "con casco" : "senza casco";
        return $"Moto: {Marca} {Modello}, {cascoInfo}";
    }
}

class Program
{
    static void Main()
    {
        // Creazione di diverse istanze di Veicolo, Auto e Moto
        Veicolo veicoloGenerale = new Veicolo { Marca = "Generica", Modello = "Veicolo" };
        Auto auto = new Auto { Marca = "Toyota", Modello = "Corolla", NumeroPorte = 4 };
        Moto moto = new Moto { Marca = "Honda", Modello = "CBR600RR", HaCasco = true };

        // Chiamata al metodo Descrizione() su ciascuna istanza
        Console.WriteLine(veicoloGenerale.Descrizione());
        Console.WriteLine(auto.Descrizione());
        Console.WriteLine(moto.Descrizione());
    }
}


