using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //public GameObject player;

    //private Vector3 offset;

    private Vector3 a;
    private Rigidbody rb;
    //private bool q = true;
    //private var player : GameObject;

    void Start()
    {
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        this.enabled = false;
        GetNCloseWindow s = GetComponent<GetNCloseWindow>();
        yield return new WaitUntil(() => s.E >= 1);
        this.enabled = true;
    }

    void FixedUpdate()
    {
        GetNCloseWindow s = GetComponent<GetNCloseWindow>();
        a = s.X1;
        transform.position = a;
        this.enabled = false;
    }

}
