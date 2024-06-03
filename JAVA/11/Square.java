public class Square implements Shape {
    private int sideLength;
    public void rotate(int degree)
    {

    }
    public int getSideLength(){
        return this.sideLength;
    }
    @Override
    public boolean equals(Object anotherObject) {
        // if (this == anotherObject) return true;
        // if (!(anotherObject instanceof Square)) return false;
        // Square anotherSquare = (Square) anotherObject;
        Square anotherSquare = (Square) anotherObject;
        return this.sideLength == anotherSquare.getSideLength();
    }
    
}
