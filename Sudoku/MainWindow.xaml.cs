using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //class objects for grid
        public int font_size { get; set; }
        public string font_family { get; set; }
        public string font_stye { get; set; }

        private void gameGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DefineGrid(9, 35);
            PopulateGameGrid();
        }

        /// <summary>
        /// Define game grid
        /// </summary>
        /// <param name="gridSize"></param>
        /// <param name="cell_size"></param>
        
        public void GameGrid(int font_size, string font_family, string font_stye)
        {
            this.font_size = font_size;
            this.font_family = font_family;
            this.font_stye = font_stye;
        }
        
        private void DefineGrid(int gridSize, int cell_size)
        {
            // define grid size and alligment properties

            gameGrid.Width = gridSize * cell_size;
            gameGrid.Height = gridSize * cell_size;

            gameGrid.HorizontalAlignment = HorizontalAlignment.Left;
            gameGrid.VerticalAlignment = VerticalAlignment.Top;
            gameGrid.ShowGridLines = false;

            // define grid rows
            for(int row=0;row<gridSize;row++)
            {
                RowDefinition rows = new RowDefinition();
                {
                    gameGrid.RowDefinitions.Add(rows);
                }
            }


            // define grid columns
            for (int col=0;col<gridSize;col++)
            {
                ColumnDefinition columns = new ColumnDefinition();
                {
                    gameGrid.ColumnDefinitions.Add(columns);
                }
            }

          // Add sudoku grid cells to the grid using text boxes
          for(int row=0;row< gridSize;row++) 
            {
                for(int col=0;col<gridSize;col++)
                {
                    TextBox tb = new TextBox()
                    {
                        Text = "",
                        TextAlignment = TextAlignment.Center,
                        FontFamily = new FontFamily("Arial"),
                        FontStyle = FontStyles.Italic,
                        FontSize = 35,
                        Background = Brushes.Gray,

                       

                    };
                }
            }


        }

        public void PopulateGameGrid()
        {
            CreateGrid.GenerateGrid(9);
            CreateGrid c = new CreateGrid();
            List<CreateGrid> grid = c.GetGameGridList();

            foreach(var x in grid)
            {
                if (x.isChangeable == false)
                {

                    TextBox tb = new TextBox()
                    {

                        Text = x.cell_no.ToString(),
                        TextAlignment = TextAlignment.Center,
                        FontFamily = new FontFamily("Arial"),
                        FontStyle = FontStyles.Italic,
                        FontSize = 35,
                        Background = Brushes.Gray,
                        IsReadOnly=true

                    };

                    gameGrid.Children.Add(tb);
                    Grid.SetRow(tb, x.row_no);
                    Grid.SetColumn(tb, x.col_no);
                }
                else if(x.isChangeable ==true)
                {
                    TextBox tb = new TextBox()
                    {

                        Text = "",
                        TextAlignment = TextAlignment.Center,
                        FontFamily = new FontFamily("Arial"),
                        FontStyle = FontStyles.Italic,
                        FontSize = 35,
                        Background = Brushes.White,

                    };

                    gameGrid.Children.Add(tb);
                    Grid.SetRow(tb, x.row_no);
                    Grid.SetColumn(tb, x.col_no);
                }
           
                }


              
            }

        }

    }

