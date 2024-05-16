using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    
    public int Life, Maxlife =2;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        Life = Maxlife;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //function to call when the player atack find this collider
    public void GetHit(int Damage) 
    {
        Debug.Log("chamou  GetHit");
        Life -= Damage;
       
        if (Life<=0) 
        {
            isDead = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(gameObject,2f);
        }
        
        
    }

}
