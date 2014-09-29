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
            int[][] possiblePoints = new int[numberOfRobots][];
            for (int i = 0; i < numberOfRobots; i++)
            {
                possiblePoints[i] = NextNextPoints(i);
            }

            bool[] isConnect = new bool[numberOfRobots];
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

        // Cheks two arrays have the same values or not.
        private bool HaveSameValue(int[] first, int[] second)
        {
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    if (first[i] == second[j])
                        return true;
                }
            }
            return false;
        }
        
        // Return array with points where robot can jump (it can jump to the next next point)
        private int[] NextNextPoints(int point)
        {
            List<int> list = new List<int>();
            int[] nextPoints = graph.WhoConnect(startPoints[point]);
            for (int i = 0; i < nextPoints.Length; i++)
            {
                int[] iNextNextPoints = graph.WhoConnect(nextPoints[i]);
                list.AddRange(iNextNextPoints);
            }

            return list.ToArray();
        }

        private int[] startPoints;
        private Graph graph;
        private int numberOfRobots;
    }
}
