using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManeger : MonoBehaviour
{
    public GameObject astreoid1, astreoid2, center;
    public float radius, killradius, slow, fast, spawntime, dificultyIncrease;
    private float size;
    private int type;

    public void Start()
    {
        StartCoroutine(Enemyspawn());
        StartCoroutine(Dificulty());
    }

    IEnumerator Enemyspawn()
    {
        while (true)
        {
            Vector3 pos = GetRandomPos();
            AddAstreoid(pos);
            yield return new WaitForSeconds(spawntime);
        }
    }
    IEnumerator Dificulty()
    {
        while (true)
        {
            spawntime -= dificultyIncrease;
            yield return new WaitForSeconds(5);
        }
    }

    Vector3 GetRandomPos()
    {
        Vector3 pos = Random.insideUnitCircle.normalized;
        pos *= radius;
        pos += center.transform.position;

        return (pos);
    }

    Astreoid AddAstreoid(Vector3 pos)
    {
        type = Random.Range(1, 5);
        GameObject newAstreoid;
        //Choses wich type of astreoid
        if (type == 1)
            newAstreoid = Instantiate(astreoid2, pos, Quaternion.FromToRotation(Vector3.up, (center.transform.position - pos)), gameObject.transform);
        else
            newAstreoid = Instantiate(astreoid1, pos, Quaternion.FromToRotation(Vector3.up, (center.transform.position - pos)), gameObject.transform);

        //Gives the astreoid the stats nessesary
        Astreoid astreoidScript = newAstreoid.GetComponent<Astreoid>();
        astreoidScript.SpawnManeger = this;
        astreoidScript.center = center;
        astreoidScript.speed = Random.Range(slow, fast);
        astreoidScript.transform.Rotate(Vector3.forward, Random.Range(45.0f, -45.0f));
        size = Random.Range(0.25f, 1.5f);
        astreoidScript.transform.localScale = new Vector3(size, size, 1);
        return astreoidScript;
    }

}
