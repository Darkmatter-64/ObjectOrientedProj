

using System.ComponentModel;
using System.Reflection.Emit;
using System.Text;

enum RoomType
{
    Hub,
    KeyRoom,
    CodeRoom,
    GeneratorRoom,
    ExitRoom
}

class Room
{
    protected RoomType roomType { get; set; }
    public Room()
    {
        roomType = RoomType.Hub; // Default        
    }

    public RoomType getRoomType()
    {
        return this.roomType;
    }

}

class Hub : Room
{

    private RoomType[] exits; // Rooms connectd to my current 


    public Hub()
    {

        exits = new RoomType[] { RoomType.KeyRoom, RoomType.CodeRoom, RoomType.GeneratorRoom, RoomType.ExitRoom }; // Hub connects to all rooms
    }

    public RoomType[] getExists()
    {
        return exits;
    }
}

class KeyRoom : Room
{

    private bool hasKey;

    public KeyRoom()
    {
        roomType = RoomType.KeyRoom;
        hasKey = true;
    }
}

class CodeRoom : Room
{

    private int code { get; set; }

    public CodeRoom(int genCode)
    {
        roomType = RoomType.CodeRoom;
        code = genCode;
    }

}

class GeneratorRoom : Room
{

    private bool genOn { get; set; }
    int codeNeeded;

    public GeneratorRoom(int genCode)
    {
        roomType = RoomType.GeneratorRoom;
        codeNeeded = genCode;
        genOn = true;
    }

    bool inputCode(int code)
    {
        if (code == codeNeeded)
        {
            genOn = false;
            Console.WriteLine("You turned off the generator");
            return true;
        }
        else
        {
            Console.WriteLine("Wrong code");
            return false;
        }
    }

}

class ExitRoom : Room
{

    private bool barrierOn { get; set; }

    public ExitRoom()
    {
        roomType = RoomType.ExitRoom;
        barrierOn = true;
    }
    bool Exit()
    {
        if (barrierOn)
        {
            Console.WriteLine("The electric barrier is on, you shall not pass");
            return false;
        }
        else
        {
            Console.WriteLine("You successfully exited the dungeon");
            return true;
        }
    }

}

class Item
{
    public string itemName { get; set; }

    public Item(string name)
    {
        itemName = name;
    
    }
}

class Flashlight : Item
{
    public bool light { get; set; }


    public Flashlight() : base("flashlight")
    {
        light = false;

    }

}

class Protagonist
{
    // Fields
    private List<Item> inventory;
    private Room currentRoom;



    // Methods
    public Protagonist(Room cr)
    { // Constructor
        inventory = new List<Item>();
        currentRoom = cr;
        inventory = new List<Item> { new Flashlight() };
    }


    public void checkInventory()
    {
        Console.WriteLine("Your inventory: ");
        foreach (Item item in inventory)
        {
            Console.WriteLine(item.itemName);   
        }
        Console.WriteLine();
    }
    public void printCurrentRoom()
    {
        Console.Write("You are currently in the ");
        Console.WriteLine(currentRoom);
    }


    public void addToInventory(string itemName)
    { // Pick up
        inventory.Add(new Item(itemName));
    }


}

class Game
{
    public Room[] rooms = new Room[5];
    public bool codeRoomOpen = false;
    public bool win = false;

    static void Main(string[] args)
    {
        Game game = new Game();

        // Random code 
        Random rnd = new Random();
        int code = rnd.Next(1000, 9999);
        // Initialize rooms
        game.rooms[0] = new Hub();
        game.rooms[1] = new KeyRoom();
        game.rooms[2] = new CodeRoom(code);
        game.rooms[3] = new GeneratorRoom(code);
        game.rooms[4] = new ExitRoom();

        Protagonist user = new Protagonist(game.rooms[0]);

        Console.WriteLine("You find yourself in an empty room");
        user.checkInventory();
        user.printCurrentRoom();

        while (!game.win)
        {
            // I'm currently in .... room
            // Do you want to go to another room...
            
        }


    }

}