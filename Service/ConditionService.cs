using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service
{
    public class ConditionService
    {
        private readonly PharmacyContext _db = DBService.Instance.Context;
        public static ObservableCollection<Condition> Users { get; set; } = new();
        public ConditionService()
        {
            GetAll();
        }
        public void Add(Condition user)
        {
            var _user = new Condition
            {
                Id = user.Id,
                Name = user.Name,

            };
            _db.Add<Condition>(_user);
            Commit();
            Users.Add(user);
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Conditions
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(Condition student)
        {
            _db.Remove<Condition>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
