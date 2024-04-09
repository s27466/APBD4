using AnimalREST.Models;
using Microsoft.AspNetCore.Mvc;
using static AnimalREST.Controllers.AnimalsController;

namespace AnimalREST.Controllers;

[Route("api/appointments")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    public static readonly List<Appointment> _appointments = new ()
    {
        new Appointment { Date = "2024-04-09", Animal = _animals[0], Description = "General checkup", Price = 50.0f },
        new Appointment { Date = "2024-04-10", Animal = _animals[1], Description = "Vaccination", Price = 70.0f },
        new Appointment { Date = "2024-04-11", Animal = _animals[2], Description = "Surgery", Price = 200.0f }
    };
    
    [HttpGet]
    public IActionResult GetAppointments()
    {
        return Ok(_appointments);
    }
    
    [HttpPost]
    public IActionResult CreateAppointment(Appointment appointment)
    {
        _appointments.Add(appointment);
        return StatusCode((StatusCodes.Status201Created));
    }
    
}