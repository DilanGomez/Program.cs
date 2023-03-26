using System;
using System.Collections.Generic;

class Ingrediente
{
    public string nombre;
    public int cantidad;
    public double precio;

    public Ingrediente(string nombre, int cantidad, double precio)
    {
        this.nombre = nombre;
        this.cantidad = cantidad;
        this.precio = precio;
    }
}

class Pastel
{
    public string nombre;
    public string tamaño;
    public List<Ingrediente> ingredientes = new List<Ingrediente>();

    public void AgregarIngrediente()
    {
        Console.Write("Ingrese el nombre del ingrediente: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la cantidad de " + nombre + " que lleva el pastel: ");
        int cantidad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el precio unitario de " + nombre + ": $pesos");
        double precio = double.Parse(Console.ReadLine());

        Ingrediente ingrediente = new Ingrediente(nombre, cantidad, precio);
        ingredientes.Add(ingrediente);
    }

    public int CantidadDeIngredientes()
    {
        return ingredientes.Count;
    }

    public string ListaDeIngredientes()
    {
        string lista = "";
        foreach (Ingrediente ingrediente in ingredientes)
        {
            lista += ingrediente.cantidad + " " + ingrediente.nombre + "\n";
        }
        return lista;
    }

    public double CalcularCosto()
    {
        double costoTotal = 0;
        foreach (Ingrediente ingrediente in ingredientes)
        {
            costoTotal += ingrediente.cantidad * ingrediente.precio;
        }
        return costoTotal;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creamos el pastel
        Pastel pastel = new Pastel();

        // Pedimos al usuario que ingrese los datos del pastel
        Console.Write("Ingrese el nombre del pastel: ");
        pastel.nombre = Console.ReadLine();
        Console.Write("Ingrese el tamaño del pastel: ");
        pastel.tamaño = Console.ReadLine();

        // Pedimos al usuario que ingrese los ingredientes del pastel
        Console.WriteLine("Ingrese los ingredientes del pastel:");
        while (true)
        {
            pastel.AgregarIngrediente();
            Console.Write("¿Desea agregar otro ingrediente? (s/n): ");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() == "n")
            {
                break;
            }
        }

        // Mostramos la lista de ingredientes, la cantidad de ingredientes y el costo total del pastel
        Console.WriteLine("Ingredientes del " + pastel.nombre + ":");
        Console.WriteLine(pastel.ListaDeIngredientes());
        Console.WriteLine("Cantidad de ingredientes: " + pastel.CantidadDeIngredientes());
        Console.WriteLine("Costo total del pastel: $" + pastel.CalcularCosto());
    }
}