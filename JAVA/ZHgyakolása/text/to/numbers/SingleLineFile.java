package text.to.numbers;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class SingleLineFile {
    public SingleLineFile(){}
    public static int addNumbers(String str) throws IOException{
        try(FileReader file = new FileReader(str); BufferedReader br = new BufferedReader(file)){
            String rd = br.readLine();
            if(rd == null) throw new IllegalArgumentException("Empty file");
            String[] breakDown = rd.split(" ");
            int[] array = new int[breakDown.length];
            int sum = 0;
            for(String s : breakDown){
                try{int i = Integer.parseInt(s);
                sum += i ;}
                catch(NumberFormatException e){
                    System.err.println(s);
                }
            }
            return sum;
        }
    }
    public static void main(String[] args){
    if (args.length < 1) {
            System.out.println("Usage: java SingleLineFile <file_path>");
            return;
        }
        
        String str = args[0];
    try {
            int sum = addNumbers(str);
            System.out.println("The sum of the numbers is: " + sum);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}