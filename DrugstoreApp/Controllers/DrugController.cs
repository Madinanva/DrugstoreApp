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
            if(drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug name");
                string drugName = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug price");
                string drugPrice = Console.ReadLine();
                double price;
                bool result = double.TryParse(drugPrice, out price);
                if (result)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug count");
                    string count = Console.ReadLine();
                    int drugCount;
                    result = int.TryParse(count, out drugCount);
                    if (result)
                    {

                    }
                }

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
        public void Logout()
        {

        }
    }
}
