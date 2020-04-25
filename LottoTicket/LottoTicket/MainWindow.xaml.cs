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

            TextBlockTickets.Text = "";

            //Lotto ticket header
            TextBlockTickets.Text = "------------------------------------\n";
            TextBlockTickets.Text += "----                            ----\n";
            TextBlockTickets.Text += "----        LOTTO TICKET        ----\n";
            TextBlockTickets.Text += "----                            ----\n";
            TextBlockTickets.Text += "------------------------------------\n";
            TextBlockTickets.Text += "-----                          -----\n";

            //Looping through the amount of rows entered
            for (int i = 0; i < LuckyDips; i++)
            {
                TextBlockTickets.Text += "----- ";

                //Calling the methods in the Lotto class
                row.SetNumbersToZero();
                row.GenerateNumbers();
                row.SortNumbers();
                row.PrintNumbers(TextBlockTickets);

                TextBlockTickets.Text += "-----\n";
            } 

            //Ticket footer
            TextBlockTickets.Text += "-----                          -----\n";
            TextBlockTickets.Text += "------------------------------------\n";
        }
    }
}
