using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DigitechTakeHomeProject.Models;

namespace DigitechTakeHomeProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private SqlContext _db;

    public HomeController(ILogger<HomeController> logger, SqlContext db)
    {
        _logger = logger;
        _db = db;
    }

    // Navigate to the Home page and display all patients
    public IActionResult Index()
    {
        List<Patient> PatientsList = _db.Patients.ToList();

        return View(PatientsList);
    }

    // Navigate to the New Patient form
    [HttpGet("patients/new")]
    public IActionResult NewPatient() => View();
    

    // Create a new patient and add to the database
    [HttpPost("patients/create")]
    public IActionResult CreatePatient(Patient newPatient)
    {

        if (!ModelState.IsValid)
        {
            return View("NewPatient");
        }

        var lastAccountNumber = _db.Patients.Max(a => (int?)a.AccountNumber) ?? 0;
        newPatient.AccountNumber = lastAccountNumber + 1;
        _db.Add(newPatient);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }


    // Display data for a single patient
    [HttpGet("patients/view/{patientId}")]
    public IActionResult ViewPatient(int patientId)
    {
        Patient? PatientToEdit = _db.Patients.FirstOrDefault(p => p.PatientKey == patientId);

        if (PatientToEdit == null)
        {
            return RedirectToAction("Index");
        }

        return View(PatientToEdit);
    }


    // Display the Edit Patient form
    [HttpGet("patients/edit/{patientId}")]
    public IActionResult EditPatient(int patientId)
    {
        Patient? PatientToEdit = _db.Patients.FirstOrDefault(p => p.PatientKey == patientId);

        if (PatientToEdit == null)
        {
            return RedirectToAction("Index");
        }

     
        return View(PatientToEdit);
    }


    // Update the patient data in the database
    [HttpPost("patients/update/{patientId}")]
    public IActionResult UpdatePatient(Patient updatedPatient, int patientId)
    {
        Patient? PatientToEdit = _db.Patients.FirstOrDefault(p => p.PatientKey == patientId);

        if (!ModelState.IsValid)
        {
            return View("EditPatient", updatedPatient);
        }

        if (PatientToEdit != null)
        {
            PatientToEdit.LastName = updatedPatient.LastName;
            PatientToEdit.FirstName = updatedPatient.FirstName;
            PatientToEdit.MiddleInitial = updatedPatient.MiddleInitial;
            PatientToEdit.Address1 = updatedPatient.Address1;
            PatientToEdit.Address2 = updatedPatient.Address2;
            PatientToEdit.City = updatedPatient.City;
            PatientToEdit.State = updatedPatient.State;
            PatientToEdit.ZipCode = updatedPatient.ZipCode;
            PatientToEdit.HomePhone = updatedPatient.HomePhone;
            PatientToEdit.BusinessPhone = updatedPatient.BusinessPhone;
            PatientToEdit.CellPhone = updatedPatient.CellPhone;
            PatientToEdit.EmailAddress = updatedPatient.EmailAddress;

            _db.SaveChanges();
        }

        return RedirectToAction("Index");

    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

