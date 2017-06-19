﻿using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGarageAngularJS.Controllers
{
    public class CheckInsParkingSpots
    {
        ParkingSpotsRepository parkingSpots = new ParkingSpotsRepository();
        CheckInsRepository checkIns = new CheckInsRepository();

        public CheckIn CheckInByParkingSpot(int parkingSpotId)
        {
            return checkIns.CheckInByParkingSpot(parkingSpotId);
        }

        public Vehicle ParkedVehicle(int parkingSpotId)
        {
            CheckIn checkIn = CheckInByParkingSpot(parkingSpotId);
            if (checkIn == null)
                return null;
            else
                return checkIn.Vehicle;
        }

        public IEnumerable<ParkingSpot> AvailableParkingSpots()
        {
            return parkingSpots.ParkingSpots().Select(p => new
            {
                ParkingSpot = p,
                CheckIns = checkIns.CheckIns().Where(ch => ch.CheckOutTime == null && ch.ParkingSpotID == p.ID)
            })
            .Where(chp => chp.CheckIns.Count() == 0)
            .Select(chp => chp.ParkingSpot);
        }

        public IEnumerable<InnerJoinResult> InnerJoin(IEnumerable<ParkingSpot> parkingSpots)
        {
            return parkingSpots.Select(p => new
            {
                ParkingSpot = p,
                CheckIn = checkIns.CheckIns().FirstOrDefault(ch => ch.CheckOutTime == null && ch.ParkingSpotID == p.ID)
            }).Select(vch => new InnerJoinResult
            {
                ParkingSpot = vch.ParkingSpot,
                CheckIn = vch.CheckIn,
                Vehicle = vch.CheckIn == null ? null : vch.CheckIn.Vehicle
            });
        }

        public string Availability(CheckIn checkIn)
        {
            if (checkIn == null)
                return "Yes";
            else
            {
                if (checkIn.Booked)
                    return "Booked by " + checkIn.Vehicle.RegistrationPlate;
                else
                    return "Taken by " + checkIn.Vehicle.RegistrationPlate;
            }
        }
    }
}