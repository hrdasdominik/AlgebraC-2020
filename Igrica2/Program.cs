using System;
using System.Collections.Generic;

namespace Igrica2
{
    class Player
    {
        //Constructor
        public Player()
        {
            Weapon woodenSword = new Weapon("Wooden sword", 4, 2, 10);
            Armor woodenArmor = new Armor("Wooden plank", 10, 4, 20);

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
            Console.WriteLine("\nName: \t{0}\nGold: \t{1}\nDamage: {2}\nArmor: \t{3}\n", name, gold, damage, armor);
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
        public Inventory fInventory() { return inventory; }

        string name;
        int gold = 150;
        int armor = 0;
        int damage = 0;
        Inventory inventory = new Inventory();
    }

    class Vendor
    {
        //Functions
        public void fListItems()
        {
            Console.WriteLine("Na prodavacevom izlogu:");
            for (int i = 0; i < vendor.Count; i++)
                Console.Write(i + ". " + "\t" + vendor[i].fGetName() + "\t" + " | type: " + vendor[i].GetType().Name + "\t" + " | Buy: " + vendor[i].fGetBuyValue() + "\n");
            Console.WriteLine();
        }

        public void fAddItem(Item item)
        {
            vendor.Add(item);
        }

        List<Item> vendor = new List<Item>();
    }

    class Inventory
    {
        //Functions
        public void fListItems()
        {
            Console.WriteLine("U tvojoj torbi:");
            for (int i = 0; i < bag.Count; i++)
                Console.Write(i + ". " + "\t" + bag[i].fGetName() + "\t" + " | type: " + bag[i].GetType().Name + "\t" + " | Sell: " + bag[i].fGetSellValue() + "\t" + "\n");
            Console.WriteLine();
        }

        public void fAddItem(Item item)
        {
            bag.Add(item);
        }

        //Weapon functions
        public void fEquipWeapon(Weapon weapon)
        {
            int weaponLimit = 2;
            if (weaponSlot.Count <= weaponLimit)
                weaponSlot.Add(weapon);
            else
                Console.WriteLine("Nemate dovoljno ruku za novo oružje. :P");
        }
        public void fUnEquipWeapon(Weapon weapon)
        {
            if (weaponSlot.Contains(weapon))
                weaponSlot.Remove(weapon);
            else
                Console.WriteLine("Trenutno ne držite u rukama {0}", weapon.fGetName());
        }

        //Armor functions
        public void fEquipArmor(Armor armor)
        {
            int armorLimit = 1;
            if (armorSlot.Count < armorLimit)
                armorSlot.Add(armor);
            else
                Console.WriteLine("Već imate na sebi oklop.");
        }
        public void fUnEquipArmor(Armor armor)
        {
            if (armorSlot.Contains(armor))
                armorSlot.Remove(armor);
            else
                Console.WriteLine("Trenutno niste opremljeni s {0}", armor.fGetName());
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

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.fInputName();
            player.fListStats();
            player.fInventory().fListItems();

            Weapon axe = new Weapon("Axe", 8, 10, 50);
            Weapon sword = new Weapon("Sword", 6, 5, 35);

            Armor plate = new Armor("Plate", 18, 25, 100);
            Armor leather = new Armor("Leather", 14, 8, 40);
            
            Vendor vendor = new Vendor();
            vendor.fAddItem(axe);
            vendor.fAddItem(sword);
            vendor.fAddItem(plate);
            vendor.fAddItem(leather);

            vendor.fListItems();
        }
    }
}
