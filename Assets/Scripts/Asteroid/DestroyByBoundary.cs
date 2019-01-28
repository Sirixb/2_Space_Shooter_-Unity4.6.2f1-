using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit(Collider other)//se llama cuando el otro Colisionador ha dejado de tocar el gatillo.
	{
		Destroy(other.gameObject);
	}
}
