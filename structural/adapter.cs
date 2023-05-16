

/*
    Adapter allows two uncompatible interfaces to work together (one-way, or both)
    It is able to communicate with both sides (the client, and the service), and makes the 
    translation between those two.
    Thus, the client is able to call an interface it is not compatible with, without implementing
    itself the translation logic between its interface and the serive's one.
*/

using System;

interface ClientLanguage {
    string[] Upperize(string[] words);
}


class ClientToServiceAdapter : ClientLanguage {
    private readonly Service service;

    public ClientToServiceAdapter() {
        this.service = new Service();
    }

    public string[] Upperize(string[] words) {
        string[] result = new string[words.Length];
        for(int i=0; i<result.Length; ++i) {
            result[i] = service.Upperize(words[i]);
        }
        return result;
    }
}

class Service {
    public string Upperize(string word) {
        return word.ToUpper();
    }
}


class Client {
    public void ClientCode() {
        string[] words = {"hello", ",world!"};
        var adapter = new ClientToServiceAdapter();
        string[] result = adapter.Upperize(words);
         Console.WriteLine("[{0}]", string.Join(" ", result));
    }
}


class Application {
    public static void Main(string[] args) {
        Client client = new Client();
        client.ClientCode();
    }
}