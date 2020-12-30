using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Models;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.Write("Enter the upper and lower boundaries (X Y) : ");
                    Plateau p = new Plateau(Console.ReadLine());
                    do
                    {
                        try
                        {
                            Console.Write("Enter the deploy position of rover (X Y Direction) : ");
                            var rover = p.DeployRover(Console.ReadLine());
                            Console.Write("Enter the series of instructions : ");
                            p.Run(rover, Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }


                    } while (true);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
            
               

            Console.ReadKey();

        }
    }

    

    

    

    


    
}

