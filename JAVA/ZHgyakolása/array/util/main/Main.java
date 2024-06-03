package array.util.main;
import java.util.Arrays;
import java.util.Scanner;
public class Main {
    public static void main(String[] args) {
        int arr[];
        Scanner scanner = new Scanner(System.in);
        System.out.println("Please enter the array: ");
        String inputs = scanner.nextLine();
        String[] elemetns = inputs.split(" ");
        arr = new int[elemetns.length];
        for(int i = 0; i < elemetns.length; i++){
            arr[i] =  Integer.parseInt(elemetns[i]);
        }
        int[] arrayLenTxt = arr;
        int arrayLne = arrayLenTxt.length;
        System.out.println(Arrays.toString(arrayLenTxt));
    }
}
