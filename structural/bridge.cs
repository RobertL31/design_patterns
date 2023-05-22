

/*
    Bridge aims to split related class into separate hierarchies (often abstraction and implementation).
    It takes advantage of composition to make sure the classes can be developed independently from each others, 
    while still being able to work together.
*/




class Client {
    public void ClientCode() {
        
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}