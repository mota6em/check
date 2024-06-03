package enumExample;
public class ExampleMain {
    public static void main(String[] args){
        Example ex = Example.EXAMPLE1;
        System.out.println("Value of ex: " + ex);
        System.out.println("Number of ex " + ex.ordinal());
    }
}
