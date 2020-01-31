using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class FindNumberAmazonGoStores
    {
        //Diagonals opposited elements are different cluster
        public int NumberAmazonGoStores(int rows, int column, int[,] grid)
        {
            var returnValue = 0;

            if (rows <= 0 || column <= 0)
                return returnValue;

            bool clusterPossible = false;
            bool clusterFound = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (grid[i, j] == 1 && clusterPossible == false)
                    {
                        clusterPossible = true;
                    }
                    else if (grid[i, j] == 1 && clusterPossible == true)
                    {
                        clusterFound = true;
                    }
                    else if (grid[i, j] == 0 && clusterFound == true)
                    {
                        returnValue += 1;
                        clusterPossible = false;
                        clusterFound = false;
                    }
                    else if (grid[i, j] == 0)
                    {
                        clusterPossible = false;
                        clusterFound = false;
                    }

                    //if (grid[i, j] == 1  && clusterPossible == false)
                    //{
                    //    if (j + 1 < column && grid[i, j + 1] == 0)
                    //    {

                    //    }
                    //    else if ((j == column - 1) && )
                    //    {

                    //    }
                    //}

                    if (grid[i, j] == 1 && (j + 1 < column && grid[i, j + 1] == 0) && clusterPossible == false)
                    {
                        if (grid[i + 1, j + 1] == 1)
                        {
                            returnValue++;
                            clusterPossible = false;
                            clusterFound = false;
                        }
                    }
                    else if (grid[i, j] == 1 && (j == column - 1) && clusterPossible == false)
                    {
                        if (i == 0 && grid[i + 1, j - 1] == 1)
                        {
                            returnValue++;
                            clusterPossible = false;
                            clusterFound = false;
                        }
                        else if (i == rows - 1 && grid[i + 1, j - 1] == 1)
                        {

                        }

                    }



                    if ((grid[i, j] == 1) &&
                    (
                    (
                        (((j + 1 < column) && grid[i, j + 1] == 0) || ((j == column) && (i + 1 < rows) && grid[i + 1, 0] == 0)) /*ensuring that the cell is not part of any cluster*/
                            &&
                        ((i - 1 >= 0) && (j - 1 >= 0) && grid[i - 1, j - 1] == 1)
                    )  /*is diagonal?*/
                    ||
                    (
                        (i == rows - 1 && j == column - 1 && grid[i - 1, j - 1] == 1)
                        ||
                        (i == 0 && j == 0 && grid[i + 1, j + 1] == 1)
                    ) /*first or last cell*/
                    ))
                    {
                        //diagonal    
                        returnValue += 1;
                        clusterPossible = false;
                        clusterFound = false;
                    }
                }
            }

            return returnValue;

        }

    }
}
