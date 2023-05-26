

/*
    Flyweight is the idea of sharing as much between instances of a class as possible, to lower 
    memory consumption. In a general case, one could split class data in two categories :
    - the extrinsic state of the class, which is common to all instances
    - the intrisic state of a class, which is instance specific
    Maximizing the extrinsic / intrinsic balance allows to lower the program's memory consumption
    if lots and lots of instances are created for that class.
    In C#, it can sometimes be as simple as declaring class members as static 
    to share them between instances.
*/

using System;
using System.Collections.Generic;


class Flyweight {
    
    object repeatingState;

    public Flyweight(object repeatingState) {
        this.repeatingState = repeatingState;
    }
}


class FlyweightFactory {

    static Dictionary<object, Flyweight> cache = new Dictionary<object, Flyweight>();

    public static Flyweight GetFlyweight(object repeatingState) {
        if (!cache.ContainsKey(repeatingState)){
            var flyweight = new Flyweight(repeatingState);
            cache[repeatingState] = flyweight;
            return flyweight;
        }

        return cache[repeatingState];
    }
}


class Context {

    object uniqueState;
    public Flyweight flyweight;

    public Context(object uniqueState, object repeatingState) {
        this.uniqueState = uniqueState;
        this.flyweight = FlyweightFactory.GetFlyweight(repeatingState);
    }
}



class Client {
    public void ClientCode() {
        int uniqueState1 = 5;
        int uniqueState2 = 6;
        string[] repeatingState = {"this", "is", "heavy"};
        var context1 = new Context(uniqueState1, repeatingState);
        var context2 = new Context(uniqueState2, repeatingState);
        Console.WriteLine(context1.flyweight == context2.flyweight);
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}