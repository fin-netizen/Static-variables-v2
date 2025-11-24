using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int PlayerHealth;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("do not destroy");
        }
        else
        {
            print("do destroy");
            Destroy(gameObject);
        }
    }


    //these methods are globally accessible
    public void Setplayerhealth(int health)
    {
        PlayerHealth = health;
    }
    public int GetPlayerHealth()
    {
        return PlayerHealth;
    }
    public void HealthModefier(int amount)
    {
        PlayerHealth += amount;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
