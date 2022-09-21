using Agreement_Management.DTOs;
using Agreement_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.Interface
{
    public interface IUser
    {
        Task<ServiceResponse> Register(RegisterDTO registerDTO);
        Task<ServiceResponse> Login(UserDTO user);
        Agreement NewAgreement(AgreementDTO dTO, string userId);
        Task<ServiceResponse> CreateProductGroup(ProductGroupDTO dTO);
        Product CreateProduct(ProductDTO dTO);
        Product UpdateProduct(ProductDTO dTO);
        ProductGroup UpdateProductGroup(ProductGroupDTO dTO);
        Product GetById(int Id);

        IEnumerable<Product> GetAll();
        Product DeleteProduct(int Id);
    }
}
