using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject terrain;
    private GameObject camera;
    private Transform pose;

    private float offset = 32f;
    private float zTerrain = -26f;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        NewTerrain();
        NewTerrain();
        NewTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, camera.transform.position.z - 10);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        print("enter");
        if(other.tag == "Terrain")
        {
            Destroy(other.gameObject);

            NewTerrain();
        }
    }

    private void NewTerrain()
    {
        //pose.position = new Vector3(0, 0, zTerrain);
        //pose.rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(terrain, new Vector3(0, -11, zTerrain), new Quaternion(0, 0, 0, 0));
        zTerrain += offset;
    }
}

