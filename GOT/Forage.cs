using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT
{
    abstract class Forage : Product
    {
        abstract public string UnitOfMeasure { get;}
        abstract public int Amount { get; set; }
    }
    class Wheat : Forage
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
        public Wheat(int amount)
        {
            this.unitOfMeasure = "kg";
            this.amount = amount;
        }

    }
    class Oats: Forage
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
        public Oats(int amount)
        {
            this.unitOfMeasure = "kg";
            this.amount = amount;
        }

    }
    class Rice : Forage
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
        public Rice(int amount)
        {
            this.unitOfMeasure = "kg";
            this.amount = amount;
        }

    }

}
