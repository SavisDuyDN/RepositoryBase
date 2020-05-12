using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                TableTest table = new TableTest()
                {
                    Name = "Duy"
                };
                unitOfWork.GetRepository<TableTest>().Create(table);
                unitOfWork.Save();
            }
            Console.ReadKey();
        }
    }
}
