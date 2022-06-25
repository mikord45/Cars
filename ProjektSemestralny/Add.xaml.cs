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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();
            InputCarName.Text = "";
            InputMileage.Text = "";
            InputYear.Text = "";
            var data1 = LoadEngines();
            SelectEngine.DisplayMemberPath = "Name";
            SelectEngine.SelectedValuePath = "Id";
            SelectEngine.DataContext = data1;
            var data2 = LoadColors();
            SelectColor.DisplayMemberPath = "Name";
            SelectColor.SelectedValuePath = "Id";
            SelectColor.DataContext = data2;
            var data3 = LoadStates();
            SelectState.DisplayMemberPath = "Name";
            SelectState.SelectedValuePath = "Id";
            SelectState.DataContext = data3;
        }

        private List<Engine> LoadEngines()
        {
            List<Engine> engines = new List<Engine>();
            engines.Add(new Engine()
            {
                Id = 101,
                Name = "Engine1"
            });
            engines.Add(new Engine()
            {
                Id = 102,
                Name = "Engine2"
            });

            return engines;
        }

        private List<Color> LoadColors()
        {
            List<Color> colors = new List<Color>();
            colors.Add(new Color()
            {
                Id = 201,
                Name = "Color1"
            });
            colors.Add(new Color()
            {
                Id = 202,
                Name = "Color2"
            });

            return colors;
        }

        private List<State> LoadStates()
        {
            List<State> states = new List<State>();
            states.Add(new State()
            {
                Id = 301,
                Name = "Nowy"
            });
            states.Add(new State()
            {
                Id = 302,
                Name = "Używany"
            });
            states.Add(new State()
            {
                Id = 303,
                Name = "Uszkodzony"
            });

            return states;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
