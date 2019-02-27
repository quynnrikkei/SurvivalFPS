using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBowScript : MonoBehaviour
{

    private Rigidbody myrb;

    public float speed = 30f;

    public float decative_Timer = 3f;

    public float damage = 50f;

    private void Awake()
    {
        myrb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {
        Invoke("DecativeGameObject", decative_Timer);
    }

    public void Launch(Camera mainCamera)
    {
        myrb.velocity = mainCamera.transform.forward * speed;
        transform.LookAt(transform.position + myrb.velocity);
    }

    void DecativeGameObject()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider tagret)
    {
        if(tagret.tag == Tags.ENEMY_TAG)
        {
            tagret.GetComponent<HealthScript>().ApplyDamage(damage);

            gameObject.SetActive(false);
        }
    }
}
