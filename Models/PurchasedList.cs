using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models
{
    /// <summary>
    /// Name : Kihyun Kim, Daniel Barbieri, Stephanie Martyna, James Bryan Bareng
    /// Date : 24 Apr 2023
    /// Description : Add Purchased list class and properties.
    /// </summary>
    public static class PurchasedList
    {
        public static List<MenuItem> PurchasedItems { get; set; } = new List<MenuItem>();
    }
}
