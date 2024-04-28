using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT
{
    abstract class UtilityAnimal : Product
    {
        abstract public string UnitOfMeasure { get; }
        abstract public int Amount { get; set; }
    }
    class Cow : UtilityAnimal
    {
        private string unitOfMeasure;
        private int amount;

        public override string UnitOfMeasure
        {
            get { return unitOfMeasure; }
        }

        public override int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public Cow(int amount)
        {
            this.unitOfMeasure = "piece";
            this.amount = amount;
        }
    }
    class Horse : UtilityAnimal
    {
        private string unitOfMeasure;
        private int amount;

        public override string UnitOfMeasure
        {
            get { return unitOfMeasure; }
        }

        public override int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public Horse(int amount)
        {
            this.unitOfMeasure = "piece";
            this.amount = amount;
        }
    }
    class Chicken : UtilityAnimal
    {
        private string unitOfMeasure;
        private int amount;

        public override string UnitOfMeasure
        {
            get { return unitOfMeasure; }
        }

        public override int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public Chicken(int amount)
        {
            this.unitOfMeasure = "piece";
            this.amount = amount;
        }
    }
}
