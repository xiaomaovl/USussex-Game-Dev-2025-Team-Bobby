using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float xRange = 2f;
    public float zRange = 0.5f;
    public GameObject centre;
    public GameObject selfPrefab;

    private void Start()
    {
        centre = GameObject.Find("EnemyCentre");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            float x = Random.Range(centre.transform.position.x - xRange, centre.transform.position.x + xRange);
            float z = Random.Range(centre.transform.position.z - zRange, centre.transform.position.x + zRange);
            GameObject g = Instantiate(selfPrefab);
            g.transform.position = new Vector3 (x, this.transform.position.y, z);
            Destroy(this.gameObject);
            //:3
        }
    }
}
