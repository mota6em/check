public class Rectangle {
    private double x;
    private double y;
    private double width;
    private double height;

    public Rectangle(double x, double y, double width, double height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }

    public double getWidth() {
        return width;
    }

    public double getHeight() {
        return height;
    }

    public Point topLeft() {
        return new Point(x, y);
    }

    public Point topRight() {
        return new Point(x + width, y);
    }

    public Point bottomLeft() {
        return new Point(x, y - height);
    }

    public Point bottomRight() {
        return new Point(x + width, y - height);
    }

    public static void main(String[] args) {
        if (args.length % 4 != 0) {
            System.out.println("Nem megfelelő számú koordináta adott meg.");
            return;
        }

        for (int i = 0; i < args.length; i += 4) {
            double x = Double.parseDouble(args[i]);
            double y = Double.parseDouble(args[i + 1]);
            double width = Double.parseDouble(args[i + 2]);
            double height = Double.parseDouble(args[i + 3]);

            Rectangle rect = new Rectangle(x, y, width, height);
            Point topLeft = rect.topLeft();
            Point bottomRight = rect.bottomRight();

            System.out.println("Téglalap bal alsó csúcsa: (" + topLeft.getX() + ", " + bottomRight.getY() + ")");
            System.out.println("Téglalap jobb felső csúcsa: (" + bottomRight.getX() + ", " + topLeft.getY() + ")");
        }
    }
}
