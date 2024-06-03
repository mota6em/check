package util;

public class ArrayUtil{
    public static int max2(int[] numbers){
        int max = Integer.MIN_VALUE;
        for(int i = 0;  i < numbers.length ; ++i){
            max = numbers[i] > max ? numbers[i] : max;
        }
        return max;
    }
    public static int max2(int[] numbers){
        int max = Integer.MIN_VALUE;
        for(int i = 0;  i < numbers.length ; ++i){
            max = numbers[i] > max ? numbers[i] : max;
        }
        return max;
    }
    public static void main(String[] args) {
        
    }
}