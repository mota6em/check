package music.fan;

public class Fan {
    private final String name;
    private final music.recording.Artist favourite;
    

    private int moneySpent;
    public String getName(){
        return this.name;
    }
    public music.recording.Artist getFavourite(){
        return this.favourite;
    }
    public int getMoneySpent(){
        return this.moneySpent;
    }
    public Fan(String s, music.recording.Artist favouriteArtist){
        this.name = s;
        this.favourite  = favouriteArtist;
        this.moneySpent = 0;
    }
    public int buyMerchandise(int basePrice, Fan[] frieds){
        return 0;
    }
    public boolean favesAtSameLabel(Fan fan){
        return false; 
    }
    public String toString1(){
        return " ";
    }
    public String toString2(){
        return " ";
    }
    public String toString3(){
        return " ";
    }
    public String toString4(){
        return " ";
    }
}
