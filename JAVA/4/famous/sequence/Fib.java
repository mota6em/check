package famous.sequence;
public class Fib{
    public static int fib(int n){
        if(n<=1){
            return n;
        }
        else{return (n-1) + fib(n-2);
        }
    }
    // public static void main(String[] args){
    //     System.out.println(fib(args[0]));
    // }
    public static void main(String[] args) {
        int n = Integer.parseInt(args[0]);
        System.out.println(fib(n));
    }
    
}