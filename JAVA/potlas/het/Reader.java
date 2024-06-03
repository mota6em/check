import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;

public class Reader{
    public static void main(String[] args) {
        if(args.length == 1)
        {
            try(BufferedReader br = new BufferedReader(new FileReader(args[0]));){
                String Line;
                while (null!= (Line = br.readLine())) {
                System.out.println(Line);
                }
            }
            catch(IOException e){
                System.out.println("FileNotExists.");
            }
        }
        else if(args.length == 2){
            try(
                BufferedReader br = new BufferedReader(new FileReader(args[0]));
                PrintWriter pr = new PrintWriter(args[1]);
            )
            {
                String Line;
                while (null!= (Line = br.readLine())){
                    pr.println((Line));
                }
            }catch (FileNotFoundException e) {
                System.out.println("Not valid filename: " + args[0]);
            }
            catch(IOException e){
                System.out.println("Can't read from " + args[0]);
            }

        }
        else{
            System.err.println("No operation needed..");
        }
    }
}