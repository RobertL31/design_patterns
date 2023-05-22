

/*
    Composite aims to represent a class architecture as a tree. By making every node of the tree implement
    the same interface, it is possible to achieve tree-wide operations simply. 
    Every class of the tree may not be the same, as long as they implement a common interface.
*/

using System.Collections.Generic;
using System;

interface IComponent {
    void SomeOperation(int depth);
}

class Leaf : IComponent {
    public void SomeOperation(int depth) {
        Console.WriteLine(new string('-', depth) + "Leaf");
    }
} 


class Composite : IComponent {

    List<IComponent> _children = new List<IComponent>();
    
    public void SomeOperation(int depth) {
        Console.WriteLine(new string('-', depth) + "Composite");
        foreach(var child in _children) {
            child.SomeOperation(depth + 1);
        }
    }

    public void AddChild(IComponent component) {
        this._children.Add(component);
    }
}


class Client {
    public void ClientCode() {
        Composite root = new Composite(), child = new Composite(), child1 = new Composite();
        Leaf leaf = new Leaf(), leaf1 = new Leaf(), leaf2 = new Leaf(), leaf11 = new Leaf(), leaf12 = new Leaf();
        root.AddChild(child);
        root.AddChild(leaf);
        child.AddChild(leaf1);
        child.AddChild(child1);
        child.AddChild(leaf2);
        child1.AddChild(leaf11);
        child1.AddChild(leaf12);
        root.SomeOperation(0);
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}