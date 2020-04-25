using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

namespace LottoTicket
{
    public class Lotto //Lotto Class
    {
        //Array for lotto numbers
        private int[] numArray;
        //Random number generater for lotto numbers
        private Random randomNumber;

        #region Constructor
        //Initializing above feilds in the constructor
        public Lotto()
        {
            numArray = new int[6];
            randomNumber = new Random(DateTime.Now.Millisecond);
        }
        #endregion

        #region GenerateNumbers
        //Method to fill the array with random numbers
        public void GenerateNumbers()
        {
            //Looping through the numArray and adding a random number to each element
            for (int i = 0; i < numArray.Length; i++)                
            {
                numArray[i] = randomNumber.Next(1, 50); //Random numbers must be between 1-50
            }
        }
        #endregion

        #region PrintNumbers
        //Method to display the numbers to the screen
        public void PrintNumbers(TextBlock OutputTextBlock)
        {
            //Looping through the array to display each random number
            for (int i = 0; i < numArray.Length; i++)
            {
                if (numArray[i] < 10)
                {
                    OutputTextBlock.Text += " ";
                    OutputTextBlock.Text += numArray[i] + "  ";
                }

                else
                {
                    OutputTextBlock.Text += numArray[i] + "  ";
                }
            }
        }
        #endregion

        #region SetNumbersToZero
        //Method to set all the numbers to 0
        public void SetNumbersToZero()
        {
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = 0;
            }
        }
        #endregion

        #region SortNumbers
        //Method to sort the lotto numbers in ascending order
        public void SortNumbers()
        {
            int t;

            //Bubble sort
            for (int a = 0; a <= numArray.Length - 2; a++)
            {
                for (int i = 0; i <= numArray.Length - 2; i++)
                {
                    if (numArray[i] > numArray[i + 1])
                    {
                        t = numArray[i + 1];
                        numArray[i + 1] = numArray[i];
                        numArray[i] = t;
                    }
                }
            }

        }
        #endregion
    }
}
