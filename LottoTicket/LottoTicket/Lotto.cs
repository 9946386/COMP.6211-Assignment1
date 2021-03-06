﻿using System;
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
            numArray = new int[6] { 0, 0, 0, 0, 0, 0 };
            randomNumber = new Random(DateTime.Now.Millisecond);
        }
        #endregion

        #region GenerateNumbers
        //Method to fill the array with random numbers
        public void GenerateNumbers()
        {
            int uniqueNum;

            //Looping through the numArray and adding a random number to each element
            for (int i = 0; i < numArray.Length; i++)
            {               
                uniqueNum = randomNumber.Next(1, 50); //Adding a new random number

                if (Array.Exists(numArray, element => element == uniqueNum)) //If the number already exists in the array
                {
                    i--; //-1 on loop counter so it loops again
                }
                else
                {
                    numArray[i] = uniqueNum; //Put the unique number into the array
                }
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
                //If the number in the array is less than 10 place a " " infront of and after the number
                if (numArray[i] < 10)
                {
                    OutputTextBlock.Text += " ";
                    OutputTextBlock.Text += numArray[i] + "  ";
                }

                //If not then only add " " after the number
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
            for (int i = 0; i < numArray.Length; i++) //Looping through the array
            {
                numArray[i] = 0; //Set the numbers in the array to zero
            }
        }
        #endregion

        #region SortNumbers
        //Method to sort the lotto numbers in ascending order
        public void SortNumbers()
        {
            int c;

            //Bubble sort
            //Looping through the array length -2
            for (int a = 0; a <= numArray.Length - 2; a++)
            {
                //Looping through the array length -2
                for (int b = 0; b <= numArray.Length - 2; b++)
                {
                    //If the array number is bigger than the index + 1
                    if (numArray[b] > numArray[b + 1])
                    {
                        c = numArray[b + 1];
                        numArray[b + 1] = numArray[b];
                        numArray[b] = c;
                    }
                }
            }

        }
        #endregion
    }
}
