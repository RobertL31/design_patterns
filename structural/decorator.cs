

/*
    Decorator aims to provide enhanced features to a wrapped object. Decorators can be stacked
    one upon the other and add up. The decorators and the decorated object implement a common interface,
    allowing to call a specific set of methods.
    The main difference with Proxy pattern is that Decorator does not aim to manage the lifecycle or 
    interactions with the wrapped object, but simply adds features to it.
*/

using System;

interface IComponent {
    void SomeOperation();
}


class ConcreteComponent : IComponent {
    public void SomeOperation() {
        Console.WriteLine("ConcreteComponent operation !");
    }
}


class BaseDecorator : IComponent {

    IComponent _wrappee;
    public BaseDecorator(IComponent wrappee) {
        this._wrappee = wrappee;
    }

    public virtual void SomeOperation() {
        _wrappee.SomeOperation();
    }
}


class ConcreteDecorator1 : BaseDecorator {

    public ConcreteDecorator1(IComponent wrappee) 
        : base(wrappee) {}

    public override void SomeOperation()
    {
        base.SomeOperation();
        this.Extra();
    }

    private void Extra() {
        Console.WriteLine("ConcreteDecorator1 operation !");
    }
}

class ConcreteDecorator2 : BaseDecorator {

    public ConcreteDecorator2(IComponent wrappee) 
        : base(wrappee) {}

    public override void SomeOperation()
    {
        base.SomeOperation();
        this.Extra();
    }

    private void Extra() {
        Console.WriteLine("ConcreteDecorator2 operation !");
    }
}


class Client {
    public void ClientCode() {
        var component = new ConcreteComponent();
        var decoratorA = new ConcreteDecorator1(component);
        var decoratorB = new ConcreteDecorator2(decoratorA);
        var decoratorC = new ConcreteDecorator1(decoratorB);
        decoratorC.SomeOperation();
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}