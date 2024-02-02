using System;

class Queen{
    public int[,] board;
    
    public Queen(){
        board = new int[8,8];
        PrintBoard(board);
        Console.WriteLine();
    }
    
    public void PrintBoard(int[,] board){
        for(int y = 0; y < 8; y++){
            for(int x = 0; x < 8; x++){
                Console.Write(board[x,y]);
                Console.Write(" "); 
            }
            Console.WriteLine();
        }
    }
    
    public int[] QueenPlace(){
        Random rnd = new Random();
        
        int[] coordinates = new int[2];
        coordinates[0] = rnd.Next(8);
        coordinates[1] = rnd.Next(8);
        return coordinates;     
    }
    
    public void PossiblePositions(int[,] board, int[] coordinates){
        int x = coordinates[0];
        int y = coordinates[1];
        
        for (int i = 0; i < 8; i++){
            for (int j = 0; j < 8; j++){
                if (j == x && i == y){
                    board[i, j] = 8; // Lets mark the Queen with 8 ;
                } else if (i == y || j == x){
                    board[i, j] = 1;
                } else if ((x - j) == (y - i)){
                    board[i, j] = 1;
                } else if ((i + j) == (x + y)){
                    board[i, j] = 1;
                }   
            } 
        }
        PrintBoard(board);
    }   
}

public class Program{
    public static void Main(string[] args){
        Queen ob = new Queen(); 
        
        int[] XY = ob.QueenPlace();
        Console.WriteLine("Coordiantes: {0}, {1}", XY[0], XY[1]);
        Console.WriteLine();
        
        ob.PossiblePositions(ob.board, XY);
    }   
}