package text.to.numbers;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.nio.Buffer;

public class SingleLineFile {
    public SingleLineFile(){}
    public static int addNumbers(String fileName) throws IOException{
        /**
         * FileReader fr = new FileReader(fileName);
         * BufferedReader br = new BufferedReader(fr);
        */
        int sum = 0;

            try(BufferedReader br = new BufferedReader(new FileReader(fileName));){
                String line = br.readLine();
            if(line == null){
                throw new IllegalArgumentException("Empy File");
            }
            String[] pieces = line.split(" ");
            for(String s : pieces)
            {
                try{
                    // int parsed = Integer.parseInt(pieces);
                    int parsed = Integer.parseInt(s);

                    sum += parsed;
                }
                catch(NumberFormatException nfe){
                    // System.out.err(s);
                    System.err.println("File does not exist");
                }
            }
    }catch (IOException ioe) {
        System.err.println("File does not exist");
    } return sum;
    }
}
