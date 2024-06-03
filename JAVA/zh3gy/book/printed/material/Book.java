package printed.material;
public class Book{
    public static final String defaultAuthor = "John Steinbeck";
    public static final String defaultTitle = "Of Mice and Men";
    public static final int defaultPageCount = 107;
    private String author;
    public String getAuthor(){
        return author;
    }
    private String title;
    public String getTitle(){
        return title;
    }
    protected int pageCount;
    public int getPageCount(){
        return pageCount;
    }
    public Book()
    {
        initBook(defaultAuthor,defaultTitle,defaultPageCount);
    }
    protected void initBook(String author, String title, int pageCount){
        // defaultAuthor = author;
        // defaultTitle = title;
        // defaultPageCount = pageCount; 
    }
    public Book(String author , String title, int n)throws InvalidBookException{
        checkInitData(author,title,n);
        initBook(author,title, n);
    }
    private void checkInitData(String author, String title, int n) throws InvalidBookException{
        if(author.length() < 2 || title.length() < 4 || pageCount < 1){
            throw new InvalidBookException(author,title);
        }
    }
    public static Book decode(String str){
        return new Book();
        //toDo
    }
    protected String getAuthorWithInitials(){
        return "";
        //toDo
    }
    public int getPrice(){
        return getPageCount();
    }
    public String getShortInfo(){
        String rslt = "Author: " + getAuthor() +", title: " + getTitle()+", number of pages: "+ getPageCount();
        return rslt;
    }
    public String createReference(String str, int n1, int n2){
        String rslt = "helio";
        return rslt; //toDo
    }
}