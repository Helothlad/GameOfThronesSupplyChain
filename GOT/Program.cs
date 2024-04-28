using System;

namespace GOT
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create product
            Wheat wheat = new Wheat(10);
            Oats oats = new Oats(2);
            Rice rice = new Rice(30);

            Chicken chicken = new Chicken(30);
            Cow cow = new Cow(30);
            Horse horse = new Horse(5);

            Banana banana = new Banana(4);
            Apple apple = new Apple(30);
            Grapes grapes = new Grapes(30);

            //Insert product
            ProductsList list = new ProductsList();
            list.InsertElement(wheat);
            list.InsertElement(oats);
            list.InsertElement(rice);

            list.InsertElement(chicken);
            list.InsertElement(cow);
            list.InsertElement(horse);

            list.InsertElement(banana);
            list.InsertElement(apple);
            list.InsertElement(grapes);
            KingWarehouse warehouse = new KingWarehouse(list);

            //warehouse.WareHouseDisplay();

            //Create Stark family 6
            List<Type> starkPreference= new List<Type> { typeof(Wheat), typeof(Oats), typeof(Chicken) };
            ProductPreference starkPref = new ProductPreference(starkPreference, 10);
            House Stark = new House(starkPref, "Stark");
            Stark.InsertPerson("Eddard Stark");
            Stark.InsertPerson("Catelyn Stark");
            Stark.InsertPerson("Sansa Stark");
            Stark.InsertPerson("Arya Stark");
            Stark.InsertPerson("Brandon Stark");
            Stark.InsertPerson("Robb Stark");


            //Create Lannister family 5
            List<Type> lannisterPreference = new List<Type> { typeof(Cow), typeof(Grapes), typeof(Rice) };
            ProductPreference lannisterPref = new ProductPreference(lannisterPreference, 5);
            House Lannister = new House(lannisterPref, "Lannister");
            Lannister.InsertPerson("Jaime Lannister");
            Lannister.InsertPerson("Tyrion Lannister");
            Lannister.InsertPerson("Cersei Lannister");
            Lannister.InsertPerson("Tywin Lannister");
            Lannister.InsertPerson("Kevan Lannister");

            //Create Greyjoy family2
            List<Type> greyjoyPreference = new List<Type> { typeof(Oats), typeof(Banana), typeof(Horse) };
            ProductPreference greyjoyPref = new ProductPreference(greyjoyPreference, 7);
            House Greyjoy = new House(greyjoyPref, "Greyjoy");
            Greyjoy.InsertPerson("Theon Greyjoy");
            Greyjoy.InsertPerson("Horserd Bahorsen Greyjoy");

            //Create Martell family 1
            List<Type> martellPreference = new List<Type> { typeof(Wheat), typeof(Banana), typeof(Oats) };
            ProductPreference martellPref = new ProductPreference(martellPreference, 4);
            House Martell = new House(martellPref, "Martell");
            Martell.InsertPerson("Doran Martell");

            //Create Arryn family 3
            List<Type> arrynPreference = new List<Type> { typeof(Wheat), typeof(Banana), typeof(Oats) };
            ProductPreference arrynPref = new ProductPreference(arrynPreference, 4);
            House Arryn = new House(arrynPref, "Arryn");
            Arryn.InsertPerson("Jon Arryn");
            Arryn.InsertPerson("Lysa Arryn");
            Arryn.InsertPerson("Robin Arryn");

            //Create Tyrell family 4
            List<Type> tyrellPreference = new List<Type> { typeof(Wheat), typeof(Banana), typeof(Oats) };
            ProductPreference tyrellPref = new ProductPreference(tyrellPreference, 4);
            House Tyrell = new House(tyrellPref, "Tyrell");
            Tyrell.InsertPerson("Mace Tyrell");
            Tyrell.InsertPerson("Alerie Tyrell");
            Tyrell.InsertPerson("Margaery Tyrell");
            Tyrell.InsertPerson("Horseras Tyrell");

            //insert into BinarySearchTree
            BinarySearchTree<House, int> tree = new BinarySearchTree<House, int>();
            tree.InsertIntoTree(Stark, Stark.NumberOfPersons);
            tree.InsertIntoTree(Lannister, Lannister.NumberOfPersons);
            tree.InsertIntoTree(Greyjoy, Greyjoy.NumberOfPersons);
            tree.InsertIntoTree(Martell, Martell.NumberOfPersons);
            tree.InsertIntoTree(Arryn, Arryn.NumberOfPersons);
            tree.InsertIntoTree(Tyrell, Tyrell.NumberOfPersons);
            tree.Iterate = BinarySearchTree<House, int>.IterativeMethod.InOrder;
            
            warehouse.DivideProducts(tree);
        }
    }
}