using UnityEngine;
using System.Collections;


public class ControlAndroid : MonoBehaviour
{

    float angulo = 0;
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public int eleccion = 1;
    int toactivate = 0;
    public Transform toparent;
    bool nueva = false;
    bool rotar = true;
    GameObject[] figura = new GameObject[360];

    // public int interfaz=0; //0 para teclado, 1 para telefono
    // Update is called once per frame
    void Update()
    {

        if (rotar)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                /*if (nueva)
                {
                    borrarfigura();
                    nueva = false;
                    rotar = true;
                }
                Vector3 p = this.transform.position;

                GameObject o = null;
                switch (eleccion)
                {
                    case 1:
                        o = (GameObject)Object.Instantiate(prefab, p, Quaternion.Euler(0.0f, angulo, 0.0f)); break;
                    case 2:
                        o = (GameObject)Object.Instantiate(prefab2, p, Quaternion.Euler(0.0f, angulo, 0.0f)); break;
                    case 3:
                        o = (GameObject)Object.Instantiate(prefab3, p, Quaternion.Euler(0.0f, angulo, 0.0f)); break;
                }
                if (o != null)
                {
                    //o.transform.parent = this.transform.parent;
                    o.transform.parent = toparent;
                    angulo = angulo + 0.5f;
                    if (angulo == 360)
                        rotar = false;
                }*/
                if (toactivate < 360)
                {
                    figura[toactivate++].SetActive(true);
                }
            }
        }

        if (!isActiveAndEnabled)
            return;

        int nbTouches = Input.touchCount;

        if (nbTouches > 0)
        {
            /* if (nueva)
             {
                 borrarfigura();
                 nueva = false;
                 rotar = true;
             }

             if (rotar == true)
             {
                 for (int i = 0; i < nbTouches; i++)
                 {
                     Touch touch = Input.GetTouch(i);

                     Vector3 p = this.transform.position;

                     GameObject o = null;
                     switch (eleccion)
                     {
                         case 1:
                             o = (GameObject)Object.Instantiate(prefab, p, Quaternion.Euler(0.0f, angulo, 0.0f)); break;
                         case 2:
                             o = (GameObject)Object.Instantiate(prefab2, p, Quaternion.Euler(0.0f, angulo, 0.0f)); break;
                         case 3:
                             o = (GameObject)Object.Instantiate(prefab3, p, Quaternion.Euler(0.0f, angulo, 0.0f)); break;
                     }

                     if (o != null)
                     {


                         //o.transform.parent = this.transform.parent;
                         o.transform.parent = toparent;
                         angulo = angulo + 0.5f;

                     if (angulo == 360)
                         rotar=false;
                     }

                 }
             }*/

            if (toactivate < 360)
            {
                figura[toactivate++].SetActive(true);
            }
        }
    }

    public void setEleccion(int sel)
    {
        if (sel < 1 || sel > 3)
            return;
        if (eleccion != sel)
        {
            borrarfigura();
            eleccion = sel;
            nueva = true;
            rotar = true;
            angulo = 0;
            Vector3 p = this.transform.position;
            for (int n = 0; n < 360; n++)
            {
                switch (eleccion)
                {
                    case 1:
                        figura[n] = (GameObject)Object.Instantiate(prefab, p, Quaternion.Euler(0.0f, angulo, 0.0f));
                        break;
                    case 2:
                        figura[n] = (GameObject)Object.Instantiate(prefab2, p, Quaternion.Euler(0.0f, angulo, 0.0f));
                        break;

                    case 3:
                        figura[n] = (GameObject)Object.Instantiate(prefab3, p, Quaternion.Euler(0.0f, angulo, 0.0f));
                       break;
                }

                figura[n].transform.parent = toparent;
                figura[n].SetActive(false);
                angulo = angulo + 1;
            }
            toactivate = 1;
            figura[0].SetActive(true);

        }

    }

    void borrarfigura()
    {
        for (int i = 0; i < toparent.childCount; i++)
        {
            Destroy(toparent.GetChild(i).gameObject);
        }
    }
}
