using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropSystem : MonoBehaviour {

	public int Level;
	List<Item> DropList = new List<Item>();
	List<AI> Enemies = new List<AI>();
	public GameObject ItemGameObject;
	public int MoneyDropRate = 60, ItemDropRate = 30;
	public Sprite MoneySprite;

	// Use this for initialization
	void Start () {
		ItemDatabase temp = GameObject.FindGameObjectWithTag ("Database").GetComponent<ItemDatabase> ();
		DropList = temp.GetAllItemFromLevel (Level);
		GameObject[] Enemynodes = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject Enemy in Enemynodes)
		{
			Enemies.Add (Enemy.GetComponent<AI>() );
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (AI Enemy in Enemies) {
			if (Enemy.state == AI.AI_ENEMY_State.Enemy_Dead)
			{
				DropItem(Enemy.gameObject.transform);
				Enemies.Remove(Enemy);
				return;
			}
		}
	}

	public void DropItem(Transform position)
	{
		GameObject tempItem = (GameObject)Instantiate(ItemGameObject, position.position, position.rotation);
		ItemScript ItemDetail = tempItem.GetComponent<ItemScript> ();

		int roll = Random.Range (0, 100);
		if (roll < ItemDropRate)
		{
			int id = Random.Range (0, DropList.Count);
			id = DropList[id].getIdNum();

			ItemDetail.isItem = true;
			ItemDetail.Setvalue(id);

			tempItem.GetComponent<SpriteRenderer>().sprite = DropList[id].SpriteItem;

		} else if (roll < ItemDropRate + MoneyDropRate) {
			//GameObject TempMoney = (GameObject)Instantiate(MoneyGameObject, Enemy.gameObject.transform.position, Enemy.gameObject.transform.rotation);
			ItemDetail.isItem = false;
			ItemDetail.Setvalue (Random.Range (Level, Level * 5) );
			tempItem.GetComponent<SpriteRenderer>().sprite = MoneySprite;

		}
	}

	void onDestroy()
	{
		Inventory theInventory = GameObject.FindGameObjectWithTag ("Database").GetComponent<Inventory> ();
		if (Level > theInventory.GetNextLevel()) {
			theInventory.SetNextLevel (Level);
		}
	}
}
