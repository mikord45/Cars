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


namespace ProjektSemestralny
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        public Edit()
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
            List<Id> data4 = LoadIds();
            SelectId.DisplayMemberPath = "Name";
            SelectId.SelectedValuePath = "ID";
            SelectId.DataContext = data4;
        }

        private List<Engines> LoadEngines()
        {
            using (MotoryzacjaEntities2 context = new MotoryzacjaEntities2())
            {
                List<Engines> engines = context.Engines.ToList();
                return engines;
            }
        }

        private List<Colors> LoadColors()
        {
            using (MotoryzacjaEntities2 context = new MotoryzacjaEntities2())
            {
                List<Colors> colors = context.Colors.ToList();
                return colors;
            }

        }

        private List<States> LoadStates()
        {
            using (MotoryzacjaEntities2 context = new MotoryzacjaEntities2())
            {
                List<States> states = context.States.ToList();
                return states;
            }
        }

        private List<Id> LoadIds()
        {
            using (MotoryzacjaEntities2 context = new MotoryzacjaEntities2())
            {
                List<Id> ids = new List<Id>();
                List<Cars> allCars = context.Cars.ToList();
                foreach (Cars car in allCars){
                    Id currentId = new Id()
                    {
                        ID = car.Id,
                        Name = car.Id.ToString()
                    };
                    ids.Add(currentId);
                }
                return ids;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (SelectId.SelectedValue != null && InputCarName.Text != "" && InputMileage.Text != "" && InputYear.Text != "" && SelectEngine.SelectedValue != null && SelectColor.SelectedValue != null && SelectState.SelectedValue != null)
            {
                using (MotoryzacjaEntities2 context = new MotoryzacjaEntities2())
                {
                    int properId = Int32.Parse(SelectId.SelectedValue.ToString());
                    Cars toEdit = (from car in context.Cars
                                 where car.Id == properId
                                 select car).First();

                    toEdit.CarName = InputCarName.Text;
                    toEdit.Engine = Int32.Parse(SelectEngine.SelectedValue.ToString());
                    toEdit.Color = Int32.Parse(SelectColor.SelectedValue.ToString());
                    toEdit.State = Int32.Parse(SelectState.SelectedValue.ToString());
                    toEdit.CarMileage = Int32.Parse(InputMileage.Text);
                    toEdit.Year = Int32.Parse(InputYear.Text);
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
