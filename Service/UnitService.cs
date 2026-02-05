using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service
{
    public class UnitService
    {
        private readonly PharmacyContext _db = DBService.Instance.Context;
        public static ObservableCollection<Unit> Users { get; set; } = new();
        public UnitService()
        {
            GetAll();
        }
        public void Add(Unit user)
        {
            var _user = new Unit
            {
                Id = user.Id,
                Name = user.Name,

            };
            _db.Add<Unit>(_user);
            Commit();
            Users.Add(user);
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Units
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(Unit student)
        {
            _db.Remove<Unit>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
