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

    public IActionResult Index()
    {
        List<Patient> PatientsList = _db.Patients.ToList();

        return View(PatientsList);
    }

    [HttpGet("patients/new")]
    public IActionResult NewPatient()
    {
        DetailFormViewModel detailFormViewModel = new()
        {
            isNotEditable = false
        };
        return View(detailFormViewModel);
    }
    
    
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


    [HttpGet("patients/view/{patientId}")]
    public IActionResult ViewPatient(int patientId)
    {
        Patient? PatientToEdit = _db.Patients.FirstOrDefault(p => p.PatientKey == patientId);
        

        if (PatientToEdit == null)
        {
            return RedirectToAction("Index");
        }

        DetailFormViewModel detailFormViewModel = new()
        {
            Patient = PatientToEdit,
            isNotEditable = true
        };

        return View(detailFormViewModel);
    }


    [HttpGet("patients/edit/{patientId}")]
    public IActionResult EditPatient(int patientId)
    {
        Patient? PatientToEdit = _db.Patients.FirstOrDefault(p => p.PatientKey == patientId);

        if (PatientToEdit == null)
        {
            return RedirectToAction("Index");
        }

        DetailFormViewModel detailFormViewModel = new()
        {
            Patient = PatientToEdit,
            isNotEditable = false
        };

        return View(detailFormViewModel);
    }


    [HttpPost("patients/update/{patientId}")]
    public IActionResult UpdatePatient(Patient updatedPatient, int patientId)
    {
        Patient? PatientToEdit = _db.Patients.FirstOrDefault(p => p.PatientKey == patientId);

        if (!ModelState.IsValid)
        {
            return View("EditPatient", PatientToEdit);
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

