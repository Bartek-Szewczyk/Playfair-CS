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

namespace Playfair
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


        private void wykonaj_Click(object sender, RoutedEventArgs e)
        {













            szyfr.Text = "";
            string klucz = key.Text.Replace(" ", "").ToLower().Replace("j", "i");
            string tekstJawny = text.Text.Replace(" ", "").ToLower().Replace("j", "i");


            if (tekstJawny.Length % 2 != 0)
            {
                tekstJawny += 'z';
            }



            char[,] matrixKw = new char[5, 5];
            string kontrolny = "";
            string alfabet = "abcdefghiklmnopqrstuvwxyz";

            int x = 0, y = 0;
            int pozycja;

            foreach (char znak in klucz.ToCharArray())
            {
                pozycja = kontrolny.IndexOf(znak);
                if (pozycja == -1)
                {
                    kontrolny += znak;
                    matrixKw[x, y] = znak;
                    x++;
                    if (x == 5)
                    {
                        x = 0;
                        y++;
                    }
                }
            }

            foreach (char znak in alfabet.ToCharArray())
            {
                pozycja = kontrolny.IndexOf(znak);
                if (pozycja == -1)
                {
                    kontrolny += znak;
                    matrixKw[x, y] = znak;
                    x++;
                    if (x == 5)
                    {
                        x = 0;
                        y++;
                    }
                }
            }


            if (key.Text == "" || text.Text=="")
            {
                MessageBox.Show("Nie podano klucza syfrującego lub treści wiadomości", "PlayFair", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (szyfruj.IsSelected)
            {


                for (int j = 0; j < tekstJawny.Length; j += 2)
                {
                    char firstLetter = tekstJawny[j];
                    char secondLetter = tekstJawny[j + 1];

                    int firstX = 0, firstY = 0, secondX = 0, secondY = 0;

                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            if (firstLetter == matrixKw[row, col])
                            {
                                firstX = row;
                                firstY = col;
                            }

                            if (secondLetter == matrixKw[row, col])
                            {
                                secondX = row;
                                secondY = col;
                            }
                        }
                    }

                    if (firstX == secondX)
                    {
                        szyfr.Text += matrixKw[firstX, (firstY + 1) % 5];
                        szyfr.Text += matrixKw[secondX, (secondY + 1) % 5];

                    }
                    else if (firstY == secondY)
                    {
                        szyfr.Text += matrixKw[(firstX + 1) % 5, firstY];
                        szyfr.Text += matrixKw[(secondX + 1) % 5, secondY];
                    }
                    else
                    {
                        szyfr.Text += matrixKw[secondX, firstY];
                        szyfr.Text += matrixKw[firstX, secondY];
                    }
                }

            }
            else
            {

                for (int j = 0; j < tekstJawny.Length; j += 2)
                {
                    char firstLetter = tekstJawny[j];
                    char secondLetter = tekstJawny[j + 1];


                    int firstX = 0, firstY = 0, secondX = 0, secondY = 0;

                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            if (firstLetter == matrixKw[row, col])
                            {
                                firstX = row;
                                firstY = col;
                            }

                            if (secondLetter == matrixKw[row, col])
                            {
                                secondX = row;
                                secondY = col;
                            }
                        }
                    }

                    if (firstX == secondX)
                    {
                        if (firstY - 1 < 0)
                        {
                            szyfr.Text += matrixKw[firstX, 4];
                        }
                        else
                        {
                            szyfr.Text += matrixKw[firstX, firstY - 1];
                        }

                        if (secondY - 1 < 0)
                        {
                            szyfr.Text += matrixKw[secondX, 4];
                        }
                        else
                        {
                            szyfr.Text += matrixKw[secondX, secondY - 1];
                        }



                    }
                    else if (firstY == secondY)
                    {
                        if (firstX - 1 < 0)
                        {
                            szyfr.Text += matrixKw[4, firstY];
                        }
                        else
                        {
                            szyfr.Text += matrixKw[firstX - 1, firstY];
                        }

                        if (secondX - 1 < 0)
                        {
                            szyfr.Text += matrixKw[4, secondY];
                        }
                        else
                        {
                            szyfr.Text += matrixKw[secondX - 1, secondY];
                        }
                    }
                    else
                    {
                        szyfr.Text += matrixKw[secondX, firstY];
                        szyfr.Text += matrixKw[firstX, secondY];
                    }
                }






            }

        }
    }
}
