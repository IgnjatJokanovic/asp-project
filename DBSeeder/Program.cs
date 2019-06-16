using Domain;
using EfCommands.CarCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;

namespace DBSeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ProjectContext();

            var trans1 = new Transmission();
            trans1.Type = "automatic";
            context.Transmissions.Add(trans1);
            
            var trans2 = new Transmission();
            trans2.Type = "manual";
            context.Transmissions.Add(trans2);

            var fuel1 = new Fuel();
            fuel1.Type = "diesel";
            context.Fuels.Add(fuel1);

            var fuel2 = new Fuel();
            fuel2.Type = "gasolene";
            context.Fuels.Add(fuel2);
            //
            var equipment1 = new Equipment();
            equipment1.Name = "airbag";
            context.Equipment.Add(equipment1);

            var equipment2 = new Equipment();
            equipment2.Name = "Seatbelts";
            context.Equipment.Add(equipment2);

            var equipment3 = new Equipment();
            equipment3.Name = "Gps";
            context.Equipment.Add(equipment3);
            //
            var engine1 = new Engine();
            engine1.Name = "V7";
            engine1.CC = 3500;
            context.Engines.Add(engine1);

            var engine2 = new Engine();
            engine2.Name = "V8";
            engine2.CC = 3500;
            context.Engines.Add(engine2);

            var model = new Model();
            model.Name = "maserati";
            context.Models.Add(model);

            var car1 = new Car();
            car1.Name = "X1";
            car1.Price = 58000;
            car1.Engine = engine1;
            car1.Model = model;
            car1.Fuel = fuel1;
            car1.Transmission = trans1;
            car1.Alt = "X1";
            car1.Src = "www.example.com";
            car1.CarEquipment = new List<CarEquipment>();
            var carEquipment1 = new CarEquipment();
            carEquipment1.Equipment = equipment1;
            car1.CarEquipment.Add(carEquipment1);
            var carEquipment2 = new CarEquipment();
            carEquipment2.Equipment = equipment2;
            car1.CarEquipment.Add(carEquipment2);
            context.Cars.Add(car1);

            var car2 = new Car();
            car2.Name = "X2";
            car2.Price = 58000;
            car2.Engine = engine1;
            car2.Model = model;
            car2.Fuel = fuel1;
            car2.Transmission = trans1;
            car2.Alt = "X2";
            car2.Src = "www.example.com";
            car2.CarEquipment = new List<CarEquipment>();
            var carEquipment3 = new CarEquipment();
            carEquipment3.Equipment = equipment1;
            car2.CarEquipment.Add(carEquipment3);
            var carEquipment4 = new CarEquipment();
            carEquipment4.Equipment = equipment2;
            car2.CarEquipment.Add(carEquipment4);
            var carEquipment5 = new CarEquipment();
            carEquipment5.Equipment = equipment3;
            car2.CarEquipment.Add(carEquipment5);
            context.Cars.Add(car2);

            context.SaveChanges();








        }
    }
}
