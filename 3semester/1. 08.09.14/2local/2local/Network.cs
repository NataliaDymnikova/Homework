using System;
using System.IO;

namespace _2local
{
    /// <summary>
    /// Class simulate the network, in which some computers infected.
    /// </summary>
    public class Network
    {
        public Network(string fileName)
        {
            ReadFromFile(fileName);
            while (numberOfInfected != numberOfComps)
            {
                for (int i = 0; i < numberOfInfected; i++)
                    Console.Write("{0} ", infected[i] + 1);
                Console.WriteLine();
                StepInfection();
            }
            for (int i = 0; i < numberOfInfected; i++)
                Console.Write("{0} ", infected[i] + 1);
            Console.WriteLine();
        }

        /// <summary>
        /// Read information from file.
        /// </summary>
        /// <param name="fileName"> Name of file. </param>
        private void ReadFromFile(string fileName)
        {
            StreamReader reader;
            if ((reader = new StreamReader(fileName)) == null)
            {
                throw new FileLoadException("Can't open", fileName);
            }

            // Number of computers.
            numberOfComps = Convert.ToInt32(reader.ReadLine());
            comps = new bool[numberOfComps, numberOfComps];

            // Matrix of comps.
            for (int i = 0; i < numberOfComps; i++)
            {
                string[] strOfNumbers = reader.ReadLine().Split(' ');
                for (int j = 0; j < strOfNumbers.Length; j++)
                    comps[i, j] = Convert.ToBoolean(Convert.ToInt32(strOfNumbers[j]));
            }

            // Computer's OS.
            opSyst = new string[numberOfComps];
            for (int i = 0; i < numberOfComps; i++)
            {
                opSyst[i] = reader.ReadLine().Split(' ')[1];
            }

            // Infected.
            numberOfInfected = 0;
            infected = new int[numberOfComps];
            string[] arrayInfected = reader.ReadLine().Split(' ');
            for (int i = 0; i < arrayInfected.Length; i++)
            {
                infected[i] = Convert.ToInt32(arrayInfected[i]) - 1;
                numberOfInfected++;
            }

            // Chance of Infection.
            int numberOfOS = Convert.ToInt32(reader.ReadLine());
            chanceOfInfection = new ArrayIntString(numberOfOS);
            for (int i = 0; i < numberOfOS; i++)
            {
                string[] temp = reader.ReadLine().Split(' ');
                chanceOfInfection.Add(100 / Convert.ToInt32(temp[1]), temp[0]);
            }

            reader.Close();
        }

        /// <summary>
        /// One step to infect some comps.
        /// </summary>
        private void StepInfection()
        {
            int[] newInfected = new int[numberOfComps];
            int newNumberOfInfected = numberOfInfected;
            infected.CopyTo(newInfected, 0);
            for (int i = 0; i < numberOfInfected; i++)
            {
                for (int j = 0; j < numberOfComps; j++)
                {
                    if (infected[i] != j && comps[infected[i], j])
                    {
                        if (Infect(j))
                        {
                            newInfected[newNumberOfInfected++] = j;
                        }
                    }
                }
            }
            numberOfInfected = newNumberOfInfected;
            infected = newInfected;
        }

        /// <summary>
        /// Will it infect or not.
        /// </summary>
        /// <param name="infected"> Number comp wich can will infect. </param>
        /// <returns> True - if it will infect, false - otherwise. </returns>
        private bool Infect(int infected)
        {
            if (IsInfectNow(infected))
            {
                return false;
            }

            Random rnd = new Random();
            int i = rnd.Next();
            if (i % chanceOfInfection.Number(opSyst[infected]) == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Is comp is infect now.
        /// </summary>
        /// <param name="comp"> Number of computer. </param>
        /// <returns> True - if this's infected, false - otherwise. </returns>
        private bool IsInfectNow(int comp)
        {
            for ( int i = 0; i < numberOfInfected; i++)
            {
                if (infected[i] == comp)
                    return true;
            }
            return false;
        }

        private int numberOfComps;
        private int numberOfInfected;
        private bool[,] comps;
        private string[] opSyst;
        private int[] infected;
        private ArrayIntString chanceOfInfection;
    }
}
