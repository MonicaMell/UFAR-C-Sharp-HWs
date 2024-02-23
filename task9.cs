using System;

class Equation{
    public double A;
    public double B;
    public double C;
    public double root1;
    public double root2;
    
    public Equation(double a, double b, double c){
        A = a;
        B = b;
        C = c;
    }
    
    public void withRef(ref double root1, ref double root2){
        double D = Math.Pow(B,2) - 4 *A *C;
        
        if (0 < D){
            root1 = (-B + Math.Pow(D, 0.5))/(2 * A);
            root2 = (-B - Math.Pow(D, 0.5))/(2 * A);
        } else if (0 == D){
            root1 = -B / (2 * A);
            root2 = root1;
        } else{
            Console.WriteLine("Impossible to find any non-complex/real root.");
        }
    }
    
    public (double, double) withTuple(){
        double D = Math.Pow(B,2) - 4 *A *C;
        
        if (0 < D){
            root1 = (-B + Math.Pow(D, 0.5))/(2 * A);
            root2 = (-B - Math.Pow(D, 0.5))/(2 * A);
        } else if (0 == D){
            root1 = -B / (2 * A);
            root2 = root1;
        } else{
            Console.WriteLine("Impossible to find any non-complex/real root.");
        }
        return (root1, root2);
    }
    
    public double[] withArray(){
        double D = Math.Pow(B,2) - 4 *A *C;
        
        if (0 < D){
            root1 = (-B + Math.Pow(D, 0.5))/(2 * A);
            root2 = (-B - Math.Pow(D, 0.5))/(2 * A);
        } else if (0 == D){
            root1 = -B / (2 * A);
            root2 = root1;
        } else{
            Console.WriteLine("Impossible to find any non-complex/real root.");
        }
        double[] arr = new double[] {root1, root2};
        return arr;
    }
    
    public void Deconstruct(out double a, out double b){
        double D = Math.Pow(B,2) - 4 *A *C;
        
        if (0 < D){
            root1 = (-B + Math.Pow(D, 0.5))/(2 * A);
            root2 = (-B - Math.Pow(D, 0.5))/(2 * A);
        } else if (0 == D){
            root1 = -B / (2 * A);
            root2 = root1;
        } else{
            Console.WriteLine("Impossible to find any non-complex/real root.");
        }
            
        a = root1;
        b = root2;
    }    
}

public class Program{
        public static void Main(string[] args){
            Equation ob = new Equation(1, -3, 2);
            
            ob.withRef(ref ob.root1, ref ob.root2);
            Console.WriteLine(ob.root1);
            Console.WriteLine(ob.root2);
            
            (double, double) t = ob.withTuple();
            Console.WriteLine(t.Item1);
            Console.WriteLine(t.Item2);
            
            double[] arr = ob.withArray();
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);
            
            (double a, double b) = ob;
            Console.WriteLine(a);
            Console.WriteLine(b);
    }
}
