using UnityEngine;
using System.Collections;

public class weaponChangeButton : MonoBehaviour
{
    //public WeaponManager weaponManager;
    private PlayerStatusfixed playerStatus;

    private void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatusfixed>();
    }

    public void OnClick()
    {
        //weaponManager.SendMessage("OnChangeButtonClick");
        playerStatus.SendMessage("OnChangeButtonClick");
    }
}