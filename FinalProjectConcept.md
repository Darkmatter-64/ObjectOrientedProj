# Final Project Blueprint

## Concept

We will have 5 different rooms where the objective is to make your way to the exit by utilizing the contents within each of the five rooms, We made sure that each sub room would be used at least one point to serve a purpose for completion.

CodeRoom    Exit
   |         |    
   |--------Hub----Generator
   |
KeyRoom



enum RoomType {
    Hub,
    KeyRoom,
    CodeRoom,
    GeneratorRoom,
    ExitRoom
}



## Ojbects

class Game {
    private Room[] rooms = new Room[5];

    // Initialize everything here, tell story here

}



Protagonist
----
Write here: what do they need/do
- Open Inventory

```
class Protagonist{
    // Fields
    private List<Item> inventory; 
    private Room currentRoom; 

    enum RoomType {
        Hub,
        KeyRoom,
        CodeRoom,
        GeneratorRoom,
        ExitRoom
    }

    // Methods
    public Protagonist(){ // Constructor
        inventory = new List<Item>();
        currentRoom = Room.Hub;
        inventory = new List<Item>{Item("flashlight")};
    }

    public void openInventory(){
        foreach(Item item in inventory){
            item.print(); // Number next to it
        }
        Console.WriteLine("Q - Exit Inventory");
        Console.WriteLine("Select your option");
        string option = Console.ReadLine();

        if( (int) option == (int) Type.Flashlight){
            ... // if in code room
        }
        else if ( (int) option == (int) Type.Key){
            .... // Lock room
        }
    }

    public bool checkInventory(string itemName){
        foreach(Item item in inventory){
            if(item.getName() == itemName){
                return True;
            }
        }
        return False;
    }

    public void addToInventory(string itemName){ // Pick up
        inventory.Add(Item(itemName))
        
    }


}

```

Enum Type
--------

enum Type {
    Key = 2,
    Flashlight = 1
}


Items
-----

```
class Item{
    protected string itemName { get; set; }
    protected itemType { get; set; }

    public Item(string name){
        itemName = name;
        if(name=="key"){
            itemType=Type.Key;
        }else if (name == "flashlight"){
            itemType=Type.Flashlight;
        }
    }
}

class Flashlight: Item {
    private bool light {get; set;}
    
    public Flashlight(string name) : base(name){
        itemType = Type.Flashlight;
    
    }

}

Rooms
-----
What are the rooms, what do they, what's in them
- Hub: ...
- Key room ...
- Code room ...
- Generator room ...
- Exit room ...

```
class Room{
    protected RoomType roomType {get; set;}
    protected List<RoomType> exits;
}

class Hub: Room{

}

class KeyRoom : Room{
    
}