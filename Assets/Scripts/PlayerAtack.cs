using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    public int Damage;
    public Transform CircleOrigin;
    public float radius,AtckCD = 0.5f,AtckTimer =0f;
    public bool canAtack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkTime();
        if (Input.GetKeyDown(KeyCode.Space) && canAtack) 
        {
            Atack();
            canAtack = false;
            AtckTimer = 0;
        }
    }

    //function of the player atack
    void Atack() 
    {
        
            foreach (Collider2D collider in Physics2D.OverlapCircleAll(CircleOrigin.position, radius))
            {
                //check if it's a hit object with the tag
                if (collider.gameObject.CompareTag("Hits"))
                {
                    collider.GetComponent<EnemyParent>().GetHit(Damage);
                    Debug.Log(collider.name);
                }

            }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = CircleOrigin ==null?Vector3.zero:CircleOrigin.position;
        Gizmos.DrawSphere(position, radius);
    }
    void checkTime() 
    {
        if (AtckTimer <= AtckCD) 
        {
            AtckTimer += Time.deltaTime;
        }else
        {
            canAtack = true;
        }
    }
}

