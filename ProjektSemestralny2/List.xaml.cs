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
using System.Diagnostics;


namespace ProjektSemestralny
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Page
    {
        public List()
        {
            InitializeComponent();
            List<Car> data1 = LoadCollectionData();
            this.DataContext = data1;
        }
        private List<Car> LoadCollectionData()
        {
            using (MotoryzacjaEntities2 context = new MotoryzacjaEntities2())
            {
                var cars = from car in context.Cars
                           join engine in context.Engines on car.Engine equals engine.Id
                           join color in context.Colors on car.Color equals color.Id
                           join state in context.States on car.State equals state.Id
                           select new Car(){Id = car.Id, CarName = car.CarName, Engine = engine.Name, Color = color.Name, State = state.Name, CarMileage = car.CarMileage, Year = car.Year };
                return cars.ToList();
            }

        }

    }
}
