using Agreement_Management.Data;
using Agreement_Management.DTOs;
using Agreement_Management.Interface;
using Agreement_Management.Models;
using Agreement_Management.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.Repositories
{
    public class UserRepo : IUser
    {

        private readonly ApplicationDContext _dContext;
        ServiceResponse res = new ServiceResponse();
        public UserRepo(ApplicationDContext dContext)
        {

            _dContext = dContext;
        }

        public async Task<ServiceResponse> Register(RegisterDTO registerDTO)
        {
            byte[] passwordHash, passwordSalt;
            EnumManager.CreatePasswordHash(registerDTO.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = registerDTO.Email,
                Name = registerDTO.Name,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };
            _dContext.Add(user);
            var result =await _dContext.SaveChangesAsync();

            if (result > 0)
            {
                res.Message = "Registration Successfull!";
                res.Success = true;
                res.Data = user;
                return res;
            }
            else
            {
                res.Message = "Registration failed!";
                res.Success = false;
                res.Data = null;
                return res;
            }


        }

        public async Task<ServiceResponse> Login(UserDTO user)
        {
            var data = await _dContext.Users.Where(x => x.Email == user.Email).FirstOrDefaultAsync();
            if (data != null)
            {
                var check = VerifyPasswordHash(user.Password, data.PasswordHash, data.PasswordSalt);
                if (check == true)
                {
                    res.Data = data;
                    res.Message = "Login Successful!";
                    res.Success = true;
                    return res;
                }

                res.Message = "Login Failed";
                res.Success = false;
                return res;

            }
            res.Data = null;
            res.Message = "no Record found";
            res.Success = false;
            return res;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (passwordHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (passwordSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");


            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }


                }

                return true;
            }
        }

        public  Agreement NewAgreement(AgreementDTO dTO, string userId)
        {
            try
            {
                var agree = new Agreement
                {
                    EffectiveDate = DateTime.Now,
                    New_Price = dTO.New_Price,
                    Product_Price = dTO.Product_Price,
                    ExpirationDate = DateTime.Today,
                    ProductGroupId = new ProductGroup(),
                    Product = new Product(),
                    AgreementId = dTO.AgreementId,
                    UserId = userId,
                    Active = dTO.Active
                };

                 _dContext.AddAsync(agree);
                var data =  _dContext.SaveChanges();
                if (data > 0)
                {
                    return agree;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.InnerException + ex.StackTrace);
            }


        }
        
        public  Product GetById(int Id)
        {
            var data =  _dContext.products.Where(x => x.ProductId == Id).FirstOrDefault();
            if(data != null)
            {
                return data;
            }
            return null;
        }

        public Product DeleteProduct(int Id)
        {
            var data = _dContext.products.Where(x => x.ProductId == Id).FirstOrDefault();
            if(data != null)
            {
                _dContext.Remove(data);
                 _dContext.SaveChanges();
                return data;
            }
            return null;
        }


        public  Product UpdateProduct(ProductDTO dTO)
        {
            try
            {
                var result =  _dContext.products.Where(x => x.ProductId == dTO.ProductId).FirstOrDefault();

                if (result != null)
                {
                    result.Product_Description = dTO.Product_Description;
                }
                _dContext.Entry(result).State = EntityState.Modified;
                var updated =  _dContext.SaveChanges();
                if (updated > 0)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.InnerException);
            }



        }

        public  ProductGroup UpdateProductGroup(ProductGroupDTO dTO)
        {
            try
            {
                var result = _dContext.ProductGroups.Where(x => x.productGroupId == dTO.productGroupId).FirstOrDefault();

                if (result != null)
                {
                    result.Group_Description = dTO.Group_Description;
                }
                _dContext.Entry(result).State = EntityState.Modified;
                var updated = _dContext.SaveChanges();
                if (updated > 0)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.InnerException);
            }



        }

        public async Task<ServiceResponse> CreateProductGroup(ProductGroupDTO dTO)
        {
            try
            {
                var group = new ProductGroup
                {
                    Active = dTO.Active,
                    Group_Code = dTO.Group_Code,
                    Group_Description = dTO.Group_Description
                };

                await _dContext.ProductGroups.AddAsync(group);
                 var data =  _dContext.SaveChanges();

                if (data > 0)
                {
                    res.Data = group;
                    res.Success = true;
                    return res;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message +  ex.InnerException);
            }

           
        }
        public  Product CreateProduct(ProductDTO dTO)
        {
            try
            {
                var product = new Product
                {
                    Active = dTO.Active,
                    Price = dTO.Price,
                   Product_Description = dTO.Product_Description,
                   Product_Number = dTO.Product_Number,
                   ProductGroupId = dTO.ProductGroupId
                };

                 _dContext.products.Add(product);
                var result = _dContext.SaveChanges();
                if (result > 0)
                {
                    return product;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.InnerException);
            }


        }

        public IEnumerable<Product> GetAll()
        {
            return _dContext.products.ToList();
        }
    }
}
