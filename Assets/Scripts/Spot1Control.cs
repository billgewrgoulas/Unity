using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot1Control : MonoBehaviour
{
    private Vector3 a;
	public GameObject player;
	
    void Start()
    {
        //mainCam = Camera.main;
        //Debug.Log("1");
        //x.SetActive(true);
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        this.enabled = false;
        //Debug.Log("waiting");
        player = GameObject.Find("/GameObject");
        //GetNCloseWindow s = GetComponent<GetNCloseWindow>();
        GetNCloseWindow s = player.GetComponent<GetNCloseWindow>();
        //int x = s.E;
        //Debug.Log("x is: " + s.E);
        yield return new WaitUntil(() => s.E >= 1);
        //Debug.Log("Cube has size");
        //InitializeWorld(s.X);
        //Debug.Log("Cube was initialized");
        this.enabled = true;
    }

    void LateUpdate()
    {
        player = GameObject.Find("/GameObject");
        //GetNCloseWindow s = GetComponent<GetNCloseWindow>();
        GetNCloseWindow s = player.GetComponent<GetNCloseWindow>();
        a = s.spot1;
        //Debug.Log("a is : " + a);
        //offset = offset + a;
        this.transform.position = a;
        this.enabled = false;
    }
}
