using DAL_Library;
using Overriding_Overloading_model_library;
namespace RequestTrackerTest
{
    public class DepartmentRepositoryTest
    {
        IRepository<int, Department> repository;
        [SetUp]
        
        public void Setup()
        {
            repository = new DepartmentRepository();
     
        }

        [Test]
        public void Test1()
        {   // Arrange
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            var result = repository.Add(department);
            Department department1 = new Department() { Name = "A", Department_Head = 102 };
            // Action
            var result1 = repository.Add(department1);
            // Assert
            List<Department> departmentList = repository.GetAll();
            Assert.AreEqual(2,departmentList.Count);
        }

        // when we run for multiple test case
        [TestCase(1, "Hr", 101)]
        //[TestCase(2, "Admin", 101)]
        public void GetPassTest(int id, string name, int hid)
        {
            //Arrange 
            Department department = new Department() { Name = name, Department_Head = hid };
            repository.Add(department);

            //Action
            var result = repository.Get(id);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}