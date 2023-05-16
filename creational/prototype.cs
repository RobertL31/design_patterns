
/*
    Prototype aims to provide a better way to copy objects. As an outer user may not know about 
    some fields of an objects, thus may not be able to deep copy it properly, we delegate the responsability
    to be able to make a copy to the object itself. A prototype (Clone) interface must be implemented 
    for an object to be able to copy itself.
*/

using System;

interface IPrototype {
    IPrototype Clone();
}


class ConcreteProtype : IPrototype {

    private float _field1;
    private bool _field2;

    public ConcreteProtype() {
        this._field1 = float.NaN;
        this._field2 = false;
    }

    public ConcreteProtype(ConcreteProtype source) {
        this._field1 = source._field1;
        this._field2 = source._field2;
    }

    public virtual IPrototype Clone() {
        return new ConcreteProtype(this);
    }

    public virtual void Show() {
        Console.WriteLine($"SubclassPrototype content :");
        Console.WriteLine($"field_1 = {this._field1}");
        Console.WriteLine($"field_2 = {this._field2}");
    }
}


class SubclassPrototype : ConcreteProtype {
    private int _field3;

    public SubclassPrototype() {
        this._field3 = 5;
    }

    public SubclassPrototype(SubclassPrototype source) : base(source) {
        this._field3 = source._field3;
    }

    public override IPrototype Clone() {
        return new SubclassPrototype(this);
    }

    public override void Show() {
        base.Show();
        Console.WriteLine($"SubclassPrototype content :");
        Console.WriteLine($"field_3 = {this._field3}");
    }
}


class Client {
    public void ClientCode(SubclassPrototype prototype) {
        IPrototype clone = prototype.Clone();
        (clone as SubclassPrototype).Show();
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        SubclassPrototype prototype = new SubclassPrototype();
        client.ClientCode(prototype);
    }
}