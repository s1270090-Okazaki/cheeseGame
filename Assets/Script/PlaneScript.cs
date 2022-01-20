using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneScript : MonoBehaviour
{
    public GameObject Plane;
    public static bool moving = true;

    GameObject[] step = new GameObject[10];
    float speed = 10;
    float disappear = -7;
    float respawn = 20;

    void Start()
    {
        //StartCoroutine(InitStep());
        moving = true;
        InitStep();
        //for (int i = 0; i < step.Length + 10; i++)
        //{
        //    if (i < 10) { }
        //    else step[i] = Instantiate(Plane, new Vector3(Random.Range(-3, 3), 6 * i, 0), Quaternion.identity);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            for (int i = 0; i < step.Length; i++)
            {
                step[i].gameObject.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                if (step[i].gameObject.transform.position.y < disappear)
                {
                    ChangeScale(i);
                    step[i].gameObject.transform.position = new Vector3(Random.Range(-3, 3), respawn, 0);
                    if (speed <= 25) speed += Time.deltaTime;
                }
            }
        }
    }

    void ChangeScale(int i)
    {
        int x = (i + 9) % 10;
        if(step[x].transform.localScale.x < 0.5 && step[x].transform.localScale.y < 0.5)
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(Random.Range(1,2), Random.Range(1,2), 0);
        }
        else if(step[x].transform.localScale.x > 2 || step[x].transform.localScale.y > 3)
        {
            step[i].transform.localScale = step[x].transform.localScale - new Vector3(Random.Range(1,2), Random.Range(1, 2), 0);
        }
        else
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(Random.Range(0,1), Random.Range(0,1), 0);
        }
    }

    //IEnumerator Wait()
    //{
    //    Debug.Log("please wait");
    //    yield return new WaitForSeconds(3);
    //    Debug.Log("Let's start!!!");
    //    InitStep();
    //}

    public void InitStep()
    {
        //yield return new WaitForSeconds(3);
        for (int i = 0; i < step.Length; i++)
        {
            if(i == 0) step[i] = Instantiate(Plane, new Vector3(Random.Range(-3, 3), 6, 0), Quaternion.identity);
            else if (i < 3) step[i] = Instantiate(Plane, new Vector3(Random.Range(-3, 3), 5 * i, 0), Quaternion.identity);
            else step[i] = Instantiate(Plane, new Vector3(Random.Range(-3, 3), 3 * i, 0), Quaternion.identity);
        }
    }
}