using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ConsistentArmy : MonoBehaviour {

	public ArmyStats[] TheArmy = new ArmyStats[3];
	public Color ArmyColor;
//	public Sprite BodySprite;
	public int SpriteIndex;

	public List<Sprite> SpriteDatabase;

	// Use this for initialization
	void Start () {

//		DirectoryInfo BodyImagePath = new DirectoryInfo ("Resources/BodyImages");
//		print (BodyImagePath);

		Sprite[] BodyImages = Resources.LoadAll<Sprite> ("BodyImages");
//
//		for (int i = 0; i < 6; i ++) {
//			SpriteDatabase.Add (Resources.Load<Sprite> ("BodyImages/BodyType" + i));
//		}

		foreach (Sprite Image in BodyImages) {
			SpriteDatabase.Add (Image);
		}

		if (Load ()) {
			print ("Load Successful");
		} else {
			print ("Load Failed");
			ArmyColor = new Color (1, 1, 1, 1);
			for (int i = 0; i < TheArmy.Length; i ++)
			{
				TheArmy[i].Helmet = GameObject.FindGameObjectWithTag("Database").GetComponent<ItemDatabase>().GetItem(11);
				TheArmy[i].Weapon = GameObject.FindGameObjectWithTag("Database").GetComponent<ItemDatabase>().GetItem(1);
			}
//			BodySprite = SpriteDatabase[0];
			SpriteIndex = 0;
		}
		//print (Application.persistentDataPath);
	}

	public Color GetArmyColor ()
	{
		return ArmyColor;
	}

	public void SetArmyColor (Color NewColor)
	{
		ArmyColor = NewColor;
	}

	public Sprite GetSprite (int index)
	{
		if (index < SpriteDatabase.Count)
			return SpriteDatabase [index];
		else
			return null;
	}

	public Sprite GetCurrentBodySprite ()
	{
		return SpriteDatabase[SpriteIndex];
	}

//	public void SetSprite (Sprite NewSprite)
//	{
//		BodySprite = NewSprite;
//	}

	public void Save ()
	{
		ArmyData theArmyData = new ArmyData();
		theArmyData.r = ArmyColor.r;
		theArmyData.g = ArmyColor.g;
		theArmyData.b = ArmyColor.b;
//		theArmyData.SpriteIndex = SpriteDatabase.IndexOf (BodySprite);
//		if (theArmyData.SpriteIndex < 0)
//		{
//			theArmyData.SpriteIndex = 0;
//		}
		theArmyData.SpriteIndex = SpriteIndex;
//		theArmyData.TheArmy = TheArmy;
		
		theArmyData.TheArmy = new ArmyStatsNoImage[3];

		for (int i = 0; i < 3; i++) {
			theArmyData.TheArmy[i] = new ArmyStatsNoImage();
			theArmyData.TheArmy[i].HelmetID = TheArmy[i].Helmet.getIdNum();
			theArmyData.TheArmy[i].WeaponID = TheArmy[i].Weapon.getIdNum();
			theArmyData.TheArmy[i].Quantity = TheArmy[i].Quantity;
			theArmyData.TheArmy[i].Type = TheArmy[i].Type;
		}

		BinaryFormatter bf = new BinaryFormatter ();
		if (!File.Exists (Application.persistentDataPath + "/ArmyData.data")) {
			FileStream filetemp = File.Create (Application.persistentDataPath + "/ArmyData.data");
			filetemp.Close();
		}
		FileStream file = File.Open (Application.persistentDataPath + "/ArmyData.data", FileMode.Open);

		bf.Serialize (file, theArmyData);
		file.Close (); 

		print ("Save Successful");
	}

	public bool Load()
	{
		if (File.Exists (Application.persistentDataPath + "/ArmyData.data")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/ArmyData.data", FileMode.Open);

			ArmyData data = (ArmyData)bf.Deserialize(file) as ArmyData;
			file.Close();

			ArmyColor = new Color(data.r, data.g, data.b);
//			BodySprite = SpriteDatabase[data.SpriteIndex];
			SpriteIndex = data.SpriteIndex;

			for (int i= 0; i < data.TheArmy.Length; i++)
			{
				TheArmy[i].Quantity = data.TheArmy[i].Quantity;
				TheArmy[i].Type = data.TheArmy[i].Type;
				//				TheArmy[i] = data.TheArmy[i];
				TheArmy[i].Weapon = GameObject.FindGameObjectWithTag("Database").GetComponent<ItemDatabase>().GetItem(data.TheArmy[i].WeaponID);
				TheArmy[i].Helmet = GameObject.FindGameObjectWithTag("Database").GetComponent<ItemDatabase>().GetItem(data.TheArmy[i].HelmetID);
			}

			return true;

		} else {
			return false;
		}
	}

	void OnApplicationQuit()
	{
		Save();
	}
}

[System.Serializable]
public class ArmyData
{
	public float r, g, b;
	public int SpriteIndex;
	public ArmyStatsNoImage[] TheArmy;
}
