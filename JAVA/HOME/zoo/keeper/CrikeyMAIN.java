package keeper;
import animal.Panda;
public class CrikeyMAIN {
    Panda pipo = new Panda("PIPO",18, "Palestine");
    Panda unKnown = new Panda(15, "Russa");
    public static void main(String[] args){
        boolean toGoToChina = false;
        CrikeyMAIN obj = new CrikeyMAIN();
        boolean isOlder ;
        isOlder = obj.pipo.happyBirthday(30);
        if(isOlder){
            toGoToChina = true;
        }
    }
}
