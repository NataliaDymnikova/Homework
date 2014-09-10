using System;

namespace TicTacToe
{
    /// <summary>
    /// Class computer - player.
    /// </summary>
    public class ComputerGo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="isToe"> Is Computer play "O". </param>
        public ComputerGo(bool isToe)
        {
            isCompToe = isToe;
        }

        /// <summary>
        /// Computer go.
        /// </summary>
        /// <param name="masValue"> Array with bool value - is button not empty. </param>
        /// <returns> Number button, where computer play. </returns>
        public int Add(bool[] masValue)
        {
            for (int i = 0; i < masValue.Length; i++)
                if (!masValue[i])
                {
                    masValue[i] = !masValue[i];
                    return i;
                }
            return -1;
        }

        /// <summary>
        /// Is computer play "O".
        /// </summary>
        public bool IsCompToe
        {
            get { return isCompToe; }
        }

        /// <summary>
        /// Is computer play "O".
        /// </summary>
        private bool isCompToe;
    }
}
