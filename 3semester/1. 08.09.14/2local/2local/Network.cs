using System;
using System.IO;
using System.Collections.Generic;

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
            random = new Random();
        }

        public string Run()
        {
            string str = "";
            int j = 0;
            while (numberOfInfected != numberOfComps)
            {
                for (int i = 0; i < numberOfComps; i++)
                    if (comps[i].IsInfected)
                        str += i + 1 + " ";
                StepInfection();
                str += '\n';
            }
            for (int i = 0; i < numberOfComps; i++)
                str += i + 1 + " ";

            return str;
        }
        /// <summary>
        /// Read information from file.
        /// </summary>
        /// <param name="fileName"> Name of file. </param>
        private void ReadFromFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            if (reader == null)
            {
                throw new FileLoadException("Can't open", fileName);
            }

            // Number of comps and matrix.
            numberOfComps = Convert.ToInt32(reader.ReadLine());
            compsMatrix = new Matrix(reader, numberOfComps);

            // Chance of Infection with number os OS.
            int numberOfOS = Convert.ToInt32(reader.ReadLine());
            opSysts = new OperationSystem[numberOfOS];
            for (int i = 0; i < numberOfOS; i++)
            {
                string[] temp = reader.ReadLine().Split(' ');
                opSysts[i] = new OperationSystem(temp[0], 100 / Convert.ToInt32(temp[1]));
            }

            // Computer's OS.
            comps = new Comp[numberOfComps];
            for (int i = 0; i < numberOfComps; i++)
            {
                comps[i] = new Comp(false, OpSystWithName(reader.ReadLine().Split(' ')[1]));
            }

            // Infected.
            numberOfInfected = 0;
            string[] arrayInfected = reader.ReadLine().Split(' ');
            for (int i = 0; i < arrayInfected.Length; i++)
            {
                comps[Convert.ToInt32(arrayInfected[i]) - 1].IsInfected = true;
                numberOfInfected++;
            }

            reader.Close();
        }

        /// <summary>
        /// Return OperationSystem with this name.
        /// </summary>
        /// <param name="nameOpSyst"> Name of system. </param>
        /// <returns></returns>
        private OperationSystem OpSystWithName(string nameOpSyst)
        {
            for (int i = 0; i < opSysts.Length; i++)
                if (opSysts[i].Name == nameOpSyst)
                    return opSysts[i];

            return null;
        }

        /// <summary>
        /// One step to infect some comps.
        /// </summary>
        private void StepInfection()
        {
            Comp[] newInfectedComps = new Comp[numberOfComps];
            comps.CopyTo(newInfectedComps, 0);
            for (int i = 0; i < numberOfComps; i++)
            {
                if (comps[i].IsInfected)
                    for (int j = 0; j < numberOfComps; j++)
                        if (compsMatrix.IsConnect(i, j))
                            if (!comps[j].IsInfected && comps[j].Infect(random.Next(100)))
                                numberOfInfected++;
            }   
            comps = newInfectedComps;
        }

        
        /// <summary>
        /// Class with name of system and chance of infection.
        /// </summary>
        private class OperationSystem
        {
            public OperationSystem(string name, int chanceOfInfection)
            {
                this.Name = name;
                this.ChanceOfInfection = chanceOfInfection;
            }

            public int ChanceOfInfection
            {
                get;
                private set;
            }

            public string Name
            {
                get;
                private set;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private class Comp
        {
            public Comp(bool isInfected, OperationSystem opSyst)
            {
                this.IsInfected = isInfected;
                this.opSyst = opSyst;
            }

            /// <summary>
            /// Is infect comp after attempts to infect and infect if yes.
            /// </summary>
            /// <param name="rand"> Random number. </param>
            /// <returns> True - if now it's infected, false - otherwise. </returns>
            public bool Infect(int rand)
            {
                if (!IsInfected)
                    IsInfected = (rand % opSyst.ChanceOfInfection == 0);

                return IsInfected;
            }
            
            public bool IsInfected
            { 
                get; set; 
            }

            private OperationSystem opSyst;
        }

        private class Matrix
        {
            public Matrix(StreamReader reader, int numberOfElements)
            {
                // Number of computers.
                this.numberOfElements = numberOfElements;
                comps = new bool[numberOfElements, numberOfElements];

                // Matrix of comps.
                for (int i = 0; i < numberOfElements; i++)
                {
                    string[] strOfNumbers = reader.ReadLine().Split(' ');
                    for (int j = 0; j < strOfNumbers.Length; j++)
                        comps[i, j] = Convert.ToBoolean(Convert.ToInt32(strOfNumbers[j]));
                }
    
            }

            /// <summary>
            /// Return is two elements connected.
            /// </summary>
            /// <param name="first"></param>
            /// <param name="second"></param>
            /// <returns></returns>
            public bool IsConnect(int first, int second)
            {
                return (first < numberOfElements && second < numberOfElements) && comps[first, second];
            }

            private bool[,] comps;
            private int numberOfElements;
        
        }

        private int numberOfComps;
        private int numberOfInfected;
        private Matrix compsMatrix;
        private Comp[] comps;
        private OperationSystem[] opSysts;
        private Random random;
    }
}
