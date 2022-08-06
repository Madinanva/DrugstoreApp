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
        public DrugstoreController()
        {
            _drugstoreRepository = new DrugstoreRepository();
            _ownerRepository = new OwnerRepository();
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
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Please choose owner id to give drug store to owner:");
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
                            Owner = dbOwner
                        };
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
                        string number= Console.ReadLine();
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
                                    dbDrugstore.Owner = dbDrugstore.Owner;
                                    _drugstoreRepository.Update(dbDrugstore);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"The drugstore is updated. Id : {dbDrugstore.Id}, Name : {dbDrugstore.Name}, Address : {dbDrugstore.Address}, ContactNumber : {dbDrugstore.ContactNumber}");

                                    break;
                                case 2:
                                 ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Owner List");
                                    var owners = _ownerRepository.GetAll(dso=>dso.Id!= dbDrugstore.Owner.Id);
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
                                            var dbOwner = _ownerRepository.Get(O => O.Id == newId);
                                            if (dbOwner != null)
                                            {

                                                dbDrugstore.Id = drugstoreId;
                                                dbDrugstore.Name = newName;
                                                dbDrugstore.Address = newAddress;
                                                dbDrugstore.ContactNumber = newContactNumber;
                                                dbDrugstore.Owner = dbOwner;
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"The drugstore is updated to- Id : {dbDrugstore.Id}, Name : {dbDrugstore.Name}, Address : {dbDrugstore.Address}, ContactNumber : {dbDrugstore.ContactNumber}, Owner: {dbDrugstore.Owner.Name}");
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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drugstore.Id}, Name: {drugstore.Name} OwnerName: {drugstore.Owner.Name}");
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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drugstore.Id}, Name: {drugstore.Name} OwnerName: {drugstore.Owner.Name}");
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
            if(owners.Count > 0)
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
                        var drugstore1 = _drugstoreRepository.GetAll(d => d.Owner != null ? d.Owner.Id == owner.Id : false);
                        if(drugstore1.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "The drugstores of owner");
                            foreach(var drugstore in drugstores)
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

        }
        public void Logout()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Thanks for using this application");
        }
    }
}