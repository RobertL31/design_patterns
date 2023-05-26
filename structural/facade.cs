

/*
    Facade is a way to provide a new, simpler interface to a complex service. By implementing wrappers around
    many function calls to offer a end-service, it allow a simple interaction for a user toward a more complex library 
*/

using System;

class ServiceA {
    public void Method1() { Console. WriteLine("ServiceA : Method1"); }
    public void Method2() { Console. WriteLine("ServiceA : Method2"); }
    public void Method3() { Console. WriteLine("ServiceA : Method3"); }
}


class ServiceB {
    public void Method1() { Console. WriteLine("ServiceB : Method1"); }
    public void Method2() { Console. WriteLine("ServiceB : Method2"); }
    public void Method3() { Console. WriteLine("ServiceB : Method3"); }
}

class ServiceC {
    public void Method1() { Console. WriteLine("ServiceC : Method1"); }
    public void Method2() { Console. WriteLine("ServiceC : Method2"); }
    public void Method3() { Console. WriteLine("ServiceC : Method3"); }
}


class FacadeA {
    public void Feature1(){
        var a = new ServiceA();
        var b = new ServiceB();
        a.Method1();
        b.Method2();
        a.Method1();
        a.Method3();
    }

    public void Feature2(){
        var b = new ServiceB();
        var c = new ServiceC();
        c.Method1();
        b.Method1();
        c.Method2();
        c.Method3();
    }
}

class FacadeB {
    public void Feature1(){
        var a = new ServiceA();
        var b = new ServiceB();
        var c = new ServiceC();
        a.Method3();
        c.Method2();
        b.Method1();
    } 
}


class Client {
    public void ClientCode() {
        var facadeA = new FacadeA();
        facadeA.Feature1();
        facadeA.Feature2();

        var facadeB = new FacadeB();
        facadeB.Feature1();
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}