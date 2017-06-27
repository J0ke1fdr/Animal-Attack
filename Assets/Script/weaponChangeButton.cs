using UnityEngine;
using System.Collections;

public class weaponChangeButton : MonoBehaviour
{
    //public WeaponManager weaponManager;
    public PlayerStatus playerStatus;

    public void OnClick()
    {
        //weaponManager.SendMessage("OnChangeButtonClick");
        playerStatus.SendMessage("OnChangeButtonClick");
    }
}