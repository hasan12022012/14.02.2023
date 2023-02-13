using System;

namespace tasK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course();
            string opt;
            do
            {
                Console.WriteLine("\n1. Qrup elave et");
                Console.WriteLine("2. Bütün qruplara bax");
                Console.WriteLine("3. Verilmiş point aralığındaki qruplara bax");
                Console.WriteLine("4. Verilmiş nömrəsi qrupa bax");
                Console.WriteLine("5. Verilmiş qruplar üzrə axtarış et");
                Console.WriteLine("0 . Menudan cıx");

                Console.Write("\nEmeliyyat secin: ");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        string no;
                        do
                        {
                            Console.Write("No: ");

                            no = Console.ReadLine();
                        } while (!CheckNo(no));


                        byte avgPoint;
                        string avgPointStr;
                        do
                        {
                            Console.Write("AvgPoint: ");
                            avgPointStr = Console.ReadLine();

                        } while (!byte.TryParse(avgPointStr, out avgPoint) || avgPoint > 100);


                        Group group = new Group
                        {
                            AveragePoint = avgPoint,
                            No = no
                        };

                        course.AddGroup(group);
                        break;
                    case "2":
                        foreach (var item in course.gp)
                        {
                            Console.WriteLine($"No: {item.No} - AvgPoint: {item.AveragePoint}");
                        }
                        break;
                    case "3":
                        Console.Write("MinPoint: ");
                        byte minPoint = Convert.ToByte(Console.ReadLine());

                        Console.Write("MaxPoint: ");
                        byte maxPoint = Convert.ToByte(Console.ReadLine());

                        var arr = course.GetGroupsByPointRange(minPoint, maxPoint);

                        foreach (var item in arr)
                        {
                            Console.WriteLine($"No: {item.No} - AvgPoint: {item.AveragePoint}");
                        }
                        break;
                    case "4":
                        Console.Write("No: ");
                        string wantedNo = Console.ReadLine();
                        var wantedGroup = course.GetGroupByNo(wantedNo);

                        if (wantedGroup == null)
                            Console.WriteLine($"{wantedNo} nomreli qrup yoxdur!");
                        else
                            Console.WriteLine($"No: {wantedGroup.No} - AvgPoint: {wantedGroup.AveragePoint}");
                        break;
                    case "5":
                        Console.Write("Search: ");
                        string search = Console.ReadLine();

                        arr = course.Search(search);

                        foreach (var item in arr)
                        {
                            Console.WriteLine($"No: {item.No} - AvgPoint: {item.AveragePoint}");
                        }

                        break;
                    case "0":
                        Console.WriteLine("proqram bitdi");
                        break;
                    default:
                        Console.WriteLine("\nSeciminiz sehvdir!");
                        break;
                }


            } while (opt != "0");

        }

        static bool CheckNo(string no)
        {
            if (no != null)
            {
                if (no.Length == 4)
                {
                    if (char.IsUpper(no[0]) && char.IsDigit(no[1]) && char.IsDigit(no[2]) && char.IsDigit(no[3]))
                        return true;
                }
            }

            return false;
        }
    }
}
