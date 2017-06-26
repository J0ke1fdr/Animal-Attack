using UnityEngine;
using System.Collections;

public class weaponChangeButton : MonoBehaviour {

    public WeaponManager weaponManager;

	public void OnClick()
    {
        weaponManager.SendMessage("OnChangeButtonClick");
    }
}
