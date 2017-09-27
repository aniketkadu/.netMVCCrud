using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCRUDWebApplication.Models
{
    public class CustomerContex : DbContext
    {
        public CustomerContex() : base("myConnectionString")
        {


        }


        public  DbSet<Customer2> Customers { get; set; }

    }
}