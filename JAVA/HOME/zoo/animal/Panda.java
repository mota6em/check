package animal;
public class Panda{
    public String name;
    public int életkor ;
    public String tartOrsz ;
    public Panda(String n, int d, String s){
        this.name = n;
        this.életkor = d;
        this.tartOrsz = s;
    }

    public Panda(int d, String s){
        this.életkor = d;
        this.tartOrsz = s;
        this.name = d + " years old founding from " + s;
    }
    public boolean happyBirthday(int limitYear){
        System.out.println("Happy birthday for " + name + ", from " + tartOrsz + ", today will be " + (életkor+ 1) + " :)");
        if((életkor+1) > limitYear)
            return true;
        else 
            return false; 
    }
}