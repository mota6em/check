public class Foo {
    private final int[] data;
    public Foo(int[] data){
        this.data = data.clone();
    }
    public int[] getData(){
        return data.clone();
    }
}
