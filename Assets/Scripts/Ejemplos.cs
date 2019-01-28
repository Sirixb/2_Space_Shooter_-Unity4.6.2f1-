using UnityEngine;
using System.Collections;

public class Ejemplos : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Example ();
	}
	void Example() 
	{
		Debug.Log(Mathf.Sign(-10));//devuelve -1
		Debug.Log(Mathf.Sign(10));// devuelve 1
	}
	// Update is called once per frame
	void Update () {
	
	}
}
//NO OLVIDE LA BASURA QUE QUEDA CUANDO EXPLOTAN LOS ASTEROIDES Y LAS NAVES