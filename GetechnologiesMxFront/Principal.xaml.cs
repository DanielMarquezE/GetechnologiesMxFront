﻿using System;
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
using System.Windows.Shapes;

namespace GetechnologiesMxFront
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            myFrame.NavigationService.Navigate(new Personas());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            myFrame.NavigationService.Navigate(new Facturas());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            myFrame.NavigationService.Navigate(new Personas());
        }
    }
}
