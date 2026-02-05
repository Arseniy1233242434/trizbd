using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service
{
    public class MedicineService
    {
        private readonly PharmacyContext _db = DBService.Instance.Context;
        public static ObservableCollection<Models.Medicine> Users { get; set; } = new();
        public MedicineService()
        {
            GetAll();
        }
        public void Add(Models.Medicine user)
        {
            var _user = new Models.Medicine
            {
                Id = user.Id,
                Name = user.Name,
                TypeId=user.TypeId,
                CategotyId=user.CategotyId,
                ManufacturerId = user.ManufacturerId,
                Prescription = user.Prescription,
                ExpirationPeriod = user.ExpirationPeriod,
                Dosage = user.Dosage,
                Count = user.Count,
                ConditionId=user.ConditionId,
                UnitId=user.UnitId,
              
                UnitinId = user.UnitinId,
                Arrivals = user.Arrivals,
                Categoty = user.Categoty,
                Condition = user.Condition,
                Manufacturer = user.Manufacturer,
                Type = user.Type,
                Unit= user.Unit,
                Unitin=user.Unitin,


            };
            _db.Add<Models.Medicine>(_user);
            Commit();
            Users.Add(user);
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Medicines
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(Models.Medicine student)
        {
            _db.Remove<Models.Medicine>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
