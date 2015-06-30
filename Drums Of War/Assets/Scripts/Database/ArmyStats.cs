using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArmyStats {

	static float BASE_ATTACK_DAMAGE = 10
			, BASE_ATTACK_SPEED = 0.75f
			, BASE_ATTACK_RANGE_MELEE = 2
			, BASE_ATTACK_RANGE_RANGE = 10
			, BASE_EVASION = 5
			, BASE_HP = 100;

	public int Quantity;
	public AllyClass.Unit_Type Type;

	public Item Helmet, Weapon;

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
		TheGroup.InitStats (Type, BASE_ATTACK_DAMAGE + Helmet.attackDamage + Weapon.attackDamage, BASE_ATTACK_SPEED - Helmet.attackSpeed - Weapon.attackSpeed,
		                    (Type == AllyClass.Unit_Type.Type_Melee ? BASE_ATTACK_RANGE_MELEE : BASE_ATTACK_RANGE_RANGE), BASE_EVASION + Helmet.Evasion + Weapon.Evasion,
		                    BASE_HP);
	}
}
