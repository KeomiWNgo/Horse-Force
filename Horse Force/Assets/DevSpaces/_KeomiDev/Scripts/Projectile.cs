using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int damage;


    public void SetDamage (int dmg)
    {

        damage = dmg;
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HasHealthComp"))
        {
            Debug.Log("Hit");

            Health healthOfTarget;

            healthOfTarget = other.gameObject.GetComponent<Health>();

            healthOfTarget.currhealth = healthOfTarget.currhealth - damage;

            Destroy(gameObject);
        }
       
    }


    private void Start()
    {
        transform.position = FindAnyObjectByType<AttackButton>().transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 50f * Time.deltaTime, gameObject.transform.position.z);
    }
}

