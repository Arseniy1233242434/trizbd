using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service
{
    public class ManufacturerService
    {
        private readonly PharmacyContext _db = DBService.Instance.Context;
        public static ObservableCollection<Models.Manufacturer> Users { get; set; } = new();
        public ManufacturerService()
        {
            GetAll();
        }
        public void Add(Models.Manufacturer user)
        {
            var _user = new Models.Manufacturer
            {
                Id = user.Id,
                Name = user.Name,
                Country = user.Country,

            };
            _db.Add<Models.Manufacturer>(_user);
            Commit();
            Users.Add(user);
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Manufacturers
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(Models.Manufacturer student)
        {
            _db.Remove<Models.Manufacturer>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
