using System;

namespace UserManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var userManager = new UserManager();

                userManager.GetAllUsers().Wait();
                userManager.CreateUser().Wait();
                userManager.UpdateUser().Wait();
                userManager.DeleteUser().Wait();
                userManager.AddRoleToUser().Wait();
                userManager.RemoveRoleFromUser().Wait();
            }
            catch (AggregateException ag)
            {
                if (ag.InnerExceptions.Count == 1)
                    throw ag.InnerException;
                else
                    throw ag.Flatten();
            }
            catch (Exception)
            {
                throw;
            }

            Console.ReadLine();
        }
    }
}
