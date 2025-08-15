using System;

namespace Healthcare_System
{
    public class Prescription
    {
        public int Id { get; }
        public int PatientId { get; }
        public string MedicationName { get; }
        public DateTime DateIssued { get; }

        public Prescription(int id, int patientId, string medicationName, DateTime dateIssued)
        {
            Id = id;
            PatientId = patientId;
            MedicationName = medicationName ?? throw new ArgumentNullException(nameof(medicationName));
            DateIssued = dateIssued;
        }

        // Overrides ToString() to display prescription details in a readable format when printed
        public override string ToString() => $"Rx[{Id}] {MedicationName} — {DateIssued:yyyy-MM-dd} (PatientId: {PatientId})";
    }
}
