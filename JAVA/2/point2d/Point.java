package point2d;
public class Point {
    public double x;
    public double y;
    public void move (int dx, int dy){
        this.x += dx;
        this.y += dy;
    }
    public void mirror(double cx, int cy){
        this.x = cx;
        this.y = cy;
    }
    public double distance(double px, double py){
        double dx = px - this.x;
        double dy = py - this.y;
        double sumSQRt = Math.pow(dx, 2) + Math.pow(dy, 2);
        double result = Math.sqrt(sumSQRt);
        return result;
    }
    
    public static void main(String[] args) {
        // Print "Hello, world!" to the console
        System.out.println("Hello, world!");
        
    }

}
