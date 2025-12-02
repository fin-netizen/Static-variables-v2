using JetBrains.Annotations;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static int playerhealth = 2;
    Rigidbody rb;
    float xvel, yvel, zvel;
    public Transform respawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerhealth++;
        LevelManager.instance.Setplayerhealth(3);
    }

    // Update is called once per frame
    void Update()
    {
         
        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;
        zvel = rb.linearVelocity.z;
        if (Input.GetKey("a"))
        {
            xvel = -5;
        }
        if (Input.GetKey("d"))
        {
            xvel = 5;
        }
        if (Input.GetKey("w"))
        {
            zvel = 5;
        }
        if (Input.GetKey("s"))
        {
            zvel = -5;
        }

       
        rb.linearVelocity = new Vector3(xvel, yvel, zvel);
        if (LevelManager.instance.GetPlayerHealth() <= 0)
        {
            RespawnPlayer();
            playerhealth = 3;
        }
        
    }
    void RespawnPlayer()
    {
        transform.position = respawnPoint.position;
        rb.linearVelocity = new Vector2(0, 0);


    }
    private void OnGUI()
    {
        //read variable from LevelManager singleton
        int Health = LevelManager.instance.GetPlayerHealth();

        string text = "Player health: " + Health;

        text += "\nBe careful of enemies";

        // define debug text area
        GUI.contentColor = Color.white;
        GUILayout.BeginArea(new Rect(10f, 10f, 1600f, 1600f));
        GUILayout.Label($"<size=24>{text}</size>");
        GUILayout.EndArea();
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("the players health is now " + playerhealth);
    }

}
