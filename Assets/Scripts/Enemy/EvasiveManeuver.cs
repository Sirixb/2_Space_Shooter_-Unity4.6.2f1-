using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour
{
	public Done_Boundary boundary;
	public float tilt;//Inclinacion
	public float dodge;//Esquivar
	public float smoothing;//Suavizado

	public Vector2 startWait;//tiempo de espera para hacer comenzar las actividades de maniobra.
	public Vector2 maneuverTime;//duraccion de la maniobra.
	public Vector2 maneuverWait;//espera entre una maniobra y otra.
	
	private float currentSpeed;//velocidad actual
	private float targetManeuver;//objetivo de la maniobra

	void Start () 
	{
		currentSpeed = rigidbody.velocity.z;//guarda la velocidad actual de la nave
		StartCoroutine (Evade());//Una co-rutina es una función que puede suspender su ejecución (yield:rendimiento) hasta que los dados dados YieldInstruction hayan acabado.
	}
	
	IEnumerator Evade()//Reguladores de maniobras
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));//Regula espera para realizar actividades de maniobra.
		while (true) 
		{
			//Mathf.Sign: Devuelve el signo o valor de f .Retorna 1 o cero cuando f es positivo, -1 cuando f es negativo.
			targetManeuver = Random.Range (1, dodge * -Mathf.Sign (transform.position.x)) ;//rango para moverse en el eje X. Mathf.sign me ayuda a que los enemigos vallan al lado contrario.
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));//Regula la duracion de la maniobra en ejecucion.
			targetManeuver = 0;//se asigna a cero para una nueva ubicacion de nave enemiga por vuelta en el while. 
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));//Regula la duracion de una maniobra a otra.
		}
	}

	void FixedUpdate ()//Comportamientos de maniobra
	{
		/*Mathf.MoveTowardas: Mueve un valor actual hacia un nuevo destino.
		Current corriente El valor actual.Target objetivo	El valor de avanzar hacia.Maxdelta	El cambio máximo que se debe aplicar al valor.*/
		float newManeuver = Mathf.MoveTowards (rigidbody.velocity.x, targetManeuver, smoothing * Time.deltaTime);// condiciones de comportamiento de eje X. Deltatime: metros por segundo y no metros por trama.
		//Desplazamiento
		rigidbody.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);//Comportamiento en eje x,y,z.
		//Posicionamiento limites del escenario
		rigidbody.position = new Vector3
			(
				Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		//Inclinacion
		rigidbody.rotation = Quaternion.Euler (0, 0, rigidbody.velocity.x * -tilt);
	}
}//cierre de monoBehaviour