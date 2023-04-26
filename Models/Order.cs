using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models
{
    /// <summary>
    /// Name : Kihyun Kim, Daniel Barbieri, Stephanie Martyna, James Bryan Bareng
    /// Date : 17 Apr 2023
    /// Description : Add class and properties.
    /// </summary>
    class Order
    {
        public int OrderID { get; set; }
        public int TableID { get; set; }
        
        // EmployeeID includes owner, manager ID
        public int EmployeeID { get; set; }



        // TODO : Add more properties (If we need).


    }
}
