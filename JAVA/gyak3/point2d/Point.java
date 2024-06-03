package point2d;

public class Point {

    double x;

    double y;

    public Point(double x, double y) {
        this.x = x;
        this.y = y;
    }

    public void move(double dx, double dy) {
        this.x += dx;
        this.y += dy;
    }

    public void mirror(double cx, double cy) {
        this.x = 2 * cx - this.x;
        this.y = 2 * cy - this.y;
    }

    public void mirror(Point p) {
        this.x = 2 * p.x - this.x;
        this.y = 2 * p.y - this.y;
    }

    public double distance(Point p) {
        double deltaX = p.x - this.x;
        double deltaY = p.y - this.y;
        double distanceSquared = deltaX * deltaX + deltaY * deltaY;
        return Math.sqrt(distanceSquared);
    }

}