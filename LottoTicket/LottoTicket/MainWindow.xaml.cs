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
            Lotto row;

            row = new Lotto();

            TextBlockTickets.Text = "";

            TextBlockTickets.Text += "--------Your Lotto Ticket--------";
            TextBlockTickets.Text += "--      ";

            row.SetNumbersToZero();
            row.GenerateNumbers();
            row.PrintNumbers(TextBlockTickets);


            TextBlockTickets.Text += "     --\n";
        }
    }
}
