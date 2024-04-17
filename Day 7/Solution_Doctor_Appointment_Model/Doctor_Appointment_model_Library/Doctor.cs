namespace Doctor_Appointment_model_Library
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Speciality { get; set; }
        public double Experience {  get; set; }

        public override bool Equals(object? obj)
        {
            return this.Id.Equals((obj as Doctor).Id);
        }
    }
}
