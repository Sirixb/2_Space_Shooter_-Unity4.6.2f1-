using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble;//caer.
	void Start () 
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
	//rigidbody.angularVelocity=El vector de velocidad angular de la rigidbody.
	//Random.insideUnitSphere= Devuelve un punto al azar dentro de una esfera de radio 1 (sólo lectura).
}
