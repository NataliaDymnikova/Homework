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
                if (graph[point, i])
                    mas.Add(i);
            }

            return mas.ToArray();
        }

        private bool[,] graph;
        private int size;
    }
}
