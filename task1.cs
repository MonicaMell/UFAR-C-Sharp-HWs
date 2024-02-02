using System;

class Knight{
    public int[,] board;
    
    public Knight(){
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
    
    public int[] KnightPlace(){
        Random rnd = new Random();
        
        int[] coordinates = new int[2];
        coordinates[0] = rnd.Next(8);
        coordinates[1] = rnd.Next(8);
        return coordinates;     
    }
    
    int IsInBoard(int a, int b){
        if (a >= 0 && a < 8){
            if (b >= 0 && b < 8){
                return 1;
            }
            return 0;
        }
        return 0;   
    }
    
    public void PossiblePositions(int[,] board, int[] coordinates){
        int x = coordinates[0];
        int y = coordinates[1];
        
        // Let's mark Knight as 8 :)
        board[x, y] = 8;
        
        // Upper - Lower possible moves;
        if (Convert.ToBoolean(IsInBoard(x+1, y+2))){
            board[x+1, y+2] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x-1, y+2))){
            board[x-1, y+2] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x+1, y-2))){
            board[x+1, y-2] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x-1, y-2))){
            board[x-1, y-2] = 1;
        }
        
        // Right - Left possible moves;
        if (Convert.ToBoolean(IsInBoard(x+2, y+1))){
            board[x+2, y+1] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x+2, y-1))){
            board[x+2, y-1] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x-2, y+1))){
            board[x-2, y+1] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x-2, y-1))){
            board[x-2, y-1] = 1;
        }
        
        PrintBoard(board);
    }   
}

public class Program{
    public static void Main(string[] args){
        Knight ob = new Knight(); 
        
        int[] XY = ob.KnightPlace();
        Console.WriteLine("Coordiantes: {0}, {1}", XY[0], XY[1]);
        Console.WriteLine();
        
        ob.PossiblePositions(ob.board, XY);
    }   
}