using DoctorPatientDALLibrary.Model;
//using ModelClassLibrary;


namespace DoctorPatientDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        //readonly Dictionary<int, ModelClassLibrary.Doctor> _doctors;
        db_ClinicShopContext context;
        public DoctorRepository()
        {
            context = new db_ClinicShopContext();
        }

        //int GenerateId()
        //{
        //    if (_doctors.Count == 0)
        //        return 1;
        //    int id = _doctors.Keys.Max();
        //    return ++id;
        //}

        public Doctor Add(Doctor item)
        {
            var doctors = context.Doctors.ToList();
            Doctor result = doctors.FirstOrDefault(d => d.Name == item.Name);
            if (result != null)
            {
                return null;
            }
            //item.DoctorID = GenerateId()
            context.Doctors.Add(item);
            context.SaveChanges();
            return item;
        }

        public Doctor Get(int key)
        {
            var doctors = context.Doctors.ToList();
            Doctor result = doctors.FirstOrDefault(d => d.Id == key);
            if (result != null)
                return result;
            return null;
        }

        public List<Doctor> GetAll()
        {
            return context.Doctors.ToList();

        }

        public Doctor Update(Doctor item)
        {
            var doctors = context.Doctors.ToList();
            Doctor result = doctors.FirstOrDefault(d => d.Id == item.Id);
            if (result != null)
            {
                context.Doctors.Update(item);
                context.SaveChanges();
                return item;
            }

            return null;
        }

        public Doctor Delete(int key)
        {
            var doctors = context.Doctors.ToList();
            Doctor result = doctors.FirstOrDefault(d => d.Id == key);
            if (result != null)
            {
                context.Doctors.Remove(result);
                context.SaveChanges();
                return result;
            }
            return null;
        }


    }
}
