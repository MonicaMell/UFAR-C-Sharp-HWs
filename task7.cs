using System;

class Queens {
    public int[,] board;
    public int[,] background;
    
    public Queens() {
        board = new int[8, 8];
        background = new int[,] {{22, 22, 22, 22, 22, 22, 22, 22}, {22, 24, 24, 24, 24, 24, 24, 22}, {22, 24, 26, 26, 26, 26, 24, 22}, {22, 24, 26, 28, 28, 26, 24, 22}, {22, 24, 26, 28, 28, 26, 24, 22}, {22, 24, 26, 26, 26, 26, 24, 22}, {22, 24, 24, 24, 24, 24, 24, 22}, {22, 22, 22, 22, 22, 22, 22, 22}};
        
        placeQueens();
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
    
    int[,] coordinates22(){
        int [,] coordinates = new int[0,2];
        
        int j = 0;
        int i;
        for (i = 1; i < 8; i++) {
            if (background[i, j] == 22){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        } 
        
        i = 7;
        for (j = 0; j < 8; j++){
            if (background[i, j] == 22){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        }
        
        j = 7;
        for (i = 0; i < 7; i++){
            if (background[i, j] == 22){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        }
        
        i = 0;
        for (j = 0; j < 7; j++){
            if (background[i, j] == 22){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        }
        
        return coordinates;
    }
    
    int[,] coordinates24(){
        int [,] coordinates = new int[0,2];
        
        int j = 1;
        int i;
        for (i = 2; i < 7; i++) {
            if (background[i, j] == 24){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        } 
        
        i = 6;
        for (j = 2; j < 7; j++){
            if (background[i, j] == 24){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        }
        
        j = 6;
        for (i = 1; i < 6; i++){
            if (background[i, j] == 24){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        }
        
        i = 1;
        for (j = 1; j < 6; j++){
            if (background[i, j] == 24){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        }
        
        return coordinates;
    }
    
    int[,] coordinates26(){
        int [,] coordinates = new int[0,2];
        
        int j = 2;
        int i;
        for (i = 3; i < 6; i++) {
            if (background[i, j] == 26){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        } 
        
        i = 5;
        for (j = 3; j < 6; j++){
            if (background[i, j] == 26){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        }
        
        j = 5;
        for (i = 2; i < 5; i++){
            if (background[i, j] == 26){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        }
        
        i = 2;
        for (j = 2; j < 5; j++){
            if (background[i, j] == 26){
                    coordinates = appendCoordinate(coordinates, i, j);
            }
        }
        
        return coordinates;
    }
    
    int[,] coordinates28(){
        int [,] coordinates = new int[0,2];
       
        if (background[3, 3] == 28){
            coordinates = appendCoordinate(coordinates, 3, 3);
        }
        
        if (background[4, 4] == 28){
            coordinates = appendCoordinate(coordinates, 4, 4);
        }
        
        if (background[4, 3] == 28){
            coordinates = appendCoordinate(coordinates, 4, 3);
        }
        
        if (background[3, 4] == 28){
            coordinates = appendCoordinate(coordinates, 3, 4);
        }
        
        return coordinates;
    }
    
    int[] getRow(int[,] arr, int index){
        int l = arr.GetLength(1);
        int[] row = new int[l];
        
        for (int j = 0; j < l; j++) {
            row[j] = arr[index, j];
        }
        return row;
    }
    
    int[] randomHeuristic(){
        Random rnd = new Random();
        
        int[,] coordinates = coordinates22();
        int l = coordinates.GetLength(0);
        
        if (0 != l){
            int index = rnd.Next(0, l);
            int[] xy = getRow(coordinates, index);
            return xy;
            
        } else {
            coordinates = coordinates24();
            l = coordinates.GetLength(0);
            
            if (0 != l){
                int index = rnd.Next(0, l);
                int[] xy = getRow(coordinates, index);
                return xy;
                
            } else {
                coordinates = coordinates26();
                l = coordinates.GetLength(0);
                
                if (0 != l){
                    int index = rnd.Next(0, l);
                    int[] xy = getRow(coordinates, index);
                    return xy;
                    
                } else {
                    coordinates = coordinates28();
                    l = coordinates.GetLength(0);
                    
                    if (0 != l){
                        int index = rnd.Next(0, l);
                        int[] xy = getRow(coordinates, index);
                        return xy;
                    } else {
                        int[] arr = {-1, -1};
                        return arr;
                    } 
                }
            }
        }  
    }
    
    void drawPossibleMoves(int[] coordinate){
        int y = coordinate[0];
        int x = coordinate[1];
        board[y, x] = 8;
        background[y, x] = -1;
        
        for (int i = 0; i < 8; i++){
            for (int j = 0; j < 8; j++){
                if (board[i, j] == 0){
                    
                    if (i == y || j == x){
                        board[i, j] = 1;
                        background[i, j] = -1;
                    } else if ((x - j) == (y - i)){
                        board[i, j] = 1;
                        background[i, j] = -1;
                    } else if ((i + j) == (x + y)){
                        board[i, j] = 1;
                        background[i, j] = -1;
                    }
                }
            } 
        }
        
        printBoard();
        Console.WriteLine(); 
        printBackground();
        Console.WriteLine();
    }
    
    void placeQueens(){
        int[] queen = randomHeuristic();
        
        while (-1 != queen[0]){
            drawPossibleMoves(queen);
            
            queen = randomHeuristic();
        }
    }         
    
}


public class Program {
    public static void Main(string[] args){
        Queens ob = new Queens();
    }
}