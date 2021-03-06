﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
  public int lifeSpan = 300;
    public bool StopProjectileOnAnyCollision;
  private int time = 0;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    time++;
    if (time == lifeSpan)
    {
      Destroy(gameObject);
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    foreach (ContactPoint contact in collision.contacts)
    {
      Debug.DrawRay(contact.point, contact.normal, Color.white);
    }
    if (StopProjectileOnAnyCollision || collision.gameObject.tag == "Wall")
    {
      GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
      GetComponent<SphereCollider>().enabled = false;
    }
    else {
      GetComponent<Rigidbody>().useGravity = true;
    }


        
  }
}
