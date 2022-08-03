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
    public class OwnerController
    {
        private OwnerRepository _ownerRepository;
        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
        }
        public void CreateOwner()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner name:");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner surname:");
            string surname = Console.ReadLine();
            var owner = new Owner
            {
                Name = name,
                Surname = surname
            };

            var dbOwner = _ownerRepository.Create(owner);
            if (dbOwner != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{dbOwner.Name} {dbOwner.Surname} is created");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Something went wrong");
            }
        }
        public void UpdateOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All owners list:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {owner.Id}, Fullname: {owner.Name} {owner.Surname}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner id:");
                string id = Console.ReadLine();
                int ownerId;
                var result = int.TryParse(id, out ownerId);
                if (result)
                {
                    var dbOwner = _ownerRepository.Get(o => o.Id == ownerId);
                    if (dbOwner != null)
                    {
                        string oldName = dbOwner.Name;
                        string oldSurname = dbOwner.Surname;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner's new name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner's new surname");
                        string newSurname = Console.ReadLine();
                        var updatedOwner = new Owner
                        {
                            Id = dbOwner.Id,
                            Name = newName,
                            Surname = newSurname
                        };
                        _ownerRepository.Update(updatedOwner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{oldName} {oldSurname} is updated to {newName} {newSurname}");
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
        public void DeleteOwner()
        {
            var owners = _ownerRepository.GetAll();
            if(owners.Count() > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All owners list");
                foreach(var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {owner.Id}, Fullname: {owner.Name} {owner.Surname}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner id:");
                string id = Console.ReadLine();
                int ownerId;
                var result = int.TryParse(id, out ownerId);

                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == ownerId);
                    if(owner != null)
                    {
                        string fullName = $"{owner.Name} {owner.Surname}";
                        _ownerRepository.Delete(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{fullName} is deleted");
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
        public void GetAllOwners()
        {
            var owners = _ownerRepository.GetAll();
            if(owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All owners list:");
                foreach(var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {owner.Id}, Fullname: {owner.Name} {owner.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }
        public void Logout()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Thanks for using this application");
        }
    }
}
