using System;

class Matrix{
    public int[,] matrix;
    public int hight;
    public int width;
    
    
    public Matrix(int y, int x){
        hight = y;
        width = x;
        matrix = new int[hight, width];
        GenerateMatrix();
    }
    
    void GenerateMatrix(){
        Random rnd = new Random();
        
        for (int i = 0; i < hight; i++){
            for (int j = 0; j < width; j++){
                matrix[i, j] = rnd.Next(1, 5);                
            }
        }
    }
    
    public void PrintMatrix(){
        for (int i = 0; i < hight; i++){
            for (int j = 0; j < width; j++){
                Console.Write(matrix[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    
    public void MaxInRows(){
        int[] MaxVector = new int[hight];
        int[] CountVector = new int[hight];
        
        for (int i = 0; i < hight; i++){
            CountVector[i] = 1;
        }
        
        for (int i = 0; i < hight; i++){
            MaxVector[i] = matrix[i, 0];
        }
        
        for (int i = 0; i < hight; i++){
            for (int j = 1; j < width; j++){
                if (matrix[i, j] == MaxVector[i]){
                    CountVector[i] = 2;
                } else if (matrix[i, j] > MaxVector[i]){
                    MaxVector[i] = matrix[i, j];
                    CountVector[i] = 1;
                }
            }
        }
        
        for (int i = 0; i < hight; i++){
            if (CountVector[i] == 1){
                Console.Write(MaxVector[i]);
                Console.Write(" ");
            } else {
                Console.Write("<No such value>");
            }
        }
        Console.WriteLine();
    }
    
    public void MinInColumns(){
        int[] MinVector = new int[width];
        int[] CountVector = new int[width];
        
        for (int j = 0; j < width; j++){
            CountVector[j] = 1;
        }
        
        for (int j = 0; j < width; j++){
            MinVector[j] = matrix[0, j];
        }
        
        for (int i = 1; i < hight; i++){
            for (int j = 0; j < width; j++){
                if (matrix[i, j] == MinVector[j]){
                    CountVector[j] = 2;
                } else if (matrix[i, j] < MinVector[j]){
                    MinVector[j] = matrix[i, j];
                    CountVector[j] = 1;
                }
            }
        }
        
        for (int j = 0; j < width; j++){
            if (CountVector[j] == 1){
                Console.Write(MinVector[j]);
                Console.Write(" ");
            } else {
                Console.Write("<No such value>");
            }
        }
        Console.WriteLine();
    }
}


public class Program{
    public static void Main(string[] args){
        Matrix ob = new Matrix(4, 4);
        ob.PrintMatrix();
        ob.MaxInRows();
        ob.MinInColumns();
        
    }
}