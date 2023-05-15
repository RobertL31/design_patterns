
/*
    Factory method provides an object implementing to a general interface to the client,
    while creating a proper derived object, depending on the context, in the back-end.
    The Creator should be able to provide the object, but also allows to interact with it.
*/

using System;

interface IProduct {
    public void SomeOperation();
}

class ConcreteProduct1 : IProduct {
    public void SomeOperation(){
        Console.WriteLine($"Hello, here is {nameof(ConcreteProduct1)}");
    }
}

class ConcreteProduct2 : IProduct {
    public void SomeOperation(){
        Console.WriteLine($"Hello, here is {nameof(ConcreteProduct2)}");
    }
}


abstract class ACreator {
    public abstract IProduct GetProduct();

    public void DoOperation(){
        IProduct product = this.GetProduct();
        product.SomeOperation();
    }
}


class ConcreteCreator1 : ACreator {
    public override IProduct GetProduct()  {
        return new ConcreteProduct1();
    }
}


class ConcreteCreator2 : ACreator {
    public override IProduct GetProduct() {
        return new ConcreteProduct2();
    }
}


class Client {
    public void ClientCode(ACreator creator){
        creator.DoOperation();
    }
}

class Application
{
    static void Main(string[] args)
    {
        Client client = new Client();
        client.ClientCode(new ConcreteCreator1());
        client.ClientCode(new ConcreteCreator2());
    }
}