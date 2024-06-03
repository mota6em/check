package array.util;

public class ArrayUtil {
    public ArrayUtil(){}
    public static int max(int[] arr){
        int max = Integer.MIN_VALUE;
        if(arr.length == 0){
            return 0;
        }
        else{
            for(int i = 0; i < arr.length; i++)
            {
                if(arr[i] > max){
                    max = arr[i];
                }
            }
            return max;
        }
    }
    
    public static int max2(int[] arr){
        int max = Integer.MIN_VALUE;
        if(arr.length == 0){
            return 0;
        }
        else{
            for(int i = 0; i < arr.length; i++)
            {
                max = arr[i] > max? arr[i] : max;
            }
            return max;
        }
    }
    
    public static int max3(int[] arr){
        int max = Integer.MIN_VALUE;
        if(arr.length == 0){
            return 0;
        }
        else{
            for(int i = 0; i < arr.length; i++)
            {
                max = Math.max(arr[i], max);
            }
            return max;
        }
    }

    public static int max4(int[] arr){
        int max = Integer.MIN_VALUE;
        if(arr.length == 0){
            return 0;
        }
        for(int e : arr){
            if(e > max){
                max = e;
            }
        }
        return max;
    }

    public static int[] minMax(int[] arr)
    {
        int max = max4(arr);

        int[] outPut = new int[2];
        outPut[0] = arr[0] == max ? arr[1] : arr[0];
        outPut[1] = max;
        return outPut;
    }
}