using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropSystem : MonoBehaviour {

	public int Level;
	List<Item> DropList = new List<Item>();
	List<AI> Enemies = new List<AI>();
	public GameObject ItemGameObject, MoneyGameObject;

	// Use this for initialization
	void Start () {
		DropList = GameObject.FindGameObjectWithTag ("Database").GetComponent<ItemDatabase> ().GetAllItemFromLevel (Level);
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
				if (Random.Range (0,100) > 60)
				{
					int id = Random.Range (0, DropList.Count);
					id = DropList[id].getIdNum();

					GameObject tempItem = (GameObject)Instantiate(ItemGameObject, Enemy.gameObject.transform.position, Enemy.gameObject.transform.rotation);
					tempItem.GetComponent<ItemScript>().SetID(id);
				} else {
					//GameObject TempMoney = (GameObject)Instantiate(MoneyGameObject, Enemy.gameObject.transform.position, Enemy.gameObject.transform.rotation);
				}
			}
		}
	}
}
