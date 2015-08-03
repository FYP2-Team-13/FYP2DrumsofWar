using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelbuttondisabling : MonoBehaviour {

	public Image level2;
	public Image level3;
	public Image level4;
	public Image level5;
	public Image level6;
	public Image level7;
	public Image level8;
	public Image level9;
	public Image level10;
	public Image level11;
	public Image level12;
	public Image level13;
	public Image level14;
	public Image level15;

	// Use this for initialization
	void Start () {
		//level2 = level2.GetComponent<Image> ();
		//enablelevel2 ();
		int  level = GameObject.FindGameObjectWithTag ("Database").GetComponent<Inventory> ().nextlevel;
		if (level == 1) {

		}
		if (level == 2) {
			level2.enabled = false;
		}
		if (level == 3) {
			level2.enabled = false;
			level3.enabled = false;
		}
		if (level == 4) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
		}
		if (level == 5) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
		}
		if (level == 6) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
		}
		if (level == 7) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
			level7.enabled = false;
		}
		if (level == 8) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
			level7.enabled = false;
			level8.enabled = false;
		}
		if (level == 9) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
			level7.enabled = false;
			level8.enabled = false;
			level9.enabled = false;
		}
		if (level == 10) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
			level7.enabled = false;
			level8.enabled = false;
			level9.enabled = false;
			level10.enabled = false;
		}
		if (level == 11) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
			level7.enabled = false;
			level8.enabled = false;
			level9.enabled = false;
			level10.enabled = false;
			level11.enabled = false;
		}
		if (level == 12) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
			level7.enabled = false;
			level8.enabled = false;
			level9.enabled = false;
			level10.enabled = false;
			level11.enabled = false;
			level12.enabled = false;
		}
		if (level == 13) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
			level7.enabled = false;
			level8.enabled = false;
			level9.enabled = false;
			level10.enabled = false;
			level11.enabled = false;
			level12.enabled = false;
			level13.enabled = false;
		}
		if (level == 14) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
			level7.enabled = false;
			level8.enabled = false;
			level9.enabled = false;
			level10.enabled = false;
			level11.enabled = false;
			level12.enabled = false;
			level13.enabled = false;
			level14.enabled = false;

		}
		if (level == 15) {
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
			level6.enabled = false;
			level7.enabled = false;
			level8.enabled = false;
			level9.enabled = false;
			level10.enabled = false;
			level11.enabled = false;
			level12.enabled = false;
			level13.enabled = false;
			level14.enabled = false;
			level15.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
