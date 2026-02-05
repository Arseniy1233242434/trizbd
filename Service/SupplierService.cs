using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service
{
    public class SupplierService
    {
        private readonly PharmacyContext _db = DBService.Instance.Context;
        public static ObservableCollection<Models.Supplier> Users { get; set; } = new();
        public SupplierService()
        {
            GetAll();
        }
        public void Add(Models.Supplier user)
        {
            var _user = new Models.Supplier
            {
                Id = user.Id,
                Name = user.Name,
                ContactPerson= user.ContactPerson,
                Phone  = user.Phone,
                Email = user.Email,


            };
            _db.Add<Models.Supplier>(_user);
            Commit();
            Users.Add(user);
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Suppliers
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(Models.Supplier student)
        {
            _db.Remove<Models.Supplier>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
