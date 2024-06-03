public class TSTRl {
    public static void main(String[] args) {
        Point p = new Point(1.2,5.2);
        Line l1 = new Line(0,0,2.4);
        Line l2 = new Line(0,0,3.6);
        if(l1.isOrthogonalTo(l2)){
            System.out.println("HEllo World~");
        }
        else{
            System.out.println("NoWay");
        }
    }
}
