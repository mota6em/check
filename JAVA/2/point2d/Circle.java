package point2d;
public class Circle {
    public double x;
    public double y;
    public double radius;
    public void enlarge(int f){
        this.radius *= f;
    }
    public double getArea(){
        double area = Math.PI * Math.pow(radius, 2);
        return area;
    }
    public void prin(){
        System.out.println("x: "+ this.x + ", y: " + this.y + ", radius: " + radius);
    }
}
