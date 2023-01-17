namespace BOL;

public class user{

    public int Userid{get;set;}

    public string Username{get; set;}

    public string Email{get;set;}

    public string Mobileno{get;set;}

    public string Password{get;set;}

    public string role{get;set;}

    public user(int userid, string username, string email, string mobileno, string password, string role)
    {
        Userid = userid;
        Username = username;
        Email = email;
        Mobileno = mobileno;
        Password = password;
        this.role = role;
    }
}