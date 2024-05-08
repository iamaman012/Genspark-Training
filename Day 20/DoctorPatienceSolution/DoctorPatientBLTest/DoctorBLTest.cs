using DoctorPatientBLLibrary;
using DoctorPatientDALLibrary;
using DoctorPatientDALLibrary.Model;

//using ModelClassLibrary;

using NuGet.Frameworks;

namespace DoctorPatientBLTest
{
    public class Tests
    {
        IRepository<int, Doctor> repository;
        IDoctorSerivce service;
        [SetUp]
        public void Setup()
        {
            repository = new DoctorRepository();
            Doctor doctor = new Doctor();
            doctor.Name = "Mike";
            repository.Add(doctor);
            service = new DoctorBL(repository);

        }

        [Test]
        public void GetDoctorByIdSuccessTest()
        {
            // Action
            ; 
            Doctor result = service.GetDoctorByID(33);
            // Assert
            Assert.AreEqual(33,result.Id); 
        }
        [Test]
        public void GetDoctorByIdFailedTest()
        {
            // Action 
            Doctor doctor = service.GetDoctorByID(33);
            // Assert
            Assert.AreNotEqual(2, doctor.Id);
        }
        [Test]
        public void GetDoctorByIdExceptionTest()
        {
            var exception = Assert.Throws<DoctorNotFoundException>(() => service.GetDoctorByID(2));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);
        }
        [Test]
        public void CreateDoctorSuccessTest()
        {
            var doctor = new Doctor();
            doctor.Name = "Aman";

            int result = service.CreateDoctor(doctor);
            Assert.AreEqual(34, result);
        }
        [Test]
        public void CreateDoctorFailedTest()
        {
            var doctor = new Doctor();
                doctor.Name = "Ramu";
            int result = service.CreateDoctor(doctor);
            Assert.AreNotEqual(1, result);
        }
        [Test]
        public void DuplicateDoctorNameExceptionTest()
        {
            Doctor doctor = new Doctor();
            doctor.Name = "Mike";   
            service.CreateDoctor(doctor);
            var exception = Assert.Throws<DuplicateDoctorNameException>(() => service.CreateDoctor(doctor));
            Assert.AreEqual("Doctor Name Already Exist !!", exception.Message);
        }

        [Test]
        public void DeleteDoctorByIdSuccessTest()
        {
            var doctor = service.DeleteDoctor(35);
            Assert.AreEqual(35, doctor.Id);
        }
        [Test]
        public void DeleteDoctorByIdFailedTest()
        {
            var doctor = service.DeleteDoctor(34);
            Assert.AreNotEqual(2, doctor.Id);

        }
        [Test]
        public void DeleteDoctorByIdExceptionTest()
        {
            var exception = Assert.Throws<DoctorNotFoundException>(() => service.DeleteDoctor(16));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);
        }
        [Test]
        public void GetAllDoctorsTest()
        {
            List<Doctor> doctors = service.GetAllDoctors();
            Assert.AreEqual(1, doctors.Count);
        }
        [Test]
        public void GetAllDoctorsExceptionTest()
        {
            service.DeleteDoctor(33);
            var exception = Assert.Throws<DoctorNotFoundException>(() => service.GetAllDoctors());
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);
        }
        [Test]
        public void UpdateDoctorTest()
        {
            Doctor doctor = new Doctor();
            doctor.Name = "Mike";

             service.CreateDoctor(doctor);
            Doctor result1 = new Doctor();
            result1.Id = 36 ; 
            result1.Name = "Dan";
            result1.Available = true;
            Doctor result = service.UpdateDoctor(result1);
            Assert.AreEqual(36, result.Id);

        }
        [Test]
        public void UpdateDoctorExceptionTest()
        {
            Doctor doctor = new Doctor();
            doctor.Id = 2;
            var exception = Assert.Throws<DoctorNotFoundException>(() => service.UpdateDoctor(doctor));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);

        }
        [Test]
        public void GetDoctorBySpecialisationTest()
        {
            Doctor doctor = new Doctor();
            doctor.Name = "Mike";
            doctor.Specialization= "Cardiologist";
            service.CreateDoctor(doctor);
            List<Doctor> result = service.GetDoctorBySpecialization("Cardiologist");
            Assert.AreEqual(1, result.Count);
        }
        [Test]
        public void GetDoctorBySpecializationExceptionTest()
        {

            var exception = Assert.Throws<DoctorNotFoundException>(() => service.GetDoctorBySpecialization("Ortho"));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);

        }
        [Test]
        public void GetDoctorBySpecializationExceptionTest2()
        {
            service.DeleteDoctor(37);
            var exception = Assert.Throws<DoctorNotFoundException>(() => service.GetDoctorBySpecialization("Cardiologist"));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);

        }
        [Test]
        public void GetDoctorOnAvailability()
        {
            
            List<Doctor> result = service.GetDoctorByAvailability(true);
            Assert.AreEqual(1, result.Count);
        }
        [Test]
        public void GetDoctorOnAvailabilityExceptionTest()
        {
         
            var exception = Assert.Throws<DoctorNotFoundException>(() => service.GetDoctorByAvailability(false));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);
        }




    }
}