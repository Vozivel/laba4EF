using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace laba1EF
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private dartbaseEntities content = new dartbaseEntities();
        public Window2()
        {
            InitializeComponent();
            MyDataGrid.ItemsSource = content.Platforms.ToList();
            ComboFilter.ItemsSource = content.Platforms.ToList();
            ComboFilter.DisplayMemberPath = "Platform_Name";
        }

        private void DevelopersButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow DevelopersDS = new MainWindow();
            DevelopersDS.Show();
            Close();
        }

        private void GamesButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 GamesDS = new Window1();
            GamesDS.Show();
            Close();
        }

        private void PlatformsButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 PlatformsDS = new Window2();
            PlatformsDS.Show();
            Close();
        }

        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboFilter.SelectedItem != null)
            {
                var selected = ComboFilter.SelectedItem as Platforms;
                MyDataGrid.ItemsSource = content.Platforms.ToList().Where(item => item.Platform_Name == selected.Platform_Name);
            }
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            MyDataGrid.ItemsSource = content.Platforms.ToList();
        }
    }
}
