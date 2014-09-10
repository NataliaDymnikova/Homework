using System;
using System.IO;
using ElementType = System.Int32;
using Position = System.Int32;

namespace _1parseTree
{
    /// <summary>
    /// Class parse tree.
    /// </summary>
    public class Tree
    {
        public Tree(System.IO.StreamReader file)
        {
            root = CreateTreeFromFile(file, root);
        }

        /// <summary>
        /// Print tree.
        /// </summary>
        public void Print()
        {
            root.Print();
        }

        /// <summary>
        /// Result of calculate.
        /// </summary>
        /// <returns> Result. </returns>
        public int Result()
        {
            if (root == null)
                return 0;
            return root.Calculate();
        }

        /// <summary>
        /// </summary>
        /// <returns> Root this tree. </returns>
        private int Root
        {
            get { return root.Value; }
        }

        // Create Tree from file.
        private TreeElement CreateTreeFromFile
            (System.IO.StreamReader file, TreeElement treeElement)
        {
            int value = 0;
            TreeElement left = null;
            TreeElement right = null;

            if (file.EndOfStream)
                return treeElement;
            int ch = file.Read(); //  '(' или цифра или ' '
            if (ch == ' ')
                ch = file.Read(); //  '(' или цифра
            if (ch == '(')
            {
                ch = file.Read();  // ' '
                if (ch != ' ')
                    throw new ExceptionTree("Waiting ' '.");

                ch = file.Read();  // sign
                if (ch != '+' && ch != '-' && ch != '*' && ch != '/')
                    throw new ExceptionTree("Waiting sign.");

                value = ch;
                ch = file.Read();  // ' '
                if (ch != ' ')
                    throw new ExceptionTree("Waiting ' '.");

                left = CreateTreeFromFile(file, left);
                right = CreateTreeFromFile(file, right);

                if (value == '+')
                    treeElement = new Add(value, left, right);
                if (value == '-')
                    treeElement = new Subtract(value, left, right);
                if (value == '*')
                    treeElement = new Multiply(value, left, right);
                if (value == '/')
                    treeElement = new Divide(value, left, right);
                ch = file.Read(); // ')' или ' '
                if (ch == ' ')
                    ch = file.Read(); // ')'
                if (ch != ')')
                    throw new ExceptionTree("Waiting ).");
               /* ch = file.Read(); // ' '
                if (ch != ' ')
                    throw new ExceptionTree("Waiting ' '."); */
            }

            else if (ch <= '9' && ch >= '0')
            {
                int number = 0;
                while (ch <= '9' && ch >= '0')
                {
                    number = number * 10 + ch - '0';
                    ch = file.Read();
                }
                if (ch != ' ')
                    throw new ExceptionTree("Waiting ' '.");

                value = number;
                treeElement = new Value(value);
            }
            else
                throw new ExceptionTree("Waiting '(' or number.");
            return treeElement;
        }
        
        private TreeElement root;

        /// <summary>
        /// Element of tree - with value and two children - left and right.
        /// </summary>
        private class TreeElement
        {
            public TreeElement()
            { }

            public TreeElement(int value)
            {
                this.value = value;
            }

            public TreeElement(int value, TreeElement left, TreeElement right)
            {
                this.value = value;
                this.left = left;
                this.right = right;
            }


            /// <summary>
            /// </summary>
            /// <returns> Result calculate left and right children. </returns>
            public virtual int Calculate()
            {
                return 5;
//                return 0;
            }
            
            /// <summary>
            /// Print tree in recursion.
            /// </summary>
            public virtual void Print()
            {
            }

            /// <summary>
            /// </summary>
            /// <returns> Value this element. </returns>
            public int Value
            {
                get { return value; }
            }

            /// <summary>
            /// </summary>
            /// <returns> Right child. </returns>
            public TreeElement Right
            {
                get { return right; }
            }

            /// <summary>
            /// </summary>
            /// <returns> Left child. </returns>
            public TreeElement Left
            {
                get { return left; }
            }

            private int value;
            private TreeElement left;
            private TreeElement right;
        }

        /// <summary>
        /// Some class Operation and Value. 
        /// </summary>
        
        private class Sign: TreeElement
        {
            public Sign(int value, TreeElement left, TreeElement right)
                : base(value, left, right)
            { }

            public override void Print()
            {
                Console.Write("(");
                Left.Print();
                Console.Write((char)Value);
                Right.Print();
                Console.Write(")");
            }
        }
        
        private class Add: Sign
        {
            public Add(int value, TreeElement left, TreeElement right)
                : base(value, left, right)
            { }

            override public int Calculate() 
            {
                if (Left == null || Right == null)
                    throw new ExceptionTree("Can't calculate. Error in tree");
                return Left.Calculate() + Right.Calculate();
            }
        }

        private class Subtract : Sign
        {
            public Subtract(int value, TreeElement left, TreeElement right)
                : base(value, left, right)
            { }

            public override int Calculate()
            {
                if (Left == null || Right == null)
                    throw new ExceptionTree("Can't calculate. Error in tree");
                return Left.Calculate() - Right.Calculate();
            }
        }

        private class Multiply : Sign
        {
            public Multiply(int value, TreeElement left, TreeElement right)
                : base(value, left, right)
            { }

            public override int Calculate()
            {
                if (Left == null || Right == null)
                    throw new ExceptionTree("Can't calculate. Error in tree");
                return Left.Calculate() * Right.Calculate();
            }
        }

        private class Divide : Sign
        {
            public Divide(int value, TreeElement left, TreeElement right)
                : base(value, left, right)
            { }

            public override int Calculate()
            {
                if (Left == null || Right == null)
                    throw new ExceptionTree("Can't calculate. Error in tree");
                int rightCalculate = Right.Calculate();
                if (rightCalculate == 0)
                    throw new ExceptionTree("Division by 0 is bad!");
                return Left.Calculate() / rightCalculate;
            }
        }

        private class Value: TreeElement
        {
            public Value(int value)
                : base(value, null, null)
            { }

            public override int Calculate()
            {
                return Value;
            }

            public override void Print()
            {
                Console.Write(Value);
            }

        }
    }
}