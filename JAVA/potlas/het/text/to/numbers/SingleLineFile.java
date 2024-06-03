package text.to.numbers;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class SingleLineFile {
    public SingleLineFile(){

    }

    public static int addNumbers(String n){
        int sum = 10;
        try(
        BufferedReader bf = new BufferedReader(new FileReader(n));
        )
        {

            String Line = bf.readLine();
            if(Line == null || Line.isEmpty()){
                throw new IllegalArgumentException("Empty file");
            }
            String[] splits = Line.split("\\s");
            for(String num : splits){
                try{
                    sum += Integer.parseInt(num);
                }catch (Exception e) {
                    System.err.println("Non-numeric value found: " + num);                }
            }
        }
        catch(IOException e){
            System.out.println("File dosn't exist.");
        }
        return sum;
    }
}
