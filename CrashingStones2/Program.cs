using System.Linq;

namespace MyNamespace
{
    class MyClass
    {
        public static void Main()
        {
            // Initializing the data for the stones
            System.Console.WriteLine("Let's crash some stones");
            List<Stones> StoneList = new List<Stones>();
            StoneList.Add(new Stones
            {
                Weight = 1
            });
            StoneList.Add(new Stones
            {
                Weight = 2
            });
            StoneList.Add(new Stones
            {
                Weight = 3
            });
            StoneList.Add(new Stones
            {
                Weight = 6
            });
            StoneList.Add(new Stones
            {
                Weight = 7
            });
            StoneList.Add(new Stones
            {
                Weight = 7
            });
            // Check for stones list
            foreach (Stones stone in StoneList)
            {
                Console.WriteLine(stone.Weight);
            }

            // Need to initialize list length also
            int ListLength = StoneList.Count;
            Console.WriteLine("The list length = " + ListLength);

            // Some variable to ensure the while loop keeps running
            // Break while loop once 1 stone is left, or no stone is left
            string Test = "Test";

            while (Test == "Test")
            {
                if (ListLength > 1)
                {

                    // If ListLength > 1, run algo. If List length == 1 share stone weight. If ListLength == 0, let them know no stones left

                    Console.WriteLine("Ordering the list of stones by Weight");
                    StoneList = StoneList.OrderBy(x => x.Weight).ToList();

                    // Check for stones being re-ordered by weight
                    foreach (Stones stone in StoneList)
                    {
                        Console.WriteLine(stone.Weight);
                    }

                    // Check weight for 2 largest stones, if same delete both stones
                    // If different, calculate difference - update largest stone to reflect difference, delete smaller stone
                    Console.WriteLine("Weight of second largest stone: " + StoneList[ListLength - 2].Weight);
                    Console.WriteLine("Weight of Heavier Stone: " + StoneList[ListLength - 1].Weight);
                    
                    if (StoneList[ListLength - 2].Weight == StoneList[ListLength - 1].Weight)
                    {
                        StoneList.RemoveAt(ListLength - 1);
                        StoneList.RemoveAt(ListLength - 2);
                        Console.WriteLine("Both largest and second largest stones are the same weight, hence both are disintegrated when smashed");

                        //update list length
                        ListLength = StoneList.Count;
                        Console.WriteLine("The updated list length = " + ListLength);
                    } else
                    {
                        int StoneDiff = StoneList[ListLength - 1].Weight - StoneList[ListLength - 2].Weight;
                        StoneList[ListLength - 1].Weight = StoneDiff;
                        StoneList.RemoveAt(ListLength - 2);

                        //update list length
                        ListLength = StoneList.Count;
                        Console.WriteLine("The updated list length = " + ListLength);
                    }
                }
                else if (ListLength == 1)
                {
                    Console.WriteLine("The weight of the last stone is: " + StoneList[0].Weight);
                    break;
                }
                else
                {
                    Console.WriteLine("There no stones left");
                    break;
                }
            }

            

        }

        class Stones
        {
            public int Weight { get; set; }
        }
    }
}