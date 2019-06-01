using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.Persistence
{
    public class PizzaSizesRepository
    {
         
        public static List<DTO.Size> GetPizzaSizes()
        {
            Database1Entities db = new Database1Entities();
            var dbSizes = db.PizzaSizes.ToList();

            List<DTO.Size> Sizes = new List<DTO.Size>();

            foreach (var dbItem in dbSizes)
            {
                DTO.Size size = new DTO.Size();

                size.Id = dbItem.Id;
                size.Price = dbItem.Price;
                size.InchSize = dbItem.Size;
                size.Description = dbItem.Description;

                Sizes.Add(size);
            }
            return Sizes;
        }
    }

    public class PizzaCrustsRepository
    {
        public static List<DTO.Crust> GetCrusts()
        {
            Database1Entities db = new Database1Entities();
            var dbcrusts = db.PizzaCrusts.ToList();

            List<DTO.Crust> crusts = new List<DTO.Crust>();

            foreach (var item in dbcrusts)
            {
                crusts.Add(new DTO.Crust()
                {
                    CrustType = item.Description,
                    Id = item.Id,
                    Price = item.Price

                });
            }

            return crusts;
        }
    }

    public class PizzaToppingsRepository
    {
        public static List<DTO.Topping> GetToppings()
        {
            Database1Entities db = new Database1Entities();
            var dbToppings = db.PizzaToppings.ToList();

            List<DTO.Topping> toppings = new List<DTO.Topping>();

            foreach (var item in dbToppings)
            {
                toppings.Add(new DTO.Topping()
                {
                    Name = item.Description,
                    Price = item.Prize,
                    Id = item.Id
                });
            }

            return toppings;
        }
    }


    public class OrdersRepository
    {
        public static Database1Entities db = new Database1Entities();

        public static List<DTO.PizzaInformations> GetUnfinishedOrders()
        {
            
            var dbToMake = db.View.ToList();
            List<DTO.PizzaInformations> unfinishedOrder = new List<DTO.PizzaInformations>();

            foreach (var item in dbToMake)
            {
                DTO.PizzaInformations pizzaInformations = new DTO.PizzaInformations();

                unfinishedOrder.Add(new DTO.PizzaInformations()
                {
                    Crust = item.Crust,
                    Id = item.Id,
                    Size = item.Size,
                    Toppings = item.Toppings
                });
            }

            return unfinishedOrder;
        }

        

        


        public static void InsertOrder(DTO.Order order)
        {

            Orders orderEntity = new Orders()
            {
                CrustId = order.CrustId,
                Address = order.Address,
                Name = order.Name,
                Phone = order.Phone,
                SizeId = order.SizeId,
                Toppings  = order.ToppingIds,
                Zip = order.ZipCode,
                Payment = (int)order.paymentMethod,
                Id = Guid.NewGuid(),
                Finished = order.Finished
            };
            db.Orders.Add(orderEntity);
            db.SaveChanges();
        }

        public static void SetFinishedFlag(Guid orderGuid, bool value)
        {
            var order = db.Orders.SingleOrDefault(x => x.Id == orderGuid);
            order.Finished = value;
            db.SaveChanges();
        }
    }
}
