using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject[] hazards;
	//public GameObject hazard; cuando es una sola amenaza
	public Vector3 spawnValues;//valores de desove
	public int hazardCount;//cuantos peligros
	public float spawnWait;//espera de desove
	public float startWait;//inicio de desove
	public float waveWait;// espera de onda

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());//La ejecución de una co-rutina se puede pausar en cualquier momento mediante la sentencia rendimiento: yield.
	}

	void Update()
	{
		if (restart)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()//funcion ondas de desove, leer StartCoroutine en la parte superior.
	{
		yield return new WaitForSeconds (startWait);//yield:rendimiento -El valor de retorno especifica el rendimiento cuando se reanuda la co-rutina., startwait:espera de onda
		while(true)
		{
			for (int i=0; i < hazardCount; i++) 
			{
				GameObject hazard= hazards[Random.Range(0,hazards.Length)];//vector aleatorio para varias amenzas
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;//Q.i: permite la alineacion del objeto
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);//espera de desove = 0.5.
			}
			yield return new WaitForSeconds(waveWait);//espera de onda = 4.
			if(gameOver)
			{
				//restartText.text= "Press 'R' for Restart";
				restartText.text= "Presiona 'R' para Reiniciar";
				restart=true;
				break;
			}
		}
	}
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore()
	{
		//scoreText.text = "Score: " + score;
		scoreText.text = "Puntaje: " + score;
	}
	public void GameOver()
	{
		//gameOverText.text = "Game Over!";
		gameOverText.text = "Juego Terminado!";
		gameOver = true;
	}
}
