using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {

	public List<Item> ItemList = new List<Item>();
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

			temp.idNum = float.Parse(values[0]);
			temp.name = values[1];

			temp.attackDamage = float.Parse(values[2]);
			temp.attackSpeed = float.Parse(values[3]);
			temp.Defense = float.Parse(values[4]);
			temp.Evasion = float.Parse(values[5]);
						
			temp.beingUsed = float.Parse(values[6]);

			ItemList.Add(temp);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
