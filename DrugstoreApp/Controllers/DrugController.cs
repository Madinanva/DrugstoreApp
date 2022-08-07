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

        }
        public void DeleteDrug()
        {

        }
        public void GetAllDrugs()
        {

        }
        public void GetAllDrugsByDrugstore()
        {

        }
        public void Filter()
        {

        }
    }
}
