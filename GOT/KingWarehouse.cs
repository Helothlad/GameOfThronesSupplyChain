using System.Runtime.ExceptionServices;

namespace GOT
{
    class KingWarehouse
    {
        private ProductsList product;
        public KingWarehouse(ProductsList list)
        {
            this.product = list;
        }

        public void WareHouseDisplay()
        {
            product.WriteOutList();
        }
        public void DivideProducts(BinarySearchTree<House, int> tree)
        {

            List<Product[]>[] listOfAllPosibilitys = AllPossibilities(tree);

            Product[][] resultList = new Product[6][];
            bool thereIs = false;
            BTS(listOfAllPosibilitys, 0, resultList, ref thereIs);

            WriteOutDividedProducts(resultList, tree);
        }
        private List<Product[]>[] AllPossibilities(BinarySearchTree<House, int> tree)
        {
            List<Product[]>[] finalList = new List<Product[]>[6];
            tree.Iterate = BinarySearchTree<House, int>.IterativeMethod.InOrder;
            int i = 0;
            foreach (var house in tree)
            {
                List<Product[]> listPerHouse = PossibilitiesPerHouse(house);
                finalList[i++] = listPerHouse;
            }
            return finalList;
        }

        private List<Product[]> PossibilitiesPerHouse(House house)
        {
            List<Type> typeList = house.Preference.PreferredProduct;
            int quantity = house.Preference.RequiredQuantity;
            int productCount = typeList.Count;

            List<Product[]> list = new List<Product[]>();

            GenerateCombinations(typeList, quantity, new Product[productCount], list);

            return list;
        }

        private void GenerateCombinations(List<Type> typeList, int requiredQuantity, Product[] products, List<Product[]> list)
        {
            int productCount = typeList.Count;

            // Generate all combinations of quantities for the 3 types
            for (int qty1 = 0; qty1 <= requiredQuantity; qty1++)
            {
                for (int qty2 = 0; qty2 <= requiredQuantity - qty1; qty2++)
                {
                    int qty3 = requiredQuantity - qty1 - qty2;

                    // Ensure quantities don't exceed requiredQuantity
                    if (qty3 >= 0)
                    {
                        Product[] combination = new Product[productCount];
                        combination[0] = (Product)Activator.CreateInstance(typeList[0], new object[] { qty1 });
                        combination[1] = (Product)Activator.CreateInstance(typeList[1], new object[] { qty2 });
                        combination[2] = (Product)Activator.CreateInstance(typeList[2], new object[] { qty3 });

                        list.Add(combination);
                    }
                }
            }
        }
        private void BTS(List<Product[]>[] listOfAllPosibilitys, int level, Product[][] resultList, ref bool thereIs)
        {
            int i = -1;
            while (!thereIs && i < listOfAllPosibilitys[level].Count - 1)
            {
                i++;
                if (Fk(level, listOfAllPosibilitys[level][i], resultList))
                {
                    resultList[level] = listOfAllPosibilitys[level][i];

                    if (level == listOfAllPosibilitys.Length - 1)
                    {
                        thereIs = true;
                    }
                    else
                    {
                        BTS(listOfAllPosibilitys, level + 1, resultList, ref thereIs);
                    }
                }
            }
            if (!thereIs)
            {
                throw new Exception("No valid distribution exists to meet all house needs.");
            }
        }
        private bool Fk(int level, Product[] newProduct, Product[][] resultList)
        { 
            bool ok = true;
            List<Product> workingWarehouse = new List<Product>(product.List);
            for (int i = 0; i < level; i++)
            {
                for (int j = 0; j < resultList[i].Length; j++)
                {
                    bool removable = RemoveFromWarehouse(workingWarehouse, resultList[i][j]);
                    if (!removable)
                    {
                        ok = false;
                        break;
                    }
                }
            }
            for (int i = 0; i < newProduct.Length; i++)
            {
                bool removable = RemoveFromWarehouse(workingWarehouse, newProduct[i]);
                if (!removable)
                {
                    ok = false;
                }
            }
            
            return ok;
        }
        private bool RemoveFromWarehouse(List<Product> tmpWarehouse, Product remove)
        {
            
            foreach(var product in tmpWarehouse)
            {
                if(product.GetType() == remove.GetType())
                {
                    Product productCopy = (Product)Activator.CreateInstance(product.GetType(), new object[] { product.Amount });

                    productCopy.Amount -= remove.Amount;
                    if (productCopy.Amount < 0)
                    {
                        return false;
                    }
                    else
                    {

                        tmpWarehouse[tmpWarehouse.IndexOf(product)] = productCopy;
                    }
                    break;
                }
            }
            return true;
        }
        private void WriteOutDividedProducts(Product[][] resultList, BinarySearchTree<House, int> tree)
        {
            tree.Iterate = BinarySearchTree<House, int>.IterativeMethod.InOrder;
            string[] listOfHouses = new string[resultList.Length];
            int idx = 0;
            foreach(var house in tree)
            {
                listOfHouses[idx++] = house.Name; 
            }
            Console.WriteLine("Distribution of products among the great houses: \n");
            
            for (int i = 0; i < resultList.Length; i++)
            {
                Console.WriteLine($"House: {listOfHouses[i]}");
                for (int j = 0; j < resultList[i].Length; j++)
                {
                    Console.WriteLine($"{resultList[i][j]} {resultList[i][j].Amount}");
                }
                Console.WriteLine();
            }
        }
    }
}
