package printed.material;
public class InvalidBookException extends Exception{
    private String author;
    private String title;

    public InvalidBookException(String author,String title){
        this.author = author;
        this.title = title;
    }

    public String getAuthor(){
        return this.author;
    }
    public String getTitle(){
        return this.title;
    }
}