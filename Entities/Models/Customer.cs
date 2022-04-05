using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entities.Core;
using Microsoft.EntityFrameworkCore;

namespace Entities.Abstract
{
    [Comment("CustomerInfo")]
    public class Customer :IEntity
    {
        public Customer()
        {

        }

        public int Id { get; init; }
        public string FullName { get; init; }
        public string Nationality { get; init; }
        public string NationalityNumber { get; init; }
        public string PhoneNumber { get; init; }
        public bool Deleted { get; init; }
        public CustomerStatus CustomerStatus { get; init; }
        public string CustomerStatusMeaning { get; init; }
        public string Description { get; init; }
        public string DescriptionTwo { get; init; }
        public string DescriptionThree { get; init; }

    }



    public enum CustomerStatus
    {
        TakenForProcessing,
        Qualified,
        OutofScope,

    }
}
