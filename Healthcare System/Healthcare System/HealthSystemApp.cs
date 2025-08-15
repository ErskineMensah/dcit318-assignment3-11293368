using System;
using System.Collections.Generic;
using System.Linq;

namespace Healthcare_System
{
    public class HealthSystemApp
    {
        // repositories for patients and prescriptions
        private readonly Repository<Patient> _patientRepo = new Repository<Patient>();
        private readonly Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();

        // Map that stores prescriptions grouped by PatientId where Key = PatientId & Value = list of prescriptions for that patient.
        private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

        public void BuildPrescriptionMap()
        {
            _prescriptionMap = _prescriptionRepo
                .GetAll()
                .GroupBy(rx => rx.PatientId)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToList()
                );
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            return _prescriptionMap.TryGetValue(patientId, out var list)
                ? new List<Prescription>(list)   
                : new List<Prescription>();     
        }

        public void SeedData()
        {
            // sample patients
            _patientRepo.Add(new Patient(101, "Alice Mensah", 28, "Female"));
            _patientRepo.Add(new Patient(102, "Kojo Owusu", 34, "Male"));
            _patientRepo.Add(new Patient(103, "Ama Boateng", 45, "Female"));

            // sample prescriptions (PatientIds must match existing patients)
            _prescriptionRepo.Add(new Prescription(1, 101, "Amoxicillin 500mg", DateTime.Today.AddDays(-7)));
            _prescriptionRepo.Add(new Prescription(2, 101, "Paracetamol 1g", DateTime.Today.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(3, 102, "Ibuprofen 400mg", DateTime.Today.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(4, 103, "Metformin 850mg", DateTime.Today.AddDays(-1)));
            _prescriptionRepo.Add(new Prescription(5, 103, "Atorvastatin 20mg", DateTime.Today));
        }



        // Overload 1: Print all patients
        public void PrintAllPatients()
        {
            Console.WriteLine("=== Patients ===");
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine(patient);
            }
            Console.WriteLine();
        }

        // Overload 2: Print prescriptions for a specific patient
        public void PrintAllPatients(int patientId)
        {
            var patient = _patientRepo.GetById(p => p.Id == patientId);
            if (patient == null)
            {
                Console.WriteLine($"No patient found with Id = {patientId}");
                return;
            }

            Console.WriteLine($"=== Prescriptions for {patient.Name} (Id: {patient.Id}) ===");
            var prescriptions = GetPrescriptionsByPatientId(patientId);

            if (prescriptions.Count == 0)
            {
                Console.WriteLine("No prescriptions found.");
            }
            else
            {
                foreach (var rx in prescriptions.OrderByDescending(r => r.DateIssued))
                {
                    Console.WriteLine(rx);
                }
            }
            Console.WriteLine();
        }

    }
}
