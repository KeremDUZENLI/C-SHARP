﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Brand = "BMW", Model = "520", HirePrice = 1000 };

            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine("Normal Offer : {0}", personalCar.HirePrice);
            Console.WriteLine("Special Offer : {0}", specialOffer.HirePrice);


            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Brand { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommericalCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get
            {
                return _carBase.HirePrice - (_carBase.HirePrice * DiscountPercentage / 100);
            }
            set
            {

            }
        }

    }
}
