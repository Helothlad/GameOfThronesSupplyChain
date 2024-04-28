using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT
{
    abstract class Fruit : Product
    {
        abstract public string UnitOfMeasure { get; }
        abstract public int Amount { get; set; }
    }
    class Apple : Fruit
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
        public Apple(int amount)
        {
            this.unitOfMeasure = "kg";
            this.amount = amount;
        }
    }
    class Grapes : Fruit 
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
        public Grapes(int amount)
        {
            this.unitOfMeasure = "kg";
            this.amount = amount;
        }
    }
    class Banana : Fruit 
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
        public Banana(int amount)
        {
            this.unitOfMeasure = "kg";
            this.amount = amount;
        }
    }



}
