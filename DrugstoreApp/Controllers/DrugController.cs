using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class DrugController
    {
        private DrugRepository _drugRepository;
        private DrugstoreRepository _drugstoreRepository;
        public DrugController()
        {
            _drugRepository = new DrugRepository();
            _drugstoreRepository = new DrugstoreRepository();
        }
        public void CreateDrug()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug name");
                string drugName = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug price");
                string price = Console.ReadLine();
                double drugPrice;
                bool result = double.TryParse(price, out drugPrice);
                if (result)
                {
                Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug count");
                    string count = Console.ReadLine();
                    int drugCount;
                    result = int.TryParse(count, out drugCount);
                    if (result)
                    {
                        if (drugCount > 0)
                            foreach (var drugstore in drugstores)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drugstore.Id}, Name: {drugstore.Name}");
                            }
                        id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore id");
                        string id = Console.ReadLine();
                        int chosenId;
                        result = int.TryParse(id, out chosenId);
                        if (result)
                        {
                            var drugstore = _drugstoreRepository.Get(d => d.Id == chosenId);
                            if (drugstore != null)
                            {
                                var drug = new Drug
                                {
                                    Name = drugName,
                                    Price = drugPrice,
                                    Count = drugCount,
                                    Drugstore = drugstore
                                };
                                _drugRepository.Create(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id: {drug.Id}, Name: {drugName}, Price: {drugPrice}, Count: {drugCount}, Drugstore: {drugstore.Name}");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore with this id");
                                goto id;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct id");
                            goto id;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drug with this count");
                        goto Count;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct price");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }



        public void UpdateDrug()
        {

            var drugStores = _drugstoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            drugStoreId: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Choose one of the drugstores with id");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All drugstores list:");
                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id}," +
                        $" Name : {drugStore.Name}, Address : {drugStore.Address}," +
                        $"Contact Number: {drugStore.ContactNumber}");
                }
                string Id = Console.ReadLine();
                if (Id != "")
                {


                    int choosenId;
                    bool result = int.TryParse(Id, out choosenId);
                    if (result)
                    {
                        var drugStore = _drugstoreRepository.Get(ds => ds.Id == choosenId);
                        if (drugStore != null)
                        {
                            if (drugStore.Drugs.Count > 0)
                            {
                            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please, choose one of the drugs with id ");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"All drugs in the drug store {drugStore.Name}");
                                foreach (var drug in drugStore.Drugs)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id : {drug.Id}, Name : {drug.Name},  Price :{drug.Price}, Count : {drug.Count}");
                                }
                                string drugId = Console.ReadLine();
                                if (drugId != "")
                                {


                                    int choosenDrugId;
                                    result = int.TryParse(drugId, out choosenDrugId);
                                    if (result)
                                    {
                                        var drug = _drugRepository.Get(d => d.Id == choosenDrugId);
                                        if (drug != null)
                                        {
                                        name: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter new name");
                                            string newName = Console.ReadLine();
                                            if (newName != "")
                                            {


                                            Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter new price");
                                                string newPriceStr = Console.ReadLine();
                                                double newPrice;
                                                result = double.TryParse(newPriceStr, out newPrice);
                                                if (result)
                                                {
                                                Amount: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter new count");
                                                    string newCountStr = Console.ReadLine();
                                                    if (newCountStr != "")
                                                    {


                                                        int newCount;
                                                        result = int.TryParse(newCountStr, out newCount);
                                                        if (result)
                                                        {

                                                        Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "if you want to keep the drug in the same drugstore press 1, else press 2");
                                                            string option = Console.ReadLine();
                                                            if (option != "")
                                                            {


                                                                byte optionInt;
                                                                result = byte.TryParse(option, out optionInt);
                                                                if (result)
                                                                {
                                                                    if (optionInt == 1 || optionInt == 2)
                                                                    {
                                                                        if (optionInt == 1)
                                                                        {

                                                                            drug.Name = newName;
                                                                            drug.Price = newPrice;
                                                                            drug.Count = newCount;
                                                                            drug.Drugstore = drugStore;
                                                                            _drugRepository.Update(drug);
                                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"new name is : {drug.Name}," +
                                                                                $" new price : {drug.Price}, new amount : {drug.Count}, stored in drugstore {drug.Drugstore.Name}");
                                                                        }
                                                                        else
                                                                        {
                                                                        id1: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, choose one of the drugstores by id");
                                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All drugStores");

                                                                            foreach (var drugStore1 in drugStores)
                                                                            {
                                                                                if (drugStore1 != drug.Drugstore)
                                                                                {

                                                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore1.Id}," +
                                                                                        $" Name : {drugStore1.Name}, Address : {drugStore1.Address}," +
                                                                                        $"Contact Number: {drugStore1.ContactNumber}");

                                                                                }


                                                                            }
                                                                            Id = Console.ReadLine();
                                                                            if (Id != "")
                                                                            {


                                                                                int intId;
                                                                                result = int.TryParse(Id, out intId);
                                                                                if (result)
                                                                                {
                                                                                    var dStore = _drugstoreRepository.Get(ds => ds.Id == intId);
                                                                                    if (dStore != null)
                                                                                    {
                                                                                        drug.Drugstore = dStore;
                                                                                        drug.Name = newName;
                                                                                        drug.Price = newPrice;
                                                                                        drug.Count = newCount;
                                                                                        _drugRepository.Update(drug);
                                                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"new name is : {drug.Name}," +
                                                                                            $" new price : {drug.Price}, new amount : {drug.Count}, stored in drugstore {drug.Drugstore.Name}");

                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drug store found with this id ");
                                                                                    }

                                                                                }
                                                                                else
                                                                                {
                                                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter drug store id in digits");
                                                                                    goto id1;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "This field is required");
                                                                                goto id1;
                                                                            }

                                                                        }

                                                                    }
                                                                    else
                                                                    {
                                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Options should be within 1-2");
                                                                        goto Digit;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please type option in digits");
                                                                    goto Digit;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "This field is required");
                                                                goto Digit;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the amount in correct format");
                                                            goto Amount;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "This field is required");
                                                        goto Amount;
                                                    }
                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the price in correct format");
                                                    goto Price;
                                                }
                                            }
                                            else
                                            {

                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "This field is required");
                                                goto name;
                                            }
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no drug with this id");

                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct id");
                                        goto Id;
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "This field is required");
                                    goto Id;
                                }


                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no drug");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no drugstore with this id");

                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter drugstore id in digits");
                        goto drugStoreId;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number");
                    goto drugStoreId;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no any drugstore");
            }


        }
        public void DeleteDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugs list:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drug.Id}, Name: {drug.Name}, DrugstoreName: {drug.Drugstore.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug id");
                string id = Console.ReadLine();
                int drugId;
                var result = int.TryParse(id, out drugId);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == drugId);
                    if (drug != null)
                    {
                        string name = drug.Name;
                        _drugRepository.Delete(drug);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct id");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");
            }
        }
        public void GetAllDrugs()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugs list:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drug.Id}, Name: {drug.Name}, DrugstoreName: {drug.Drugstore.Name}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");
            }
        }
        public void GetAllDrugsByDrugstore()
        {
            var drugstores = _drugstoreRepository.GetAll();
            var drugs = _drugRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugstores list:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drugstore.Id}, Name: {drugstore.Name} ");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug store id:");
                string id = Console.ReadLine();
                int drugStoreId;
                var result = int.TryParse(id, out drugStoreId);
                if (result)
                {
                    var drugStore = _drugstoreRepository.Get(d => d.Id == drugStoreId);
                    if (drugStore != null)
                    {
                        drugs = _drugRepository.GetAll(d => d.Drugstore.Id == drugStoreId);
                        if (drugs.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "The drugs of drugstore");
                            foreach (var drug in drugs)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id: {drug.Id}, Name: {drug.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "the drugstore has no drugs");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "drug store doesn't exist with this id");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct id");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }
        public void Filter()
        {
        digits: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter max price of drugs until which and including you want to list");
            string price = Console.ReadLine();
            double maxPrice;
            bool result = double.TryParse(price, out maxPrice);
            if (result)
            {
                var drugs = _drugRepository.GetAll(d => d.Price <= maxPrice);

                if (drugs.Count > 0)
                {
                    foreach (var drug in drugs)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Id}, Count: {drug.Count}");
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "No drug found with this price or less this price");

                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Price should be in digits");
                goto digits;
            }
        }


    }
}
