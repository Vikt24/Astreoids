using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManeger : MonoBehaviour
{
    public GameObject astreoid, center;
    private Vector3 enemySpawn;
    public float radius, killradius, slow, fast, spawntime;

    public void Start()
    {
        StartCoroutine(Enemyspawn());
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

    Vector3 GetRandomPos()
    {
        Vector3 pos = Random.insideUnitCircle.normalized;
        pos *= radius;
        pos += center.transform.position;

        return (pos);
    }

    Astreoid AddAstreoid( Vector3 pos)
    {
        GameObject newAstreoid = Instantiate(astreoid, pos, Quaternion.FromToRotation(Vector3.up, (center.transform.position - pos)), gameObject.transform);
        Astreoid astreoidScript = newAstreoid.GetComponent<Astreoid>();
        astreoidScript.SpawnManeger = this;
        astreoidScript.center = center;
        astreoidScript.speed = Random.Range(slow, fast);
        astreoidScript.transform.Rotate(Vector3.forward, Random.Range(45.0f, -45.0f));
        return astreoidScript;
    }

}
