using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSetting : UICanvas {

	public UICanvas parentUI;

	public GameObject Yukari;
	public GameObject Maki;
	public GameObject Akane;
	public GameObject Aoi;

    [SerializeField]
    private GameObject selectObj;

	[SerializeField]
	private GameObject charaStatus;

	public Text SelectObjName;
	public Text activeControllText;

	public InputField XPosInput;
	public InputField YPosInput;
	public InputField ZPosInput;
	public InputField scaleInput;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable()
	{
		init ();
	}

	public void init()
	{
		selectObj = null;
		charaStatus.SetActive (false);
	}

	public void Back()
	{		
		parentUI.settingOpenFlag = false;
		this.gameObject.SetActive(false);
	}

	public void SaveAndBack()
	{
		PlayerDataManager.instance.playerData.yukariPosX = (double)Yukari.transform.position.x;
		PlayerDataManager.instance.playerData.yukariPosY = (double)Yukari.transform.position.y;
		PlayerDataManager.instance.playerData.yukariPosZ = (double)Yukari.transform.position.z;
		PlayerDataManager.instance.playerData.yukariScale = (double)Yukari.transform.localScale.x;

		PlayerDataManager.instance.playerData.MakiPosX = (double)Maki.transform.position.x;
		PlayerDataManager.instance.playerData.MakiPosY = (double)Maki.transform.position.y;
		PlayerDataManager.instance.playerData.MakiPosZ = (double)Maki.transform.position.z;
		PlayerDataManager.instance.playerData.MakiScale = (double)Maki.transform.localScale.x;

		PlayerDataManager.instance.playerData.AkanePosX = (double)Akane.transform.position.x;
		PlayerDataManager.instance.playerData.AkanePosY = (double)Akane.transform.position.y;
		PlayerDataManager.instance.playerData.AkanePosZ = (double)Akane.transform.position.z;
		PlayerDataManager.instance.playerData.AkaneScale = (double)Akane.transform.localScale.x;

		PlayerDataManager.instance.playerData.AoiPosX = (double)Aoi.transform.position.x;
		PlayerDataManager.instance.playerData.AoiPosY = (double)Aoi.transform.position.y;
		PlayerDataManager.instance.playerData.AoiPosZ = (double)Aoi.transform.position.z;
		PlayerDataManager.instance.playerData.AoiScale = (double)Aoi.transform.localScale.x;

		SaveData.SetClass<PlayerData> (PlayerDataManager.playerDataKey, PlayerDataManager.instance.playerData);
		SaveData.Save ();
		parentUI.settingOpenFlag = false;
		this.gameObject.SetActive(false);
	}

	public void ActiveControll()
	{
		selectObj.SetActive (selectObj.activeSelf ? false : true);

		if (selectObj == Yukari) {
			PlayerDataManager.instance.playerData.YukariFlag = selectObj.activeSelf;
		} else if (selectObj == Maki) {
			PlayerDataManager.instance.playerData.MakiFlag = selectObj.activeSelf;
		} else if (selectObj == Akane) {
			PlayerDataManager.instance.playerData.AkaneFlag = selectObj.activeSelf;
		} else if (selectObj == Aoi) {
			PlayerDataManager.instance.playerData.AoiFlag = selectObj.activeSelf;
		}

		activeControllText.text = selectObj.activeSelf ? "状態：表示中" : "状態：非表示中";
	}

	public void SummonYukari()
	{
		selectObj = Yukari;
		SelectObjName.text = "ゆかり";
		if (!charaStatus.activeSelf) {
			charaStatus.SetActive (true);
		}

		XPosInput.text = selectObj.transform.position.x.ToString("f2");
		YPosInput.text = selectObj.transform.position.y.ToString("f2");
		ZPosInput.text = selectObj.transform.position.z.ToString();
		scaleInput.text = selectObj.transform.localScale.x.ToString("f2");

        activeControllText.text = selectObj.activeSelf ? "状態：表示中" : "状態：非表示中";
    }

	public void SummonMaki()
	{
		selectObj = Maki;
		SelectObjName.text = "マキ";
		if (!charaStatus.activeSelf) {
			charaStatus.SetActive (true);
		}

		XPosInput.text = selectObj.transform.position.x.ToString("f2");
		YPosInput.text = selectObj.transform.position.y.ToString("f2");
		ZPosInput.text = selectObj.transform.position.z.ToString();
		scaleInput.text = selectObj.transform.localScale.x.ToString("f2");

        activeControllText.text = selectObj.activeSelf ? "状態：表示中" : "状態：非表示中";
    }

	public void SummonAkane()
	{
		selectObj = Akane;
		SelectObjName.text = "茜";
		if (!charaStatus.activeSelf) {
			charaStatus.SetActive (true);
		}

		XPosInput.text = selectObj.transform.position.x.ToString("f2");
		YPosInput.text = selectObj.transform.position.y.ToString("f2");
		ZPosInput.text = selectObj.transform.position.z.ToString();
		scaleInput.text = selectObj.transform.localScale.x.ToString("f2");

        activeControllText.text = selectObj.activeSelf ? "状態：表示中" : "状態：非表示中";
    }

	public void SummonAoi()
	{
		selectObj = Aoi;
		SelectObjName.text = "葵";
		if (!charaStatus.activeSelf) {
			charaStatus.SetActive (true);
		}

		XPosInput.text = selectObj.transform.position.x.ToString("f2");
		YPosInput.text = selectObj.transform.position.y.ToString("f2");
		ZPosInput.text = selectObj.transform.position.z.ToString();
		scaleInput.text = selectObj.transform.localScale.x.ToString("f2");

        activeControllText.text = selectObj.activeSelf ? "状態：表示中" : "状態：非表示中";
    }

	public void ChangePosExcute()
	{
		float Xpos = float.Parse (XPosInput.text);
		float Ypos = float.Parse (YPosInput.text);
		float Zpos = float.Parse (ZPosInput.text);
		float scale = float.Parse (scaleInput.text);
		selectObj.transform.position = new Vector3 (Xpos, Ypos, Zpos);
		selectObj.transform.localScale = new Vector3(scale, scale, 1);
	}
}
