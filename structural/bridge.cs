

/*
    Bridge aims to split related class into separate hierarchies (often abstraction and implementation).
    It takes advantage of composition to make sure the classes can be developed independently from each others, 
    while still being able to work together.
*/

using System; 

class Abstraction {

    protected IImplemention _implementation;
    
    public Abstraction(IImplemention implementation){
        this._implementation = implementation;
    }
    
    public void SomeFeature() {
        this._implementation.SomeMethod();
    }

    public void SomeOtherFeature() {
        this._implementation.SomeOtherMethod();
    }
}


class RefinedAbstraction : Abstraction {

    public RefinedAbstraction(RefinedImplementation implementation)
        : base(implementation){}

    public void ExtraFeature() {
        this._implementation.SomeMethod();
        this._implementation.SomeOtherMethod();
    }
}


interface IImplemention {
    void SomeMethod();
    void SomeOtherMethod();
}


class RefinedImplementation : IImplemention {
    
    public void SomeMethod() {
        Console.WriteLine("SomeMethod");
    }

    public void SomeOtherMethod() {
        Console.WriteLine("SomeOtherMethod");
    }

    public void ExtraMethod() {
        Console.WriteLine("ExtraMethod");
    }
}


class Client {
    public void ClientCode() {
        var implementation = new RefinedImplementation();
        var abstraction = new RefinedAbstraction(implementation);
        abstraction.SomeFeature();
        abstraction.SomeOtherFeature();
        abstraction.ExtraFeature();
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}