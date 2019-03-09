using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour {

    public static float fadeTimer;

    public Camera mainCamera;
	public GameObject keySettingUI;
    public GameObject settingUI;
    public YukariControler yukaCon;

	public bool settingOpenFlag = false;

    // Use this for initialization
    void Start () {
        keySettingUI.SetActive(false);
		settingUI.SetActive (false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void keySettingOpen()
    {
        keySettingUI.SetActive(true);
		settingOpenFlag = true;
    }

	public void SettingOpen()
	{
		settingUI.SetActive (true);
		settingOpenFlag = true;
	}

    public void RedBackGround()
    {
        mainCamera.backgroundColor = Color.red;
    }

    public void BlueBackGround()
    {
        mainCamera.backgroundColor = Color.blue;
    }

    public void GreenBackGround()
    {
        mainCamera.backgroundColor = Color.green;
    }

    public void fadeTimeChange()
    {
        yukaCon.fadeValue = yukaCon.fadeslider.value;
    }

	public void SaveButton()
	{
		SaveData.SetClass<PlayerData> (PlayerDataManager.playerDataKey, PlayerDataManager.instance.playerData);
		SaveData.Save ();
	}

    public void CharaCreate()
    {
        /*//各種初期設定
        Model = Instantiate(Resources.Load("Model/yukari")) as GameObject;

        if (Model.GetComponent<Animator>() == null)
        {
            anim = Model.AddComponent<Animator>();
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Motion/YukariMotion/00_Yukari");
        }
        else
        {
            anim = Model.GetComponent<Animator>();
            if (anim.runtimeAnimatorController == null)
            {
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Motion/YukariMotion/00_Yukari");
            }
        }

        if (windowCon == null)
        {
            windowCon = this.GetComponent<myWindowController>();
        }

        Init();*/
    }
}
