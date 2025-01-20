namespace raa
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> Products = new List<Product>
{
  new Product { Name = "Wizard Hat", ProductTypeId = 1, Price = 15.00M,  Sold = false, ProductId = 1, DateStocked = new DateTime(2021, 10, 1), ProductType = "Appareal",},
  new Product { Name = "Healing Potion", ProductTypeId = 2, Price = 10.00M,  Sold = false, ProductId = 2, DateStocked = new DateTime(2024, 10, 22), ProductType = "Potion",},
  new Product { Name = "Mystical Orb", ProductTypeId = 3, Price = 20.00M, Sold = false, ProductId = 3, DateStocked = new DateTime(2025, 01, 05), ProductType = "Enchanted Object",},
  new Product { Name = "Birchwood Wand", ProductTypeId = 4, Price = 25.00M, Sold = true, ProductId = 4, DateStocked = new DateTime(2024, 11, 15), ProductType = "Wand",},
  new Product { Name = "Just a Stick", ProductTypeId = 4, Price = 8.00M, Sold = true, ProductId = 5, DateStocked = new DateTime(1999, 10, 13), ProductType = "Wand",},
};

            string? readResult = null;
            string menuSelection = "start";

            do
            {
                Console.WriteLine("SELECT AN OPTION:");
                Console.WriteLine(" 1. See all products");
                Console.WriteLine(" 2. Post a new product");
                Console.WriteLine(" 3. Remove a product listing");
                Console.WriteLine(" 4. Update product details");
                Console.WriteLine(" 5. Search for a Product by its Product Type");
                Console.WriteLine(" 6. View all available products");
                Console.WriteLine(" 7. Exit");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult.ToLower();
                }

                if (menuSelection == "1")
                {
                    // See all products
                    Console.Clear();
                    Console.WriteLine("All products:");

                    for (int i = 0; i < Products.Count; i++)
                    {
                        Console.WriteLine(ProductDetails(Products[i]));
                    }

                    menuSelection = "start";
                    continue;
                }

                else if (menuSelection == "2")
                {
                    // Post a new product
                    string newProduct = "";
                    decimal newPrice = 0;
                    string newProductType = "";
                    int newProductTypeId = 0;
                    bool validEntry = false;

                    Console.Clear();
                    Console.WriteLine("Post a new product:");

                    do
                    {
                        Console.WriteLine("Enter the name of the product:");
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrEmpty(readResult))
                        {
                            newProduct = readResult;
                            validEntry = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry. Please try again.");
                            validEntry = false;
                            continue;
                        }
                    } while (validEntry == false);

                    do
                    {
                        Console.WriteLine("Enter the price of the product:");
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrEmpty(readResult))
                        {
                            newPrice = Convert.ToDecimal(readResult);
                            validEntry = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry. Please try again.");
                            validEntry = false;
                            continue;
                        }
                    } while (validEntry == false);

                    do
                    {

                        Console.WriteLine("Enter the product type of the product:");
                        Console.WriteLine(" 1. Appareal");
                        Console.WriteLine(" 2. Potion");
                        Console.WriteLine(" 3. Enchanted Object");
                        Console.WriteLine(" 4. Wand");

                        readResult = Console.ReadLine();
                        if (!string.IsNullOrEmpty(readResult))
                        {
                            newProductTypeId = Convert.ToInt32(readResult);

                            if (newProductTypeId == 1)
                            {
                                newProductType = "Appareal";
                            }
                            else if (newProductTypeId == 2)
                            {
                                newProductType = "Potion";
                            }
                            else if (newProductTypeId == 3)
                            {
                                newProductType = "Enchanted Object";
                            }
                            else if (newProductTypeId == 4)
                            {
                                newProductType = "Wand";
                            }

                            validEntry = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry. Please try again.");
                            validEntry = false;
                            continue;
                        }

                    } while (validEntry == false);

                    Products.Add(new Product { Name = newProduct, Price = newPrice, ProductType = newProductType, ProductTypeId = newProductTypeId, Sold = false, ProductId = Products.Count + 1, DateStocked = DateTime.Now });

                    menuSelection = "start";
                    continue;
                }

                else if (menuSelection == "3")
                {
                    // Remove a product listing
                    Console.Clear();
                    Console.WriteLine("Remove a product listing:");

                    for (int i = 0; i < Products.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Products[i].Name}");
                    }

                    Console.WriteLine("Which product would you like to remove?");
                    readResult = Console.ReadLine();
                    if (!string.IsNullOrEmpty(readResult))
                    {
                        Product? listResult = Products.FirstOrDefault(t => t.ProductId.ToString().StartsWith(readResult));
                        if (listResult != null)
                        {
                            int removeIndex = listResult.ProductId;
                            if (removeIndex > 0 && removeIndex <= Products.Count)
                            {
                                Products.RemoveAt(removeIndex - 1);
                            }
                            else
                            {
                                Console.WriteLine("Invalid entry. Please try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry. Please try again.");
                        }
                    }

                    menuSelection = "start";
                    continue;
                }

                else if (menuSelection == "4")
                {
                    // Update product details
                    Console.Clear();
                    Console.WriteLine("Update product details:");

                    for (int i = 0; i < Products.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Products[i].Name}");
                    }

                    Console.WriteLine("Which product would you like to update?");
                    readResult = Console.ReadLine();
                    if (!string.IsNullOrEmpty(readResult))
                    {
                        Product? listResult = Products.FirstOrDefault(t => t.ProductId.ToString().StartsWith(readResult));
                        if (listResult != null)
                        {
                            int updateIndex = listResult.ProductId;
                            string updatedName = "";
                            decimal updatedPrice = 0;
                            string updatedProductType = "";
                            int updatedProductTypeId = 0;
                            bool updatedSold = false;
                            bool validEntry = false;

                            do
                            {
                                Console.WriteLine("Enter the updated name of the product:");
                                readResult = Console.ReadLine();
                                if (!string.IsNullOrEmpty(readResult))
                                {
                                    updatedName = readResult;
                                    validEntry = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid entry. Please try again.");
                                    continue;
                                }
                            } while (validEntry == false);

                            do
                            {
                                Console.WriteLine("Enter the updated price of the product:");
                                readResult = Console.ReadLine();
                                if (!string.IsNullOrEmpty(readResult))
                                    try
                                    {
                                        updatedPrice = Convert.ToDecimal(readResult);
                                        validEntry = true;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Invalid entry. Please try again.");
                                        validEntry = false;
                                        continue;
                                    }

                            } while (validEntry == false);

                            do
                            {
                                Console.WriteLine("Enter the updated product type of the product:");
                                Console.WriteLine(" 1. Appareal");
                                Console.WriteLine(" 2. Potion");
                                Console.WriteLine(" 3. Enchanted Object");
                                Console.WriteLine(" 4. Wand");

                                readResult = Console.ReadLine();

                                if (!string.IsNullOrEmpty(readResult))
                                    try
                                    {
                                        updatedProductTypeId = Convert.ToInt32(readResult);
                                        if (updatedProductTypeId == 1)
                                        {
                                            updatedProductType = "Appareal";
                                        }
                                        else if (updatedProductTypeId == 2)
                                        {
                                            updatedProductType = "Potion";
                                        }
                                        else if (updatedProductTypeId == 3)
                                        {
                                            updatedProductType = "Enchanted Object";
                                        }
                                        else if (updatedProductTypeId == 4)
                                        {
                                            updatedProductType = "Wand";
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid entry. Please try again.");
                                            validEntry = false;
                                            continue;
                                        }

                                        validEntry = true;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Invalid entry. Please try again.");
                                        validEntry = false;
                                        continue;
                                    }

                            } while (validEntry == false);

                            do
                            {
                                Console.WriteLine("Has the product been sold? (y/n)");
                                readResult = Console.ReadLine();
                                if (!string.IsNullOrEmpty(readResult))
                                {

                                    if (readResult.ToLower() == "y")
                                    {
                                        updatedSold = true;
                                        validEntry = true;
                                    }
                                    else if (readResult.ToLower() == "n")
                                    {
                                        updatedSold = false;
                                        validEntry = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid entry. Please try again.");
                                        validEntry = false;
                                    }
                                }

                            } while (validEntry == false);

                            Console.WriteLine("Product details updated!");

                            Products[updateIndex - 1].Name = updatedName;
                            Products[updateIndex - 1].Price = updatedPrice;
                            Products[updateIndex - 1].ProductType = updatedProductType;
                            Products[updateIndex - 1].ProductTypeId = updatedProductTypeId;
                            Products[updateIndex - 1].Sold = updatedSold;

                            menuSelection = "start";
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry. Please try again.");
                    }

                }

                else if (menuSelection == "5")
                {
                    //    Search for a Product by its Product Type
                    Console.Clear();
                    Console.WriteLine("Search Products by Type:");
                    Console.WriteLine("1. Appareal");
                    Console.WriteLine("2. Potion");
                    Console.WriteLine("3. Enchanted Object");
                    Console.WriteLine("4. Wand");

                    Console.WriteLine("Which product type would you like to search for?");
                    readResult = Console.ReadLine();

                    if (readResult == "1")
                    {
                        List<Product> apparealProducts = Products.Where(product => product.ProductTypeId == 1).ToList();
                        List<string> apparealProductNames = apparealProducts.Select(product => product.Name).ToList();

                        Console.WriteLine("Appareal products:");
                        // string.Join should gather all the names into a single string, Environment.Newline will place them each on their own separate line.
                        Console.WriteLine(string.Join(Environment.NewLine, apparealProductNames));
                    }
                    else if (readResult == "2")
                    {
                        List<Product> apparealProducts = Products.Where(product => product.ProductTypeId == 2).ToList();
                        List<string> apparealProductNames = apparealProducts.Select(product => product.Name).ToList();

                        Console.WriteLine("Potion products:");
                        Console.WriteLine(string.Join(Environment.NewLine, apparealProductNames));
                    }
                    else if (readResult == "3")
                    {
                        List<Product> apparealProducts = Products.Where(product => product.ProductTypeId == 3).ToList();
                        List<string> apparealProductNames = apparealProducts.Select(product => product.Name).ToList();

                        Console.WriteLine("Enchanted Object products:");
                        Console.WriteLine(string.Join(Environment.NewLine, apparealProductNames));
                    }
                    else if (readResult == "4")
                    {
                        List<Product> apparealProducts = Products.Where(product => product.ProductTypeId == 4).ToList();
                        List<string> apparealProductNames = apparealProducts.Select(product => product.Name).ToList();

                        Console.WriteLine("Wand products:");
                        Console.WriteLine(string.Join(Environment.NewLine, apparealProductNames));
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry. Please try again.");
                        continue;
                    }
                }

                else if (menuSelection == "6")
                {
                    // View all available products
                    Console.Clear();
                    Console.WriteLine("View all available products:");

                    List<Product> unsoldProducts = Products.Where(p => !p.Sold).ToList();

                    Console.WriteLine("Available products:");
                    for (int i = 0; i < unsoldProducts.Count; i++)
                    {
                        Console.WriteLine(ProductDetails(unsoldProducts[i]));
                    }

                    menuSelection = "start";
                    continue;
                }


                else if (menuSelection == "7")
                // Exit
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid menu selection.");
                    menuSelection = "start";
                }


                static string ProductDetails(Product Product)
                {
                    string nameString = Product.Name;
                    string priceString = Product.Price.ToString();
                    bool justSold = Product.Sold;
                    string typeString = Product.ProductTypeId.ToString();

                    if (typeString == "1")
                    {
                        typeString = "Appareal";
                    }
                    else if (typeString == "2")
                    {
                        typeString = "Potion";
                    }
                    else if (typeString == "3")
                    {
                        typeString = "Enchanted Object";
                    }
                    else if (typeString == "4")
                    {
                        typeString = "Wand";
                    }
                    return $"{nameString} with a product type of {typeString} {(justSold ? "has been sold." : $"is available for ${priceString}. It has been on the shelf for {Product.DaysOnShelf} days.")}";
                }

            } while (menuSelection != "exit");
        }
    }
}
