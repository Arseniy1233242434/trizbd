using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service
{
    public class SaleService
    {
        private readonly PharmacyContext _db = DBService.Instance.Context;
        public static ObservableCollection<Models.Sale> Users { get; set; } = new();
        public SaleService()
        {
            GetAll();
        }
        public void Add(Models.Sale user)
        {
            var _user = new Models.Sale
            {
                Id = user.Id,
               
                OrderNumber = user.OrderNumber,
                Date = user.Date,
                Price = user.Price,
               ArrivalId = user.ArrivalId,
               Count = user.Count,
               SellerId = user.SellerId,
               BuyerId = user.BuyerId,
               Buyer=user.Buyer,
               Payment=user.Payment,
               Arrival=user.Arrival,
               Seller=user.Seller,

            };
            _db.Add<Models.Sale>(_user);
            Commit();
            Users.Add(user);
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Sales
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(Models.Sale student)
        {
            _db.Remove<Models.Sale>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
