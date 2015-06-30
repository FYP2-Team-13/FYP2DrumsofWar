using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConsistentArmy : MonoBehaviour {

	public ArmyStats[] TheArmy = new ArmyStats[3];
	public Color ArmyColor;
	public Sprite BodySprite;

	public List<Sprite> SpriteDatabase;

	// Use this for initialization
	void Start () {
		ArmyColor = new Color (1,1,1,1);
	}
	
	// Update is called once per frame
	void Update () {
	
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
		return BodySprite;
	}

	public void SetSprite (Sprite NewSprite)
	{
		BodySprite = NewSprite;
	}
}
