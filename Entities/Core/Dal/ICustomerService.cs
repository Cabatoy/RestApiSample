using System.Collections.Generic;
using Entities.Abstract;
using EntitiesAndCore.Models.Dto.ResultDto;

namespace EntitiesAndCore.Core.Dal
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetCustomerList();
        IDataResult<Customer> GetCustomerById(int CustomerId);
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);

        IDataResult<List<Customer>> GetCustomerListWithNation(string Nation);
    }
}
