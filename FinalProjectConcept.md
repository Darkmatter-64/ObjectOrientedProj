# Final Project Blueprint

## Concept






## Ojbects

Protagonist
----
Write here: what do they need/do
- Open Inventory

```
class Protagonist{
    // Fields
    private List<Item> inventory; 


    // Methods
    public Protagonist(){ // Constructor
        inventory = new List<Item>();
        // Add notebook
        inventory.add(Item("notepad"));
    }

    public void openInventory(){
        foreach(Item item in inventory){
            item.print();
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


}

```

Enum Type
enum type {
    Key,
    Notebook
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
        }else if (name == "notebook"){
            itemType=Type.Notebook;
        }
    }
}


class Notepad: Item {

    private string notes { get; set;}

    public Notepad(string name) : base(name){
        notes = "";
    }

    public void writeCode(string code){
        notes = code;
    }

    public void checkNotes(){
        if(notes == ""){
            Console.WriteLine("Your notebook is empty");
        }else{
            Console.WriteLine("The code is written in your notebook: " + code);
        }
    }

}

...

```

enum RoomType {
    Hub,
    KeyRoom,
    CodeRoom,
    GeneratorRoom,
    ExitRoom
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

```