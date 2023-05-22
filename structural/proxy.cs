

/*
    Proxy aims to wrap a service to manage it as wanted, without modifying its code. 
    It should have the same interface as the service, so that the client interacts with 
    it as it would interact with the service.
    It would allow to lazily instanciate a class that has not implemented lazy initialisation 
    for example.
*/

using System;

interface IService {
    void SomeOperation();
}


class Service : IService {

    public void SomeOperation() {
        Console.WriteLine("Hello, World !");
    }
}


class ServiceProxy : IService {
    
    static Service _service;

    public void SomeOperation() {
        if (_service is null) {
            _service = new Service();
        }
        _service.SomeOperation();   
        this.PostOperation();
    }

    private void PostOperation() {
        Console.WriteLine("Bye ~Proxy");
    }
}


class Client {
    public void ClientCode() {
        ServiceProxy proxy = new ServiceProxy();
        proxy.SomeOperation();
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}