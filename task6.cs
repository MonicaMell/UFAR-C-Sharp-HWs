using System;

class Matrix{
    public int[,] matrix;
    public int hight;
    public int width;
    Random rnd = new Random();
    
    public Matrix(int y, int x){
        hight = y;
        width = x;
        matrix = new int[hight, width];
        NonRepeatingMatrix();
        PrintMatrix();
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
    
    int GenerateNumber(){
        return rnd.Next(1, hight*width + 10);
    }
    
    bool IsInMatrix(int number, int CurrentY, int CurrentX){
        for (int i = 0; i < CurrentY; i++){ 
            for (int j = 0; j < width; j++){
                if (matrix[i, j] == number){
                    return true;
                }
            }
        }
        
        for (int j = 0; j < CurrentX; j++){
            if (matrix[CurrentY, j] == number){
                    return true;
            }
        }
        
        return false;
    }
    
    void NonRepeatingMatrix(){
        for(int i = 0; i < hight; i++){
            for(int j = 0; j < width; j++){
                int number = GenerateNumber();
                
                while (IsInMatrix(number, i, j)){
                    number = GenerateNumber();
                }
                
                matrix[i, j] = number; 
            }
        }
    }
}


public class Program{
    public static void Main(string[] args){
        Matrix ob = new Matrix(2, 2);
        
    }
}