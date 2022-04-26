using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Object
{
    class Order
    {
        string EmportID;
        string ProductID;
        string ProductName;
        string AgentID;
        string AgentName;
        string AgentAdress;
        float Price;
        int Quantity;
        float TotalPrice;

        public string EmportID1 { get => EmportID; set => EmportID = value; }
        public string ProductID1 { get => ProductID; set => ProductID = value; }
        public string ProductName1 { get => ProductName; set => ProductName = value; }
        public string AgentID1 { get => AgentID; set => AgentID = value; }
        public string AgentName1 { get => AgentName; set => AgentName = value; }
        public string AgentAdress1 { get => AgentAdress; set => AgentAdress = value; }
        public float Price1 { get => Price; set => Price = value; }
        public int Quantity1 { get => Quantity; set => Quantity = value; }
        public float TotalPrice1 { get => TotalPrice; set => TotalPrice = value; }
    }
}
