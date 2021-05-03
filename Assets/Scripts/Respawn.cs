using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float hold = -5;
    private GetNCloseWindow s;    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        this.enabled = false;
        s = GetComponent<GetNCloseWindow>();
        yield return new WaitUntil(() => s.E >= 1);
        this.enabled = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < hold)
        {
            GameObject m = GameObject.Find("/GameObject");
            s = m.GetComponent<GetNCloseWindow>();
            Vector3 a = s.X1;
            s.AddLifes();
            transform.position = a;
            this.enabled = false;
        }
		if(transform.position.y>0){

            /*GameObject m = GameObject.Find("/GameObject");
            GetNCloseWindow s = m.GetComponent<GetNCloseWindow>();
            if (s.E != 0)
            {
            }*/
            this.enabled = true;
        }
    }
}
