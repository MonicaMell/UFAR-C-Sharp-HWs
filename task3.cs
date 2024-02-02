using System;

class Queen{
    public int[,] board;
    
    public Queen(){
        board = new int[8,8];
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
    
    public int[] FirstQueen(){
        Random rnd = new Random();
        
        int[] coordinates = new int[2];
        coordinates[0] = rnd.Next(8);
        coordinates[1] = rnd.Next(8);
        PossiblePositions(board, coordinates);
        return coordinates;    
    }
    
    int[] Place(){
        int[] coordinates = new int[2];
        
        for (int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                if (board[i, j] == 0){
                    coordinates[0] = i;
                    coordinates[1] = j;
                    return coordinates;
                }
            }
        }
        return null;
    }
    
    public void Next(){
        int[] coordinates = Place();
        if (coordinates != null){
            PossiblePositions(board, coordinates);
        } else {
            Console.WriteLine("NO PLACE REMAINED.");
        }
    }
    
    public void PossiblePositions(int[,] board, int[] coordinates){
        int x = coordinates[1];
        int y = coordinates[0];
        board[y, x] = 8;
        
        for (int i = 0; i < 8; i++){
            for (int j = 0; j < 8; j++){
                if (board[i, j] == 0){
                    
                    if (i == y || j == x){
                        board[i, j] = 1;
                    } else if ((x - j) == (y - i)){
                        board[i, j] = 1;
                    } else if ((i + j) == (x + y)){
                        board[i, j] = 1;
                    }
                }
            } 
        }
        PrintBoard(board);
        Console.WriteLine();
    }   
}

public class Program{
    public static void Main(string[] args){
        Queen ob = new Queen();        
        ob.FirstQueen();
        ob.Next();
        ob.Next();
        ob.Next();
        ob.Next();
        ob.Next();
    }   
}