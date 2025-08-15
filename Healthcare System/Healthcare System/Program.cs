using System;

namespace Healthcare_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiating HealthSystemApp
            var app = new HealthSystemApp();

            // Calling Seed sample patients and prescriptions
            app.SeedData();

            // Calling BuildPrescriptionMap()
            app.BuildPrescriptionMap();

            // Print all patients
            app.PrintAllPatients();

            // Selecting a PatientId and display all prescriptions for that patient
            int selectedPatientId = 102; 
            app.PrintAllPatients(selectedPatientId);

            Console.WriteLine("Done. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
