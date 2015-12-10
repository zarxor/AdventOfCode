using AdventOfCode.Days;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace AdventOfCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IDay> _dayList = new List<IDay>();
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

            foreach (Type t in types)
            {
                _dayList.Add((IDay)Activator.CreateInstance(t));
            }

            List<string> daysNames = new List<string>();
            foreach( var d in _dayList)
            {
                daysNames.Add("Dag " + d.GetDayNumber());
            }

            cbDays.ItemsSource = daysNames;
            cbDays.SelectedIndex = 0;
        }

        private void btnGetResult_Click(object sender, RoutedEventArgs e)
        {
            var result = _dayList[cbDays.SelectedIndex].GetResult(txtInput.Text.Trim());
            txtResult.Text = result.PartOne;
            txtResult2.Text = result.PartTwo;
        }

        private void wndMain_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDays();
        }

        private void btnGetInput_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var currentday = _dayList[cbDays.SelectedIndex].GetDayNumber();
                var _url = string.Format("http://adventofcode.com/day/{0}/input", currentday);
                var res = client.GetStringAsync(_url);
                res.Wait();
                txtInput.Text = res.Result;
            }
        }

        private string getInputFileName()
        {
            var daynum = _dayList[cbDays.SelectedIndex].GetDayNumber();
            var fileName = "input_day" + daynum.ToString() + ".txt";
            return fileName;
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            File.WriteAllText(getInputFileName(), txtInput.Text);
        }

        private void cbDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var daynum = _dayList[cbDays.SelectedIndex].GetDayNumber();
            var fileName = getInputFileName();

            if (File.Exists(fileName))
            {
                txtInput.Text = File.ReadAllText(fileName);
            }
            else
            {
                txtInput.Text = "";
            }
        }
    }
}
