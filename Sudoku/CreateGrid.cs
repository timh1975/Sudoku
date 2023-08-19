using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku
{
    public class CreateGrid
    {

        public int row_no { get; set; }
        public int col_no { get; set; }
        public int cell_no { get; set; }
        public bool isChangeable { get; set; }
        public int cell_size { get; set; }

        static List<CreateGrid> gameGrid = new List<CreateGrid>();
        int[,] grid = new int[0, 0];
        int[,] hide_cell = new int[0, 0];


        public static void GenerateGrid(int gridSize)
        {


            CreateGrid c = new CreateGrid();
            int[] arr;
            bool inValid;

            c.grid = new int[gridSize, gridSize];

            for (int i = 0; i < gridSize; i++)
            {
                if (i == 0)
                {
                    arr = c.GenerateRow(9);
                    c.AddToArray(arr, 9, i);
                }

                arr = c.GenerateRow(9);
                inValid = c.ValidateRow(gridSize, i, arr);

                while (inValid)
                {
                    arr = c.GenerateRow(9);
                    inValid = c.ValidateRow(gridSize, i, arr);
                }
                c.AddToArray(arr, 9, i);


            }

           c.HideCellNumber(9, 8);
           c.CreateList(9);
            
            
            
           

        }

        private int[] GenerateRow(int gridSize)
        {

            int[] return_array = new int[gridSize];
            int[] validate_row = new int[gridSize];

            Random rnd = new Random();
            int r;

            for (int index = 0; index < gridSize; index++)
            {
                r = rnd.Next(1, gridSize + 1);
                while (r == validate_row[r - 1])
                {
                    r = rnd.Next(1, gridSize + 1);
                }
                validate_row[r - 1] = r;
                return_array[index] = r;

            }

            return return_array;

        }

        private void AddToArray(int[] arr, int gridSize, int rowNumber)
        {
            for (int x = 0; x < gridSize; x++)
            {
                int num = arr[x];
                grid[rowNumber, x] = num;
            }
        }

        private void HideCellNumber(int gridSize, int cols_to_hide)
        {

            Random rnd = new Random();
            int r;
            int colCount = 0;

            hide_cell = new int[gridSize, gridSize];

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    colCount = 0;
                    do
                   {
                        r = rnd.Next(0, 2);
                        if (r == 0)
                        {
                            hide_cell[row, col] = 0;
                        }
                        else
                        {
                            hide_cell[row, col] = 1;
                        }
                        colCount++;

                    }

                    while (colCount < cols_to_hide);

                }

            }

        }

        
        
        private void CreateList(int gridSize)
        {
            for (int row = 0; row < gridSize; row++)
            {

                for (int col = 0; col < gridSize; col++)
                {
                    if (hide_cell[row, col] == 1)
                    {

                        gameGrid.Add(new CreateGrid
                        {
                            row_no = row,
                            col_no = col,
                            cell_no = grid[row, col],
                            isChangeable = true,
                            cell_size = 30
                        });
                    }
                    else
                    {
                        gameGrid.Add(new CreateGrid
                        {
                            row_no = row,
                            col_no = col,
                            cell_no = grid[row, col],
                            isChangeable = false,
                            cell_size = 30
                        });
                    }
                  
                }


            }
        }

       private bool ValidateRow(int gridSize, int rowNumber, int[] arr)
        {

            bool inValid = false;

            for (int row = 0; row < rowNumber; row++)
            {

                for (int col = 0; col < gridSize; col++)
                {
                    if (grid[row, col] == arr[col])
                    {
                        inValid = true;
                        break;
                    }
                }
            }

            return inValid;
        }

        public List<CreateGrid> GetGameGridList()
        {
          
            List<CreateGrid> grids = gameGrid;
            
            return grids;
        }

    }
}
