using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service
{
    public class BuyersService
    {
        private readonly PharmacyContext _db = DBService.Instance.Context;
        public static ObservableCollection<Models.Buyer> Users { get; set; } = new();
        public BuyersService()
        {
            GetAll();
        }
        public void Add(Models.Buyer user)
        {
            var _user = new Models.Buyer
            {
                Id = user.Id,
                Name = user.Name,
                Date = user.Date,
                Phone = user.Phone,
                Email = user.Email,


            };
            _db.Add<Models.Buyer>(_user);
            Commit();
            Users.Add(user);
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Buyers
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(Models.Buyer student)
        {
            _db.Remove<Models.Buyer>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
