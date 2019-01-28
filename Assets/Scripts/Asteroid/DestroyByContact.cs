using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;//Explosion de Asteroides y nave enemiga
	public GameObject playerExplosion;//Explosion jugador
	public int scoreValue;
	private GameController gameController;//sirve para almacenar un componente
	//private GameObject eliminaExplosion;//Declaracion propia :D

	void Start()
	{
		//Permite llamar la funcion de addscore,gameover del script GameController
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");//en el script de ejemplo aparece diferente
		if(gameControllerObject != null)//si lo encontro
		{
			gameController= gameControllerObject.GetComponent <GameController>();
		}
		if(gameControllerObject == null)
		{
			Debug.Log("Cannot find 'GameController' script");		
		}
	}
	void eliminarExplosiones()//Mi primera funcion propia :D
	{
		//Mi primer codigo propio :D
		GameObject eliminaExplosion= GameObject.FindWithTag("Explosiones");
		Destroy(eliminaExplosion,0.5F);
	}
	void OnTriggerEnter(Collider other)//se llama cuando otro Colisionador entra en el gatillo.
	{
		//evita que el objeto que lo poseea no elimine el collider del Boundary y que entre enemigos se eliminen.
		if (other.tag == "Boundary" || other.tag == "Enemy" ) 
		{
			return;
		}
		if (explosion != null)//este if no estaba // Si explosion no esta vacia explote.
		{
			Instantiate(explosion, transform.position, transform.rotation);//Instancia la explosion de los peligros.
			eliminarExplosiones();// mi creacion para limpiar escenario
		}
		if (other.tag == "Player") // efectos de explosion del jugador y funcion Game Over.
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation); //Instancia la explosion del jugador.
			eliminarExplosiones();//mi creacion para limpiar escenario
			gameController.GameOver();
		}
		gameController.AddScore (scoreValue);
		Destroy(other.gameObject);//Destruye el otro objeto.
		Destroy (gameObject);//Se destruye asi mismo.
	}
}
