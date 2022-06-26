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
            var data4 = LoadIds();
            SelectId.DisplayMemberPath = "Name";
            SelectId.SelectedValuePath = "ID";
            SelectId.DataContext = data4;
        }

        private List<Engines> LoadEngines()
        {
            using (var context = new MotoryzacjaEntities2())
            {
                var engines = context.Engines.ToList();
                return engines;
            }
        }

        private List<Colors> LoadColors()
        {
            using (var context = new MotoryzacjaEntities2())
            {
                var colors = context.Colors.ToList();
                return colors;
            }

        }

        private List<States> LoadStates()
        {
            using (var context = new MotoryzacjaEntities2())
            {
                var states = context.States.ToList();
                return states;
            }
        }

        private List<Id> LoadIds()
        {
            using (var context = new MotoryzacjaEntities2())
            {
                List<Id> ids = new List<Id>();
                var allCars = context.Cars.ToList();
                foreach (var car in allCars){
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
    }
}