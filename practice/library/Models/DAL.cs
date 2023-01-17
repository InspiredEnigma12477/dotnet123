using BOL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace DAL;


public class DataAccessLayer{

    public List<Book> getAllBooks(){
     List<Book> books=new List<Book>();
      MySqlConnection conn=new MySqlConnection();
      conn.ConnectionString=@"server=localhost;port=3306;user=root;password=root@123;database=library";
        string str="select * from book";
        try{
            conn.Open();
      MySqlCommand cmd=new MySqlCommand(str,conn);

      MySqlDataReader reader=cmd.ExecuteReader();
      while(reader.Read()){
        int bid=Int32.Parse(reader["bookid"].ToString());
        string bname=reader["bname"].ToString();
        string author=reader["author"].ToString();
        string cat=reader["category"].ToString();
        double price=Convert.ToDouble(reader["price"].ToString());
       Book b=new Book(bid,bname,author,cat,price);
      books.Add(b);
      }
     }catch(Exception e){
      Console.WriteLine(e);
     }
     finally{
        conn.Close();
     }
       return books;
    }

    public void delete(int id){
        MySqlConnection conn=new MySqlConnection();
      conn.ConnectionString=@"server=localhost;port=3306;user=root;password=root@123;database=library";
        string str="delete from book where bookid="+id;
        try{
            conn.Open();
      MySqlCommand cmd=new MySqlCommand(str,conn);

      MySqlDataReader reader=cmd.ExecuteReader();
    //   while(reader.Read()){
    //     int bid=Int32.Parse(reader["bookid"].ToString());
    //     string bname=reader["bname"].ToString();
    //     string author=reader["author"].ToString();
    //     string cat=reader["category"].ToString();
    //     double price=Convert.ToDouble(reader["price"].ToString());
    //    Book b=new Book(bid,bname,author,cat,price);
    //   books.Add(b);
    //   }
     }catch(Exception e){
      Console.WriteLine(e);
     }
     finally{
        conn.Close();
     }

    }

    public List<user> getAllUser(){
       
     List<user> users=new List<user>();
      MySqlConnection conn=new MySqlConnection();
      conn.ConnectionString=@"server=localhost;port=3306;user=root;password=root@123;database=library";
        string str="select * from user";
        try{
            conn.Open();
      MySqlCommand cmd=new MySqlCommand(str,conn);

      MySqlDataReader reader=cmd.ExecuteReader();
      while(reader.Read()){
        int uid=Int32.Parse(reader["userid"].ToString());
        string uname=reader["username"].ToString();
        string emial=reader["email"].ToString();
        string mbno=reader["mobileno"].ToString();
        string pass=reader["password"].ToString();
        string role=reader["role"].ToString();
        // double price=Convert.ToDouble(reader["price"].ToString());
      user u=new user(uid,uname,emial,mbno,pass,role);
      users.Add(u);
      }
     }catch(Exception e){
      Console.WriteLine(e);
     }
     finally{
        conn.Close();
     }
    //   Console.WriteLine(users);
       return users;
    }

    public  bool AddBook(int bookid,string bname,string author,string category,double price){
           bool status=false;
        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString=@"server=localhost;port=3306;user=root;password=root@123;database=library";
        string str="insert into book(bookid,bname,author,category,price) values("+bookid+",'"+bname+"','"+author+"','"+category+"',"+price+")";
        try{
          Console.WriteLine("in add book");
            conn.Open();
            MySqlCommand cmd=new MySqlCommand(str,conn);
            cmd.ExecuteNonQuery();
            status = true;
        } 
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            conn.Close();
        }               
        return status;
    }

    public bool deleteb(int bookid){
      bool status=false;
      MySqlConnection conn=new MySqlConnection();
      conn.ConnectionString=@"server=localhost;port=3306;user=root;password=root@123;database=library";
      try{
        conn.Open();
        string str="delete from book where bookid="+bookid;
        MySqlCommand cmd=new MySqlCommand(str,conn);
        cmd.ExecuteNonQuery();
        status=true;
      }
      catch(Exception e){

      }
      finally{
        conn.Close();
      }
      return status;
    }
}