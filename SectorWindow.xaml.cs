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
    /// Логика взаимодействия для SectorWindow.xaml
    /// </summary>
    public partial class SectorWindow : Window
    {
        public DataBase dataBase = new DataBase();
        public Sector currentSector;
        public int minX, minY;
        public SectorWindow(Sector sector)
        {
            InitializeComponent();
            dataBase.GetConnection();
            currentSector = sector;
            CreateProfilesList();
            DrawSector();
            DrawProfiles();
            CreateButtons();
            FillSectorText();
            FillDataGrid();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            Window window = this.Owner;
            window.Show();
            this.Hide();
        }

        public void DrawSector()
        {
            Polygon polygon = new Polygon();
            polygon.Stroke = Brushes.Black;
            PointCollection points = new PointCollection();
            minX = currentSector.Coordinates[0].Item1;
            minY = currentSector.Coordinates[0].Item2; 
            for (int i = 1; i < currentSector.Coordinates.Count; i++)
            {
                if(currentSector.Coordinates[i].Item1 < minX)
                {
                    minX = currentSector.Coordinates[i].Item1;
                }
                if (currentSector.Coordinates[i].Item2 < minY)
                {
                    minY = currentSector.Coordinates[i].Item2;
                }
            }
            for (int i = 0; i < currentSector.Coordinates.Count; i++)
            {
                points.Add(new Point((currentSector.Coordinates[i].Item1 - minX + 6) * 1.7, (currentSector.Coordinates[i].Item2 - minY + 6) * 1.7));
            }
            polygon.Points = points;
            polygon.Tag = currentSector.IdSector;
            sectorView.Children.Add(polygon);
        }

        public void CreateProfilesList()
        {
            DataTable dataTable = dataBase.SqlSelect("select * from Profiles where IdSector = " + currentSector.IdSector);
            if (dataTable.Rows.Count == 0)
            {
                return;
            }
            Profile profile;
            for(int i = 0; i < dataTable.Rows.Count - 1; i++)
            {
                profile = new Profile(Convert.ToInt32(dataTable.Rows[i][0]), Convert.ToInt32(dataTable.Rows[i][1]), Convert.ToInt32(dataTable.Rows[i][2]));
                DataTable dt = dataBase.SqlSelect("select * from ProfileCoordinates where IdProfile = " + Convert.ToInt32(dataTable.Rows[i][0]));
                for(int j = 0; j < dt.Rows.Count; j++)
                {
                    Tuple<int, int> coord = new Tuple<int, int>(Convert.ToInt32(dt.Rows[j][2]), Convert.ToInt32(dt.Rows[j][3]));
                    profile.Coordinates.Add(coord);
                }
                currentSector.Profiles.Add(profile);
            }
        }

        public void DrawProfiles()
        {
            Polyline polyline;
            foreach (var p in currentSector.Profiles)
            {
                polyline = new Polyline();
                polyline.Stroke = Brushes.Black;
                PointCollection points = new PointCollection();
                for(int i = 0; i < p.Coordinates.Count; i++)
                {
                    points.Add(new Point((p.Coordinates[i].Item1 - minX + 6) * 1.7, (p.Coordinates[i].Item2 - minY + 6) * 1.7));
                }
                polyline.Points = points;
                polyline.Tag = p.IdProfile;
                sectorView.Children.Add(polyline);
            }
        }

        public void FillSectorText()
        {
            sectorId.Text = currentSector.IdSector.ToString();
            sectorSquare.Text = currentSector.SquareSector.ToString();
            profilesAmount.Text = (currentSector.Profiles.Count + 1).ToString();
            string text = "";
            int i = 0;
            foreach (var c in currentSector.Coordinates)
            {
                text = c.Item1.ToString() + " " + c.Item2.ToString();
                listCoordinates.Items.Insert(i, text);
                i++;
            }
        }

        public void CreateButtons()
        {
            Button btn;
            foreach (var p in currentSector.Profiles)
            {
                btn = new Button();
                switch (p.IdProfile)
                {
                    case 1:
                        btn.Content = "Профиль 1";
                        break;
                    default:
                        btn.Content = "Профиль " + p.IdProfile.ToString() + " (нерабочий)";
                        break;
                }
                
                btn.Tag = p.IdProfile;
                btn.Click += btn_Click;
                buttonsPanel.Children.Add(btn);
            }
            btn = new Button();
            btn.Content = "Профиль 7 (нерабочий)";
            btn.Tag = 7;
            btn.Click += btn_Click;
            buttonsPanel.Children.Add(btn);

        }
        public void btn_Click(object sender, EventArgs e)
        {
            Profile selectedProfile = null;
            foreach (var p in currentSector.Profiles)
            {
                if (p.IdProfile == Convert.ToInt32(((Button)sender).Tag))
                {
                    selectedProfile = p;
                    break;
                }
            }
            ProfileWindow window = new ProfileWindow(selectedProfile);
            window.Owner = this;
            window.Show();
            this.Hide();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        public void FillDataGrid()
        {
            DataTable dataTable = dataBase.SqlSelect("select * from Profiles, ProfileCoordinates where " +
                "Profiles.IdProfile = ProfileCoordinates.IdProfile and IdSector = " + currentSector.IdSector);
            gridProfiles.ItemsSource = dataTable.DefaultView;
        }
    }
}
