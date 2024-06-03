public class Demo {

    static void printTomb(int[] tomb){
        for(int elem : tomb){
            System.out.print(elem + " ");
        }
        System.out.println();
    }
    public static void main(String[] args){
        int[] tomb = new int[] {1,2,3};
        Foo foo = new Foo(tomb); 
        printTomb(foo.getData());
    }
}