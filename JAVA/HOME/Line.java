public class Line {
    private double a;
    private double b;
    private double c;

    public Line(double a, double b, double c) {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public boolean contains(Point p) {
        double result = a * p.getX() + b * p.getY() + c;
        return result == 0;
    }

    public boolean isParallelWith(Line l) {
        return a * l.b == b * l.a;
    }

    public boolean isOrthogonalTo(Line l) {
        return a * l.a + b * l.b == 0;
    }
}
