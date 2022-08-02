using Core.Helpers;
using Manage.Controllers;

namespace Manage
{
    public class Program
    {
        static void Main()
        {
            AdminController _adminController = new AdminController();
            DrugController _drugController = new DrugController();
            DruggistController _druggistController = new DruggistController();
            DrugstoreController drugstoreController = new DrugstoreController();
            OwnerController _ownerController = new OwnerController();

        Authentication: var admin = _adminController.Authenticate();
            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Welcome");
                Console.WriteLine("---");
                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1- Create Owner");

                }

            }
        }
    }
}