using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service
{
    public class Arrivalservice
    {
        private readonly PharmacyContext _db = DBService.Instance.Context;
        public static ObservableCollection<Models.Arrival> Users { get; set; } = new();
        public Arrivalservice()
        {
            GetAll();
        }
        public void Add(Models.Arrival user)
        {
            var _user = new Models.Arrival
            {
                Id = user.Id,
               MedicineId = user.MedicineId,
               SupplierId = user.SupplierId,
               OrderNumber = user.OrderNumber,
               Date = user.Date,
               Price = user.Price,
               PricePackage = user.PricePackage,


            };
            _db.Add<Models.Arrival>(_user);
            Commit();
            Users.Add(user);
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Arrivals
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(Models.Arrival student)
        {
            _db.Remove<Models.Arrival>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
