﻿using DataAccess.Example.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Example.EntityFramework
{
    public class VehiclesDataManager : IVehiclesDataManager
    {
        private readonly VehiclesDataContext _dataContext;

        public VehiclesDataManager(VehiclesDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(Vehicles vehicle)
        {
            var make = _dataContext.Makes.Find(vehicle.Make.Id);
            var model = _dataContext.Models.Find(vehicle.Model.Id);

            vehicle.Make = null;
            vehicle.Model = null;

            _dataContext.Vehicles.Add(vehicle);

            make.Vehicles.Add(vehicle);
            model.Vehicles.Add(vehicle);

            _dataContext.SaveChanges();
        }

        public void Update(Vehicles vehicle)
        {
            var make = _dataContext.Makes.Find(vehicle.Make.Id);
            var model = _dataContext.Models.Find(vehicle.Model.Id);

            var entity = _dataContext.Vehicles.Find(vehicle.Id);

            entity.Year = vehicle.Year;
            entity.Make = make;
            entity.Model = model;

            _dataContext.SaveChanges();
        }

        public Vehicles Get(int id)
        {
            var entity = _dataContext.Vehicles.Find(id);
            return entity;
        }

        public IList<Vehicles> GetAll()
        {
            var result = _dataContext.Vehicles.ToList();
            return result;
        }

        public void Delete(int id)
        {
            var entity = _dataContext.Vehicles.Find(id);
            _dataContext.Vehicles.Remove(entity);

            _dataContext.SaveChanges();
        }
    }
}
