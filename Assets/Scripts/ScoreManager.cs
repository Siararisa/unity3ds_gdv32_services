using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //[SerializeField]
    public int score;

    //METHOD 1: Simplest implementation of Singleton Design Pattern
    /*
    public static ScoreManager instance;

    public void Awake()
    {
        //Debug.Log("This is called first before start.");

        //There should only be one instance of the class in the game
        if(instance != null) //if this is true, there is already an existing instance
        {
            Destroy(gameObject);//since there is already an instance, destroy this gameobject to ensure there are no other copies in  the game
        }
        else//if no instance
        {
            instance = this;//set ourself as the instance
            //Make sure the singleton persists
            DontDestroyOnLoad(gameObject);
        }
    }*/

    //METHOD 2: A better approach for Singleton Design Pattern
    private static ScoreManager instance = null;
    public static ScoreManager Instance
    {
        get
        {
            //there is still no instance in our game
            if (instance == null)
            {
                //Check if there is an existing game object in the scene that has the component
                instance = FindObjectOfType<ScoreManager>();
                //did not find any gameobject with the instance in the heirarchy
                if (instance == null)
                {
                    //generate our own instance by creating a new gameobject
                    GameObject go = new GameObject();
                    //change the default name
                    go.name = "ScoreManager";
                    //add component and set it as the instance
                    instance = go.AddComponent<ScoreManager>();
                    //make sure the object persists
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        //set the instance if no copy in the heirarchy
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //if there is copy, destroy
            Destroy(gameObject);
        }
    }


    public void OnEnable()
    {
        //Debug.Log("everytime the object is set active-d");
    }



    public void Start()
    {
       // Debug.Log("This is called before the first frame of the update");
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public int GetScore() { return score; }
}
