using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float scrollerSpeed;//velocidad del desplazador
	public float tileSizeZ;//Tamaño de la baldosa Z.

	private Vector3 startPosition;
	
	void Start () 
	{
		startPosition = transform.position;//guarde la posicion inicial
	}
	
	// Update is called once per frame
	void Update () 
	{
		float newPosition = Mathf.Repeat (Time.time * scrollerSpeed, tileSizeZ);//repita durante este tiempo de velocidad este tamaño
		transform.position = startPosition + Vector3.forward * newPosition;//de la posicion incial + hacia adelante la nueva posicion
	}
}
