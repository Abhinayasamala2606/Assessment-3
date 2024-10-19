using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp79
{
    enum CommodityCategory
    {
        Furniture,
        Grocery,
        Service
    }
    class Commodity
    {
        public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
        {

            CommodityName = commodityName;
            CommodityQuantity = commodityQuantity;
            CommodityPrice = commodityPrice;

        }
        public CommodityCategory Category { get; set; }
        public string CommodityName { get; set; }
        public int CommodityQuantity { get; set; }
        public double CommodityPrice { get; set; }

    }
    class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates;
        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();

        }
        public void SetTaxRates(CommodityCategory category, double taxRate)
        {

            if (!_taxRates.ContainsKey(category))
            {
                _taxRates.Add(category, taxRate);
            }
        }
        public double CalculateBillAmount(IList<Commodity> items)
        {
            double totalamount = 0;
            double taxRate = 0;
            foreach (Commodity item in items)
            {

                if (!_taxRates.ContainsKey(item.Category))
                {
                    Console.WriteLine("ArgumentEception");
                }

                double itemTotal = item.CommodityPrice * item.CommodityQuantity;
                totalamount += itemTotal;
                taxRate += itemTotal * _taxRates[item.Category] / 100;



            }
            return totalamount + taxRate;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Commodities = new List<Commodity>()
            {
                new Commodity(CommodityCategory.Furniture,"Bed",2,50000),
                new Commodity(CommodityCategory.Grocery,"Flour",5,80),
                new Commodity(CommodityCategory.Service,"Insurance",8,8500)
            };
            var prepareBill = new PrepareBill();
            prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);
            var billAmount = prepareBill.CalculateBillAmount(Commodities);
            Console.WriteLine($"{billAmount}");

        }
    }
}

