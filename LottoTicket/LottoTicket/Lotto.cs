using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

namespace LottoTicket
{
    public class Lotto
    {
        private int[] numArray;
        private Random randomNumber;

        public Lotto()
        {
            numArray = new int[6];
            randomNumber = new Random(DateTime.Now.Millisecond);
        }

        public void GenerateNumbers()
        {
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[0] = randomNumber.Next(1, 50);
            }
            
        }

        public void PrintNumbers(TextBlock OutputTextBlock)
        {
            for (int i = 0; i < 6; i++)
            {
                OutputTextBlock.Text = OutputTextBlock.Text + numArray[0] + " ";
            }
        }

        public void SetNumbersToZero()
        {

        }
    }
}
