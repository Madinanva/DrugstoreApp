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
    public class DruggistController
    {
        private DruggistRepository _druggistRepository;
        private DrugstoreRepository _drugstoreRepository;
        public DruggistController()
        {
            _druggistRepository = new DruggistRepository();
            _drugstoreRepository = new DrugstoreRepository();
        }
        public void CreateDruggist()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist name:");
                string name = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist surname:");
                string surname = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist age:");
                string age = Console.ReadLine();
                byte druggistAge;
                var result = byte.TryParse(age, out druggistAge);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist experience");
                string experience = Console.ReadLine();
                int druggistExperience;
                result = int .TryParse(experience, out druggistExperience);

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugstores list:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {drugstore.Id}, Drugstore name :{drugstore.Name}, Drugstore adress: {drugstore.Address}, Drugstore contact number: {drugstore.ContactNumber}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore id:");
                string id = Console.ReadLine();
                int drugstoreId;
                result = int.TryParse(id, out drugstoreId);
                if (result)
                {
                    var dbDrugstore = _drugstoreRepository.Get(d => d.Id == drugstoreId);
                    if (dbDrugstore != null)
                    {
                        Druggist druggist = new Druggist
                        {

                            Name = name,
                            Experience = druggistExperience,
                            Age = druggistAge,
                            Surname= surname,
                            Drugstore = dbDrugstore

                        };
                        _druggistRepository.Create(druggist);

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Fullname: {druggist.Name} {druggist.Surname} is created");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"No drugstore with this id");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drugstore");
                
            }
        }
        
        public void UpdateDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            if(druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All druggists list:");
                foreach(var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {druggist.Id} Fullname: {druggist.Name}, {druggist.Surname}, Age: {druggist.Age}, Experience: {druggist.Experience}");
                }
              Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist id:");
                string id = Console.ReadLine();
                int druggistId;
                var result = int.TryParse(id, out druggistId);
                if (result)
                {
                    var dbDruggist = _druggistRepository.Get(d => d.Id == druggistId);
                    if (dbDruggist != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist's new name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist's new surname");
                        string newSurname = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist's new age");
                        string age = Console.ReadLine();
                        byte druggistAge;
                        result = byte.TryParse(age, out druggistAge);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist's new experience");
                        string experience = Console.ReadLine();
                        int druggistExperience;
                        result = int.TryParse(experience, out druggistExperience);



                        dbDruggist.Id = druggistId;
                        dbDruggist.Name = newName;
                        dbDruggist.Surname = newSurname;
                        dbDruggist.Age = druggistAge;
                        dbDruggist.Experience = druggistExperience;

                       
                        _druggistRepository.Update(dbDruggist);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"The druggist updated to- Fullname: {dbDruggist.Name} {dbDruggist.Surname}, Age: {dbDruggist.Age}, Experience: {dbDruggist.Experience}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Druggist doesn't exist with this id");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }
        public void DeleteDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All druggists list:");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {druggist.Id} Fullname: {druggist.Name}, {druggist.Surname}, Age: {druggist.Age}, Experience: {druggist.Experience}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist id:");
                string id = Console.ReadLine();
                int druggistId;
                var result = int.TryParse(id, out druggistId);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == druggistId);
                    if (druggist != null)
                    {
                        string fullName = $"{druggist.Name} {druggist.Surname}";
                        _druggistRepository.Delete(druggist);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{fullName} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Druggist doesn't exist with this id");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }
        public void GetAllDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            if(druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All druggists list:");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {druggist.Id} Fullname: {druggist.Name}, {druggist.Surname}, Age: {druggist.Age}, Experience: {druggist.Experience}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }
        public void GetAllDruggistByDrugstore()
        {
            var drugstores = _drugstoreRepository.GetAll();
            var druggists = _druggistRepository.GetAll();
            if(drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All drugstores list:");
                foreach(var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $" Id:{drugstore.Id}  Name :{drugstore.Name}, Adress: {drugstore.Address}, Contact number: {drugstore.ContactNumber}");
                }
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore id:");
                string id = Console.ReadLine();
                int drugstoreId;
                var result = int.TryParse(id, out drugstoreId);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == drugstoreId);
                    if(drugstore != null)
                    {
                         druggists = _druggistRepository.GetAll(d => d.Drugstore != null ? d.Drugstore.Id == drugstoreId : false);
                        if(druggists.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "The druggists of drugstore");
                            foreach (var druggist in druggists)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id: {druggist.Id}, Name: {druggist.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Drugstore has no druggist");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Drugstore doesn't exist with this id");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct id");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }
        public void Logout()
        {

        }
    }
}