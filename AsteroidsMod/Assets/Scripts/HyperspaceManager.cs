using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HyperspaceManager : MonoBehaviour
{
    public int currentArena = 1;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            currentArena++;
            if (currentArena > 4)
            {
                currentArena = 1;
            }
            Invoke("ArenaSwitcher", 1.5f);
        }

        
    }

    private void ArenaSwitcher()
    {
        if (currentArena == 1)
        {
            player1.layer = 6;
            player2.layer = 7;
            player3.layer = 7;
            player4.layer = 7;
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }
        else if (currentArena == 2)
        {
            player1.layer = 7;
            player2.layer = 6;
            player3.layer = 7;
            player4.layer = 7;
            camera1.SetActive(false);
            camera2.SetActive(true);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }
        else if(currentArena == 3)
        {
            player1.layer = 7;
            player2.layer = 7;
            player3.layer = 6;
            player4.layer = 7;
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(true);
            camera4.SetActive(false);
        }
        else
        {
            player1.layer = 7;
            player2.layer = 7;
            player3.layer = 7;
            player4.layer = 6;
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(true);
        }
    }


    

}
