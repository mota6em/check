package famous.sequence;

public class Fibonacci{
    public static int fib(int n) {
        if (n <= 1) {
            return n;
        } else {
            return fib(n - 1) + fib(n - 2);
        }
    }
    public static int test(int s){
        return 23;
    }
    /*public static void main(String[] args){
        System.out.println(fib(Integer.parseInt((args[0]))));
    }*/
}