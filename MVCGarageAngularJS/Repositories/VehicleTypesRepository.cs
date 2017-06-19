using System;
using System.Collections.Generic;
using System.Linq;
using MVCGarageAngularJS.DataAccess;
using MVCGarageAngularJS.Models;
using System.Data.Entity;

namespace MVCGarageAngularJS.Repositories
{
    public class VehicleTypesRepository : IDisposable
    {
        private GarageContext db = new GarageContext();

        public IEnumerable<VehicleType> VehicleTypes()
        {
            return db.VehicleTypes;
        }

        public VehicleType VehicleType(int? id)
        {
            return db.VehicleTypes.Find(id);
        }

        public void Add(VehicleType type)
        {
            db.VehicleTypes.Add(type);
            db.SaveChanges();
        }

        public void Delete(int typeId)
        {
            db.VehicleTypes.Remove(VehicleType(typeId));
            db.SaveChanges();
        }

        public void Edit(VehicleType vehicleType)
        {
            db.Entry(vehicleType).State = EntityState.Modified;
            SaveChanges();
        }

        private void SaveChanges()
        {
            db.SaveChanges();
        }

        private bool disposedValue = false; // To detect redundant calls

        // This code added to correctly implement the disposable pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}