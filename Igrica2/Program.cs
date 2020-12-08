using System;
using System.Collections.Generic;

namespace Igrica2
{
    class Player
    {
        //Constructor
        public Player()
        {
            Weapon woodenSword = new Weapon("wooden sword", 4, 2, 10);
            Armor woodenArmor = new Armor("wooden plank", 10, 4, 20);

            fInventory().fBag().Add(woodenSword);
            fEquip(woodenSword);

            fInventory().fBag().Add(woodenArmor);
            fEquip(woodenArmor);
        }
        
        //Functions
        public void fInputName()
        {
            Console.WriteLine("Upisite svoje ime:");
            name = Console.ReadLine();
        }
        
        public void fListStats()
        {
            Console.WriteLine("\nName: {0}\nGold: {1}", name, gold);
        }

        //Weapon
        public void fEquip(Weapon weapon)
        {
            fInventory().fEquipWeapon(weapon);
            damage += weapon.fGetDamage();
        }
        public void fUnEquip(Weapon weapon)
        {
            fInventory().fUnEquipWeapon(weapon);
            damage -= weapon.fGetDamage();
        }

        //Armor
        public void fEquip(Armor armor)
        {
            fInventory().fEquipArmor(armor);
            this.armor += armor.fGetArmor();
        }
        public void fUnEquip(Armor armor)
        {
            fInventory().fUnEquipArmor(armor);
            this.armor -= armor.fGetArmor();
        }

        //Accessor
        public int fGetGold() { return gold; }
        public Inventory fInventory() { return inventory; }

        //Modifier
        public void fSetGold(int gold) { this.gold = gold; }

        string name;
        int gold = 150;
        int armor = 0;
        int damage = 0;
        Inventory inventory = new Inventory();
    }

    class Vendor
    {
        public Vendor()
        {
            Weapon axe = new Weapon("axe", 8, 10, 50);
            Weapon sword = new Weapon("sword", 6, 5, 35);

            Armor plate = new Armor("plate", 18, 25, 100);
            Armor leather = new Armor("leather", 14, 8, 40);

            fAddItem(axe);
            fAddItem(sword);
            fAddItem(plate);
            fAddItem(leather);
        }
        //Functions
        public void fListItems()
        {
            Console.WriteLine("\nNa prodavacevom izlogu:");
            for (int i = 0; i < vendor.Count; i++)
                Console.Write(i + ". " + "\t" + vendor[i].fGetName() + "\t" + " | type: " + vendor[i].GetType().Name + "\t" + " | Buy: " + vendor[i].fGetBuyValue() + "\n");
            Console.WriteLine();
        }

        public void fAddItem(Item item)
        {
            vendor.Add(item);
        }

        //Accessor
        public List<Item> fGetVendor() { return vendor; }

        List<Item> vendor = new List<Item>();
    }

    class Inventory
    {
        //Functions
        public void fListItems()
        {
            if (bag.Count != 0)
            {
                Console.WriteLine("\nU tvojoj torbi:");
                for (int i = 0; i < bag.Count; i++)
                    Console.Write(i + ". " + "\t" + bag[i].fGetName() + " | type: " + bag[i].GetType().Name + " | Sell: " + bag[i].fGetSellValue() + "\t" + "\n");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nU tvojoj torbi se nalazi prašina.");
            }
        }

        public void fAddItem(Item item)
        {
            bag.Add(item);
        }
        public void fRemoveItem(Item item)
        {
            bag.Remove(item);
        }

        //Weapon functions
        public void fEquipWeapon(Weapon weapon)
        {
            int weaponLimit = 2;
            if (weaponSlot.Count <= weaponLimit)
                weaponSlot.Add(weapon);
            else
                Console.WriteLine("\nNemate dovoljno ruku za novo oružje.");
        }
        public void fUnEquipWeapon(Weapon weapon)
        {
            if (weaponSlot.Contains(weapon))
                weaponSlot.Remove(weapon);
            else
                Console.WriteLine("\nTrenutno ne držite u rukama {0}.", weapon.fGetName());
        }

        //Armor functions
        public void fEquipArmor(Armor armor)
        {
            int armorLimit = 1;
            if (armorSlot.Count < armorLimit)
                armorSlot.Add(armor);
            else
                Console.WriteLine("\nVeć imate na sebi oklop.");
        }
        public void fUnEquipArmor(Armor armor)
        {
            if (armorSlot.Contains(armor))
                armorSlot.Remove(armor);
            else
                Console.WriteLine("\nTrenutno niste opremljeni s {0}", armor.fGetName());
        }

        //Accessor
        public List<Item> fBag() { return bag; }

        List<Item> bag = new List<Item>();
        List<Weapon> weaponSlot = new List<Weapon>();
        List<Armor> armorSlot = new List<Armor>();

    }

    class Item
    {
        //Accessor
        public string fGetName() { return name; }
        public int fGetSellValue() { return sellValue; }
        public int fGetBuyValue() { return buyValue; }

        //Modifier
        public void fSetName(string name) { this.name = name; }
        public void fSetSellValue(int sellValue) { this.sellValue = sellValue; }
        public void fSetBuyValue(int buyValue) { this.buyValue = buyValue; }

