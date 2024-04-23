using DoctorPatientBLLibrary;
using DoctorPatientDALLibrary;
using ModelClassLibrary;
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
            Doctor doctor = new Doctor() { DoctorName = "Mike" };
            repository.Add(doctor);
            service = new DoctorBL(repository);

        }

        [Test]
        public void GetDoctorByIdSuccessTest()
        {
            // Action 
            Doctor doctor = service.GetDoctorByID(1);
            // Assert
            Assert.AreEqual(1,doctor.DoctorID); 
        }
        [Test]
        public void GetDoctorByIdFailedTest()
        {
            // Action 
            Doctor doctor = service.GetDoctorByID(1);
            // Assert
            Assert.AreNotEqual(2, doctor.DoctorID);
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
            var doctor = new Doctor() { DoctorName = "Peter" };
            int result= service.CreateDoctor(doctor);
            Assert.AreEqual(2,result);
        }
        [Test]
        public void CreateDoctorFailedTest()
        {
            var doctor = new Doctor() { DoctorName = "Peter" };
            int result = service.CreateDoctor(doctor);
            Assert.AreNotEqual(1, result);
        }
        [Test]
        public void DuplicateDoctorNameExceptionTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "Dan" };
            service.CreateDoctor(doctor);
            var exception = Assert.Throws<DuplicateDoctorNameException>(()=>service.CreateDoctor(doctor));
            Assert.AreEqual("Department Name Already Exist !!", exception.Message);
        }
        
        [Test]
        public void DeleteDoctorByIdSuccessTest()
        {
            var doctor = service.DeleteDoctor(1);
            Assert.AreEqual(1, doctor.DoctorID);
        }
        [Test]
        public void DeleteDoctorByIdFailedTest()
        {
            var doctor = service.DeleteDoctor(1);
            Assert.AreNotEqual(2, doctor.DoctorID);

        }
        [Test]
        public void DeleteDoctorByIdExceptionTest()
        {
            var exception= Assert.Throws<DoctorNotFoundException>(()=>service.DeleteDoctor(2));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);
        }
        [Test]
        public void GetAllDoctorsTest()
        {
            List<Doctor> doctors= service.GetAllDoctors();
            Assert.AreEqual(1,doctors.Count);
        }
        [Test]
        public void GetAllDoctorsExceptionTest()
        {
            service.DeleteDoctor(1);
            var exception= Assert.Throws<DoctorNotFoundException>(()=>service.GetAllDoctors());
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);
        }
        [Test]
        public void UpdateDoctorTest()
        {
            Doctor doctor = new Doctor()
            {
                DoctorName = "Jack"
            };
            service.CreateDoctor(doctor);
            Doctor result = service.UpdateDoctor(doctor);
            Assert.AreEqual(2,result.DoctorID);

        }
        [Test]
        public void UpdateDoctorExceptionTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "Denial" };
            var exception = Assert.Throws<DoctorNotFoundException>(() => service.UpdateDoctor(doctor));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);

        }
        [Test]
        public void GetDoctorBySpecialisationTest()
        {
            Doctor doctor = new Doctor() { Specialization = "Cardiologist" };
            service.CreateDoctor(doctor);
            List<Doctor> result = service.GetDoctorBySpecialization("Cardiologist");
            Assert.AreEqual(1,result.Count);    
        }
        [Test]
        public void GetDoctorBySpecializationExceptionTest()
        {

            var exception = Assert.Throws<DoctorNotFoundException>(() => service.GetDoctorBySpecialization("Cardiologist"));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);
        
        }
        [Test]
        public void GetDoctorBySpecializationExceptionTest2()
        {
            service.DeleteDoctor(1);
            var exception = Assert.Throws<DoctorNotFoundException>(() => service.GetDoctorBySpecialization("Cardiologist"));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);

        }
        [Test]
        public void GetDoctorOnAvailability()
        {
            Doctor doctor = new Doctor() { Available = true };
            service.CreateDoctor(doctor);
            List<Doctor> result = service.GetDoctorByAvailability(true);
            Assert.AreEqual(2, result.Count);
        }
        [Test]
        public void GetDoctorOnAvailabilityExceptionTest()
        {
            service.DeleteDoctor(1);
            var exception = Assert.Throws<DoctorNotFoundException>(() => service.GetDoctorByAvailability(true));
            Assert.AreEqual("Doctor not Found in the System!!", exception.Message);
        }




    }
}