using System;
using System.Collections.Generic;

namespace Igrica2
{
    class Player
    {
        public void fInputName()
        {
            Console.WriteLine("Upisite svoje ime:");
            name = Console.ReadLine();
        }
        string name;
        int gold = 250;
        int armor = 0;
        int damage = 0;
        Inventory inventory = new Inventory();
    }

    class Vendor
    {
        //Functions
        public void fListItems()
        {
            for (int i = 0; i < vendor.Count; i++)
                Console.Write(i + ". " + vendor[i].fGetName() +" | type: " + vendor[i].GetType() + " | Buy: " + vendor[i].fGetBuyValue() + "\n");
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
            for (int i = 0; i < bag.Count; i++)
                Console.Write(i + ". " + bag[i].fGetName() + " | type: " + bag[i].GetType() + " | Buy: " + bag[i].fGetBuyValue() + "\n");
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
