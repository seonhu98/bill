﻿using BillProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace BillProject
{
    /// <summary>
    /// mainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class mainPage : System.Windows.Window
    {
        //network net = new network();
        public mainPage()
        {  
            InitializeComponent();
            GetWindows getWindows = new GetWindows();
            DataContext = getWindows;
        }

        //private void bill_Click(object sender, RoutedEventArgs e)
        //{
        //    Window VP = new VidioPage();
        //    VP.Show();
        //}

        //private void day_Click(object sender, RoutedEventArgs e)
        //{
        //    Window Day = new DayDay();
        //    Day.Show();
        //}

        //private void total_Click(object sender, RoutedEventArgs e)
        //{
        //    Window To = new Total();
        //    To.Show();
        //}
    }
}
