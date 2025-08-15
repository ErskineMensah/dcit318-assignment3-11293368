using System;

namespace Healthcare_System
{
    public class Patient
    {
        public int Id { get; }
        public string Name { get; }
        public int Age { get; }
        public string Gender { get; }

        public Patient(int id, string name, int age, string gender)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Age = age;
            Gender = gender ?? throw new ArgumentNullException(nameof(gender));
        }

        // Overrides ToString() to display patient details in a readable format when printed
        public override string ToString() => $"[{Id}] {Name} — Age: {Age}, Gender: {Gender}";
    }
}
