using System;

class Knights {
    public int[,] board;
    public int[,] background;
    
    public Knights() { 
        board = new int[8, 8];
        background = new int[,] {{2, 3, 4, 4, 4, 4, 3, 2},
                                {3, 4, 6, 6, 6, 6, 4, 3},
                                {4, 6, 8, 8, 8, 8, 6, 4},
                                {4, 6, 8, 8, 8, 8, 6, 4},
                                {4, 6, 8, 8, 8, 8, 6, 4},
                                {4, 6, 8, 8, 8, 8, 6, 4},
                                {3, 4, 6, 6, 6, 6, 4, 3},
                                {2, 3, 4, 4, 4, 4, 3, 2}};
        
        placeKnights();    
    }
    
    int[] firstRandom(){
        Random rnd = new Random();
        int i = rnd.Next(0, 8);
        int j = rnd.Next(0, 8);
        
        int[] coordinate = new int[] {i, j};
        return coordinate;
    }
    
    public void printBoard(){
        for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                Console.Write(board[i, j]);
                Console.Write(" "); 
            }
            Console.WriteLine();
        }
    }
    
    public void printBackground(){
        for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                Console.Write(background[i, j]);
                Console.Write(" "); 
            }
            Console.WriteLine();
        }
    }
    
    // I have done some research on how to append element to an array;
    int[,] resizeArray(int[,] oldArray, int size) {
        int[,] newArray = new int[size, 2];
        Array.Copy(oldArray, newArray, oldArray.Length);
        return newArray;
    }

    int[,] appendCoordinate(int[,] array, int i, int j) {
        int[,] newArray = resizeArray(array, array.GetLength(0) + 1);
        newArray[newArray.GetLength(0) - 1, 0] = i;
        newArray[newArray.GetLength(0) - 1, 1] = j;
        return newArray;
    }
    
    bool isInBoard(int a, int b){
        if ((a >= 0) && (a < 8)){
            if ((b >= 0) && (b < 8)){
                return true;
            }
            return false;
        }
        return false;   
    }
    
    int[,] possibleMoves(int[] coordinate){
        int[,] nextMoves = new int[0, 2];
        int i = coordinate[0];
        int j = coordinate[1];
        
        if (isInBoard(i+2, j+1) && (0 != background[i+2, j+1])){
            nextMoves = appendCoordinate(nextMoves, i+2, j+1);
        }
        if (isInBoard(i+2, j-1) && (0 != background[i+2, j-1])){
            nextMoves = appendCoordinate(nextMoves, i+2, j-1);
        }
        if (isInBoard(i-2, j+1) && (0 != background[i-2, j+1])){
            nextMoves = appendCoordinate(nextMoves, i-2, j+1);
        }
        if (isInBoard(i-2, j-1) && (0 != background[i-2, j-1])){
            nextMoves = appendCoordinate(nextMoves, i-2, j-1);
        }
        if (isInBoard(i+1, j+2) && (0 != background[i+1, j+2])){
            nextMoves = appendCoordinate(nextMoves, i+1, j+2);
        }
        if (isInBoard(i-1, j+2) && (0 != background[i-1, j+2])){
            nextMoves = appendCoordinate(nextMoves, i-1, j+2);
        }
        if (isInBoard(i+1, j-2) && (0 != background[i+1, j-2])){
            nextMoves = appendCoordinate(nextMoves, i+1, j-2);
        }
        if (isInBoard(i-1, j-2) && (0 != background[i-1, j-2])){
           nextMoves = appendCoordinate(nextMoves, i-1, j-2); 
        }
        
        return nextMoves;
    }
    
    void adjustedBackground(int[] coordinate, int[,] moves, int l){
        int i = coordinate[0];
        int j = coordinate[1];
        background[i, j] = 0;
        board[i, j] = 8;
        
        for (int k = 0; k < l; k++){
            int a = moves[k, 0];
            int b = moves[k, 1];
            background[a, b] = background[a, b] - 1;
        } 
    }
    
    int[] findMin(int[,] moves, int l){
        int[] min = new int[2];
        
        min[0] = moves[0, 0];
        min[1] = moves[0, 1];
        
        for (int k = 0; k < l; k++){
            int a = moves[k, 0];
            int b = moves[k, 1];
            if (background[min[0], min[1]] >= background[a, b]){
                min[0] = a;
                min[1] = b;
            }
        }
        return min;
    }
    
    void placeKnights(){
        int[] Knight = firstRandom();
        int[,] moves = possibleMoves(Knight);
        int l = moves.GetLength(0);
        Console.WriteLine(l);
        Console.WriteLine();
        
        while(0 != l){
            int[] next = findMin(moves, l);
            adjustedBackground(Knight, moves, l);
            printBoard();
            Console.WriteLine();
            printBackground();
            Console.WriteLine();
            
            
            Knight = next;
            moves = possibleMoves(Knight);
            l = moves.GetLength(0);
            Console.WriteLine(l);
            Console.WriteLine();  
        }
        
        printBoard();
        Console.WriteLine();
        printBackground();
    }
}

public class Program {
    public static void Main(string[] args){
        Knights ob = new Knights();
    }
}