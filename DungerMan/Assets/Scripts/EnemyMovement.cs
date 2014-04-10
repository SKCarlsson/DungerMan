using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	private NavMeshAgent agent;
	GameObject player;
	float dist = 0;

	void Start() {
		player = GameObject.Find ("Cube");
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