        string name;
        int sellValue;
        int buyValue;
    }

    class Weapon : Item
    {
        public Weapon(string name, int damage, int sellValue, int buyValue)
        {
            fSetName(name);
            this.damage = damage;
            fSetSellValue(sellValue);
            fSetBuyValue(buyValue);
        }
        //Accessor
        public int fGetDamage() { return damage; }

        //Modifier
        public void fSetDamage(int damage) { this.damage = damage; } 

        int damage;
    }

    class Armor : Item
    {
        public Armor(string name, int armor, int sellValue, int buyValue)
        {
            fSetName(name);
            this.armor = armor;
            fSetSellValue(sellValue);
            fSetBuyValue(buyValue);
        }
        //Accessor
        public int fGetArmor() { return armor; }

        //Modifier
        public void fSetArmor(int armor) { this.armor = armor; }

        int armor;
    }

    class Logic
    {
        public Logic()
        {
            player.fInputName();
            player.fListStats();
        }

        //Functions
        public void fGiveItem(string name)
        {
            int count = 1;
            for (int i = 0; i < vendor.fGetVendor().Count; i++)
            {
                if (vendor.fGetVendor()[i].fGetName() == name)
                {
                    if (player.fGetGold() >= vendor.fGetVendor()[i].fGetBuyValue())
                    {
                        player.fSetGold(player.fGetGold() - vendor.fGetVendor()[i].fGetBuyValue());
                        player.fInventory().fAddItem(vendor.fGetVendor()[i]);
                        Console.WriteLine("\nUspiješno ste kupili {0} artikl", vendor.fGetVendor()[i].fGetName());
                    }
                    else
                    {
                        Console.WriteLine("\nNemas dovoljno novčića.");
                    }
                }
                else
                    count++;
            }
            if (count > vendor.fGetVendor().Count)
            {
                Console.WriteLine("\nArtikal nije pronađen.\nPokušajte ponovno.");
            }
        }

        public void fGiveItem(int number)
        {
            if (number < vendor.fGetVendor().Count)
            {
                if (player.fGetGold() >= vendor.fGetVendor()[number].fGetBuyValue())
                {
                    player.fSetGold(player.fGetGold() - vendor.fGetVendor()[number].fGetBuyValue());
                    player.fInventory().fAddItem(vendor.fGetVendor()[number]);
                    Console.WriteLine("\nUspiješno ste kupili {0} artikl.", vendor.fGetVendor()[number].fGetName());
                }
                else
                {
                    Console.WriteLine("\nNemas dovoljno novčića.");
                }
            }
            else
            {
                Console.WriteLine("\nArtikal nije pronađen.\nPokušajte ponovno.");
            }
        }

        public void fTakeItem(int number)
        {
            if (number < player.fInventory().fBag().Count)
            {
                player.fSetGold(player.fGetGold() + player.fInventory().fBag()[number].fGetSellValue());
                player.fInventory().fRemoveItem(player.fInventory().fBag()[number]);
            }
            else
            {
                Console.WriteLine("\nNije pronađen artikl.");
            }
        }

        //Market functions
        public void fBuyItem()
        {
            vendor.fListItems();
            Console.WriteLine("\nKoji artikal bi voljeli kupiti?");
            string choice = Console.ReadLine();
            choice.ToLower();
            int number;
            if(Int32.TryParse(choice, out number))
            {
                fGiveItem(number);
            }
            else
            { 
                fGiveItem(choice);
            }
        }

        public void fSellItem()
        {
            if (player.fInventory().fBag().Count != 0)
            {
                player.fInventory().fListItems();
                Console.WriteLine("\nKoji artikal bi voljeli prodati?");
                string choice = Console.ReadLine();
                int number;
                if (Int32.TryParse(choice, out number))
                {
                    fTakeItem(number);
                }
                else
                {
                    Console.WriteLine("\nNije pronađen artikl.");
                }
            }
            else
            {
                Console.WriteLine("\nU tvojoj torbi se nalazi prašina.");
            }
        }

        //Action
        public void fAction()
        {
            Console.WriteLine("\nŠto bi voljeli učiniti?");
            Console.WriteLine("1. Kupi artikl\n2. Prodaj artikl\n3. Prolistaj inventar\n4. Provjeri svoj status\n5. Izlaz iz prodavaonice");
            string izbor = Console.ReadLine();
            int choice;
            bool success = Int32.TryParse(izbor, out choice);
            if(success)
            {
                switch (choice)
                {
                    case 1:
                        fBuyItem();
                        break;
                    case 2:
                        fSellItem();
                        break;
                    case 3:
                        player.fInventory().fListItems();
                        break;
                    case 4:
                        player.fListStats();
                        break;
                    case 5:
                        Console.WriteLine("Izašali ste iz prodavaonice.");
                        gameIsRunning = false;
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nMolim unesite broj da odaberete opciju!");
            }
            
        }

        Player player = new Player();
        Vendor vendor = new Vendor();

        public bool gameIsRunning = true;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            while (logic.gameIsRunning == true)
            {
                logic.fAction();
            }
        }
    }
}
