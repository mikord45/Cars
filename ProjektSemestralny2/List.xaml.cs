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
using ProjektSemestralny.Database;

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
            using (MotoryzacjaDBContext context = new MotoryzacjaDBContext())
            {
                if(context.Cars.FirstOrDefault() == null)
                {
                    var listOfEngines = new List<Engines>{
                        new Engines()
                        {
                            Name = "Honda 100KM"
                        },
                        new Engines()
                        {
                            Name = "Mercedes 200KM"
                        },
                        new Engines()
                        {
                            Name = "Mercedes 300KM"
                        },
                        new Engines()
                        {
                            Name = "Fiat 80KM"
                        },
                        new Engines()
                        {
                            Name = "Fiat 120KM"
                        },
                        new Engines()
                        {
                            Name = "Fiat 160KM"
                        },
                        new Engines()
                        {
                            Name = "Suzuki 150KM"
                        },
                        new Engines()
                        {
                            Name = "Audi 250KM"
                        }
                    };
                    context.Engines.AddRange(listOfEngines);

                    var listOfStates = new List<States>
                    {
                        new States()
                        {
                            Name = "Nowy"
                        },
                        new States()
                        {
                            Name = "Używany"
                        },
                        new States()
                        {
                            Name = "Uszkodzony"
                        }
                    };
                    context.States.AddRange(listOfStates);

                    var listOfColors = new List<Colors>
                    {
                        new Colors()
                        {
                            Name = "Czerwony"
                        },
                        new Colors()
                        {
                            Name = "Niebieski"
                        },
                        new Colors()
                        {
                            Name = "Zielony"
                        },
                        new Colors()
                        {
                            Name = "Fioletowy"
                        },
                        new Colors()
                        {
                            Name = "Czarny"
                        },
                        new Colors()
                        {
                            Name = "Bialy"
                        }
                    };
                    context.Colors.AddRange(listOfColors);

                    context.SaveChanges();

                    var listOfCars = new List<Cars>
                    {
                        new Cars()
                        {
                            CarName = "Mercedes A Klasa",
                            Engine = 2,
                            Color = 3,
                            State = 1,
                            CarMileage = 0,
                            Year = 2022
                        },
                        new Cars()
                        {
                            CarName = "Mercedes B Klasa",
                            Engine = 2,
                            Color = 2,
                            State = 2,
                            CarMileage = 20120,
                            Year = 2020
                        },
                        new Cars()
                        {
                            CarName = "Mercedes S Klasa",
                            Engine = 3,
                            Color = 1,
                            State = 3,
                            CarMileage = 234321,
                            Year = 2010
                        },
                        new Cars()
                        {
                            CarName = "Honda Civic",
                            Engine = 1,
                            Color = 3,
                            State = 1,
                            CarMileage = 0,
                            Year = 2022
                        },
                        new Cars()
                        {
                            CarName = "Fiat 500",
                            Engine = 4,
                            Color = 4,
                            State = 1,
                            CarMileage = 0,
                            Year = 2022
                        },
                        new Cars()
                        {
                            CarName = "Fiat Tipo",
                            Engine = 6,
                            Color = 1,
                            State = 3,
                            CarMileage = 3212,
                            Year = 2021
                        },
                        new Cars()
                        {
                            CarName = "Fiat Panda",
                            Engine = 5,
                            Color = 2,
                            State = 2,
                            CarMileage = 345321,
                            Year = 2005
                        },
                        new Cars()
                        {
                            CarName = "Suzuki Vitara",
                            Engine = 7,
                            Color = 5,
                            State = 1,
                            CarMileage = 0,
                            Year = 2022
                        },
                        new Cars()
                        {
                            CarName = "Audi A5",
                            Engine = 8,
                            Color = 2,
                            State = 2,
                            CarMileage = 45343,
                            Year = 2017
                        },
                    };
                    context.Cars.AddRange(listOfCars);


                    context.SaveChanges();

                }
                
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
