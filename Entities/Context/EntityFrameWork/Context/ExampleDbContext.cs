using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Entities.Concrete.EntityFrameWork.Context
{
    public class ExampleDbContext :DbContext
    {
        public ExampleDbContext()
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (optionsBuilder != null)
                optionsBuilder.UseSqlServer(
                    @"Server =.; Database =ExampleDb ; User Id =sa ; Password =kutukola ; trusted_connection=true;");
           
        }

        public  DbSet<Customer> Customers { get; set; }
    }
}
