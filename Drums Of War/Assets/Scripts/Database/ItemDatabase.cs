using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour{

	public static List<Item> ItemList = new List<Item>();
	public TextAsset Database;

	void Start () {
		//Create a String Reader that has loaded the Text Asset
		StringReader Data = new StringReader (Database.text); 
		//Store all the Text into a string
		string Contents = Data.ReadToEnd (); 
		//Split Contents of Text Asset by lines
		string[] Lines = Contents.Split ("\n"[0]);
		
		foreach (string line in Lines) {
			//Split each line into variables by comma (,)
			string[] values = line.Split(","[0]);
			
			//Create temporal variables to Load all Sequence in
			Item temp = new Item();

			temp.idNum = int.Parse(values[0]);
			temp.itemName = values[1];

			temp.type = int.Parse(values[2]);

			temp.attackDamage = int.Parse(values[3]);
			temp.attackSpeed = int.Parse(values[4]);
			temp.HealthPoint = int.Parse(values[5]);
			temp.Evasion = int.Parse(values[6]);
						
			temp.beingUsed = int.Parse(values[7]);

			ItemList.Add(temp);
		}
	}

	
	public Item ItemCheck(Item item)
	{
		foreach (Item I in ItemList) {
			if (I.isSame(item) )
				return item;
		}
		return item;
	}
}
