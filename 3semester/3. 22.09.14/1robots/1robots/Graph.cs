using System;
using System.IO;
using System.Collections.Generic;

namespace _1robots
{
    /// <summary>
    /// Disconnected graph.
    /// </summary>
    class Graph
    {
        public Graph(StreamReader reader)
        {
            size = Convert.ToInt32(reader.ReadLine().ToString());
            graph = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                string[] str = reader.ReadLine().Split(' ');
                for (int j = 0; j < size; j++)
                {
                    graph[i, j] = Convert.ToBoolean(Convert.ToUInt32(str[j]));
                }
            }
        }

        /// <summary>
        /// First and second are connected or not.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public bool IsConnect(int first, int second)
        {
            return graph[first, second];
        }

        /// <summary>
        /// Return array with numbers wich with point has a connect.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public int[] WhoConnect(int point)
        {
            List<int> mas = new List<int>();
            for (int i = 0; i < size; i++)
            {
                if (graph[point, i] && point != i)
                    mas.Add(i);
            }

            return mas.ToArray();
        }

        /// <summary>
        /// Return array with points next next this point. 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public List<int> NextNextPoints(int point)
        {
            List<int> list = new List<int>();
            int[] nextPoints = WhoConnect(point);
            for (int i = 0; i < nextPoints.Length; i++)
            {
                int[] iNextNextPoints = WhoConnect(nextPoints[i]);
                list.AddRange(iNextNextPoints);
            }

            return list;
        }

        /// <summary>
        /// Return size.
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return size;
        }

        private bool[,] graph;
        private int size;
    }
}
