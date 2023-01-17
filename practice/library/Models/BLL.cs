namespace BLL;

using BOL;
using DAL;

public static class BuisnessLogic{

    public static List<Book> getallbook(){
       DataAccessLayer da=new DataAccessLayer();
       return da.getAllBooks();
    }

    public static void deletebook(int id){
        DataAccessLayer da=new DataAccessLayer();
        da.delete(id);
    }

    public static List<user> alluser(){
        DataAccessLayer da=new DataAccessLayer();
        return da.getAllUser();
    }

    public static string validateuser(string email,string password){
        Console.WriteLine("in validate");
        DataAccessLayer da=new DataAccessLayer();
        List<user> allusr=da.getAllUser();
        foreach(user us in allusr ){
            if(us.Email==email && us.Password==password){
                Console.WriteLine("in validate1");
                string rol=us.role;
                return rol;
            }
        }
        return null;
        
    }

    // 

    
}