using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace GeophysicsApp
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public DataBase dataBase = new DataBase();
        public Profile currentProfile;
        public List<Measurement> measurements = new List<Measurement>();
        public ProfileWindow(Profile profile)
        {
            InitializeComponent();
            dataBase.GetConnection();
            currentProfile = profile;
            CreatePicketList();
            CreateMeasurementList();
            DrawDiagram();
            FillDataGrids();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        public void CreatePicketList()
        {
            DataTable dataTable = dataBase.SqlSelect("select * from Pickets where IdProfile = " + currentProfile.IdProfile);
            if(dataTable.Rows.Count == 0)
            {
                currentProfile.Pickets = null;
                return;
            }
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                currentProfile.Pickets.Add(new Picket(Convert.ToInt32(dataTable.Rows[i][0]), Convert.ToInt32(dataTable.Rows[i][1]), 
                    new Tuple<int, int>(Convert.ToInt32(dataTable.Rows[i][2]), Convert.ToInt32(dataTable.Rows[i][3]))));
            }
        }

        public void CreateMeasurementList()
        {
            DataTable dataTable = dataBase.SqlSelect("select Measurements.* from Measurements, Pickets " +
                    "where IdPicket1 = IdPicket and IdProfile = " + currentProfile.IdProfile);
            if (dataTable.Rows.Count == 0) return;
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                measurements.Add(new Measurement(Convert.ToInt32(dataTable.Rows[i][0]), Convert.ToInt32(dataTable.Rows[i][1]),
                    Convert.ToInt32(dataTable.Rows[i][2]), Convert.ToInt32(dataTable.Rows[i][3])));
            }
        }

        public void DrawDiagram()
        {
            EllipseGeometry ellipse;
            Path path;
            int startPosition = 15;
            int picketD = 5;
            int defferenceD = 20;
            int step = 40;
            for(int i = 0; i < currentProfile.Pickets.Count; i++)
            {
                path = new Path();
                path.Fill = Brushes.Black;
                ellipse = new EllipseGeometry();
                ellipse.Center = new Point(startPosition + step * i, startPosition);
                ellipse.RadiusX = picketD;
                ellipse.RadiusY = picketD;
                path.Data = ellipse;
                picketsDiagram.Children.Add(path);
            }

            for(int i = 0; i < measurements.Count; i++)
            {
                path = new Path();
                if(measurements[i].Difference <= 210) path.Fill = Brushes.DarkBlue;
                else if(measurements[i].Difference > 210 && measurements[i].Difference <= 600) path.Fill = Brushes.LightBlue;
                else if(measurements[i].Difference > 600 && measurements[i].Difference <= 1200) path.Fill = Brushes.LightGreen;
                else if(measurements[i].Difference > 1200 && measurements[i].Difference <= 2400) path.Fill = Brushes.Green;
                else if(measurements[i].Difference > 2400 && measurements[i].Difference <= 9600) path.Fill = Brushes.Orange;
                else path.Fill = Brushes.Red;
                ellipse = new EllipseGeometry();
                ellipse.Center = new Point(startPosition + defferenceD + defferenceD * 2 * (measurements[i].IdPicket1 - 1), 
                    startPosition + picketD*2 + defferenceD + defferenceD* 2 * (measurements[i].Depth - 1));
                ellipse.RadiusX = defferenceD;
                ellipse.RadiusY = defferenceD;
                path.Data = ellipse;
                picketsDiagram.Children.Add(path);
            }
        }

        public void FillDataGrids()
        {
            DataTable dataTable = dataBase.SqlSelect("select * from Measurements");
            gridMeasurements.ItemsSource = dataTable.DefaultView;

            dataTable = dataBase.SqlSelect("select * from Pickets where IdProfile = " + currentProfile.IdProfile);
            gridPickets.ItemsSource = dataTable.DefaultView;
        }
    }
}
