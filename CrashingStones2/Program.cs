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
                Weight = 2
            });
            StoneList.Add(new Stones
            {
                Weight = 5
            });
            StoneList.Add(new Stones
            {
                Weight = 13
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


                    if (ListLength % 2 == 0)
                    {
                        Console.WriteLine("There is an even number of stones, compare the 2 middle stones"); //if length is even, need to crash x/2 and x/2 - 1
                        Console.WriteLine("Weight of lighter stone: " + StoneList[ListLength / 2 - 1].Weight);
                        Console.WriteLine("Weight of Heavier Stone: " + StoneList[ListLength / 2].Weight);

                        // Find Difference in weight between heavier and lighter stone
                        int StoneDiff = StoneList[ListLength / 2].Weight - StoneList[ListLength / 2 - 1].Weight;
                        Console.WriteLine("Difference in weight: " + StoneDiff);

                        // If weight difference is zero, remove both stones. 
                        if (StoneDiff == 0)
                        {
                            StoneList.RemoveAt(ListLength / 2);
                            StoneList.RemoveAt(ListLength / 2 - 1);
                            Console.WriteLine("Both stones are the same weight, hence both are disintegrated when smashed");

                            //update list length before starting next loop
                            ListLength = StoneList.Count;
                            Console.WriteLine("The updated list length = " + ListLength);
                        }
                        else
                        {
                            // If there is a weight difference, replace the weight of the heavier stone
                            StoneList[ListLength / 2].Weight = StoneDiff;
                            Console.WriteLine("Updated weight of the heavier Stone: " + StoneList[ListLength / 2].Weight);

                            // Delete the lighter stone from the list
                            StoneList.RemoveAt(ListLength / 2 - 1);

                            // Check lighter stone has been deleted, and heavier stone weight is updated
                            foreach (Stones stone in StoneList)
                            {
                                Console.WriteLine(stone.Weight);
                            }
                            //update list length
                            ListLength = StoneList.Count;
                            Console.WriteLine("The updated list length = " + ListLength);
                        }

                    }
                    else
                    {
                        Console.WriteLine("There is an odd number of stones, compare the weight of the three stones - light, middle and heavy stones");
                        Console.WriteLine("Weight of lighter stone: " + StoneList[ListLength / 2 - 1].Weight);
                        Console.WriteLine("Weight of middle stone: " + StoneList[ListLength / 2].Weight);
                        Console.WriteLine("Weight of Heavier Stone: " + StoneList[ListLength / 2 + 1].Weight);

                        // Check diff between mid stone and lighter stone
                        int LowerStoneDiff = StoneList[ListLength / 2].Weight - StoneList[ListLength / 2 - 1].Weight;
                        Console.WriteLine("Difference between middle and lighter stone: " + LowerStoneDiff);

                        // Check diff between mid stone and heavier stone
                        int HigherStoneDiff = StoneList[ListLength / 2 + 1].Weight - StoneList[ListLength / 2].Weight;
                        Console.WriteLine("Difference between middle and heavier stone: " + HigherStoneDiff);

                        // For the two stones with the smaller difference, remove the lighter stone, update heavier stone
                        if (LowerStoneDiff <= HigherStoneDiff)
                        {
                            // If the three stones are of the same weight, delete the middle and lower stones
                            // If the middle and lower stone difference, is smaller that middle and larger stone - check middle and lower stone difference
                            // If middle and lower stone are of the same weight, delete the middle and lower stones
                            if (StoneList[ListLength / 2].Weight == StoneList[ListLength / 2 - 1].Weight)
                            {
                                StoneList.RemoveAt(ListLength / 2);
                                StoneList.RemoveAt(ListLength / 2 - 1);

                                //update list length
                                ListLength = StoneList.Count;
                                Console.WriteLine("The updated list length = " + ListLength);
                            }
                            else // Else, lower stone is lighter - hence demolished and update middle stone's weight
                            {
                                StoneList[ListLength / 2].Weight = LowerStoneDiff;
                                StoneList.RemoveAt(ListLength / 2 - 1);

                                // Check that lower stone is deleted and middle stone updated
                                foreach (Stones stone in StoneList)
                                {
                                    Console.WriteLine(stone.Weight);
                                }

                                //update list length
                                ListLength = StoneList.Count;
                                Console.WriteLine("The updated list length = " + ListLength);
                            }
                            // Check that middle stone is deleted and heavier stone is updated
                        }

                        else // If the difference betweeen middle and higher stone is smaller
                        {

                            // Check if the difference is zero between middle and higher stone. If zero difference, destroy both stones
                            // Else, update the heavier stone and destory the middle stone

                            if (StoneList[ListLength / 2].Weight == StoneList[ListLength / 2 + 1].Weight)
                            {
                                StoneList.RemoveAt(ListLength / 2 + 1);
                                StoneList.RemoveAt(ListLength / 2);
                                //update list length
                                ListLength = StoneList.Count;
                                Console.WriteLine("The updated list length = " + ListLength);
                            } else
                            {
                                StoneList[ListLength / 2 + 1].Weight = HigherStoneDiff;
                                StoneList.RemoveAt(ListLength / 2);

                                foreach (Stones stone in StoneList)
                                {
                                    Console.WriteLine(stone.Weight);
                                }

                                //update list length
                                ListLength = StoneList.Count;
                                Console.WriteLine("The updated list length = " + ListLength);
                            }

                        }
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