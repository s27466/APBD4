namespace AnimalREST.Models;

public class Appointment
{
    public string Date { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
}