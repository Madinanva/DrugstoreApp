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
    public class DrugstoreController
    {
        private DrugstoreRepository _drugstoreRepository;
        private OwnerRepository _ownerRepository;
        private DrugRepository _drugRepository;
        public DrugstoreController()
        {
            _drugstoreRepository = new DrugstoreRepository();
            _ownerRepository = new OwnerRepository();
            _drugRepository = new DrugRepository();
        }
        public void CreateDrugstore()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore name:");
                string drugstoreName = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore address:");
                string drugstoreAddress = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore contact number:");
                string drugstoreContactNumber = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All owners list:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {owner.Id}, FullName: {owner.Name} {owner.Surname}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Please choose owner id to give drugstore to owner:");
                string id = Console.ReadLine();
                int ownerId;
                var result = int.TryParse(id, out ownerId);
                if (result)
                {
                    var dbOwner = _ownerRepository.Get(o => o.Id == ownerId);
                    if (dbOwner != null)
                    {
                        Drugstore drugstore = new Drugstore()
                        {
                            Name = drugstoreName,
                            Address = drugstoreAddress,
                            ContactNumber = drugstoreContactNumber,
                            Owners = dbOwner

                        };
                        dbOwner.Drugstores.Add(drugstore);
                        _drugstoreRepository.Create(drugstore);
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Drugstore name :{drugstore.Name}, Drugstore adress: {drugstore.Address}, Drugstore contact number: {drugstore.ContactNumber}, Owner: {dbOwner.Name} is created");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner doesn't exist with this id");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }
        public void UpdateDrugstore()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugstores list:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drugstore.Id}, Name: {drugstore.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore id:");
                string id = Console.ReadLine();
                int drugstoreId;
                var result = int.TryParse(id, out drugstoreId);
                if (result)
                {
                    var dbDrugstore = _drugstoreRepository.Get(d => d.Id == drugstoreId);
                    if (dbDrugstore != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore's new name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore's new address");
                        string newAddress = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore's new contact number");
                        string newContactNumber = Console.ReadLine();
                    number: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "If you want to keep the same owner enter 1 or else 2 for choosing other owners");
                        string number = Console.ReadLine();
                        int n;
                        result = int.TryParse(number, out n);
                        if (result)
                        {
                            switch (n)
                            {
                                case 1:

                                    dbDrugstore.Id = drugstoreId;
                                    dbDrugstore.Name = newName;
                                    dbDrugstore.Address = newAddress;
                                    dbDrugstore.ContactNumber = newContactNumber;
                                    dbDrugstore.Owners = dbDrugstore.Owners;
                                    _drugstoreRepository.Update(dbDrugstore);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"The drugstore is updated. Id : {dbDrugstore.Id}, Name : {dbDrugstore.Name}, Address : {dbDrugstore.Address}, ContactNumber : {dbDrugstore.ContactNumber}");

                                    break;
                                case 2:
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Owner List");
                                    var owners = _ownerRepository.GetAll(dso => dso.Id != dbDrugstore.Owners.Id);
                                    if (owners.Count > 0)
                                    {
                                        foreach (var owner in owners)
                                        {

                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $" Id: {owner.Id}, Fullname: {owner.Name} {owner.Surname}");
                                        }
                                    Ownerid: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore's owner id");

                                        string ownerId = Console.ReadLine();
                                        int newId;
                                        result = int.TryParse(ownerId, out newId);
                                        if (result)
                                        {
                                            var dbOwner = _ownerRepository.Get(O => O.Id == newId&& O.Id!=dbDrugstore.Owners.Id);
                                            if (dbOwner != null)
                                            {

                                                dbDrugstore.Id = drugstoreId;
                                                dbDrugstore.Name = newName;
                                                dbDrugstore.Address = newAddress;
                                                dbDrugstore.ContactNumber = newContactNumber;
                                                dbDrugstore.Owners = dbOwner;
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"The drugstore is updated to- Id : {dbDrugstore.Id}, Name : {dbDrugstore.Name}, Address : {dbDrugstore.Address}, ContactNumber : {dbDrugstore.ContactNumber}, Owner: {dbDrugstore.Owners.Name}");
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
                                            goto Ownerid;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "no other owner found");

                                    }




                                    break;

                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "enter number correctly");
                            goto number;

                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore with this id");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "please enter correct id");
                    goto Id;

                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "no drug store found to update");

            }
        }
        public void DeleteDrugstore()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugstores list:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drugstore.Id}, Name: {drugstore.Name} OwnerName: {drugstore.Owners.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore id:");
                string id = Console.ReadLine();
                int drugstoreId;
                var result = int.TryParse(id, out drugstoreId);
                if (result)
                {

                    var drugstore = _drugstoreRepository.Get(d => d.Id == drugstoreId);
                    if (drugstore != null)
                    {
                        string name = drugstore.Name;
                        _drugstoreRepository.Delete(drugstore);
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }
        public void GetAllDrugstores()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugstores list");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drugstore.Id}, Name: {drugstore.Name} OwnerName: {drugstore.Owners.Name}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }
        public void GetAllDrugstoresByOwner()
        {
            var owners = _ownerRepository.GetAll();
            var drugstores = _drugstoreRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All owners list");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {owner.Id}, Fullname: {owner.Name} {owner.Surname}");
                }
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner id:");
                string id = Console.ReadLine();
                int ownerId;
                var result = int.TryParse(id, out ownerId);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == ownerId);
                    if (owner != null)
                    {
                        var drugstore1 = _drugstoreRepository.GetAll(d => d.Owners != null ? d.Owners.Id == owner.Id : false);
                        if (drugstore1.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "The drugstores of owner");
                            foreach (var drugstore in drugstores)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id: {drugstore.Id}, Name: {drugstore.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner has no drugstore");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner doesn't exist with this id");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct id");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }

        }
        public void Sale()
        {
            var drugstores = _drugstoreRepository.GetAll();

            if (drugstores.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Choose one of the drugstores with id");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All drugstores list:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"Id:{drugstore.Id},Name:{drugstore.Name},Address:{drugstore.Address},ContactNumber:{drugstore.ContactNumber},Owner:{drugstore.Owners.Name}");
                }
                string id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(id, out choosenId);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == choosenId);
                    if (drugstore != null)
                    {

                        var drugs = _drugRepository.GetAll(d => d.Drugstore.Drugs == drugstore.Drugs);
                        if (drugs.Count > 0)
                        {
                            foreach (var drug in drugs)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Id:{drug.Id},Name:{drug.Name},Price:{drug.Price},Count:{drug.Count}");
                            }
                        ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please,choose drug by ID");
                            string ID = Console.ReadLine();
                            int drugid;
                            result = int.TryParse(ID, out drugid);
                            if (result)
                            {
                                var drug = _drugRepository.Get(d => d.Id == drugid);
                                if (drug != null)
                                {
                                Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Please,enter drug's count");

                                    if (drug.Count > 0)
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Please enter drugcount you want to buy");
                                        string count = Console.ReadLine();
                                        int drugcount;
                                        result = int.TryParse(count, out drugcount);
                                        if (result)
                                        {

                                            if (drug.Count >= drugcount)
                                            {
                                                double totalPrice = drug.Price * drugcount;
                                            PRICE: ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Please pay total price if you wan to buy the drug, total price : {totalPrice}");
                                                string total = Console.ReadLine();
                                                double totalD;
                                                result = double.TryParse(total, out totalD);
                                                if (result)
                                                {
                                                    if (totalD == totalPrice)
                                                    {
                                                        drug.Count -= drugcount;
                                                        drug.Count = drug.Count;
                                                        _drugRepository.Update(drug);
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "This drug sold");

                                                    }
                                                    else
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You have not enought money to buy the drug ");
                                                        goto PRICE;
                                                    }

                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct drug price");
                                                    goto PRICE;
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");

                                            }

                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter in number");
                                            goto Count;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Thwew is no drug to sell");

                                    }
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter number");
                                goto ID;
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drug please create it");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "No drug found with this id");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter id in correct digit");
                    goto id;
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drug please, create it");
            }
        }
    }
}
