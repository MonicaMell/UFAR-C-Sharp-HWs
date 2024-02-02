using System;

class Knight{
    public int[,] board;
    public int[] coordinates;
    
    public Knight(int i, int j){
        board = new int[8,8];
        board[i, j] = 1; // Let 1 be the knight in the mentiond position; 
        
        coordinates = new int[2];
        coordinates[0] = i;
        coordinates[1] = j;
        
        PrintBoard();
     }

    public void PrintBoard(){
        for(int y = 0; y < 8; y++){
            for(int x = 0; x < 8; x++){
                Console.Write(board[y,x]);
                Console.Write(" "); 
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    public void NextPlace(){
        int[,] moves = PossiblePositions();    
        
        Random rnd = new Random();
        int move = rnd.Next(1,9);
        
        while (moves[move-1, 2] != 1){
            move = rnd.Next(1,9);
        }
        
        board[coordinates[0], coordinates[1]] = 0;
        coordinates[0] = moves[move-1,0];
        coordinates[1] = moves[move-1,1];
        board[coordinates[0], coordinates[1]] = 1;
        
        PrintBoard();
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
    
    int[,] PossiblePositions(){
        int[,] moves = new int[8,3];
        int x = coordinates[1];
        int y = coordinates[0];
        
        // Upper - Lower possible moves;
        if (Convert.ToBoolean(IsInBoard(x+1, y+2))){
            moves[0,0] = x+1;
            moves[0,1] = y+2;
            moves[0,2] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x-1, y+2))){
            moves[0,0] = x-1;
            moves[0,1] = y+2;
            moves[0,2] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x+1, y-2))){
            moves[0,0] = x+1;
            moves[0,1] = y-2;
            moves[0,2] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x-1, y-2))){
            moves[0,0] = x-1;
            moves[0,1] = y-2;
            moves[0,2] = 1;
        }
        
        // Right - Left possible moves;
        if (Convert.ToBoolean(IsInBoard(x+2, y+1))){
            moves[0,0] = x+2;
            moves[0,1] = y+1;
            moves[0,2] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x+2, y-1))){
            moves[0,0] = x+2;
            moves[0,1] = y-1;
            moves[0,2] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x-2, y+1))){
            moves[0,0] = x-2;
            moves[0,1] = y+1;
            moves[0,2] = 1;
        }
        if (Convert.ToBoolean(IsInBoard(x-2, y-1))){
            moves[0,0] = x-2;
            moves[0,1] = y-1;
            moves[0,2] = 1;
        }
        return moves; 
    }   
}


public class Program{
    public static void Main(string[] args){
        Console.WriteLine("Enter the i, j coordinates:");
        int i = Convert.ToInt32(Console.ReadLine());
        int j = Convert.ToInt32(Console.ReadLine());
 
        Knight ob = new Knight(i, j);
        ob.NextPlace();
        ob.NextPlace();
        ob.NextPlace();
        ob.NextPlace();   
    }   
}