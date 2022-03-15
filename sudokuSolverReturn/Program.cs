using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //prufa array
            int[,] test = new int[,]
            {
                { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                { 0, 0, 0, 0, 8, 0, 0, 7, 9 },
            };


            //prufa lista
            List<List<int>> Board = new List<List<int>>();
            List<int> boardDone = new List<int>();

            Board.Add(new List<int>() { 5, 3, 0, 0, 7, 0, 0, 0, 0 });
            Board.Add(new List<int>() { 6, 0, 0, 1, 9, 5, 0, 0, 0 });
            Board.Add(new List<int>() { 0, 9, 8, 0, 0, 0, 0, 6, 0 });
            Board.Add(new List<int>() { 8, 0, 0, 0, 6, 0, 0, 0, 3 });
            Board.Add(new List<int>() { 4, 0, 0, 8, 0, 3, 0, 0, 1 });
            Board.Add(new List<int>() { 7, 0, 0, 0, 2, 0, 0, 0, 6 });
            Board.Add(new List<int>() { 0, 6, 0, 0, 0, 0, 2, 8, 0 });
            Board.Add(new List<int>() { 0, 0, 0, 4, 1, 9, 0, 0, 5 });
            Board.Add(new List<int>() { 0, 0, 0, 0, 8, 0, 0, 7, 9 });




            if (solve(test, 0, 0)) print_Board(test) ;
            



                // finds all the 0 in the list 
                int find_Zero(int[,] test, int rowP, int colP)
                {

                    int rowlenght = test.GetLength(0);
                    int collenght = test.GetLength(1);


                    for (int row = 0; row < rowlenght; row++)
                    {
                        for (int col = 0; col < collenght; col++)
                        {
                            if (test[row, col] == 0)
                            {

                                Console.WriteLine("test[{0},{1}]", row, col, test[row, col]);

                                rowP = row;
                                colP = col;
                            }
                        }
                    }


                    return test[rowP, colP];
                }
        
                
            
            // til ad skoda ef that er 0 og hvort talan gangi i saetid
            bool is_valid(int [,] test, int row, int col, int number)
            {
                int rowS = (row / 3) * 3;
                int colS = (col / 3) * 3;

                for (int i = 0; i < 9; i++)
                {
                    if (test[i,col] != 0 && test[i,col] == number)
                    {
                        return false;
                    }
                    if (test[row,i] != 0 && test[row,i] == number)
                    {
                        return false;
                    }
                    if(test[rowS + (i % 3), colS + (i / 3)] == number)
                    {
                        return false;
                    }
                }
                return true;
            }

            bool solve(int[,]test, int row, int col)
            {
                if (row < 9 && col < 9)
                {
                    if (test[row, col] != 0)
                    {
                        if ((col + 1) < 9) return solve(test, row, col + 1);
                        else if ((row + 1) < 9) return solve(test, row + 1, 0);
                        else return true;
                    }
                    else
                    {
                        for (int i = 0; i < 9; ++i)
                        {
                            if (is_valid(test, row, col, i + 1))
                            {
                                test[row, col] = i + 1;

                                if ((col + 1) < 9)
                                {
                                    if (solve(test, row, col + 1)) return true;
                                    else test[row, col] = 0;
                                }
                                else if ((row + 1) < 9)
                                {
                                    if (solve(test, row + 1, 0)) return true;
                                    else test[row, col] = 0;
                                }
                                else return true;
                            }
                        }
                    }

                    return false;
                }
                else return true;
            }
        



            // prints out the board 
             void print_Board(int [,] test)
             {

                int rowlenght = test.GetLength(0);
                int collenght = test.GetLength(1);

                for (int i = 0; i < rowlenght; i++)
                {
                    for (int j = 0; j <collenght; j++)
                    {
                        Console.Write(String.Format(" {0}",test[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                    
                }
                
            
             }
            

        }
        
    }
}
