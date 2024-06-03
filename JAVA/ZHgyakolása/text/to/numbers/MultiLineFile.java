import java.io.FileReader;
import java.io.BufferedReader;
public class MultiLineFile{
    public MultiLineFile(){}
    public static int addNumbers(String str, Char chr)throws IOException{
        try(FileReader file = new FileReader(str); BufferedReader br = new BufferedReader(file)){
            String line;
            int sum = 0;
            while((line = br.readLine()) != null){
                String[] numbers = line.split(String.valueOf(chr));
                for(String s : numbers){
                    try{
                        sum+=Integer.parseInt(s);
                    }
                    catch(NumberFormatException e){
                        System.err.println("Invalid number format: " + s);
                    }
                }
            }
            return sum;
        }
}