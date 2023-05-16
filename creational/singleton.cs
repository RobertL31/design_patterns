

/*
    Singleton wraps a variable aimed to be instanciated just once.
    Every access to the variable is done through the GetInstance() method, 
    allowing to check whether to instanciate or to send the already instanciated variable.
    Thus, the only constructor for the class is private.
*/

using System;

class Singleton {

    private static Singleton instance;

    private Singleton(){}

    public static Singleton GetInstance() {
        if (Singleton.instance is null) {
            Singleton.instance = new Singleton();
        }
        return Singleton.instance;
    }
}


class Client {
    public void ClientCode() {
        Singleton singleton = Singleton.GetInstance();
        Singleton sameSingleton = Singleton.GetInstance();
        if (singleton == sameSingleton) {
            Console.WriteLine("Hello, it's me !");
        }
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}