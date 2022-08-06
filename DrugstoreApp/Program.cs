using Core.Constants;
using Core.Helpers;
using Manage.Controllers;
using static Core.Constants.Options;

namespace Manage
{
    public class Program
    {
        static void Main()
        {
            AdminController _adminController = new AdminController();

            Authentication: var admin = _adminController.Authenticate();
            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Welcome");
                Console.WriteLine("---");
                Main: Console.WriteLine("Please choose one of these options: 0-Owners, 1-Drugstores, 2-Drugs, 3-Druggists");
                string number = Console.ReadLine();
              
                    while (true)
                    {
                        if (number == "0")
                        {
                            OwnerController _ownerController = new OwnerController();
                            while (true)
                            {

                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Select Option");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0- Logout");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1- Create Owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2- Update Owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3- Delete Owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4- Get All Owners");

                                string number1 = Console.ReadLine();
                                int selectedNumber;
                                bool result = int.TryParse(number1, out selectedNumber);
                                if (result)
                                {
                                    if (selectedNumber >= 0 && selectedNumber <= 4)
                                    {
                                        switch (selectedNumber)
                                        {
                                            case (int)FirstOptions.CreateOwner:
                                                _ownerController.CreateOwner();
                                                goto Main;
                                                break;
                                            case (int)FirstOptions.UpdateOwner:
                                                _ownerController.UpdateOwner();
                                                goto Main;
                                                break;
                                            case (int)FirstOptions.DeleteOwner:
                                                _ownerController.DeleteOwner();
                                                goto Main;
                                                break;
                                            case (int)FirstOptions.GetAllOwners:
                                                _ownerController.GetAllOwners();
                                                goto Main;
                                                break;
                                            case (int)FirstOptions.Logout:
                                                _ownerController.Logout();
                                                goto Main;
                                                return;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                                }
                            }
                        }
                        else if (number == "1")
                        {
                            DrugstoreController _drugstoreController = new DrugstoreController();
                            while (true)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Select Option");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0- Logout");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1- Create Drugstore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2- Update Drugstore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3- Delete Drugstore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4- Get All Drugstores");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5- Get All Drugstores By Owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "6- Sale");

                                string number1 = Console.ReadLine();
                                int selectedNumber;
                                bool result = int.TryParse(number1, out selectedNumber);
                                if (result)
                                {
                                    if (selectedNumber >= 0 && selectedNumber <= 6)
                                    {
                                        switch (selectedNumber)
                                        {
                                            case (int)SecondOptions.CreateDrugstore:
                                                _drugstoreController.CreateDrugstore();
                                                goto Main;
                                                break;
                                            case (int)SecondOptions.UpdateDrugstore:
                                                _drugstoreController.UpdateDrugstore();
                                                goto Main;
                                                break;
                                            case (int)SecondOptions.DeleteDrugstore:
                                                _drugstoreController.DeleteDrugstore();
                                                goto Main;
                                                break;
                                            case (int)SecondOptions.GetAllDrugstores:
                                                _drugstoreController.GetAllDrugstores();
                                                goto Main;
                                                break;
                                            case (int)SecondOptions.GetAllDrugstoresByOwner:
                                                _drugstoreController.GetAllDrugstoresByOwner();
                                                goto Main;
                                                break;
                                            case (int)SecondOptions.Sale:
                                                _drugstoreController.Sale();
                                                goto Main;
                                                break;
                                            case (int)SecondOptions.Logout:
                                                _drugstoreController.Logout();
                                                goto Main;
                                                return;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                                }
                            }
                        }
                        else if (number == "2")
                        {
                            DrugController _drugController = new DrugController();
                            while (true)
                            {

                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Select Option");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0- Logout");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1- Create Drug");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2- Update Drug");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3- Delete Drug");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4- Get All Drugs");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5- Get All Drugs By Drugstore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "6- Filter");

                                string number1 = Console.ReadLine();
                                int selectedNumber;
                                bool result = int.TryParse(number1, out selectedNumber);
                                if (result)
                                {
                                    if (selectedNumber >= 0 && selectedNumber <= 6)
                                    {
                                        switch (selectedNumber)
                                        {
                                            case (int)ThirdOptions.CreateDrug:
                                                _drugController.CreateDrug();
                                                goto Main;
                                                break;
                                            case (int)ThirdOptions.UpdateDrug:
                                                _drugController.UpdateDrug();
                                                goto Main;
                                                break;
                                            case (int)ThirdOptions.DeleteDrug:
                                                _drugController.DeleteDrug();
                                                goto Main;
                                                break;
                                            case (int)ThirdOptions.GetAllDrugs:
                                                _drugController.GetAllDrugs();
                                                goto Main;
                                                break;
                                            case (int)ThirdOptions.GetAllDrugsByDrugstore:
                                                _drugController.GetAllDrugsByDrugstore();
                                                goto Main;
                                                break;
                                            case (int)ThirdOptions.Filter:
                                                _drugController.Filter();
                                                goto Main;
                                                break;
                                            case (int)ThirdOptions.Logout:
                                                _drugController.Logout();
                                                goto Main;
                                                return;

                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                                }
                            }
                        }
                        else if (number == "3")
                        {
                            DruggistController _druggistController = new DruggistController();
                            while (true)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Select Option");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0- Logout");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1- Create Druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2- Update Druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3- Delete Druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4- Get All Druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5- Get All Druggist By Drugstore");

                                string number1 = Console.ReadLine();
                                int selectedNumber;
                                bool result = int.TryParse(number1, out selectedNumber);
                                if (result)
                                {
                                    if (selectedNumber >= 0 && selectedNumber <= 5)
                                    {
                                        switch (selectedNumber)
                                        {
                                            case (int)FourthOptions.CreateDruggist:
                                                _druggistController.CreateDruggist();
                                                goto Main;
                                                break;
                                            case (int)FourthOptions.UpdateDruggist:
                                                _druggistController.UpdateDruggist();
                                                goto Main;
                                                break;
                                            case (int)FourthOptions.DeleteDruggist:
                                                _druggistController.DeleteDruggist();
                                                goto Main;
                                                break;
                                            case (int)FourthOptions.GetAllDruggist:
                                                _druggistController.GetAllDruggist();
                                                goto Main;
                                                break;
                                            case (int)FourthOptions.GetAllDruggistByDrugstore:
                                                _druggistController.GetAllDruggistByDrugstore();
                                                goto Main;
                                                break;
                                            case (int)FourthOptions.Logout:
                                                _druggistController.Logout();
                                                goto Main;
                                                return;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                                }
                            }
                        }
                    }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Admin username or password is incorrect");
                goto Authentication;
            }
        }
    }
}