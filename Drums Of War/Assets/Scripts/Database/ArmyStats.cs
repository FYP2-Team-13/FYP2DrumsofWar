using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArmyStats {

	static float BASE_ATTACK_DAMAGE = 1
			, BASE_ATTACK_SPEED = 0.75f
			, BASE_ATTACK_RANGE_MELEE = 2
			, BASE_ATTACK_RANGE_RANGE = 10
			, BASE_EVASION = 1
			, BASE_HP = 50;

	public int Quantity;
	public AllyClass.Unit_Type Type;

	public Item Helmet, Weapon;

	public ArmyStats ()
	{
		Helmet = new Item ();
		Weapon = new Item ();
	}

	public void ChangeHelmet (Item Helmet)
	{
		this.Helmet = Helmet;
	}

	public void ChangeWeapon (Item Weapon)
	{
		this.Weapon = Weapon;
		if (Weapon.itemType == Item.IType.Sword
		    || Weapon.itemType == Item.IType.Dagger) {
			Type = AllyClass.Unit_Type.Type_Melee;
		} else if (Weapon.itemType == Item.IType.Magic) {
			Type = AllyClass.Unit_Type.Type_Mage;
		} else {
			Type = AllyClass.Unit_Type.Type_Range;
		}
	}

	public void ApplyStats (AllyGroup TheGroup)
	{
		switch (Weapon.type) {
		case 1:
			Type = AllyClass.Unit_Type.Type_Melee;
			break;
		case 4:
			Type = AllyClass.Unit_Type.Type_Melee;
			break;
		case 2:
			Type = AllyClass.Unit_Type.Type_Range;
			break;
		case 3:
			Type = AllyClass.Unit_Type.Type_Range;
			break;
		case 5:
			Type = AllyClass.Unit_Type.Type_Range;
			break;
		}
		TheGroup.InitStats (Type, BASE_ATTACK_DAMAGE + Helmet.attackDamage + Weapon.attackDamage, BASE_ATTACK_SPEED - Helmet.attackSpeed - Weapon.attackSpeed,
		                    (Type == AllyClass.Unit_Type.Type_Melee ? BASE_ATTACK_RANGE_MELEE : BASE_ATTACK_RANGE_RANGE), BASE_EVASION + Helmet.Evasion + Weapon.Evasion,
		                    BASE_HP);
	}

	public bool RecruitUnit()
	{
		if (Quantity < 5) {
			Quantity ++;
			//Remove Money
			return true;
		} else {
			return false;
		}
	}
}
