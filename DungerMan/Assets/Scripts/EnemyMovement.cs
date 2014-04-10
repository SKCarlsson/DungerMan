using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	//private NavMeshAgent agent;
	GameObject player = GameObject.Find ("Cube");
	GameObject player2 = GameObject.Find ("Cylinder");


	float dist = 0;

	void Start() {
		dist = Vector2.Distance(player.transform.position, player2.transform.position);

	//agent = GetComponent<NavMeshAgent>();

	}
	void Update() {



		print (dist);
		//RaycastHit hit;

			//agent.SetDestination(player.transform.position);
		/*
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
				print (hit.point);
			
		}*/
	}
}
