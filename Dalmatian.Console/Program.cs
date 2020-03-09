namespace Dalmatian.Console
{
    using Dalmatian.Data.Models;
    using Data;

    public class Program
    {
        public static void Main() 
        {
            using (var data = new ApplicationDbContext())
            {
                var dalmatian = new Dog 
                { 
                    PedigreeName = "AAAAAAAAAAAAAA"
                };
            }
        }
    }
}
