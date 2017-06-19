﻿using MVCGarageAngularJS.DataAccess;
using MVCGarageAngularJS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVCGarageAngularJS.Repositories
{
    public class ParkingSpotsRepository : IDisposable
    {
        private GarageContext db = new GarageContext();

        public IEnumerable<ParkingSpot> ParkingSpots()
        {
            return db.ParkingSpots;
        }

        public ParkingSpot ParkingSpot(int? id)
        {
            return db.ParkingSpots.Find(id);
        }

        public ParkingSpot ParkingSpotByIdentifiant(string label)
        {
            return ParkingSpots().SingleOrDefault(p => string.Compare(p.Label, label, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        public IEnumerable<ParkingSpot> ParkingSpotsByIdentifiant(string label)
        {
            return ParkingSpots().Where(p => p.Label.ToUpper().Contains(label.ToUpper()));
        }

        public void Add(ParkingSpot parkingSpot)
        {
            db.ParkingSpots.Add(parkingSpot);
            SaveChanges();
        }

        public void Edit(ParkingSpot parkingSpot)
        {
            db.Entry(parkingSpot).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(int id)
        {
            db.ParkingSpots.Remove(ParkingSpot(id));
            db.SaveChanges();
        }

        private void SaveChanges()
        {
            db.SaveChanges();
        }

        #region IDisposable Support

        private bool disposedValue = false;

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

        #endregion
    }
}
