using UnityEngine;
using System.Collections;

public class BoundaryFog : MonoBehaviour
{
	public float distToFoggyBound;
	//holder for last fog factor. Just incase we go above maxHeight and it becomes negative
	public float prevFogFactor; 
	public PlayerController player;
	//holder for max player altitude
	public float maxHeight;
	//the fog density factor
	public float fogFactor;

	//public PlayerController player;



	void Start ()
	{
		RenderSettings.fog = true;
		maxHeight = player.maxPlayerAltitude;

		if (Application.loadedLevel == 2) {
			RenderSettings.fogColor = Color.green;
		}
		if (Application.loadedLevel == 3) {
			RenderSettings.fogColor = Color.red;
		}
		if (Application.loadedLevel == 4) {
			RenderSettings.fogColor = Color.yellow;
		}
	}

	void Update ()
	{

			fogFactor = (maxHeight + 2000 - player.transform.position.y);


		//fogFactor = (maxHeight + 200 - player.transform.position.y) * 2;
		//Debug.Log (maxHeight - player.transform.position.y);

		//if we're below max altitude, calculate new fog factor
		//else, use the previous one
		if (fogFactor > 0) {

			RenderSettings.fogEndDistance = fogFactor;
			prevFogFactor = fogFactor;
		}else {
			RenderSettings.fogEndDistance = prevFogFactor;
		}
	}
}
