# Final Project Blueprint

## Concept

We will have 5 different rooms where the objective is to make your way to the exit by utilizing the contents within each of the five rooms, We made sure that each sub room would be used at least one point to serve a purpose for completion.




Rooms
-----

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




What are the rooms, what do they, what's in them
- Hub: ...
- Key room ...
- Code room ...
- Generator room ...
- Exit room ...

```
class Room{
    protected RoomType roomType {get; set;}
    Room(){
        roomType = RoomType.Hub; // Default        
    }

}

class Hub : Room{

    private RoomType[] exits; // Rooms connectd to my current 


    Hub(){

        exits = new RoomType[]{RoomType.KeyRoom, RoomType.CodeRoom, RoomType.GeneratorRoom, RoomType.ExitRoom}; // Hub connects to all rooms
    }
}

class KeyRoom : Room{

    private bool hasKey; 

    KeyRoom()
    { 
        roomType = RoomType.KeyRoom;
        hasKey = true;
    }    
}

class CodeRoom : Room{

    private int code {get; set;}

    CodeRoom(int genCode)
    {
        roomType = RoomType.CodeRoom;
        code = genCode;
    }

}

class GenertorRoom : Room{

    private bool genOn {get; set;}
    int codeNeeded;

    GeneratorRoom(genCode)
    {
        roomType = RoomType.GeneratorRoom;
        codeNeeded = genCode;
        genOn = true;
    }

    bool inputCode(int code){
        if(code == codeNeeded){
            genOn =false;
            Console.WriteLine("You turned off the generator");
            return true;
        }else{
            Console.WriteLine("Wrong code");
            return false;
        }
    }

}

class ExitRoom : Room {

    privat bool barrierOn {get; set;}

    ExitRoom()
    {
        roomType = RoomType.ExitRoom;
        barrierOn = true;
    }
    bool Exit(){
        if(barrierOn){
            Console.WriteLine("The electric barrier is on, you shall not pass");
            return false;
        }else{
            Console.WriteLine("You successfully exited the dungeon");
            return true;
        }
    }

}

## Ojbects





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

class Game {
    private Room[] rooms = new Room[5];

    // Initialize everything here, tell story here

}