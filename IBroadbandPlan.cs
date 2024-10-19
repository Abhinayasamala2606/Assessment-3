using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp78
{
    interface IBroadbandPlan
    {
        int GetBroadbandPlanAmount();

    }
    class Black : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;

        private readonly int _discountPercentage;

        private const int PlanAmount = 3000;

        public Black(bool isSusbcriptionValid, int discountPercentage)
        {

            if (discountPercentage > 50 || discountPercentage < 0)
            {
                Console.WriteLine("Argument out of range");
            }
            else
            {
                _isSubscriptionValid = isSusbcriptionValid;
                _discountPercentage = discountPercentage;
            }

        }
        public int GetBroadbandPlanAmount()
        {
            if (_isSubscriptionValid == true)
            {
                int res = PlanAmount - (PlanAmount * _discountPercentage / 100);
                return res;
            }
            return PlanAmount;
        }
    }
    class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;

        private readonly int _discountPercentage;

        private const int PlanAmount = 1500;
        public Gold(bool isSusbcriptionValid, int discountPercentage)
        {

            if (discountPercentage > 30 || discountPercentage < 0)
            {
                Console.WriteLine("Argument out of range");
            }
            else
            {
                _isSubscriptionValid = isSusbcriptionValid;
                _discountPercentage = discountPercentage;
            }
        }
        public int GetBroadbandPlanAmount()
        {
            if (_isSubscriptionValid == true)
            {
                int discountprice = PlanAmount - (PlanAmount * _discountPercentage / 100);
                return discountprice;
            }
            else
            {
                return PlanAmount;
            }

        }
    }
    class SubscribePlan
    {
        private readonly IList<IBroadbandPlan> boardbandPlans;

        public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
        {

            if (broadbandPlans == null)
            {
                throw new ArgumentNullException("broadbandplans");
            }
            boardbandPlans = broadbandPlans;
        }
        public IList<Tuple<string, int>> GetSubscriptionPlan()
        {
            if (boardbandPlans == null)
            {
                throw new ArgumentNullException("broadbandplans");
            }
            var subscriptionPlans = new List<Tuple<string, int>>();
            foreach (var plan in boardbandPlans)
            {
                if (plan is Black)
                {

                    subscriptionPlans.Add(new Tuple<string, int>("Black", plan.GetBroadbandPlanAmount()));
                }
                else
                {

                    subscriptionPlans.Add(new Tuple<string, int>("Gold", plan.GetBroadbandPlanAmount()));
                }

            }
            return subscriptionPlans;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true,50),
                new Black(false,10),
                new Gold(true,30),
                new Black(true,20),
                new Gold(false,20),
            };
            var subscriotionPlans = new SubscribePlan(plans);
            var result = subscriotionPlans.GetSubscriptionPlan();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Item1},{item.Item2}");
            }
        }
    }
}

