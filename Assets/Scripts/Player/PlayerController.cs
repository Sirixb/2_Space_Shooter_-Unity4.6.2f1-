using UnityEngine;
using System.Collections;

[System.Serializable]//El atributo Serializable permite incrustar una clase con subpropiedades en el inspector.
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	//Disparos
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update()//Disparar
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
			audio.Play ();		
		}

	}
	void FixedUpdate()//se debe utilizar en vez de Update cuando se trata de rigibody en este caso para manejar la nave
	{
		//Movimiento de la nave
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement= new Vector3 (moveHorizontal, 0.0f,moveVertical);
		rigidbody.velocity= movement*speed;//velocidad de la nave

		// para delimitar la zona de desplazamiento. //clamp sujeta un valor min y max tipo float.
		rigidbody.position= new Vector3
		(
			Mathf.Clamp(rigidbody.position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(rigidbody.position.z,boundary.zMin,boundary.zMax)
		);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);// para la inclinacion de la nave.
	}
}
