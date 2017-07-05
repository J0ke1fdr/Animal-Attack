using UnityEngine;
using System.Collections;

public class RoleManager : MonoBehaviour
{
    // Use this for initialization

    public GameObject[] roles;
    public Transform buildPlace;

    private void Awake()
    {
        int playerIndex = PlayerPrefs.GetInt("PlayerIndex", 0);
        GameObject player = Instantiate(roles[playerIndex], buildPlace.position, buildPlace.rotation) as GameObject;
        player.name = "Player";

        Time.timeScale = 1;
    }
}