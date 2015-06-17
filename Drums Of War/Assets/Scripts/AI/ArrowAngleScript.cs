using UnityEngine;
using System.Collections;

public class ArrowAngleScript : MonoBehaviour {

	Rigidbody2D theRigidBody;
	Vector2 Direction;
	float Damage, speed;
	string EnemyTag;


	// Use this for initialization
	void Start () {
		theRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//theRigidBody.AddForce (Direction * speed);
	}

	public void CalculateAngle (Transform Target, float speed, float Damage, string EnemyTag)
	{
		theRigidBody = GetComponent<Rigidbody2D> ();

		float y = Target.transform.position.y - transform.position.y;
		float x = (Target.transform.position - transform.position).magnitude;
		float g = Physics2D.gravity.y;
		float temp = (speed * speed * speed * speed) - (g * (g * (x * x) + 2 * y * (speed * speed)));

		this.speed = speed;
		this.Damage = Damage;
		this.EnemyTag = EnemyTag;

		temp = Mathf.Sqrt (temp);

		if (temp > 0) {

			temp = Mathf.Atan( ( (speed*speed) + temp) / (g*x) );
			temp = Mathf.Rad2Deg;
			//print (temp);
			Direction = Quaternion.AngleAxis(temp, Vector3.forward) * Vector2.right;
			print (Direction * speed);
			theRigidBody.AddForce (Direction * speed, ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D( Collision2D col ) {
		if (col.gameObject.tag == gameObject.tag) {
			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), col.collider);
			return;
		} else {
			if (col.gameObject.tag == EnemyTag)
			{
				if (gameObject.GetComponent<AllyClass>() )
				{
					gameObject.GetComponent<AllyClass>().TakeDamage(Damage);
				}
				else if (gameObject.GetComponent<AI>())
				{
					gameObject.GetComponent<AI>().TakeDamage(Damage);
				}
			}
			Destroy(gameObject);
		}
	}
}
