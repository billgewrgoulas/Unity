using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harvesting : MonoBehaviour
{
    public Material m_Cube;
    Color s;
    int[] eikonikoi = new int[5];
    int[] diathesimoi = new int[5];

    private GameObject Cylinder;
    // Start is called before the first frame update
    void Start()
    {
        m_Cube = GetComponent<Renderer>().material;
        s = m_Cube.color;
    }

    // Update is called once per frame
    void Update()
    {
        /*GetNCloseWindow q = GameObject.Find("/GameObject").GetComponent<GetNCloseWindow>();
        if (q.E == 0)
        {
            this.enabled = false;
        }*/
    }
    void OnMouseDown()
    {

        if (s == Color.magenta)
        {
            Debug.Log("kalws");
        }
        else
        {
            //Debug.Log("33");
            GameObject test = GameObject.Find("/FPSController");
            GameObject m = GameObject.Find("/GameObject");
            GetNCloseWindow s = m.GetComponent<GetNCloseWindow>();
            int r = (int)Mathf.Round(test.transform.position.x);
            int z = (int)Mathf.Round(test.transform.position.y);
            int w = (int)Mathf.Round(test.transform.position.z);
            Vector3 f;
            f.x = r; f.y = z; f.z = w;//pairnoume thn akribh thesh pou briskomaste
            Vector3 a = f + test.transform.forward;
            Collider[] exists = Physics.OverlapSphere(a, 0.01f);//blepoume an uparxei kubos h kulindros mprosta mas
            if (exists.Length != 0)
            {
                Debug.Log("physics");
                Destroy(gameObject);
            }
        }
    }
    void OnMouseEnter()
    {
        s = m_Cube.color;
        eikonikoi = GameObject.Find("/GameObject").GetComponent<GetNCloseWindow>().eikonikoiKuboi;
        if (s == Color.yellow)
        {
            if (eikonikoi[0] != 0)
            {
                m_Cube.color = Color.white;
            }
            else
            {
                m_Cube.color = Color.black;
            }
        }
        else if (s == Color.red)
        {
            if (eikonikoi[1] != 0)
            {
                m_Cube.color = Color.white;
            }
            else
            {
                m_Cube.color = Color.black;
            }
        }
        else if (s == Color.green)
        {
            if (eikonikoi[2] != 0)
            {
                m_Cube.color = Color.white;
            }
            else
            {
                m_Cube.color = Color.black;
            }
        }
        else if (s == Color.cyan)
        {
            if (eikonikoi[4] != 0)
            {
                m_Cube.color = Color.white;
            }
            else
            {
                m_Cube.color = Color.black;
            }
        }
        else
        {
            m_Cube.color = Color.black;
        }
    }
    void OnMouseOver()
    {
        eikonikoi = GameObject.Find("/GameObject").GetComponent<GetNCloseWindow>().eikonikoiKuboi;
        diathesimoi = GameObject.Find("/GameObject").GetComponent<GetNCloseWindow>().diathEikonKuboi;
        GetNCloseWindow q = GameObject.Find("/GameObject").GetComponent<GetNCloseWindow>();
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (s == Color.yellow)
            {
                if ((eikonikoi[0]) != 0)
                {
                    eikonikoi[0]--;
                    diathesimoi[0]++;
                    q.AddScore(5);
                }
                else
                {
                    m_Cube.color = Color.black;
                }
            }
            else if (s == Color.red)
            {
                if ((eikonikoi[1]) != 0)
                {
                    eikonikoi[1]--;
                    diathesimoi[1]++;
                    q.AddScore(5);
                }
                else
                {
                    m_Cube.color = Color.black;
                }
            }
            else if (s == Color.green)
            {
                if ((eikonikoi[2]) != 0)
                {
                    eikonikoi[2]--;
                    diathesimoi[2]++;
                    q.AddScore(5);
                }
                else
                {
                    m_Cube.color = Color.black;
                }
            }
            else if (s == Color.cyan)
            {
                if ((eikonikoi[4]) != 0)
                {
                    eikonikoi[4]--;
                    diathesimoi[4]++;
                    q.AddScore(5);
                    Destroy(gameObject);
                }
                else
                {
                    m_Cube.color = Color.black;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            int x = Random.Range(0, diathesimoi.Length);//tuxaia epilogh gia to ti tha mpei
            Debug.Log("x is: " + x);
            GameObject Cube_B = GameObject.Find("/GameObject").GetComponent<GetNCloseWindow>().Cube;
            GameObject test = GameObject.Find("/FPSController");
            GameObject m = GameObject.Find("/GameObject");
            GetNCloseWindow s = m.GetComponent<GetNCloseWindow>();
            int meg = s.X;
            int r = (int)Mathf.Round(test.transform.position.x);
            int z = (int)Mathf.Round(test.transform.position.y);
            int w = (int)Mathf.Round(test.transform.position.z);
            Vector3 f;
            f.x = r; f.y = z; f.z = w;//pairnoume thn akribh thesh pou briskomaste
            Vector3 a = f + test.transform.forward;
            Collider[] exists = Physics.OverlapSphere(a, 0.01f);//blepoume an mporoume na baloume kubo h kulindro mprosta mas
            while (exists.Length != 0)
            {
                Debug.Log("physics");
                a.y += 1.0f;
                exists = Physics.OverlapSphere(a, 0.01f);
                if (a.y > meg)
                {
                    x = 5;
                    break;
                }
            }
            if (x == 0)
            {
                if (diathesimoi[x] != 0)
                {
                    GameObject go = Instantiate(Cube_B, a, Quaternion.identity) as GameObject;
                    go.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    s.AddScore(-10);
                    diathesimoi[x]--;
                }
            }
            else if (x == 1)
            {
                if (diathesimoi[x] != 0)
                {
                    GameObject go = Instantiate(Cube_B, a, Quaternion.identity) as GameObject;
                    go.GetComponent<MeshRenderer>().material.color = Color.red;
                    s.AddScore(-10);
                    diathesimoi[x]--;
                }
            }
            else if (x == 2)
            {
                if (diathesimoi[x] != 0)
                {
                    GameObject go = Instantiate(Cube_B, a, Quaternion.identity) as GameObject;
                    go.GetComponent<MeshRenderer>().material.color = Color.green;
                    s.AddScore(-10);
                    diathesimoi[x]--;
                }
            }
            else if (x == 4)
            {
                if (diathesimoi[x] != 0)
                {
                    Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    Cylinder.AddComponent<Rigidbody>();
                    Cylinder.transform.position = a;
                    s.AddScore(-10);
                    diathesimoi[x]--;
                }
            }
        }

    }

    void OnMouseExit()
    {
        m_Cube.color = s;
    }
}
