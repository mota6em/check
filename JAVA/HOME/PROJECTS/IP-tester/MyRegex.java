public class MyRegex {
    String A,B,C,D;
    public MyRegex(String a,String b, String c , String d){
        this.A = a;
        this.B = b;
        this.C = c;
        this.D = d;
    }
    public boolean isIP() {
        try {
            if (A.length() > 4 || B.length() > 4 || C.length() > 4 || D.length() > 4) {
                throw new ArithmeticException();
            }
            int a = Integer.parseInt(A);
            int b = Integer.parseInt(B);
            int c = Integer.parseInt(C);
            int d = Integer.parseInt(D);
            if (a > 255 || b > 255 || c > 255 || d > 255 || a < 0 || b < 0 || c < 0 || d < 0) {
                throw new ArithmeticException();
            }
            return true;
        } catch (NumberFormatException | ArithmeticException e) {
            return false;
        }
    }
    

}
