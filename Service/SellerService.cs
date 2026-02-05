using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service
{
    public class SellerService
    {
        private readonly PharmacyContext _db = DBService.Instance.Context;
        public static ObservableCollection<Models.Seller> Users { get; set; } = new();
        public SellerService()
        {
            GetAll();
        }
        public void Add(Models.Seller user)
        {
            var _user = new Models.Seller
            {
                Id = user.Id,
                Name = user.Name,
                IsActive=user.IsActive,
               IsAdmin=user.IsAdmin,
               Login=user.Login,
               Password=user.Password,
               Sales=user.Sales,

            };
            _db.Add<Models.Seller>(_user);
            Commit();
            Users.Add(user);
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Sellers
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(Models.Seller student)
        {
            _db.Remove<Models.Seller>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
