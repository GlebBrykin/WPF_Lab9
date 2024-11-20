using System;
using System.IO;
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
using Microsoft.Win32;

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.text_box.FontFamily = new FontFamily((string)((ComboBox)sender).SelectedItem);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            this.text_box.FontSize = (double)((ComboBox)sender).SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.text_box.FontWeight == FontWeights.Bold)
            {
                this.text_box.FontWeight = FontWeights.Normal;
                ((Button)sender).Background = null;
            }
            else
            {
                this.text_box.FontWeight = FontWeights.Bold;
                ((Button)sender).Background = Brushes.LightBlue;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.text_box.FontStyle == FontStyles.Italic)
            {
                this.text_box.FontStyle = FontStyles.Normal;
                ((Button)sender).Background = null;
            }
            else
            {
                this.text_box.FontStyle = FontStyles.Italic;
                ((Button)sender).Background = Brushes.LightBlue;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.text_box.TextDecorations.Contains(TextDecorations.Underline[0]))
            {
                this.text_box.TextDecorations.Remove(TextDecorations.Underline[0]);
                ((Button)sender).Background = null;
            }
            else
            {
                this.text_box.TextDecorations.Add(TextDecorations.Underline);
                ((Button)sender).Background = Brushes.LightBlue;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.text_box.Foreground = Brushes.Black;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.text_box.Foreground = Brushes.Red;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            if (ofd.ShowDialog() == true)
            {
                this.text_box.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, this.text_box.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            string uri = null;
            switch((int)((ComboBox)sender).SelectedIndex)
            {
                case 0:
                {
                    uri = "Themes/Light.xaml";
                    break;
                }
                case 1:
                {
                    uri = "Themes/Dark.xaml";
                    break;
                }
            }
            if(uri != null)
            {
                Application.Current.Resources.MergedDictionaries.RemoveAt(Application.Current.Resources.MergedDictionaries.Count - 1);
                Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(uri, UriKind.Relative)));
            }
        }
    }
}
