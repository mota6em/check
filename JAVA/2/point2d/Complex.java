package point2d;
public class Complex {
    public double real;
    public double imaginary;
    public double abs()
    {
        double res = Math.pow(real,2) + Math.pow(imaginary, 2);
        return Math.sqrt(res);
    }
    public void add(Complex c)
    {
        this.real += c.real;
        this.imaginary += c.imaginary;
    }
    public void sum(Complex c)
    {
        this.real -= c.real;
        this.imaginary -= c.imaginary;
    }
    public void mul(Complex c)
    {
        this.real *= c.real;
        this.imaginary *= c.imaginary;
    }
    public void print (){
        System.out.println("REAL PART: " + this.real + ", IMAGINARY PART: " + this.imaginary);
    }
}
