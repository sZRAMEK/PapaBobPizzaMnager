using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.DTO;

namespace PapaBobsMegaChallenge.Domain
{
    public class PizzaSizeMenager
    {
        public static List<DTO.Size> GetPizzaSizes()
        {
            return Persistence.PizzaSizesRepository.GetPizzaSizes();
        }

        public static List<DTO.Crust> GetCrustTypes()
        {
            return Persistence.PizzaCrustsRepository.GetCrusts();
        }

        public static List<DTO.Topping> GetToppings()
        {
            return Persistence.PizzaToppingsRepository.GetToppings();
        }

        public static List<DTO.PizzaInformations> GetUnfinishedPizzas()
        {
            return Persistence.OrdersRepository.GetUnfinishedOrders();
        }

        

        public static Double CalculatePrice(Guid size, Guid crust, List<Guid> selectedToppingsId )
        {
            double price = 0;
            
            foreach (var item in selectedToppingsId)
            {
                price += getToppingPrice(item);
            }
            price += getCrustPrice(crust);
            price += getSizePrice(size);

            return price;
        }

        private static double getToppingPrice(Guid ToppingId)
        {
            return Persistence.PizzaToppingsRepository.GetToppings().Find(x=>x.Id== ToppingId).Price;
        }

        private static double getCrustPrice(Guid crustId)
        {
            return Persistence.PizzaCrustsRepository.GetCrusts().Find(x=>x.Id==crustId).Price;
        }

        private static double getSizePrice(Guid sizeId)
        {
            return Persistence.PizzaSizesRepository.GetPizzaSizes().Find(x => x.Id == sizeId).Price;
        }

        public static void RegisterOrder(Order order)
        { 
            if (validateOrderData(order))
            {
                Persistence.OrdersRepository.InsertOrder(order);
            } 
        }

        private static bool validateOrderData(Order order)
        {

            //validate name
            if (order.Name == "") { throw new Domain.Exceptions.EmptyFieldException("Name"); }
            
            //validate address
            if (order.Address == "") { throw new Domain.Exceptions.EmptyFieldException("Address"); }
            //validate zip
            if (order.ZipCode == "") { throw new Domain.Exceptions.EmptyFieldException("ZipCode"); }
            //validate phone
            if (order.Phone == "") { throw new Domain.Exceptions.EmptyFieldException("Phone"); }

            return true;
        }

        public static void FinishOrder(Guid orderGuid)
        {
            Persistence.OrdersRepository.SetFinishedFlag(orderGuid, true);
        }
    }
}
