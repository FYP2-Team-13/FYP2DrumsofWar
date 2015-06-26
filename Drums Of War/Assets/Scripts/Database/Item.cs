using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {

	public enum IType {
		Sword,
		Javalin,
		Bow,
		Dagger,
		Magic,

		Masks
	}


	public int idNum;
	public string itemName;
	public int type;
	public IType itemType;

	public int attackDamage;
	public int attackSpeed;
	public int Defense;
	public int Evasion;

	public int beingUsed;

	public Item () {
		this.idNum = 1;
		this.itemName = " ";

		this.type = 1;
		switch (type) {
		case 1:
			itemType = IType.Sword;
				break;
		case 2:
			itemType = IType.Javalin;
				break;
		case 3:
			itemType = IType.Bow;
				break;
		case 4:
			itemType = IType.Dagger;
				break;
		case 5:
			itemType = IType.Magic;
				break;
			
		case 6:
			itemType = IType.Masks;
				break;
		}
		
		this.attackDamage = 1;
		this.attackSpeed = 1;
		this.Defense = 1;
		this.Evasion = 1;
		
		this.beingUsed = 0;
	}

	public int getIdNum () {
		return idNum;
	}
}
