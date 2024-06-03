import java.util.Scanner;
import java.util.Stack;

public class temp{
    public void print(int[] A){
        int len = A.length;
        System.out.print("A: <");
        for(int i = 0; i < len; i++){
            if(i < len-1){
                System.out.print(A[i] + ", ");
            }
            else{
                System.out.print(A[i] );
            }
        }
        System.out.println(">");
    }
    public boolean xrx(String zaroJELEK)
    {
        char [] zx  = zaroJELEK.toCharArray();
        Stack<Integer> x = new Stack<>();
        int i = 0;
        int j = 0;
        while (j < zaroJELEK.length()) {
            i +=1;
            if(zx[j] == '(')
                v.push(i);
            else 
                if(v.isEmpty())
                {
                    return false;
                }
                else
                    System.out.println(v.pop() + ',' + i);
            j++;
        }
        return v.isEmpty();
    }
    public static void main(String[] args){
        /*int n ;
        Scanner scanner = new Scanner(System.in);
        n = scanner.nextInt();
        int [] A = new int[n];
        for(int i = 0; i < n ; i++){
            System.out.println("Enter the" + (i+1) + " number: ");
            A[i] = scanner.nextInt();
        }
        temp obj = new temp();
        obj.print(A);
        for(int i=1; i<n;i++){
            if(A[i-1] > A[i]){
                int x = A[i];
                A[i] = A[i-1];
                int j = i -2;
                while (j >= 0 && A[j] > x) {
                    A[j+1] = A[j];
                    j = j-1;
                }
                A[j+1] = x;
            }

        }
        System.out.println("");
        obj.print(A);*/
        String zaroJELEK = "(()(()(()))))";
        
        char[] zx = zaroJELEK.toCharArray();
        temp obj = new temp();
        if(obj.xrx(zaroJELEK)){
            System.out.println("ok");
        }
        else{
            
        }
    }
}

