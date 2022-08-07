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
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugs list:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, Count: {drug.Count}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug id");
                string id = Console.ReadLine();
                int drugId;
                var result = int.TryParse(id, out drugId);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == drugId);
                    if (drugs != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Please, enter new name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Please, enter new price");
                        string newPrice = Console.ReadLine();
                        double drugPrice;
                        result = double.TryParse(newPrice, out drugPrice);
                        if (result)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Please, enter new count");
                            string newCount = Console.ReadLine();
                            int drugCount;
                            result = int.TryParse(newCount, out drugCount);
                            if (result)
                            {
                         
                                if (drugCount > 0)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {newdrug.Id}, Name: {drug.Name}, Price: {drug.Price}, Count: {drug.Count}");
                                }
                            }
                        }
                    }
                }
            }
        }
        public void DeleteDrug()
        {
            var drugs = _drugRepository.GetAll();
            if(drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugs list:");
                foreach(var drug in drugs)
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
                        drugs = _drugRepository.GetAll(d=>d.Drugstore.Id==drugStoreId);
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
            digits:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter max price of drugs until which and including you want to list");
            string price = Console.ReadLine();
            double maxPrice;
            bool result = double.TryParse(price, out maxPrice);
            if (result)
            {
                var drugs = _drugRepository.GetAll(d => d.Price <= maxPrice);
                
                if (drugs.Count > 0)
                {
                    foreach(var drug in drugs)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Id}, Count: {drug.Count}, Drugstore: {drug.Drugstore.Name}");
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
