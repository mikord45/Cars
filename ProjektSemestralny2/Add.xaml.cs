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
using System.Text.RegularExpressions;
using System.Diagnostics;
using ProjektSemestralny.Database;

namespace ProjektSemestralny
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    /// 

    public partial class Add : Page
    {

        public Add()
        {
            InitializeComponent();
            InputCarName.Text = "";
            InputMileage.Text = "";
            InputYear.Text = "";
            List<Engines> data1 = LoadEngines();
            SelectEngine.DisplayMemberPath = "Name";
            SelectEngine.SelectedValuePath = "Id";
            SelectEngine.DataContext = data1;
            List<Colors> data2 = LoadColors();
            SelectColor.DisplayMemberPath = "Name";
            SelectColor.SelectedValuePath = "Id";
            SelectColor.DataContext = data2;
            List<States> data3 = LoadStates();
            SelectState.DisplayMemberPath = "Name";
            SelectState.SelectedValuePath = "Id";
            SelectState.DataContext = data3;
        }

        private List<Engines> LoadEngines()
        {
            using (MotoryzacjaDBContext context = new MotoryzacjaDBContext())
            {
                List<Engines> engines = context.Engines.ToList();
                return engines;
            }
        }

        private List<Colors> LoadColors()
        {
            using (MotoryzacjaDBContext context = new MotoryzacjaDBContext())
            {
                List<Colors> colors = context.Colors.ToList();
                return colors;
            }

        }

        private List<States> LoadStates()
        {
            using (MotoryzacjaDBContext context = new MotoryzacjaDBContext())
            {
                List<States> states = context.States.ToList();
                return states;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(InputCarName.Text != "" && InputMileage.Text != "" && InputYear.Text != "" && SelectEngine.SelectedValue != null && SelectColor.SelectedValue != null && SelectState.SelectedValue != null)
            {
                using (MotoryzacjaDBContext context = new MotoryzacjaDBContext())
                {
                    Cars currentCar = new Cars()
                    {
                        CarName = InputCarName.Text,
                        Engine = Int32.Parse(SelectEngine.SelectedValue.ToString()),
                        Color = Int32.Parse(SelectColor.SelectedValue.ToString()),
                        State = Int32.Parse(SelectState.SelectedValue.ToString()),
                        CarMileage = Int32.Parse(InputMileage.Text),
                        Year = Int32.Parse(InputYear.Text)
                    };
                    context.Cars.Add(currentCar);
                    context.SaveChanges();
                }
                this.NavigationService.Navigate((new List()));
            }
            else
            {
                labelError.Content = "Musisz uzupełnić wszystkie pola";
            }
        }
    }
}
