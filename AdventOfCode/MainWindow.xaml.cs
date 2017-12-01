// -------------------------------------------------------------------------------------------------
//  <copyright file="MainWindow.xaml.cs">
//      © Johan Boström 2017
//  </copyright>
// -------------------------------------------------------------------------------------------------

namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<IDay> days = new List<IDay>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadDays()
        {
            var type = typeof(IDay);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && type != p)
                .OrderBy(t => t.Name);

            foreach (var t in types)
            {
                days.Add((IDay) Activator.CreateInstance(t));
            }

            days = days.OrderByDescending(d => d.Year).ThenByDescending(d => d.Day).ToList();

            var daysNames = days.Select(day => $"{day.Year} dag {day.Day}").ToList();

            cbDays.ItemsSource = daysNames;
            cbDays.SelectedIndex = 0;
        }

        private void btnGetResult_Click(object sender, RoutedEventArgs e)
        {
            var result = days[cbDays.SelectedIndex].GetResult(txtInput.Text.Trim());
            txtResult.Text = result.PartOne;
            txtResult2.Text = result.PartTwo;
        }

        private void wndMain_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDays();
        }

        private void btnGetInput_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                var day = days[cbDays.SelectedIndex];
                var url = $"http://adventofcode.com/{day.Year}/day/{day.Day}/input";
                var res = client.GetStringAsync(url);
                res.Wait();
                txtInput.Text = res.Result;
            }
        }

        private string GetInputFileName()
        {
            var day = days[cbDays.SelectedIndex];
            return $"input_day_{day.Year}-{day.Day}.txt"; ;
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            File.WriteAllText(GetInputFileName(), txtInput.Text);
        }

        private void cbDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var fileName = GetInputFileName();

            txtInput.Text = File.Exists(fileName) ? File.ReadAllText(fileName) : "";
        }
    }
}