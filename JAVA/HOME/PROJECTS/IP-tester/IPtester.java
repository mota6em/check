import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class IPtester {
    public static void main(String[] args) {
        List<String> IPs = new ArrayList<>();
        List<Boolean> output = new ArrayList<>();
        Scanner scanner = new Scanner(System.in);
        // Read input lines until an empty line is entered
        while (true) {
            String line = scanner.nextLine();
            if (line.isEmpty()) {
                break;
            }
            IPs.add(line);
        }
        
        for(String ip : IPs){
            int num_of_ponts= 0;
            String A,B,C,D;
            for(int i = 0 ; i < ip.length(); i++)
            {
                if(ip.charAt(i) == '.')
                {
                    num_of_ponts+=1;
                }
            }
            if(num_of_ponts != 3)
            {
                output.add(false);
            }
            else{
                String[] parts = ip.split("\\.");
                A = parts[0];
                B = parts[1];
                C = parts[2];
                D = parts[3];
                MyRegex tester = new MyRegex(A,B,C,D); 
                output.add(tester.isIP());                                                                                                                               
            }
        }
        scanner.close();
        for(boolean i : output){
            System.out.println(i);
        }
    }
}
