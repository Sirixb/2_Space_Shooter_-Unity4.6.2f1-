using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;//tasa de fuego
	public float delay;//retraso
	
	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);//Invoca el método methodName en tiempo segundos, luego repetidamente cada repeatRate segundos.
	}
	
	void Fire ()// es llamado por "Fire" arriba
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		audio.Play();//reproduce el audioclip adjuntado
	}
}
