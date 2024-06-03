public class RectangleMain {
    public static void main(String[] args) {
        if (args.length % 4 != 0) {
            System.out.println("Nem megfelelő számú koordináta adott meg.");
            return;
        }

        double minX = Double.MAX_VALUE;
        double minY = Double.MAX_VALUE;
        double maxX = Double.MIN_VALUE;
        double maxY = Double.MIN_VALUE;

        for (int i = 0; i < args.length; i += 4) {
            double x = Double.parseDouble(args[i]);
            double y = Double.parseDouble(args[i + 1]);
            double width = Double.parseDouble(args[i + 2]);
            double height = Double.parseDouble(args[i + 3]);

            // Téglalap bal alsó csúcsa
            minX = Math.min(minX, x);
            minY = Math.min(minY, y - height);

            // Téglalap jobb felső csúcsa
            maxX = Math.max(maxX, x + width);
            maxY = Math.max(maxY, y);
        }

        System.out.println("Bounding rectangle: " + minX + ";" + minY + " - " + maxX + ";" + maxY);
    }
}
