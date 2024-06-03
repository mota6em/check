package point2d;
public class PointMain {
    public static void main(String[] args){
        Point p = new Point();
        p.x = 0;
        p.y = 0;
        System.out.println("Coordinate x: " + p.x + "\nCoordinate y: " + p.y);
        p.move(1,1);
        System.out.println("Coordinate x: " + p.x + "\nCoordinate y: " + p.y);
        p.mirror(2, 5);
        System.out.println("Coordinate x: " + p.x + "\nCoordinate y: " + p.y);
        System.out.println("THE DISTANCE IS :" + p.distance(5, 4));
        Complex z = new Complex();
        z.imaginary = 4;
        z.real = 3;
        z.print();
        Complex r = new Complex();
        r.real = 33.33;
        r.imaginary = 33.33;
        z.add(r);
        z.print();
        z.sum(r);
        z.print();
        z.mul(r);
        z.print();
        Circle c = new Circle();
        c.x = 3.4;
        c.y = 5.4;
        c.radius = 2.5;
        c.prin();
        c.enlarge(2);
        c.prin();
        System.out.println("AREA: " + c.getArea());
    }
}
