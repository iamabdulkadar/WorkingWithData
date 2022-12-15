using System;
using WWDLibrary;

namespace CURDCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
            var cusRep = new CustomerRepository();
            cusRep.InsertCustomer(new Customers
            {
                CustName = "Anish",
                CustAge = 25,
                CustCity = "Tenkasi",
            });
            Console.ReadKey();

        }
    }
}
