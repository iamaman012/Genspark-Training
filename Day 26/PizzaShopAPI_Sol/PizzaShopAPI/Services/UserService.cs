using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;
using PizzaShopAPI.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace PizzaShopAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int,Customer> _customerRepo;
        private readonly IRepository<int,CustomerDetail> _customerDRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int,Customer> customerRepo,IRepository<int,CustomerDetail> customerDRepo,ITokenService tokenService)
        { 
            _customerRepo = customerRepo;
            _customerDRepo = customerDRepo;
            _tokenService = tokenService;
        }
        public async Task<ReturnLoginDTO> Login(LoginCustomerDTO loginCustomerDTO)
        {
            var customerDetail = await _customerDRepo.GetById(loginCustomerDTO.Id);
            if (customerDetail == null)
            {
                throw new Exception("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(customerDetail.HashPasswordKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginCustomerDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, customerDetail.Password);
            if (isPasswordSame)
            {
                
                
                Customer customer = await _customerRepo.GetById(loginCustomerDTO.Id);

                ReturnLoginDTO loginReturnDTO = new ReturnLoginDTO() { Id = customer.CId, Name = customer.Name, Token = "" };
                loginReturnDTO.Token = _tokenService.GenerateToken(customer);
                return loginReturnDTO;
                // }

                
            }
            throw new Exception("Invalid username or password");
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Customer> Register(RegisterCustomerDTO registerCustomerDTO)
        {
            Customer customer = null;
            CustomerDetail customerDetail = null;
            try
            {
           
                customer = new Customer() { Name = registerCustomerDTO.Name, Address = registerCustomerDTO.Address,Phone=registerCustomerDTO.Phone };
                customer = await _customerRepo.Add(customer);
                if (customer != null)
                {
                    customerDetail = MapRegisterCustomerDTOToCustomerDetail(registerCustomerDTO);
                    customerDetail.CustomerID = customer.CId;
                    customerDetail = await _customerDRepo.Add(customerDetail);
                    return customer;
                }
                else
                {
                    throw new Exception("Customer not added");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }

        private CustomerDetail? MapRegisterCustomerDTOToCustomerDetail(RegisterCustomerDTO registerCustomerDTO)
        {
            CustomerDetail customerDetail = new CustomerDetail();
            HMACSHA512 hMACSHA = new HMACSHA512();
            customerDetail.HashPasswordKey = hMACSHA.Key;
            customerDetail.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(registerCustomerDTO.Password));
            return customerDetail;
        }
    }
}
