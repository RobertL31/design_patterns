
/*
    Abstract Factory pattern aims to provide various factory to group various products.
    A factory should provide a way to ask for any product, but it should be senseful for a single
    factory to be able to provide each specific product all together.
    To manipulate any product, they must implement a specific interface.
*/

using System;

interface IProductA {
    void SomeOperation();
}

interface IProductB {
    void SomeOtherOperation();
}

class ConcreteProductA1 : IProductA {
    public void SomeOperation() {
        Console.WriteLine($"Hello, I'm {nameof(ConcreteProductA1)}");
    }
}

class ConcreteProductA2 : IProductA {
    public void SomeOperation() {
        Console.WriteLine($"Hello, I'm {nameof(ConcreteProductA2)}");
    }
}

class ConcreteProductB1 : IProductB {
    public void SomeOtherOperation() {
        Console.WriteLine($"Hello, I'm {nameof(ConcreteProductB1)}");
    }
}

class ConcreteProductB2 : IProductB {
    public void SomeOtherOperation() {
        Console.WriteLine($"Hello, I'm {nameof(ConcreteProductB2)}");
    }
}


interface IAbstractFactory {
    IProductA CreateProductA();
    IProductB CreateProductB();
}


class ConcreteFactory1 : IAbstractFactory {
    public IProductA CreateProductA() {
        return new ConcreteProductA1();
    }

    public IProductB CreateProductB() {
        return new ConcreteProductB1();
    }
}


class ConcreteFactory2 : IAbstractFactory{
    public IProductA CreateProductA() {
        return new ConcreteProductA2();
    }

    public IProductB CreateProductB() {
        return new ConcreteProductB2();
    }
}


class Client {
    public void ClientCode(IAbstractFactory abstractFactory) {
        IProductA productA = abstractFactory.CreateProductA();
        IProductB productB = abstractFactory.CreateProductB();

        productA.SomeOperation();
        productB.SomeOtherOperation();
    }
}


class Application {
    static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode(new ConcreteFactory1());
        client.ClientCode(new ConcreteFactory2());
    }
}