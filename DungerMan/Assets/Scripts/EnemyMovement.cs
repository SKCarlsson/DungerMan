using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	private NavMeshAgent agent;
	GameObject player;
	GameObject player2;
	//Vector3 p1 = player.transform.position, p2 = player2.transform.position;


	// HEY YO BRAAAAAAAH

	float dist = 2;

	void Start() {
		player = GameObject.Find ("Cube");
		player2 = GameObject.Find ("Cylinder");
		agent = GetComponent<NavMeshAgent>();
	
	}
	void Update() {
		dist = Vector2.Distance(this.transform.position, player.transform.position);


		print (dist);
		//RaycastHit hit;
		if(dist<5){
			agent.SetDestination(player.transform.position);
		}

		/*if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
				print (hit.point);
			
		}*/
	}
}
