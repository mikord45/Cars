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
            var data1 = LoadCollectionData();
            //CarGrid.ItemsSource = data1;
            this.DataContext = data1;
        }
        private List<Car> LoadCollectionData()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });
            cars.Add(new Car()
            {
                Id = 101,
                CarName = "Jeep",
                Engine = "200KM",
                Color = "red",
                State = "nowy",
                CarMileage = 2342342,
                Year = 2009
            });

            return cars;
        }

    }
}
