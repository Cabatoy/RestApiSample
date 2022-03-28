using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Entities.Abstract;
using Entities.Core.Dal;
using Entities.Core.Extension.Managers;
using EntitiesAndCore.Core.Dal;
using EntitiesAndCore.Models.Dto.ResultDto;

namespace EntitiesAndCore.Core.Extension.Managers
{
    public class CustomerManager :ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            var result = BusinessRules.Run(CheckForCustomerDataValid(customer));
            if (result.Success != HttpStatusCode.OK)
                return result;
            _customerDal.Add(customer);
            return new DataResult<Customer>(customer,HttpStatusCode.OK);
        }



        private IResult CheckForCustomerDataValid(Customer checkValue)
        {
            if (_customerDal.GetList(p => p.NationalityNumber == checkValue.NationalityNumber).Count != 0)
                return new ErrorResult(message: "Customer Has Been Added Before");
            return new SuccessResult();
        }
        private IResult CheckForCustomerDataValidForDelete(Customer checkValue)
        {
            if (_customerDal.GetList(p => p.NationalityNumber == checkValue.NationalityNumber).Count == 0)
                return new ErrorResult(message: "Control your  `Given NationalityNumber and Id info`  ");
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            var result = BusinessRules.Run(CheckForCustomerDataValidForDelete(customer));
            if (result.Success != HttpStatusCode.OK)
                return result;

            if (_customerDal != null && _customerDal.GetList(p => p.NationalityNumber == customer.NationalityNumber).FirstOrDefault()!.Deleted != false)
            {
                customer.Deleted = true;
                //  _customerDal.Delete(customer);
                _customerDal.Update(customer);
                return new DataResult<Customer>(customer,HttpStatusCode.OK,"Success");
            }
            return new DataResult<Customer>(customer,HttpStatusCode.NotFound,"your data not suitable for deleting.Please check");
        }

        public IResult Update(Customer customer)
        {
            if (customer != null && customer.Id > 0)
            {
                _customerDal.Update(customer);
                return new DataResult<Customer>(customer,HttpStatusCode.OK,"Success");
            }
            return new DataResult<Customer>(customer,HttpStatusCode.NotFound,"Control Your Given Context attiributes");
        }

        public IDataResult<List<Customer>> GetCustomerListWithNation(string nation)
        {
            var returnvalue = _customerDal.GetList().Where(x => x.Nationality.Equals(nation)).ToList();
            if (returnvalue.Count == 0)
                return new DataResult<List<Customer>>(returnvalue,HttpStatusCode.NotFound,"No Data");
            return new DataResult<List<Customer>>(_customerDal.GetList().Where(x => x.Nationality.Equals(nation)).ToList(),HttpStatusCode.OK,"Success");
        }

        public IDataResult<List<Customer>> GetCustomerList()
        {
            var rtValue = _customerDal.GetList();
            if (rtValue.Count == 0)
                return new DataResult<List<Customer>>(rtValue,HttpStatusCode.NotFound,"No Data Found");

            return new DataResult<List<Customer>>(rtValue,HttpStatusCode.OK,"Success");
        }

        public IDataResult<Customer> GetCustomerById(Int32 customerId)
        {
            var value = _customerDal.GetList(x => x.Id == customerId).First();
            if (value != null)
                return new DataResult<Customer>(value,HttpStatusCode.OK,"Success");
            return new DataResult<Customer>(null,HttpStatusCode.NotFound,"Control your Given Id,Data Not Found");
        }


    }
}
