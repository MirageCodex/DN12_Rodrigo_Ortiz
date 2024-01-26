// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

public class Customer 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateOnly Fecha { get; set; }
}
 public class Program
{
    static void Main()
    {
        List<Customer> costumer = new List<Customer>();

        costumer.Add(new Customer { Id = 1, Nombre = "Pepito Limon", Fecha = DateOnly.FromDateTime(DateTime.Now) });
        costumer.Add(new Customer { Id = 2, Nombre = "Juan Perez", Fecha = DateOnly.FromDateTime(DateTime.Now) });
        costumer.Add(new Customer { Id = 3, Nombre = "Maria Rodriguez", Fecha = DateOnly.FromDateTime(DateTime.Now) });
        costumer.Add(new Customer { Id = 4, Nombre = "Carlos Sánchez", Fecha = DateOnly.FromDateTime(DateTime.Now) });
        costumer.Add(new Customer { Id = 5, Nombre = "Luisa Martínez", Fecha = DateOnly.FromDateTime(DateTime.Now) });
        costumer.Add(new Customer { Id = 6, Nombre = "Pedro González", Fecha = DateOnly.FromDateTime(DateTime.Now) });
        costumer.Add(new Customer { Id = 7, Nombre = "Ana Gómez", Fecha = DateOnly.FromDateTime(DateTime.Now) });
        costumer.Add(new Customer { Id = 8, Nombre = "Javier Fernández", Fecha = DateOnly.FromDateTime(DateTime.Now) });
        costumer.Add(new Customer { Id = 9, Nombre = "Elena López", Fecha = DateOnly.FromDateTime(DateTime.Now) });
        costumer.Add(new Customer { Id = 10, Nombre = "Sergio Ramírez", Fecha = DateOnly.FromDateTime(DateTime.Now) });

        Console.WriteLine("Ciclo foreach:");
        foreach (var customerF in costumer)
        {
            Console.WriteLine($"Nombre: {customerF.Nombre}, Fecha de Registro: {customerF.Fecha}");
        }

        Console.WriteLine("Ciclo for:");
        for (int i = 0; i < costumer.Count; i++)
        {

            Console.WriteLine($"Nombre: {costumer[i].Nombre}, Fecha de Registro: {costumer[i].Fecha}");
        }
        int ii = 0; 

        Console.WriteLine("Ciclo while:");
        while (ii < costumer.Count)
        {
            Console.WriteLine($"Nombre: {costumer[ii].Nombre}, Fecha de Registro: {costumer[ii].Fecha}");
            ii++;
        }
        int iii = 0;
        Console.WriteLine("Ciclo  do while:");
        do
        {
            Console.WriteLine($"Nombre: {costumer[iii].Nombre}, Fecha de Registro: {costumer[iii].Fecha}");
            iii++;

        } while (iii < costumer.Count);
    }


}
