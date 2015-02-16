using System;
using System.Collections.Generic;
using System.IO;

namespace _1robots
{
    /// <summary>
    /// Class imitates robots which can jump the node in graph.
    /// </summary>
    public class Robots
    {
        public Robots(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            graph = new Graph(reader);
            string[] str = reader.ReadLine().Split(' ');
            numberOfRobots = str.Length;
            startPoints = new int[numberOfRobots];
            for (int i = 0; i < numberOfRobots; i++)
            {
                startPoints[i] = Convert.ToInt32(str[i]) - 1;
            }
            reader.Close();
        }

        /// <summary>
        /// When 2 or more robots jump to one node, they die.
        /// </summary>
        /// <returns> True - if all robots can die, false - otherwise. </returns>
        public bool Run()
        {
            List<int>[] possiblePoints = new List<int>[numberOfRobots];
            for (int i = 0; i < numberOfRobots; i++)
            {
                possiblePoints[i] = new List<int>();
                possiblePoints[i].Add(startPoints[i]);
            }

            bool[] isConnect = new bool[numberOfRobots];
            
            for (int i = 0; i < numberOfRobots && !isAllElementsTrue(isConnect); i++)
            {
                if (isConnect[i])
                    continue;
                for (int j = 0; j <= graph.Size() / 2; j++)
                    if (OneStepForOne(i, possiblePoints[i], isConnect))
                        break;
            }

            return isAllElementsTrue(isConnect);
        }

        // Make ine step for one and add possible points to the possisblePoints.
        // Return true, if someone stay in one place with somejne else.
        private bool OneStepForOne(int num, List<int> possiblePoints, bool[] isConnect)
        {
            List<int> tmp = new List<int>(possiblePoints);
            foreach (int j in tmp)
                possiblePoints.AddRange(graph.NextNextPoints(j));
            
            foreach (int i in startPoints)
                foreach (int j in possiblePoints)
                {
                    if (i == j)
                    {
                        int k;
                        for (k = 0; k < numberOfRobots; k++)
                            if (startPoints[k] == i)
                                break;
                        if (k == num)
                            continue;
                        isConnect[k] = true;
                        isConnect[num] = true;

                        return true;
                    }
                }
            return false;
        }

        /*
        // Make one step. And add values to the possiblePoints and isConnect.
        private bool OneStep(List<int>[] possiblePoints, bool[] isConnect)
        {
            for (int i = 0; i < numberOfRobots; i++)
            {
                List<int> tmp = new List<int>(possiblePoints[i]);
                foreach (int j in tmp)
                    possiblePoints[i].AddRange(graph.NextNextPoints(j));
            }

            for (int i = 0; i < numberOfRobots; i++)
            {
                for (int j = i + 1; j < numberOfRobots && !isConnect[i]; j++)
                {
                    if (HaveSameValue(possiblePoints[i], possiblePoints[j]))
                    {
                        isConnect[i] = true;
                        isConnect[j] = true;
                    }
                }
                if (!isConnect[i])
                    return false;
            }
            return true;
        }
        */

        // Cheks two arrays have the same values or not.
        private bool HaveSameValue(List<int> first, List<int> second)
        {
            foreach (int i in first)
            {
                foreach (int j in second)
                {
                    if (i == j)
                        return true;
                }
            }

            return false;
        }
        
        // Return true - if all elements are true, false - otherwise.
        private bool isAllElementsTrue(bool[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (!mas[i])
                    return false;
            }
            return true;
        }

        private int[] startPoints;
        private Graph graph;
        private int numberOfRobots;
    }
}
