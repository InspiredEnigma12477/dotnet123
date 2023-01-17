namespace BOL;

public class Book{

    public int Bookid{get;set;}

    public string Bname{get;set;}

    public string Author{get;set;}
   
   public string Category{get;set;}

   public double Price{get;set;}

    public Book(int bookid, string bname, string author, string category, double price)
    {
        Bookid = bookid;
        Bname = bname;
        Author = author;
        Category = category;
        Price = price;
    }
}