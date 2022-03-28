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

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public string NationalityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public bool Deleted { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
        public string CustomerStatusMeaning { get; set; }
        public string Description { get; set; }
        public string DescriptionTwo { get; set; }
        public string DescriptionThree { get; set; }

    }



    public enum CustomerStatus
    {
        TakenForProcessing,
        Qualified,
        OutofScope,

    }
}
