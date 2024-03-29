using UnityEngine;
using System.Collections;


namespace UME
{
    [AddComponentMenu("UME/Triggers/CreateTrigger")]
    public class CreateTrigger : BaseTrigger {
		
		public Vector2 offset;
		public GameObject[] CollisionSpawnObjects;
		public bool unlimited = true;
		private bool m_objCreated = false;

		public override void Initialize () {
			m_objCreated = false;
		}

		public override void Activate(Collider2D other)
		{
			if  (CollisionSpawnObjects[Random.Range(0,CollisionSpawnObjects.Length)] !=null){
				if (m_objCreated == false || unlimited == true){
					Vector3 createPos = new Vector3 (gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y, gameObject.transform.position.z); 
					Instantiate (CollisionSpawnObjects [Random.Range (0, CollisionSpawnObjects.Length)], createPos, Quaternion.identity);
					m_objCreated = true;

				}
			}
			

		}
	}
}