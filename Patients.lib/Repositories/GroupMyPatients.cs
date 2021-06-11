using System;
using EntryRepresents.lib.Model.Request;

namespace EntryRepresents.lib.Repositories.Interface
{
    public class GroupMyPatients: IGroupMyPatients<int>
    {
        /// <summary>
        /// Method to prevent array out of index exception
        /// </summary>
        /// <param name="matrix">matrix of [][]</param>
        /// <param name="row">which row to validate</param>
        /// <param name="col"></param>
        /// <param name="visited"></param>
        /// <param name="rowLenght"></param>
        /// <param name="colLength"></param>
        /// <returns></returns>
        private bool IsSafe(int[][] matrix, int row,
                       int col, bool[][] visited, int rowLenght, int colLength)
        {
            //
            return (row >= 0) && (row < rowLenght) && (col >= 0) && (col < colLength) && (matrix[row][ col] == 1 && !visited[row][col]);
        }
        private void DFS(int[][] M, int row,
                    int col, bool[][] visited,int Col)
        {
            int ROW = M.GetLength(0);
            //This gives the 8 chain items in surrending
            int[] rowNbr = new int[] { -1, -1, -1, 0,
                                   0, 1, 1, 1 };
            int[] colNbr = new int[] { -1, 0, 1, -1,
                                   1, -1, 0, 1 };

           //Mark the cell as touched
            visited[row][col] = true;

            //Reach the neighbors to identify if they belong to group
            for (int k = 0; k < 8; ++k)
                if (this.IsSafe(M, row + rowNbr[k], col + colNbr[k], visited, ROW, Col))
                    DFS(M, row + rowNbr[k],
                        col + colNbr[k], visited, Col);
        }
        /// <summary>
        /// Takes in a object that contains the matrix computes and in return gives
        /// complixity nSquare
        /// </summary>
        /// <param name="patientGroup">input matrix object</param>
        /// <returns></returns>
        public int GroupedCount(PatientGroup<int> patientGroup)
        {
            int count = 0;
            try
            {
                //row
                int row = patientGroup.Matrix.GetLength(0);
                // if the elements are 0 please close the process
                if (row == 0)
                    return 0;

                bool[][] visited = new bool[row][];
                for (int i = 0; i < row; ++i)
                {
                    visited[i] = new bool[patientGroup.Matrix[i].Length];
                }

                for (int i = 0; i < row; ++i)
                    for (int j = 0; j < patientGroup.Matrix[i].Length; ++j)
                        if (patientGroup.Matrix[i][j] == 1 && !visited[i][j])
                        {
                            int Col = patientGroup.Matrix[i].Length;
                            //Check if the matrix group with DFS
                            DFS(patientGroup.Matrix, i, j, visited, Col);
                            ++count;
                        }
            }
            catch
            {
                throw;
            }
            return count;
        }
    }
}
