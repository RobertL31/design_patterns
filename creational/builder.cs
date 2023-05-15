
/*
    A builder aims to provide a simple interface to build complex objects, part by part.
    It avoids having a monstruously long constructor.
    Multiple builders can be made to provide different (specific) ways of building an object.
    A director class can be added, which is used to declare a build plan for any builder respecting
    a specific interface. Director can be used to avoid the client manipulating the builder directly.
*/

using System;

class Product {
    public Product() {
        this.Content = "Product\n";
    }

    public void ShowContent() {
        Console.WriteLine(this.Content);
    }
    public string Content {get; set;}
}

interface IBuilder {
    Product Product {get; set;}
    IBuilder Reset();
    IBuilder BuildStepA();
    IBuilder BuildStepB();
}


class ConcreteBuilder1 : IBuilder {
    public Product Product {get; set;}

    public ConcreteBuilder1() {
        this.Reset();
    }

    public IBuilder Reset() {
        this.Product = new Product();
        return this;
    }

    public IBuilder BuildStepA() {
        this.Product.Content += "StepA1\n";
        return this;
    }

    public IBuilder BuildStepB() {
        this.Product.Content += "StepB1\n";
        return this;
    }
}


class ConcreteBuilder2 : IBuilder {
    public Product Product {get; set;}

    public ConcreteBuilder2() {
        this.Reset();
    }

    public IBuilder Reset() {
        this.Product = new Product();
        return this;
    }

    public IBuilder BuildStepA() {
        this.Product.Content += "StepA2\n";
        return this;
    }

    public IBuilder BuildStepB() {
        this.Product.Content += "StepB2\n";
        return this;
    }
}


class Director {
    private IBuilder _builder;

    public void SetBuilder(IBuilder builder) {
        this._builder = builder;
    }

    public Product MakeAB() {
        return _builder.Reset()
            .BuildStepA()
            .BuildStepB()
            .Product;
    }

    public Product MakeBA() {
        return _builder.Reset()
            .BuildStepB()
            .BuildStepA()
            .Product;
    }
}


class Client {

    public void ClientCode() {
        ConcreteBuilder1 builder1 = new ConcreteBuilder1();
        ConcreteBuilder2 builder2 = new ConcreteBuilder2();

        Director director = new Director();

        director.SetBuilder(builder1);
        director.MakeAB().ShowContent();

        director.SetBuilder(builder2);
        director.MakeBA().ShowContent();
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}