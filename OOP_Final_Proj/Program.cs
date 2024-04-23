

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
    public List<Item> inventory;
    public Room currentRoom;



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

    public string getCurrentRoom()
    {
        return currentRoom.ToString();
    }


    public void addToInventory(string itemName)
    { // Pick up
        inventory.Add(new Item(itemName));
    }

    public List<string> getItemNames()
    {
        List<string> list = new List<string>(); 
        foreach (Item item in inventory)
        {
            list.Add(item.itemName);
        }
        return list;

    }


}

class Game
{
    public Room[] rooms = new Room[5];
    //public bool codeRoomOpen = false;
    //public bool generatorRoomOpen = false;
    public bool genOn = true;
    public bool win = false;

    /*
    static void roomAction(Protagonist user)
    {
        int room = (int) user.currentRoom.getRoomType();

        if(room == 1)
        {
            return user;
        } else if (room == 2)
        {
            
        } else if(room == 3)
        {

        } else if (room == 4)
        {

        }

    }*/

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

        Console.WriteLine("You find yourself in an empty room - there's a sign that says 'Hub'.");
        user.checkInventory();
        user.printCurrentRoom();

        while (!game.win)
        {
            Console.WriteLine("Would you like to 1-Open the inventory, or 2-Move to another room. Choose option [1,2]");
            int action = 0;
            while(action < 1 || action > 2)
            {
                action = Convert.ToInt32(Console.ReadLine());
            }
            if (action == 1)
            {
                user.checkInventory();
            }
            else // Movement
            {
                if (user.getCurrentRoom() == "Hub")
                {
                    Console.WriteLine("Where should I go?");
                    for (int r = 1; r < 5; r++)
                    {
                        Console.Write(r);
                        Console.WriteLine(" " + game.rooms[r].ToString());
                    }
                    int roomOption = 0;
                    Console.WriteLine("Select a room [1,2,3,4]");
                    while (roomOption < 1 || roomOption > 4)
                    {
                        roomOption = Convert.ToInt32(Console.ReadLine());
                    }

                    // Move to Appropriate Room
                    if (roomOption == 1)
                    {
                        user.currentRoom = game.rooms[1];
                        Console.WriteLine("You look around, and you find the key");
                        user.inventory.Add(new Item("key"));
                    }
                    else if (roomOption == 2)
                    {
                        if (user.getItemNames().Contains("key"))
                        {
                            Console.WriteLine("Your key opened the door to the code room.");
                            user.currentRoom = game.rooms[2];
                            Console.Write("The room is dark, you turned on your flashlight. You see a code written in a notebook. It is ");
                            Console.Write(code);
                            Console.WriteLine(". You write it down");
                            user.inventory.Add(new Item("code"));
                        }
                        else
                        {
                            Console.WriteLine("The door is locked, it looks like you need a key");
                        }

                    }
                    else if (roomOption == 3)
                    {
                        if (user.getItemNames().Contains("code"))
                        {
                            Console.Write("You entered code ");
                            Console.Write(code);    
                            Console.WriteLine(". The code opened the door to the generator room.");
                            user.currentRoom = game.rooms[3];
                            Console.WriteLine("The generator is on, and we flip the switch.");
                            game.genOn = false;
                        }
                        else
                        {
                            Console.WriteLine("The door is locked, it looks like you need a code");
                        }
                    }
                    else if (roomOption == 4)
                    {
                        if (!game.genOn)
                        {
                            Console.WriteLine("The electric field is down, you can leave.");
                            Console.WriteLine("You win! :)");
                            user.currentRoom = game.rooms[4];
                            game.win = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The door is electrified, you can't leave.");
                    
                        }
                    }


                }
                else
                {
                    user.currentRoom = game.rooms[0];
                    Console.WriteLine("You are back in the Hub");
                }
            }
            
        }


    }

}