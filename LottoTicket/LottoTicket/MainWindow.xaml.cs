using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LottoTicket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            //Calling the lotto class
            Lotto row;
            //LuckyDip variable to store the amount of ticket rows
            int LuckyDips;

            row = new Lotto();

            //Getting the number entered in the text box and assinging it to LuckyDips variable
            LuckyDips = int.Parse(TextBoxTickets.Text);

            #region Ticket Header
            //Lotto ticket header
            TextBlockTickets.Text = "**************************************\n";
            TextBlockTickets.Text += "**                                  **\n";
            TextBlockTickets.Text += "**           LOTTO TICKET           **\n";
            TextBlockTickets.Text += "**                                  **\n";
            TextBlockTickets.Text += "**************************************\n";
            TextBlockTickets.Text += "**                                  **\n";
            #endregion

            #region Ticket Numbers
            //Limiting the selection of numbers to between 1 and 20
            //If the number entered is higher than or equal to 21 run this:
            if (LuckyDips >= 21)
            {
                TextBlockTickets.Text += "**       Please enter a number      **\n" +
                                         "**          between 1 - 20          **\n";
            }

            //If is it less than 21 run this:
            else
            {
                //Looping through the amount of rows entered
                for (int i = 0; i < LuckyDips; i++)
                {
                    TextBlockTickets.Text += "**      ";

                    //Calling the methods in the Lotto class
                    row.SetNumbersToZero();
                    row.GenerateNumbers();
                    row.SortNumbers();
                    row.PrintNumbers(TextBlockTickets);

                    TextBlockTickets.Text += "    **\n";
                }
            }
            #endregion

            #region Ticket Footer
            //Ticket footer
            TextBlockTickets.Text += "**                                  **\n";
            TextBlockTickets.Text += "**************************************\n";
            #endregion
        }
    }
}
