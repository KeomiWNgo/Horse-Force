using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int damage;


    public void SetDamage (int dmg)
    {

        damage = dmg;
    
    }




    private void Start()
    {
        transform.position = FindAnyObjectByType<AttackButton>().transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.25f, gameObject.transform.position.z);
    }
}
