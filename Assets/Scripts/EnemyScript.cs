using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody rb;
    float xvel, yvel, zvel;
    public static int enemyCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        yvel = rb.linearVelocity.y;
        xvel = rb.linearVelocity.x;
        zvel = rb.linearVelocity.z;
        rb.linearVelocity = new Vector3(xvel, yvel, zvel);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LevelManager.instance.HealthModefier(-1);
            LevelManager.instance.SetHighScore(+100); 
        }
    }
    public EnemyScript()
    {
        enemyCount++; 
    }

}
