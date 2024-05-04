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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeophysicsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Sector> sectors = new List<Sector>();
        DataBase dataBase = new DataBase();

        public MainWindow()
        {
            InitializeComponent();
            dataBase.GetConnection();
            CreateSectorsList();
            DrawSectors();
            CreateButtons();
            FillDataGrid();
        }

        public void CreateSectorsList()
        {
            DataTable dataTable = dataBase.SqlSelect("select * from Sectors");
            Sector sector;
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                sector = new Sector(Convert.ToInt32(dataTable.Rows[i][0]), Convert.ToInt32(dataTable.Rows[i][2]));
                DataTable dt = dataBase.SqlSelect("select * from SectorCoordinates where IdSector = " + sector.IdSector);
                for(int j = 0; j < dt.Rows.Count; j++)
                {
                    Tuple<int, int> coord = new Tuple<int, int>(Convert.ToInt32(dt.Rows[j][2]), Convert.ToInt32(dt.Rows[j][3]));
                    sector.Coordinates.Add(coord);
                }
                sectors.Add(sector);
            }
        }

        public void DrawSectors()
        {
            Polygon polygon;
            foreach (var s in sectors)
            {
                polygon = new Polygon();
                polygon.Stroke = Brushes.Black;
                PointCollection points = new PointCollection();
                for(int i = 0; i < s.Coordinates.Count; i++)
                {
                    points.Add(new Point(s.Coordinates[i].Item1 * 1.2, s.Coordinates[i].Item2 * 1.2));
                }
                polygon.Points = points;
                polygon.Tag = s.IdSector;
                sectorsDiagram.Children.Add(polygon);
            }
        }

        public void CreateButtons()
        {
            Button btn;
            foreach (var s in sectors)
            {
                btn = new Button();
                switch (s.IdSector)
                {
                    case 1:
                        btn.Content = "Участок 1";
                        break;
                    default:
                        btn.Content = "Участок " + s.IdSector.ToString() +" (нерабочий)";
                        break;
                }
                btn.Tag = s.IdSector;
                btn.Click += btn_Click;
                buttonsPanel.Children.Add(btn);
            }
        }
        public void btn_Click(object sender, EventArgs e)
        {
            Sector selectedSector = null;
            foreach (var s in sectors)
            {
                if(s.IdSector == Convert.ToInt32(((Button)sender).Tag))
                {
                    selectedSector = s;
                    break;
                }
            }
            SectorWindow window = new SectorWindow(selectedSector);
            window.Owner = this;
            window.Show();
            this.Hide();
        }

        public void FillDataGrid()
        {
            DataTable dataTable = dataBase.SqlSelect("select * from Sectors, SectorCoordinates where Sectors.IdSector = SectorCoordinates.IdSector");
            gridSectors.ItemsSource = dataTable.DefaultView;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditSectorWindow window = new AddEditSectorWindow(null);
            window.Owner = this;
            window.Show();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(gridSectors.SelectedItem == null)
            {
                MessageBox.Show("Выберете участок для редактирования");
                return;
            }
            DataRowView row = (DataRowView)gridSectors.SelectedItems[0];
            int idSector = Convert.ToInt32(row["IdSector"]);
            foreach (var s in sectors)
            {
                if(s.IdSector == idSector)
                {
                    AddEditSectorWindow window = new AddEditSectorWindow(s);
                    window.Owner = this;
                    window.Show();
                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(control.SelectedIndex == 0)
            {
                sectors = new List<Sector>();
                sectorsDiagram.Children.Clear();
                buttonsPanel.Children.Clear();
                TextBlock text = new TextBlock();
                text.Text = "Выберите участок:";
                buttonsPanel.Children.Add(text);
                CreateSectorsList();
                DrawSectors();
                CreateButtons();
                return;
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gridSectors.SelectedItem == null)
            {
                MessageBox.Show("Выберете участок для редактирования");
                return;
            }
            DataRowView row = (DataRowView)gridSectors.SelectedItems[0];
            int idSector = Convert.ToInt32(row["IdSector"]);

            Sector selectedSector = null;
            foreach (var s in sectors)
            {
                if (s.IdSector == idSector)
                {
                    selectedSector = s;
                    break;
                }
            }
            if (selectedSector == null) return;
            DataTable dataTable = dataBase.SqlSelect("select * from Profiles where IdSector = " + selectedSector.IdSector);
            if (dataTable.Rows.Count == 0)
            {
                selectedSector.Profiles = null;
                DeleteSector(selectedSector);
                MessageBox.Show("Участок удалён");
                return;
            }
            Profile profile;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                profile = new Profile(Convert.ToInt32(dataTable.Rows[i][0]), Convert.ToInt32(dataTable.Rows[i][1]), Convert.ToInt32(dataTable.Rows[i][2]));
                DataTable dt = dataBase.SqlSelect("select * from ProfileCoordinates where IdProfile = " + Convert.ToInt32(dataTable.Rows[i][0]));
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    Tuple<int, int> coord = new Tuple<int, int>(Convert.ToInt32(dt.Rows[j][2]), Convert.ToInt32(dt.Rows[j][3]));
                    profile.Coordinates.Add(coord);
                }
                selectedSector.Profiles.Add(profile);
            }
            foreach (var p in selectedSector.Profiles)
            {
                dataTable = dataBase.SqlSelect("select * from Pickets where IdProfile = " + p.IdProfile);
                if (dataTable.Rows.Count == 0)
                {
                    p.Pickets = null;
                    DeleteProfile(p);
                    continue;
                }
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    p.Pickets.Add(new Picket(Convert.ToInt32(dataTable.Rows[i][0]), Convert.ToInt32(dataTable.Rows[i][1]),
                        new Tuple<int, int>(Convert.ToInt32(dataTable.Rows[i][2]), Convert.ToInt32(dataTable.Rows[i][3]))));
                }
                foreach (var pi in p.Pickets)
                {
                    DeletePicket(pi);
                }
                DeleteProfile(p);
            }
            DeleteSector(selectedSector);
            MessageBox.Show("Участок удалён");
        }

        public void DeletePicket(Picket p)
        {
            dataBase.SqlQuery("delete from Measurements where IdPicket1 = " + p.IdPicket + 
                    " or IdPicket2 = " + p.IdPicket);
            dataBase.SqlQuery("delete from Pickets where IdPicket = " + p.IdPicket);
        }

        public void DeleteProfile(Profile pr)
        {
            dataBase.SqlQuery("delete from ProfileCoordinates where IdProfile = " + pr.IdProfile);
            dataBase.SqlQuery("delete from Profiles where IdProfile = " + pr.IdProfile);
        }

        public void DeleteSector(Sector sector)
        {
            dataBase.SqlQuery("delete from SectorCoordinate where IdSector = " + sector.IdSector);
            dataBase.SqlQuery("delete from Sectors where IdSector = " + sector.IdSector);
        }
    }
}
