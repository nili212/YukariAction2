using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityRawInput;

public class YukariControler : MonoBehaviour {

    public GameObject Yukari;
    public GameObject Maki;
    public GameObject Akane;
    public GameObject Aoi;

	public GameObject firstHitObj;

    [SerializeField]
    public GameObject[] Model = new GameObject[4] { null, null, null, null};
    [SerializeField]
    public Animator[] anim = new Animator[4] { null, null, null, null};

    //private myWindowController windowCon;

    public List<string> motionNameList;

    #region パレット1
    public string QkeyMotionName;
	public string WkeyMotionName;
	public string EkeyMotionName;
	public string RkeyMotionName;
	public string TkeyMotionName;
	public string YkeyMotionName;
	public string UkeyMotionName;
	public string IkeyMotionName;
	public string OkeyMotionName;
	public string PkeyMotionName;
    public string AkeyMotionName;
    public string SkeyMotionName;
    public string DkeyMotionName;
    public string FkeyMotionName;
    public string GkeyMotionName;
    public string HkeyMotionName;
    public string JkeyMotionName;
    public string KkeyMotionName;
    public string LkeyMotionName;
    public string ZkeyMotionName;
    public string XkeyMotionName;
    public string CkeyMotionName;
    public string VkeyMotionName;
    public string BkeyMotionName;
    public string NkeyMotionName;
    public string MkeyMotionName;
    #endregion

    #region パレット2
    public string ShiftQkeyMotionName;
	public string ShiftWkeyMotionName;
	public string ShiftEkeyMotionName;
	public string ShiftRkeyMotionName;
	public string ShiftTkeyMotionName;
	public string ShiftYkeyMotionName;
	public string ShiftUkeyMotionName;
	public string ShiftIkeyMotionName;
	public string ShiftOkeyMotionName;
	public string ShiftPkeyMotionName;
	public string ShiftAkeyMotionName;
	public string ShiftSkeyMotionName;
	public string ShiftDkeyMotionName;
	public string ShiftFkeyMotionName;
	public string ShiftGkeyMotionName;
	public string ShiftHkeyMotionName;
	public string ShiftJkeyMotionName;
	public string ShiftKkeyMotionName;
	public string ShiftLkeyMotionName;
	public string ShiftZkeyMotionName;
	public string ShiftXkeyMotionName;
	public string ShiftCkeyMotionName;
	public string ShiftVkeyMotionName;
	public string ShiftBkeyMotionName;
	public string ShiftNkeyMotionName;
	public string ShiftMkeyMotionName;
    #endregion

    #region パレット3
    public string CtrlQkeyMotionName;
	public string CtrlWkeyMotionName;
	public string CtrlEkeyMotionName;
	public string CtrlRkeyMotionName;
	public string CtrlTkeyMotionName;
	public string CtrlYkeyMotionName;
	public string CtrlUkeyMotionName;
	public string CtrlIkeyMotionName;
	public string CtrlOkeyMotionName;
	public string CtrlPkeyMotionName;
	public string CtrlAkeyMotionName;
	public string CtrlSkeyMotionName;
	public string CtrlDkeyMotionName;
	public string CtrlFkeyMotionName;
	public string CtrlGkeyMotionName;
	public string CtrlHkeyMotionName;
	public string CtrlJkeyMotionName;
	public string CtrlKkeyMotionName;
	public string CtrlLkeyMotionName;
	public string CtrlZkeyMotionName;
	public string CtrlXkeyMotionName;
	public string CtrlCkeyMotionName;
	public string CtrlVkeyMotionName;
	public string CtrlBkeyMotionName;
	public string CtrlNkeyMotionName;
	public string CtrlMkeyMotionName;
    #endregion

    #region パレット4
    public string AltQkeyMotionName;
	public string AltWkeyMotionName;
	public string AltEkeyMotionName;
	public string AltRkeyMotionName;
	public string AltTkeyMotionName;
	public string AltYkeyMotionName;
	public string AltUkeyMotionName;
	public string AltIkeyMotionName;
	public string AltOkeyMotionName;
	public string AltPkeyMotionName;
	public string AltAkeyMotionName;
	public string AltSkeyMotionName;
	public string AltDkeyMotionName;
	public string AltFkeyMotionName;
	public string AltGkeyMotionName;
	public string AltHkeyMotionName;
	public string AltJkeyMotionName;
	public string AltKkeyMotionName;
	public string AltLkeyMotionName;
	public string AltZkeyMotionName;
	public string AltXkeyMotionName;
	public string AltCkeyMotionName;
	public string AltVkeyMotionName;
	public string AltBkeyMotionName;
	public string AltNkeyMotionName;
	public string AltMkeyMotionName;
    #endregion

    public enum SelectPalette
    {
        pallete1 = 0,
        pallete2,
        pallete3,
        pallete4,
    }
    public SelectPalette nowPalette = SelectPalette.pallete1;

    public UICanvas _UICanvas;
    public float fadeValue = 0f;
    public Slider fadeslider;
    public Text fadevalueText;

	bool hitting;
	Vector3 offset = Vector3.zero;

    void Awake()
    {
        //セットしているモデルとモーションを読み込む
        GameObject[] setModels = new GameObject[4] { Yukari, Maki, Akane, Aoi };
        Model = setModels;

        Animator[] setAnimModels = new Animator[4] { Model[0].GetComponent<Animator>(), Model[1].GetComponent<Animator>(), Model[2].GetComponent<Animator>(), Model[3].GetComponent<Animator>() };
        anim = setAnimModels;

        //各種初期設定
        for (int i = 0; i < 4; i++)
        {
            if (Model[i].GetComponent<Animator>() == null)
            {
                anim[i] = Model[i].AddComponent<Animator>();
                anim[i].runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Motion/YukariMotion/00_Yukari");
            }
            else
            {
                anim[i] = Model[i].GetComponent<Animator>();
                if (anim[i].runtimeAnimatorController == null)
                {
                    anim[i].runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Motion/YukariMotion/00_Yukari");
                }
            }

            Model[i].SetActive(false);
        }

        /*if (windowCon == null)
        {
            windowCon = this.GetComponent<myWindowController>();
        }*/
    }

    public void Init()
    {
		motionNameList.Clear();

		//キャラON/OFF設定名前登録
		motionNameList.Add("YukariActive");
		motionNameList.Add("MakiActive");
		motionNameList.Add("AkaneActive");
		motionNameList.Add("AoiActive");

		//順次にアニメーションクリップからリストを作成していく
		for(int i = 0; i < anim.Length; i++)
		{
			for (int j = 0; j < anim[i].runtimeAnimatorController.animationClips.Length; j++)
	        {
				if (anim[i].runtimeAnimatorController.animationClips[j].name != "Idle")
	                motionNameList.Add(anim[i].runtimeAnimatorController.animationClips[j].name);
	        }
		}

		QkeyMotionName = PlayerDataManager.instance.playerData.QkeyMotionName;
		WkeyMotionName = PlayerDataManager.instance.playerData.WkeyMotionName;
		EkeyMotionName = PlayerDataManager.instance.playerData.EkeyMotionName;
		RkeyMotionName = PlayerDataManager.instance.playerData.RkeyMotionName;
		TkeyMotionName = PlayerDataManager.instance.playerData.TkeyMotionName;
		YkeyMotionName = PlayerDataManager.instance.playerData.YkeyMotionName;
		UkeyMotionName = PlayerDataManager.instance.playerData.UkeyMotionName;
		IkeyMotionName = PlayerDataManager.instance.playerData.IkeyMotionName;
		OkeyMotionName = PlayerDataManager.instance.playerData.OkeyMotionName;
		PkeyMotionName = PlayerDataManager.instance.playerData.PkeyMotionName;
		AkeyMotionName = PlayerDataManager.instance.playerData.AkeyMotionName;
		SkeyMotionName = PlayerDataManager.instance.playerData.SkeyMotionName;
		DkeyMotionName = PlayerDataManager.instance.playerData.DkeyMotionName;
		FkeyMotionName = PlayerDataManager.instance.playerData.FkeyMotionName;
		GkeyMotionName = PlayerDataManager.instance.playerData.GkeyMotionName;
		HkeyMotionName = PlayerDataManager.instance.playerData.HkeyMotionName;
		JkeyMotionName = PlayerDataManager.instance.playerData.JkeyMotionName;
		KkeyMotionName = PlayerDataManager.instance.playerData.KkeyMotionName;
		LkeyMotionName = PlayerDataManager.instance.playerData.LkeyMotionName;
		ZkeyMotionName = PlayerDataManager.instance.playerData.ZkeyMotionName;
		XkeyMotionName = PlayerDataManager.instance.playerData.XkeyMotionName;
		CkeyMotionName = PlayerDataManager.instance.playerData.CkeyMotionName;
		VkeyMotionName = PlayerDataManager.instance.playerData.VkeyMotionName;
		BkeyMotionName = PlayerDataManager.instance.playerData.BkeyMotionName;
		NkeyMotionName = PlayerDataManager.instance.playerData.NkeyMotionName;
		MkeyMotionName = PlayerDataManager.instance.playerData.MkeyMotionName;

		ShiftQkeyMotionName = PlayerDataManager.instance.playerData.ShiftQkeyMotionName;
		ShiftWkeyMotionName = PlayerDataManager.instance.playerData.ShiftWkeyMotionName;
		ShiftEkeyMotionName = PlayerDataManager.instance.playerData.ShiftEkeyMotionName;
		ShiftRkeyMotionName = PlayerDataManager.instance.playerData.ShiftRkeyMotionName;
		ShiftTkeyMotionName = PlayerDataManager.instance.playerData.ShiftTkeyMotionName;
		ShiftYkeyMotionName = PlayerDataManager.instance.playerData.ShiftYkeyMotionName;
		ShiftUkeyMotionName = PlayerDataManager.instance.playerData.ShiftUkeyMotionName;
		ShiftIkeyMotionName = PlayerDataManager.instance.playerData.ShiftIkeyMotionName;
		ShiftOkeyMotionName = PlayerDataManager.instance.playerData.ShiftOkeyMotionName;
		ShiftPkeyMotionName = PlayerDataManager.instance.playerData.ShiftPkeyMotionName;
		ShiftAkeyMotionName = PlayerDataManager.instance.playerData.ShiftAkeyMotionName;
		ShiftSkeyMotionName = PlayerDataManager.instance.playerData.ShiftSkeyMotionName;
		ShiftDkeyMotionName = PlayerDataManager.instance.playerData.ShiftDkeyMotionName;
		ShiftFkeyMotionName = PlayerDataManager.instance.playerData.ShiftFkeyMotionName;
		ShiftGkeyMotionName = PlayerDataManager.instance.playerData.ShiftGkeyMotionName;
		ShiftHkeyMotionName = PlayerDataManager.instance.playerData.ShiftHkeyMotionName;
		ShiftJkeyMotionName = PlayerDataManager.instance.playerData.ShiftJkeyMotionName;
		ShiftKkeyMotionName = PlayerDataManager.instance.playerData.ShiftKkeyMotionName;
		ShiftLkeyMotionName = PlayerDataManager.instance.playerData.ShiftLkeyMotionName;
		ShiftZkeyMotionName = PlayerDataManager.instance.playerData.ShiftZkeyMotionName;
		ShiftXkeyMotionName = PlayerDataManager.instance.playerData.ShiftXkeyMotionName;
		ShiftCkeyMotionName = PlayerDataManager.instance.playerData.ShiftCkeyMotionName;
		ShiftVkeyMotionName = PlayerDataManager.instance.playerData.ShiftVkeyMotionName;
		ShiftBkeyMotionName = PlayerDataManager.instance.playerData.ShiftBkeyMotionName;
		ShiftNkeyMotionName = PlayerDataManager.instance.playerData.ShiftNkeyMotionName;
		ShiftMkeyMotionName = PlayerDataManager.instance.playerData.ShiftMkeyMotionName;

        CtrlQkeyMotionName = PlayerDataManager.instance.playerData.CtrlQkeyMotionName;
        CtrlWkeyMotionName = PlayerDataManager.instance.playerData.CtrlWkeyMotionName;
        CtrlEkeyMotionName = PlayerDataManager.instance.playerData.CtrlEkeyMotionName;
        CtrlRkeyMotionName = PlayerDataManager.instance.playerData.CtrlRkeyMotionName;
        CtrlTkeyMotionName = PlayerDataManager.instance.playerData.CtrlTkeyMotionName;
        CtrlYkeyMotionName = PlayerDataManager.instance.playerData.CtrlYkeyMotionName;
        CtrlUkeyMotionName = PlayerDataManager.instance.playerData.CtrlUkeyMotionName;
        CtrlIkeyMotionName = PlayerDataManager.instance.playerData.CtrlIkeyMotionName;
        CtrlOkeyMotionName = PlayerDataManager.instance.playerData.CtrlOkeyMotionName;
        CtrlPkeyMotionName = PlayerDataManager.instance.playerData.CtrlPkeyMotionName;
        CtrlAkeyMotionName = PlayerDataManager.instance.playerData.CtrlAkeyMotionName;
        CtrlSkeyMotionName = PlayerDataManager.instance.playerData.CtrlSkeyMotionName;
        CtrlDkeyMotionName = PlayerDataManager.instance.playerData.CtrlDkeyMotionName;
        CtrlFkeyMotionName = PlayerDataManager.instance.playerData.CtrlFkeyMotionName;
        CtrlGkeyMotionName = PlayerDataManager.instance.playerData.CtrlGkeyMotionName;
        CtrlHkeyMotionName = PlayerDataManager.instance.playerData.CtrlHkeyMotionName;
        CtrlJkeyMotionName = PlayerDataManager.instance.playerData.CtrlJkeyMotionName;
        CtrlKkeyMotionName = PlayerDataManager.instance.playerData.CtrlKkeyMotionName;
        CtrlLkeyMotionName = PlayerDataManager.instance.playerData.CtrlLkeyMotionName;
        CtrlZkeyMotionName = PlayerDataManager.instance.playerData.CtrlZkeyMotionName;
        CtrlXkeyMotionName = PlayerDataManager.instance.playerData.CtrlXkeyMotionName;
        CtrlCkeyMotionName = PlayerDataManager.instance.playerData.CtrlCkeyMotionName;
        CtrlVkeyMotionName = PlayerDataManager.instance.playerData.CtrlVkeyMotionName;
        CtrlBkeyMotionName = PlayerDataManager.instance.playerData.CtrlBkeyMotionName;
        CtrlNkeyMotionName = PlayerDataManager.instance.playerData.CtrlNkeyMotionName;
        CtrlMkeyMotionName = PlayerDataManager.instance.playerData.CtrlMkeyMotionName;

        AltQkeyMotionName = PlayerDataManager.instance.playerData.AltQkeyMotionName;
        AltWkeyMotionName = PlayerDataManager.instance.playerData.AltWkeyMotionName;
        AltEkeyMotionName = PlayerDataManager.instance.playerData.AltEkeyMotionName;
        AltRkeyMotionName = PlayerDataManager.instance.playerData.AltRkeyMotionName;
        AltTkeyMotionName = PlayerDataManager.instance.playerData.AltTkeyMotionName;
        AltYkeyMotionName = PlayerDataManager.instance.playerData.AltYkeyMotionName;
        AltUkeyMotionName = PlayerDataManager.instance.playerData.AltUkeyMotionName;
        AltIkeyMotionName = PlayerDataManager.instance.playerData.AltIkeyMotionName;
        AltOkeyMotionName = PlayerDataManager.instance.playerData.AltOkeyMotionName;
        AltPkeyMotionName = PlayerDataManager.instance.playerData.AltPkeyMotionName;
        AltAkeyMotionName = PlayerDataManager.instance.playerData.AltAkeyMotionName;
        AltSkeyMotionName = PlayerDataManager.instance.playerData.AltSkeyMotionName;
        AltDkeyMotionName = PlayerDataManager.instance.playerData.AltDkeyMotionName;
        AltFkeyMotionName = PlayerDataManager.instance.playerData.AltFkeyMotionName;
        AltGkeyMotionName = PlayerDataManager.instance.playerData.AltGkeyMotionName;
        AltHkeyMotionName = PlayerDataManager.instance.playerData.AltHkeyMotionName;
        AltJkeyMotionName = PlayerDataManager.instance.playerData.AltJkeyMotionName;
        AltKkeyMotionName = PlayerDataManager.instance.playerData.AltKkeyMotionName;
        AltLkeyMotionName = PlayerDataManager.instance.playerData.AltLkeyMotionName;
        AltZkeyMotionName = PlayerDataManager.instance.playerData.AltZkeyMotionName;
        AltXkeyMotionName = PlayerDataManager.instance.playerData.AltXkeyMotionName;
        AltCkeyMotionName = PlayerDataManager.instance.playerData.AltCkeyMotionName;
        AltVkeyMotionName = PlayerDataManager.instance.playerData.AltVkeyMotionName;
        AltBkeyMotionName = PlayerDataManager.instance.playerData.AltBkeyMotionName;
        AltNkeyMotionName = PlayerDataManager.instance.playerData.AltNkeyMotionName;
        AltMkeyMotionName = PlayerDataManager.instance.playerData.AltMkeyMotionName;

		if (PlayerDataManager.instance.playerData.YukariFlag)
			Yukari.SetActive (true);
		if(PlayerDataManager.instance.playerData.MakiFlag)
			Maki.SetActive (true);
		if(PlayerDataManager.instance.playerData.AkaneFlag)
			Akane.SetActive (true);
		if(PlayerDataManager.instance.playerData.AoiFlag)
			Aoi.SetActive (true);

		Yukari.transform.position = new Vector3 ((float)PlayerDataManager.instance.playerData.yukariPosX,
			(float)PlayerDataManager.instance.playerData.yukariPosY,
			(float)PlayerDataManager.instance.playerData.yukariPosZ);
		Yukari.transform.localScale = new Vector3 ((float)PlayerDataManager.instance.playerData.yukariScale,
			(float)PlayerDataManager.instance.playerData.yukariScale,
			1f);

		Maki.transform.position = new Vector3 ((float)PlayerDataManager.instance.playerData.MakiPosX,
			(float)PlayerDataManager.instance.playerData.MakiPosY,
			(float)PlayerDataManager.instance.playerData.MakiPosZ);
		Maki.transform.localScale = new Vector3 ((float)PlayerDataManager.instance.playerData.MakiScale,
			(float)PlayerDataManager.instance.playerData.MakiScale,
			1f);

		Akane.transform.position = new Vector3 ((float)PlayerDataManager.instance.playerData.AkanePosX,
			(float)PlayerDataManager.instance.playerData.AkanePosY,
			(float)PlayerDataManager.instance.playerData.AkanePosZ);
		Akane.transform.localScale = new Vector3 ((float)PlayerDataManager.instance.playerData.AkaneScale,
			(float)PlayerDataManager.instance.playerData.AkaneScale,
			1f);

		Aoi.transform.position = new Vector3 ((float)PlayerDataManager.instance.playerData.AoiPosX,
			(float)PlayerDataManager.instance.playerData.AoiPosY,
			(float)PlayerDataManager.instance.playerData.AoiPosZ);
		Aoi.transform.localScale = new Vector3 ((float)PlayerDataManager.instance.playerData.AoiScale,
			(float)PlayerDataManager.instance.playerData.AoiScale,
			1f);
    }

	// Use this for initialization
	void Start () {
		//ロード完了待ち
		for(;;)
		{
			if (PlayerDataManager.instance.loadEnd) {
				break;
			}
		}

		Init ();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && firstHitObj == null)
        {
            //マウスの座標
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // クリックしたスクリーン座標をrayに変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Rayの当たったオブジェクトの情報を格納する
            RaycastHit hit = new RaycastHit();
            // オブジェクトにrayが当たった時
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Chara")
                {

                    offset = hit.collider.gameObject.transform.position - mousePos;

                    if (hit.collider.gameObject == Yukari)
                    {
                        Yukari.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, hit.transform.position.z);
                        firstHitObj = Yukari;
                    }
                    else if (hit.collider.gameObject == Maki)
                    {
                        Maki.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, hit.transform.position.z);
                        firstHitObj = Maki;
                    }
                    else if (hit.collider.gameObject == Akane)
                    {
                        Akane.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, hit.transform.position.z);
                        firstHitObj = Akane;
                    }
                    else if (hit.collider.gameObject == Aoi)
                    {
                        Aoi.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, hit.transform.position.z);
                        firstHitObj = Aoi;
                    }
                }
            }
        }
        else if (Input.GetMouseButton(0) && firstHitObj != null)
        {
            //マウスの座標
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            firstHitObj.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, firstHitObj.transform.position.z);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            offset = Vector3.zero;
            firstHitObj = null;
        }

        fadevalueText.text = "フェード時間：" + fadeslider.value.ToString("f3");
    }

    private void OnEnable()
    {
        RawKeyInput.Start(true);
        RawKeyInput.OnKeyDown += keyDownTest;
    }

    // Update is called once per frame
    private void keyDownTest(RawKey key) {
		if(!_UICanvas.settingOpenFlag)
		{
            /*if (Input.GetKeyDown(RawKey.Escape))
	        {
	            windowCon.ChangeWindowBorder();
	        }*/

            if (RawKeyInput.IsKeyDown(RawKey.Numpad1) || RawKeyInput.IsKeyDown(RawKey.N1))
            {
                nowPalette = SelectPalette.pallete1;
            }
            else if (RawKeyInput.IsKeyDown(RawKey.Numpad2) || RawKeyInput.IsKeyDown(RawKey.N2))
            {
                nowPalette = SelectPalette.pallete2;
            }
            else if(RawKeyInput.IsKeyDown(RawKey.Numpad3) || RawKeyInput.IsKeyDown(RawKey.N3))
            {
                nowPalette = SelectPalette.pallete3;
            }
            else if (RawKeyInput.IsKeyDown(RawKey.Numpad4) || RawKeyInput.IsKeyDown(RawKey.N4))
            {
                nowPalette = SelectPalette.pallete4;
            }

            switch (nowPalette)
			{
                case SelectPalette.pallete1:
                    #region 通常時
                    if (RawKeyInput.IsKeyDown(RawKey.F1))
                    {
                        if (_UICanvas.gameObject.activeSelf == true)
                            _UICanvas.gameObject.SetActive(false);
                        else
                            _UICanvas.gameObject.SetActive(true);
                    }

                    if (RawKeyInput.IsKeyDown(RawKey.Q))
                    {
                        if (QkeyMotionName.Contains("Yukari"))
                        {
                            if (QkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(QkeyMotionName, fadeValue);
                        }
                        else if (QkeyMotionName.Contains("Maki"))
                        {
                            if (QkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(QkeyMotionName, fadeValue);
                        }
                        else if (QkeyMotionName.Contains("Akane"))
                        {
                            if (QkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(QkeyMotionName, fadeValue);
                        }
                        else if (QkeyMotionName.Contains("Aoi"))
                        {
                            if (QkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(QkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.W))
                    {
                        if (WkeyMotionName.Contains("Yukari"))
                        {
                            if (WkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(WkeyMotionName, fadeValue);
                        }
                        else if (WkeyMotionName.Contains("Maki"))
                        {
                            if (WkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(WkeyMotionName, fadeValue);
                        }
                        else if (WkeyMotionName.Contains("Akane"))
                        {
                            if (WkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(WkeyMotionName, fadeValue);
                        }
                        else if (WkeyMotionName.Contains("Aoi"))
                        {
                            if (WkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(WkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.E))
                    {
                        if (EkeyMotionName.Contains("Yukari"))
                        {
                            if (EkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(EkeyMotionName, fadeValue);
                        }
                        else if (EkeyMotionName.Contains("Maki"))
                        {
                            if (EkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(EkeyMotionName, fadeValue);
                        }
                        else if (EkeyMotionName.Contains("Akane"))
                        {
                            if (EkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(EkeyMotionName, fadeValue);
                        }
                        else if (EkeyMotionName.Contains("Aoi"))
                        {
                            if (EkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(EkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.R))
                    {
                        if (RkeyMotionName.Contains("Yukari"))
                        {
                            if (RkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(RkeyMotionName, fadeValue);
                        }
                        else if (RkeyMotionName.Contains("Maki"))
                        {
                            if (RkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(RkeyMotionName, fadeValue);
                        }
                        else if (RkeyMotionName.Contains("Akane"))
                        {
                            if (RkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(RkeyMotionName, fadeValue);
                        }
                        else if (RkeyMotionName.Contains("Aoi"))
                        {
                            if (RkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(RkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.T))
                    {
                        if (TkeyMotionName.Contains("Yukari"))
                        {
                            if (TkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(TkeyMotionName, fadeValue);
                        }
                        else if (TkeyMotionName.Contains("Maki"))
                        {
                            if (TkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(TkeyMotionName, fadeValue);
                        }
                        else if (TkeyMotionName.Contains("Akane"))
                        {
                            if (TkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(TkeyMotionName, fadeValue);
                        }
                        else if (TkeyMotionName.Contains("Aoi"))
                        {
                            if (TkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(TkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Y))
                    {
                        if (YkeyMotionName.Contains("Yukari"))
                        {
                            if (YkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(YkeyMotionName, fadeValue);
                        }
                        else if (YkeyMotionName.Contains("Maki"))
                        {
                            if (YkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(YkeyMotionName, fadeValue);
                        }
                        else if (YkeyMotionName.Contains("Akane"))
                        {
                            if (YkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(YkeyMotionName, fadeValue);
                        }
                        else if (YkeyMotionName.Contains("Aoi"))
                        {
                            if (YkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(YkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.U))
                    {
                        if (UkeyMotionName.Contains("Yukari"))
                        {
                            if (UkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(UkeyMotionName, fadeValue);
                        }
                        else if (UkeyMotionName.Contains("Maki"))
                        {
                            if (UkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(UkeyMotionName, fadeValue);
                        }
                        else if (UkeyMotionName.Contains("Akane"))
                        {
                            if (UkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(UkeyMotionName, fadeValue);
                        }
                        else if (UkeyMotionName.Contains("Aoi"))
                        {
                            if (UkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(UkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.I))
                    {
                        if (IkeyMotionName.Contains("Yukari"))
                        {
                            if (IkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(IkeyMotionName, fadeValue);
                        }
                        else if (IkeyMotionName.Contains("Maki"))
                        {
                            if (IkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(IkeyMotionName, fadeValue);
                        }
                        else if (IkeyMotionName.Contains("Akane"))
                        {
                            if (IkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(IkeyMotionName, fadeValue);
                        }
                        else if (IkeyMotionName.Contains("Aoi"))
                        {
                            if (IkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(IkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.O))
                    {
                        if (OkeyMotionName.Contains("Yukari"))
                        {
                            if (OkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(OkeyMotionName, fadeValue);
                        }
                        else if (OkeyMotionName.Contains("Maki"))
                        {
                            if (OkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(OkeyMotionName, fadeValue);
                        }
                        else if (OkeyMotionName.Contains("Akane"))
                        {
                            if (OkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(OkeyMotionName, fadeValue);
                        }
                        else if (OkeyMotionName.Contains("Aoi"))
                        {
                            if (OkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(OkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.P))
                    {
                        if (PkeyMotionName.Contains("Yukari"))
                        {
                            if (PkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(PkeyMotionName, fadeValue);
                        }
                        else if (PkeyMotionName.Contains("Maki"))
                        {
                            if (PkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(PkeyMotionName, fadeValue);
                        }
                        else if (PkeyMotionName.Contains("Akane"))
                        {
                            if (PkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(PkeyMotionName, fadeValue);
                        }
                        else if (PkeyMotionName.Contains("Aoi"))
                        {
                            if (PkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(PkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.A))
                    {
                        if (AkeyMotionName.Contains("Yukari"))
                        {
                            if (AkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AkeyMotionName, fadeValue);
                        }
                        else if (AkeyMotionName.Contains("Maki"))
                        {
                            if (AkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AkeyMotionName, fadeValue);
                        }
                        else if (AkeyMotionName.Contains("Akane"))
                        {
                            if (AkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AkeyMotionName, fadeValue);
                        }
                        else if (AkeyMotionName.Contains("Aoi"))
                        {
                            if (AkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.S))
                    {
                        if (SkeyMotionName.Contains("Yukari"))
                        {
                            if (SkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(SkeyMotionName, fadeValue);
                        }
                        else if (SkeyMotionName.Contains("Maki"))
                        {
                            if (SkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(SkeyMotionName, fadeValue);
                        }
                        else if (SkeyMotionName.Contains("Akane"))
                        {
                            if (SkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(SkeyMotionName, fadeValue);
                        }
                        else if (SkeyMotionName.Contains("Aoi"))
                        {
                            if (SkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(SkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.D))
                    {
                        if (DkeyMotionName.Contains("Yukari"))
                        {
                            if (DkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(DkeyMotionName, fadeValue);
                        }
                        else if (DkeyMotionName.Contains("Maki"))
                        {
                            if (DkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(DkeyMotionName, fadeValue);
                        }
                        else if (DkeyMotionName.Contains("Akane"))
                        {
                            if (DkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(DkeyMotionName, fadeValue);
                        }
                        else if (DkeyMotionName.Contains("Aoi"))
                        {
                            if (DkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(DkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.F))
                    {
                        if (FkeyMotionName.Contains("Yukari"))
                        {
                            if (FkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(FkeyMotionName, fadeValue);
                        }
                        else if (FkeyMotionName.Contains("Maki"))
                        {
                            if (FkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(FkeyMotionName, fadeValue);
                        }
                        else if (FkeyMotionName.Contains("Akane"))
                        {
                            if (FkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(FkeyMotionName, fadeValue);
                        }
                        else if (FkeyMotionName.Contains("Aoi"))
                        {
                            if (FkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(FkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.G))
                    {
                        if (GkeyMotionName.Contains("Yukari"))
                        {
                            if (GkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(GkeyMotionName, fadeValue);
                        }
                        else if (GkeyMotionName.Contains("Maki"))
                        {
                            if (GkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(GkeyMotionName, fadeValue);
                        }
                        else if (GkeyMotionName.Contains("Akane"))
                        {
                            if (GkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(GkeyMotionName, fadeValue);
                        }
                        else if (GkeyMotionName.Contains("Aoi"))
                        {
                            if (GkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(GkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.H))
                    {
                        if (HkeyMotionName.Contains("Yukari"))
                        {
                            if (HkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(HkeyMotionName, fadeValue);
                        }
                        else if (HkeyMotionName.Contains("Maki"))
                        {
                            if (HkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(HkeyMotionName, fadeValue);
                        }
                        else if (HkeyMotionName.Contains("Akane"))
                        {
                            if (HkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(HkeyMotionName, fadeValue);
                        }
                        else if (HkeyMotionName.Contains("Aoi"))
                        {
                            if (HkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(HkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.J))
                    {
                        if (JkeyMotionName.Contains("Yukari"))
                        {
                            if (JkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(JkeyMotionName, fadeValue);
                        }
                        else if (JkeyMotionName.Contains("Maki"))
                        {
                            if (JkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(JkeyMotionName, fadeValue);
                        }
                        else if (JkeyMotionName.Contains("Akane"))
                        {
                            if (JkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(JkeyMotionName, fadeValue);
                        }
                        else if (JkeyMotionName.Contains("Aoi"))
                        {
                            if (JkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(JkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.K))
                    {
                        if (KkeyMotionName.Contains("Yukari"))
                        {
                            if (KkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(KkeyMotionName, fadeValue);
                        }
                        else if (KkeyMotionName.Contains("Maki"))
                        {
                            if (KkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(KkeyMotionName, fadeValue);
                        }
                        else if (KkeyMotionName.Contains("Akane"))
                        {
                            if (KkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(KkeyMotionName, fadeValue);
                        }
                        else if (KkeyMotionName.Contains("Aoi"))
                        {
                            if (KkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(KkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.L))
                    {
                        if (LkeyMotionName.Contains("Yukari"))
                        {
                            if (LkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(LkeyMotionName, fadeValue);
                        }
                        else if (LkeyMotionName.Contains("Maki"))
                        {
                            if (LkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(LkeyMotionName, fadeValue);
                        }
                        else if (LkeyMotionName.Contains("Akane"))
                        {
                            if (LkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(LkeyMotionName, fadeValue);
                        }
                        else if (LkeyMotionName.Contains("Aoi"))
                        {
                            if (LkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(LkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Z))
                    {
                        if (ZkeyMotionName.Contains("Yukari"))
                        {
                            if (ZkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ZkeyMotionName, fadeValue);
                        }
                        else if (ZkeyMotionName.Contains("Maki"))
                        {
                            if (ZkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ZkeyMotionName, fadeValue);
                        }
                        else if (ZkeyMotionName.Contains("Akane"))
                        {
                            if (ZkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ZkeyMotionName, fadeValue);
                        }
                        else if (ZkeyMotionName.Contains("Aoi"))
                        {
                            if (ZkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ZkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.X))
                    {
                        if (XkeyMotionName.Contains("Yukari"))
                        {
                            if (XkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(XkeyMotionName, fadeValue);
                        }
                        else if (XkeyMotionName.Contains("Maki"))
                        {
                            if (XkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(XkeyMotionName, fadeValue);
                        }
                        else if (XkeyMotionName.Contains("Akane"))
                        {
                            if (XkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(XkeyMotionName, fadeValue);
                        }
                        else if (XkeyMotionName.Contains("Aoi"))
                        {
                            if (XkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(XkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.C))
                    {
                        if (CkeyMotionName.Contains("Yukari"))
                        {
                            if (CkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CkeyMotionName, fadeValue);
                        }
                        else if (CkeyMotionName.Contains("Maki"))
                        {
                            if (CkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CkeyMotionName, fadeValue);
                        }
                        else if (CkeyMotionName.Contains("Akane"))
                        {
                            if (CkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CkeyMotionName, fadeValue);
                        }
                        else if (CkeyMotionName.Contains("Aoi"))
                        {
                            if (CkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.V))
                    {
                        if (VkeyMotionName.Contains("Yukari"))
                        {
                            if (VkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(VkeyMotionName, fadeValue);
                        }
                        else if (VkeyMotionName.Contains("Maki"))
                        {
                            if (VkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(VkeyMotionName, fadeValue);
                        }
                        else if (VkeyMotionName.Contains("Akane"))
                        {
                            if (VkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(VkeyMotionName, fadeValue);
                        }
                        else if (VkeyMotionName.Contains("Aoi"))
                        {
                            if (VkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(VkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.B))
                    {
                        if (BkeyMotionName.Contains("Yukari"))
                        {
                            if (BkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(BkeyMotionName, fadeValue);
                        }
                        else if (BkeyMotionName.Contains("Maki"))
                        {
                            if (BkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(BkeyMotionName, fadeValue);
                        }
                        else if (BkeyMotionName.Contains("Akane"))
                        {
                            if (BkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(BkeyMotionName, fadeValue);
                        }
                        else if (BkeyMotionName.Contains("Aoi"))
                        {
                            if (BkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(BkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.N))
                    {
                        if (NkeyMotionName.Contains("Yukari"))
                        {
                            if (NkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(NkeyMotionName, fadeValue);
                        }
                        else if (NkeyMotionName.Contains("Maki"))
                        {
                            if (NkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(NkeyMotionName, fadeValue);
                        }
                        else if (NkeyMotionName.Contains("Akane"))
                        {
                            if (NkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(NkeyMotionName, fadeValue);
                        }
                        else if (NkeyMotionName.Contains("Aoi"))
                        {
                            if (NkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(NkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.M))
                    {
                        if (MkeyMotionName.Contains("Yukari"))
                        {
                            if (MkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(MkeyMotionName, fadeValue);
                        }
                        else if (MkeyMotionName.Contains("Maki"))
                        {
                            if (MkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(MkeyMotionName, fadeValue);
                        }
                        else if (MkeyMotionName.Contains("Akane"))
                        {
                            if (MkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(MkeyMotionName, fadeValue);
                        }
                        else if (MkeyMotionName.Contains("Aoi"))
                        {
                            if (MkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(MkeyMotionName, fadeValue);
                        }
                    }
                    #endregion
                    break;

                case SelectPalette.pallete2:
                    #region シフトキー押下中
                    if (RawKeyInput.IsKeyDown(RawKey.F1))
                    {
                        if (_UICanvas.gameObject.activeSelf == true)
                            _UICanvas.gameObject.SetActive(false);
                        else
                            _UICanvas.gameObject.SetActive(true);
                    }

                    if (RawKeyInput.IsKeyDown(RawKey.Q))
                    {
                        if (ShiftQkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftQkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftQkeyMotionName, fadeValue);
                        }
                        else if (ShiftQkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftQkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftQkeyMotionName, fadeValue);
                        }
                        else if (ShiftQkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftQkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftQkeyMotionName, fadeValue);
                        }
                        else if (ShiftQkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftQkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftQkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.W))
                    {
                        if (ShiftWkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftWkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftWkeyMotionName, fadeValue);
                        }
                        else if (ShiftWkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftWkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftWkeyMotionName, fadeValue);
                        }
                        else if (ShiftWkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftWkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftWkeyMotionName, fadeValue);
                        }
                        else if (ShiftWkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftWkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftWkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.E))
                    {
                        if (ShiftEkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftEkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftEkeyMotionName, fadeValue);
                        }
                        else if (ShiftEkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftEkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftEkeyMotionName, fadeValue);
                        }
                        else if (ShiftEkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftEkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftEkeyMotionName, fadeValue);
                        }
                        else if (ShiftEkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftEkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftEkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.R))
                    {
                        if (ShiftRkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftRkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftRkeyMotionName, fadeValue);
                        }
                        else if (ShiftRkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftRkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftRkeyMotionName, fadeValue);
                        }
                        else if (ShiftRkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftRkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftRkeyMotionName, fadeValue);
                        }
                        else if (ShiftRkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftRkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftRkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.T))
                    {
                        if (ShiftTkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftTkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftTkeyMotionName, fadeValue);
                        }
                        else if (ShiftTkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftTkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftTkeyMotionName, fadeValue);
                        }
                        else if (ShiftTkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftTkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftTkeyMotionName, fadeValue);
                        }
                        else if (ShiftTkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftTkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftTkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Y))
                    {
                        if (ShiftYkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftYkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftYkeyMotionName, fadeValue);
                        }
                        else if (ShiftYkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftYkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftYkeyMotionName, fadeValue);
                        }
                        else if (ShiftYkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftYkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftYkeyMotionName, fadeValue);
                        }
                        else if (ShiftYkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftYkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftYkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.U))
                    {
                        if (ShiftUkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftUkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftUkeyMotionName, fadeValue);
                        }
                        else if (ShiftUkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftUkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftUkeyMotionName, fadeValue);
                        }
                        else if (ShiftUkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftUkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftUkeyMotionName, fadeValue);
                        }
                        else if (ShiftUkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftUkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftUkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.I))
                    {
                        if (ShiftIkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftIkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftIkeyMotionName, fadeValue);
                        }
                        else if (ShiftIkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftIkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftIkeyMotionName, fadeValue);
                        }
                        else if (ShiftIkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftIkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftIkeyMotionName, fadeValue);
                        }
                        else if (ShiftIkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftIkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftIkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.O))
                    {
                        if (ShiftOkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftOkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftOkeyMotionName, fadeValue);
                        }
                        else if (ShiftOkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftOkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftOkeyMotionName, fadeValue);
                        }
                        else if (ShiftOkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftOkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftOkeyMotionName, fadeValue);
                        }
                        else if (ShiftOkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftOkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftOkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.P))
                    {
                        if (ShiftPkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftPkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftPkeyMotionName, fadeValue);
                        }
                        else if (ShiftPkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftPkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftPkeyMotionName, fadeValue);
                        }
                        else if (ShiftPkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftPkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftPkeyMotionName, fadeValue);
                        }
                        else if (ShiftPkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftPkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftPkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.A))
                    {
                        if (ShiftAkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftAkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftAkeyMotionName, fadeValue);
                        }
                        else if (ShiftAkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftAkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftAkeyMotionName, fadeValue);
                        }
                        else if (ShiftAkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftAkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftAkeyMotionName, fadeValue);
                        }
                        else if (ShiftAkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftAkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftAkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.S))
                    {
                        if (ShiftSkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftSkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftSkeyMotionName, fadeValue);
                        }
                        else if (ShiftSkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftSkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftSkeyMotionName, fadeValue);
                        }
                        else if (ShiftSkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftSkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftSkeyMotionName, fadeValue);
                        }
                        else if (ShiftSkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftSkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftSkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.D))
                    {
                        if (ShiftDkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftDkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftDkeyMotionName, fadeValue);
                        }
                        else if (ShiftDkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftDkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftDkeyMotionName, fadeValue);
                        }
                        else if (ShiftDkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftDkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftDkeyMotionName, fadeValue);
                        }
                        else if (ShiftDkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftDkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftDkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.F))
                    {
                        if (ShiftFkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftFkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftFkeyMotionName, fadeValue);
                        }
                        else if (ShiftFkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftFkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftFkeyMotionName, fadeValue);
                        }
                        else if (ShiftFkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftFkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftFkeyMotionName, fadeValue);
                        }
                        else if (ShiftFkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftFkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftFkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.G))
                    {
                        if (ShiftGkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftGkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftGkeyMotionName, fadeValue);
                        }
                        else if (ShiftGkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftGkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftGkeyMotionName, fadeValue);
                        }
                        else if (ShiftGkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftGkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftGkeyMotionName, fadeValue);
                        }
                        else if (ShiftGkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftGkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftGkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.H))
                    {
                        if (ShiftHkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftHkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftHkeyMotionName, fadeValue);
                        }
                        else if (ShiftHkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftHkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftHkeyMotionName, fadeValue);
                        }
                        else if (ShiftHkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftHkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftHkeyMotionName, fadeValue);
                        }
                        else if (ShiftHkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftHkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftHkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.J))
                    {
                        if (ShiftJkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftJkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftJkeyMotionName, fadeValue);
                        }
                        else if (ShiftJkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftJkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftJkeyMotionName, fadeValue);
                        }
                        else if (ShiftJkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftJkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftJkeyMotionName, fadeValue);
                        }
                        else if (ShiftJkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftJkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftJkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.K))
                    {
                        if (ShiftKkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftKkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftKkeyMotionName, fadeValue);
                        }
                        else if (ShiftKkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftKkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftKkeyMotionName, fadeValue);
                        }
                        else if (ShiftKkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftKkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftKkeyMotionName, fadeValue);
                        }
                        else if (ShiftKkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftKkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(KkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.L))
                    {
                        if (ShiftLkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftLkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftLkeyMotionName, fadeValue);
                        }
                        else if (ShiftLkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftLkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftLkeyMotionName, fadeValue);
                        }
                        else if (ShiftLkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftLkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftLkeyMotionName, fadeValue);
                        }
                        else if (ShiftLkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftLkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftLkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Z))
                    {
                        if (ShiftZkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftZkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftZkeyMotionName, fadeValue);
                        }
                        else if (ShiftZkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftZkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftZkeyMotionName, fadeValue);
                        }
                        else if (ShiftZkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftZkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftZkeyMotionName, fadeValue);
                        }
                        else if (ShiftZkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftZkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftZkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.X))
                    {
                        if (ShiftXkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftXkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftXkeyMotionName, fadeValue);
                        }
                        else if (ShiftXkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftXkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftXkeyMotionName, fadeValue);
                        }
                        else if (ShiftXkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftXkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftXkeyMotionName, fadeValue);
                        }
                        else if (ShiftXkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftXkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftXkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.C))
                    {
                        if (ShiftCkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftCkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftCkeyMotionName, fadeValue);
                        }
                        else if (ShiftCkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftCkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftCkeyMotionName, fadeValue);
                        }
                        else if (ShiftCkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftCkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftCkeyMotionName, fadeValue);
                        }
                        else if (ShiftCkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftCkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftCkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.V))
                    {
                        if (ShiftVkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftVkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftVkeyMotionName, fadeValue);
                        }
                        else if (ShiftVkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftVkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftVkeyMotionName, fadeValue);
                        }
                        else if (ShiftVkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftVkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftVkeyMotionName, fadeValue);
                        }
                        else if (ShiftVkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftVkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftVkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.B))
                    {
                        if (ShiftBkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftBkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftBkeyMotionName, fadeValue);
                        }
                        else if (ShiftBkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftBkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftBkeyMotionName, fadeValue);
                        }
                        else if (ShiftBkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftBkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftBkeyMotionName, fadeValue);
                        }
                        else if (ShiftBkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftBkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftBkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.N))
                    {
                        if (ShiftNkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftNkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftNkeyMotionName, fadeValue);
                        }
                        else if (ShiftNkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftNkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftNkeyMotionName, fadeValue);
                        }
                        else if (ShiftNkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftNkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftNkeyMotionName, fadeValue);
                        }
                        else if (ShiftNkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftNkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftNkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.M))
                    {
                        if (ShiftMkeyMotionName.Contains("Yukari"))
                        {
                            if (ShiftMkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ShiftMkeyMotionName, fadeValue);
                        }
                        else if (ShiftMkeyMotionName.Contains("Maki"))
                        {
                            if (ShiftMkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ShiftMkeyMotionName, fadeValue);
                        }
                        else if (ShiftMkeyMotionName.Contains("Akane"))
                        {
                            if (ShiftMkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ShiftMkeyMotionName, fadeValue);
                        }
                        else if (ShiftMkeyMotionName.Contains("Aoi"))
                        {
                            if (ShiftMkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ShiftMkeyMotionName, fadeValue);
                        }
                    }
                    #endregion
                    break;

                case SelectPalette.pallete3:
                    #region 左コントロールキー押下中
                    if (RawKeyInput.IsKeyDown(RawKey.F1))
                    {
                        if (_UICanvas.gameObject.activeSelf == true)
                            _UICanvas.gameObject.SetActive(false);
                        else
                            _UICanvas.gameObject.SetActive(true);
                    }

                    if (RawKeyInput.IsKeyDown(RawKey.Q))
                    {
                        if (CtrlQkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlQkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlQkeyMotionName, fadeValue);
                        }
                        else if (CtrlQkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlQkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlQkeyMotionName, fadeValue);
                        }
                        else if (CtrlQkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlQkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlQkeyMotionName, fadeValue);
                        }
                        else if (CtrlQkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlQkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlQkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.W))
                    {
                        if (CtrlWkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlWkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlWkeyMotionName, fadeValue);
                        }
                        else if (CtrlWkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlWkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlWkeyMotionName, fadeValue);
                        }
                        else if (CtrlWkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlWkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlWkeyMotionName, fadeValue);
                        }
                        else if (CtrlWkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlWkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlWkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.E))
                    {
                        if (CtrlEkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlEkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlEkeyMotionName, fadeValue);
                        }
                        else if (CtrlEkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlEkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlEkeyMotionName, fadeValue);
                        }
                        else if (CtrlEkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlEkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlEkeyMotionName, fadeValue);
                        }
                        else if (CtrlEkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlEkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlEkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.R))
                    {
                        if (CtrlRkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlRkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlRkeyMotionName, fadeValue);
                        }
                        else if (CtrlRkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlRkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlRkeyMotionName, fadeValue);
                        }
                        else if (CtrlRkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlRkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlRkeyMotionName, fadeValue);
                        }
                        else if (CtrlRkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlRkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlRkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.T))
                    {
                        if (CtrlTkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlTkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlTkeyMotionName, fadeValue);
                        }
                        else if (CtrlTkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlTkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlTkeyMotionName, fadeValue);
                        }
                        else if (CtrlTkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlTkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlTkeyMotionName, fadeValue);
                        }
                        else if (CtrlTkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlTkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlTkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Y))
                    {
                        if (CtrlYkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlYkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlYkeyMotionName, fadeValue);
                        }
                        else if (CtrlYkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlYkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlYkeyMotionName, fadeValue);
                        }
                        else if (CtrlYkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlYkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlYkeyMotionName, fadeValue);
                        }
                        else if (CtrlYkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlYkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlYkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.U))
                    {
                        if (CtrlUkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlUkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlUkeyMotionName, fadeValue);
                        }
                        else if (CtrlUkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlUkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlUkeyMotionName, fadeValue);
                        }
                        else if (CtrlUkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlUkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlUkeyMotionName, fadeValue);
                        }
                        else if (CtrlUkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlUkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlUkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.I))
                    {
                        if (CtrlIkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlIkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlIkeyMotionName, fadeValue);
                        }
                        else if (CtrlIkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlIkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlIkeyMotionName, fadeValue);
                        }
                        else if (CtrlIkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlIkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlIkeyMotionName, fadeValue);
                        }
                        else if (CtrlIkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlIkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlIkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.O))
                    {
                        if (CtrlOkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlOkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlOkeyMotionName, fadeValue);
                        }
                        else if (CtrlOkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlOkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlOkeyMotionName, fadeValue);
                        }
                        else if (CtrlOkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlOkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlOkeyMotionName, fadeValue);
                        }
                        else if (CtrlOkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlOkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlOkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.P))
                    {
                        if (CtrlPkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlPkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlPkeyMotionName, fadeValue);
                        }
                        else if (CtrlPkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlPkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlPkeyMotionName, fadeValue);
                        }
                        else if (CtrlPkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlPkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlPkeyMotionName, fadeValue);
                        }
                        else if (CtrlPkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlPkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlPkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.A))
                    {
                        if (CtrlAkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlAkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlAkeyMotionName, fadeValue);
                        }
                        else if (CtrlAkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlAkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlAkeyMotionName, fadeValue);
                        }
                        else if (CtrlAkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlAkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlAkeyMotionName, fadeValue);
                        }
                        else if (CtrlAkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlAkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlAkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.S))
                    {
                        if (CtrlSkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlSkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlSkeyMotionName, fadeValue);
                        }
                        else if (CtrlSkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlSkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlSkeyMotionName, fadeValue);
                        }
                        else if (CtrlSkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlSkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlSkeyMotionName, fadeValue);
                        }
                        else if (CtrlSkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlSkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlSkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.D))
                    {
                        if (CtrlDkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlDkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlDkeyMotionName, fadeValue);
                        }
                        else if (CtrlDkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlDkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlDkeyMotionName, fadeValue);
                        }
                        else if (CtrlDkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlDkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlDkeyMotionName, fadeValue);
                        }
                        else if (CtrlDkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlDkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlDkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.F))
                    {
                        if (CtrlFkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlFkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlFkeyMotionName, fadeValue);
                        }
                        else if (CtrlFkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlFkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlFkeyMotionName, fadeValue);
                        }
                        else if (CtrlFkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlFkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlFkeyMotionName, fadeValue);
                        }
                        else if (CtrlFkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlFkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlFkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.G))
                    {
                        if (CtrlGkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlGkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlGkeyMotionName, fadeValue);
                        }
                        else if (CtrlGkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlGkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlGkeyMotionName, fadeValue);
                        }
                        else if (CtrlGkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlGkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlGkeyMotionName, fadeValue);
                        }
                        else if (CtrlGkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlGkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlGkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.H))
                    {
                        if (CtrlHkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlHkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlHkeyMotionName, fadeValue);
                        }
                        else if (CtrlHkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlHkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlHkeyMotionName, fadeValue);
                        }
                        else if (CtrlHkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlHkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlHkeyMotionName, fadeValue);
                        }
                        else if (CtrlHkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlHkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlHkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.J))
                    {
                        if (CtrlJkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlJkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlJkeyMotionName, fadeValue);
                        }
                        else if (CtrlJkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlJkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlJkeyMotionName, fadeValue);
                        }
                        else if (CtrlJkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlJkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlJkeyMotionName, fadeValue);
                        }
                        else if (CtrlJkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlJkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlJkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.K))
                    {
                        if (CtrlKkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlKkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlKkeyMotionName, fadeValue);
                        }
                        else if (CtrlKkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlKkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlKkeyMotionName, fadeValue);
                        }
                        else if (CtrlKkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlKkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlKkeyMotionName, fadeValue);
                        }
                        else if (CtrlKkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlKkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlKkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.L))
                    {
                        if (CtrlLkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlLkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlLkeyMotionName, fadeValue);
                        }
                        else if (CtrlLkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlLkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlLkeyMotionName, fadeValue);
                        }
                        else if (CtrlLkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlLkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlLkeyMotionName, fadeValue);
                        }
                        else if (CtrlLkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlLkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlLkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Z))
                    {
                        if (CtrlZkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlZkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlZkeyMotionName, fadeValue);
                        }
                        else if (CtrlZkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlZkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlZkeyMotionName, fadeValue);
                        }
                        else if (CtrlZkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlZkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlZkeyMotionName, fadeValue);
                        }
                        else if (CtrlZkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlZkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlZkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.X))
                    {
                        if (CtrlXkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlXkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlXkeyMotionName, fadeValue);
                        }
                        else if (CtrlXkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlXkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlXkeyMotionName, fadeValue);
                        }
                        else if (CtrlXkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlXkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlXkeyMotionName, fadeValue);
                        }
                        else if (CtrlXkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlXkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlXkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.C))
                    {
                        if (CtrlCkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlCkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlCkeyMotionName, fadeValue);
                        }
                        else if (CtrlCkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlCkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlCkeyMotionName, fadeValue);
                        }
                        else if (CtrlCkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlCkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlCkeyMotionName, fadeValue);
                        }
                        else if (CtrlCkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlCkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlCkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.V))
                    {
                        if (CtrlVkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlVkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlVkeyMotionName, fadeValue);
                        }
                        else if (CtrlVkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlVkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlVkeyMotionName, fadeValue);
                        }
                        else if (CtrlVkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlVkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlVkeyMotionName, fadeValue);
                        }
                        else if (CtrlVkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlVkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlVkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.B))
                    {
                        if (CtrlBkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlBkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlBkeyMotionName, fadeValue);
                        }
                        else if (CtrlBkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlBkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlBkeyMotionName, fadeValue);
                        }
                        else if (CtrlBkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlBkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlBkeyMotionName, fadeValue);
                        }
                        else if (CtrlBkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlBkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlBkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.N))
                    {
                        if (CtrlNkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlNkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlNkeyMotionName, fadeValue);
                        }
                        else if (CtrlNkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlNkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlNkeyMotionName, fadeValue);
                        }
                        else if (CtrlNkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlNkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlNkeyMotionName, fadeValue);
                        }
                        else if (CtrlNkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlNkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlNkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.M))
                    {
                        if (CtrlMkeyMotionName.Contains("Yukari"))
                        {
                            if (CtrlMkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CtrlMkeyMotionName, fadeValue);
                        }
                        else if (CtrlMkeyMotionName.Contains("Maki"))
                        {
                            if (CtrlMkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CtrlMkeyMotionName, fadeValue);
                        }
                        else if (CtrlMkeyMotionName.Contains("Akane"))
                        {
                            if (CtrlMkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CtrlMkeyMotionName, fadeValue);
                        }
                        else if (CtrlMkeyMotionName.Contains("Aoi"))
                        {
                            if (CtrlMkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CtrlMkeyMotionName, fadeValue);
                        }
                    }
                    #endregion
                    break;

                case SelectPalette.pallete4:
                    #region 右コントロールキー押下中
                    if (RawKeyInput.IsKeyDown(RawKey.F1))
                    {
                        if (_UICanvas.gameObject.activeSelf == true)
                            _UICanvas.gameObject.SetActive(false);
                        else
                            _UICanvas.gameObject.SetActive(true);
                    }

                    if (RawKeyInput.IsKeyDown(RawKey.Q))
                    {
                        if (AltQkeyMotionName.Contains("Yukari"))
                        {
                            if (AltQkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltQkeyMotionName, fadeValue);
                        }
                        else if (AltQkeyMotionName.Contains("Maki"))
                        {
                            if (AltQkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltQkeyMotionName, fadeValue);
                        }
                        else if (AltQkeyMotionName.Contains("Akane"))
                        {
                            if (AltQkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltQkeyMotionName, fadeValue);
                        }
                        else if (AltQkeyMotionName.Contains("Aoi"))
                        {
                            if (AltQkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltQkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.W))
                    {
                        if (AltWkeyMotionName.Contains("Yukari"))
                        {
                            if (AltWkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltWkeyMotionName, fadeValue);
                        }
                        else if (AltWkeyMotionName.Contains("Maki"))
                        {
                            if (AltWkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltWkeyMotionName, fadeValue);
                        }
                        else if (AltWkeyMotionName.Contains("Akane"))
                        {
                            if (AltWkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltWkeyMotionName, fadeValue);
                        }
                        else if (AltWkeyMotionName.Contains("Aoi"))
                        {
                            if (AltWkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltWkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.E))
                    {
                        if (AltEkeyMotionName.Contains("Yukari"))
                        {
                            if (AltEkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltEkeyMotionName, fadeValue);
                        }
                        else if (AltEkeyMotionName.Contains("Maki"))
                        {
                            if (AltEkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltEkeyMotionName, fadeValue);
                        }
                        else if (AltEkeyMotionName.Contains("Akane"))
                        {
                            if (AltEkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltEkeyMotionName, fadeValue);
                        }
                        else if (AltEkeyMotionName.Contains("Aoi"))
                        {
                            if (AltEkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltEkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.R))
                    {
                        if (AltRkeyMotionName.Contains("Yukari"))
                        {
                            if (AltRkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltRkeyMotionName, fadeValue);
                        }
                        else if (AltRkeyMotionName.Contains("Maki"))
                        {
                            if (AltRkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltRkeyMotionName, fadeValue);
                        }
                        else if (AltRkeyMotionName.Contains("Akane"))
                        {
                            if (AltRkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltRkeyMotionName, fadeValue);
                        }
                        else if (AltRkeyMotionName.Contains("Aoi"))
                        {
                            if (AltRkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltRkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.T))
                    {
                        if (AltTkeyMotionName.Contains("Yukari"))
                        {
                            if (AltTkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltTkeyMotionName, fadeValue);
                        }
                        else if (AltTkeyMotionName.Contains("Maki"))
                        {
                            if (AltTkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltTkeyMotionName, fadeValue);
                        }
                        else if (AltTkeyMotionName.Contains("Akane"))
                        {
                            if (AltTkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltTkeyMotionName, fadeValue);
                        }
                        else if (AltTkeyMotionName.Contains("Aoi"))
                        {
                            if (AltTkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltTkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Y))
                    {
                        if (AltYkeyMotionName.Contains("Yukari"))
                        {
                            if (AltYkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltYkeyMotionName, fadeValue);
                        }
                        else if (AltYkeyMotionName.Contains("Maki"))
                        {
                            if (AltYkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltYkeyMotionName, fadeValue);
                        }
                        else if (AltYkeyMotionName.Contains("Akane"))
                        {
                            if (AltYkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltYkeyMotionName, fadeValue);
                        }
                        else if (AltYkeyMotionName.Contains("Aoi"))
                        {
                            if (AltYkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltYkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.U))
                    {
                        if (AltUkeyMotionName.Contains("Yukari"))
                        {
                            if (AltUkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltUkeyMotionName, fadeValue);
                        }
                        else if (AltUkeyMotionName.Contains("Maki"))
                        {
                            if (AltUkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltUkeyMotionName, fadeValue);
                        }
                        else if (AltUkeyMotionName.Contains("Akane"))
                        {
                            if (AltUkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltUkeyMotionName, fadeValue);
                        }
                        else if (AltUkeyMotionName.Contains("Aoi"))
                        {
                            if (AltUkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltUkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.I))
                    {
                        if (AltIkeyMotionName.Contains("Yukari"))
                        {
                            if (AltIkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltIkeyMotionName, fadeValue);
                        }
                        else if (AltIkeyMotionName.Contains("Maki"))
                        {
                            if (AltIkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltIkeyMotionName, fadeValue);
                        }
                        else if (AltIkeyMotionName.Contains("Akane"))
                        {
                            if (AltIkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltIkeyMotionName, fadeValue);
                        }
                        else if (AltIkeyMotionName.Contains("Aoi"))
                        {
                            if (AltIkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltIkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.O))
                    {
                        if (AltOkeyMotionName.Contains("Yukari"))
                        {
                            if (AltOkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltOkeyMotionName, fadeValue);
                        }
                        else if (AltOkeyMotionName.Contains("Maki"))
                        {
                            if (AltOkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltOkeyMotionName, fadeValue);
                        }
                        else if (AltOkeyMotionName.Contains("Akane"))
                        {
                            if (AltOkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltOkeyMotionName, fadeValue);
                        }
                        else if (AltOkeyMotionName.Contains("Aoi"))
                        {
                            if (AltOkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltOkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.P))
                    {
                        if (AltPkeyMotionName.Contains("Yukari"))
                        {
                            if (AltPkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltPkeyMotionName, fadeValue);
                        }
                        else if (AltPkeyMotionName.Contains("Maki"))
                        {
                            if (AltPkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltPkeyMotionName, fadeValue);
                        }
                        else if (AltPkeyMotionName.Contains("Akane"))
                        {
                            if (AltPkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltPkeyMotionName, fadeValue);
                        }
                        else if (AltPkeyMotionName.Contains("Aoi"))
                        {
                            if (AltPkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltPkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.A))
                    {
                        if (AltAkeyMotionName.Contains("Yukari"))
                        {
                            if (AltAkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltAkeyMotionName, fadeValue);
                        }
                        else if (AltAkeyMotionName.Contains("Maki"))
                        {
                            if (AltAkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltAkeyMotionName, fadeValue);
                        }
                        else if (AltAkeyMotionName.Contains("Akane"))
                        {
                            if (AltAkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltAkeyMotionName, fadeValue);
                        }
                        else if (AltAkeyMotionName.Contains("Aoi"))
                        {
                            if (AltAkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltAkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.S))
                    {
                        if (AltSkeyMotionName.Contains("Yukari"))
                        {
                            if (AltSkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltSkeyMotionName, fadeValue);
                        }
                        else if (AltSkeyMotionName.Contains("Maki"))
                        {
                            if (AltSkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltSkeyMotionName, fadeValue);
                        }
                        else if (AltSkeyMotionName.Contains("Akane"))
                        {
                            if (AltSkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltSkeyMotionName, fadeValue);
                        }
                        else if (AltSkeyMotionName.Contains("Aoi"))
                        {
                            if (AltSkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltSkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.D))
                    {
                        if (AltDkeyMotionName.Contains("Yukari"))
                        {
                            if (AltDkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltDkeyMotionName, fadeValue);
                        }
                        else if (AltDkeyMotionName.Contains("Maki"))
                        {
                            if (AltDkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltDkeyMotionName, fadeValue);
                        }
                        else if (AltDkeyMotionName.Contains("Akane"))
                        {
                            if (AltDkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltDkeyMotionName, fadeValue);
                        }
                        else if (AltDkeyMotionName.Contains("Aoi"))
                        {
                            if (AltDkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltDkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.F))
                    {
                        if (AltFkeyMotionName.Contains("Yukari"))
                        {
                            if (AltFkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltFkeyMotionName, fadeValue);
                        }
                        else if (AltFkeyMotionName.Contains("Maki"))
                        {
                            if (AltFkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltFkeyMotionName, fadeValue);
                        }
                        else if (AltFkeyMotionName.Contains("Akane"))
                        {
                            if (AltFkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltFkeyMotionName, fadeValue);
                        }
                        else if (AltFkeyMotionName.Contains("Aoi"))
                        {
                            if (AltFkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltFkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.G))
                    {
                        if (AltGkeyMotionName.Contains("Yukari"))
                        {
                            if (AltGkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltGkeyMotionName, fadeValue);
                        }
                        else if (AltGkeyMotionName.Contains("Maki"))
                        {
                            if (AltGkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltGkeyMotionName, fadeValue);
                        }
                        else if (AltGkeyMotionName.Contains("Akane"))
                        {
                            if (AltGkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltGkeyMotionName, fadeValue);
                        }
                        else if (AltGkeyMotionName.Contains("Aoi"))
                        {
                            if (AltGkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltGkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.H))
                    {
                        if (AltHkeyMotionName.Contains("Yukari"))
                        {
                            if (AltHkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltHkeyMotionName, fadeValue);
                        }
                        else if (AltHkeyMotionName.Contains("Maki"))
                        {
                            if (AltHkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltHkeyMotionName, fadeValue);
                        }
                        else if (AltHkeyMotionName.Contains("Akane"))
                        {
                            if (AltHkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltHkeyMotionName, fadeValue);
                        }
                        else if (AltHkeyMotionName.Contains("Aoi"))
                        {
                            if (AltHkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltHkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.J))
                    {
                        if (AltJkeyMotionName.Contains("Yukari"))
                        {
                            if (AltJkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltJkeyMotionName, fadeValue);
                        }
                        else if (AltJkeyMotionName.Contains("Maki"))
                        {
                            if (AltJkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltJkeyMotionName, fadeValue);
                        }
                        else if (AltJkeyMotionName.Contains("Akane"))
                        {
                            if (AltJkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltJkeyMotionName, fadeValue);
                        }
                        else if (AltJkeyMotionName.Contains("Aoi"))
                        {
                            if (AltJkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltJkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.K))
                    {
                        if (AltKkeyMotionName.Contains("Yukari"))
                        {
                            if (AltKkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltKkeyMotionName, fadeValue);
                        }
                        else if (AltKkeyMotionName.Contains("Maki"))
                        {
                            if (AltKkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltKkeyMotionName, fadeValue);
                        }
                        else if (AltKkeyMotionName.Contains("Akane"))
                        {
                            if (AltKkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltKkeyMotionName, fadeValue);
                        }
                        else if (AltKkeyMotionName.Contains("Aoi"))
                        {
                            if (AltKkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltKkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.L))
                    {
                        if (AltLkeyMotionName.Contains("Yukari"))
                        {
                            if (AltLkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltLkeyMotionName, fadeValue);
                        }
                        else if (AltLkeyMotionName.Contains("Maki"))
                        {
                            if (AltLkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltLkeyMotionName, fadeValue);
                        }
                        else if (AltLkeyMotionName.Contains("Akane"))
                        {
                            if (AltLkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltLkeyMotionName, fadeValue);
                        }
                        else if (AltLkeyMotionName.Contains("Aoi"))
                        {
                            if (AltLkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltLkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Z))
                    {
                        if (AltZkeyMotionName.Contains("Yukari"))
                        {
                            if (AltZkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltZkeyMotionName, fadeValue);
                        }
                        else if (AltZkeyMotionName.Contains("Maki"))
                        {
                            if (AltZkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltZkeyMotionName, fadeValue);
                        }
                        else if (AltZkeyMotionName.Contains("Akane"))
                        {
                            if (AltZkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltZkeyMotionName, fadeValue);
                        }
                        else if (AltZkeyMotionName.Contains("Aoi"))
                        {
                            if (AltZkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltZkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.X))
                    {
                        if (AltXkeyMotionName.Contains("Yukari"))
                        {
                            if (AltXkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltXkeyMotionName, fadeValue);
                        }
                        else if (AltXkeyMotionName.Contains("Maki"))
                        {
                            if (AltXkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltXkeyMotionName, fadeValue);
                        }
                        else if (AltXkeyMotionName.Contains("Akane"))
                        {
                            if (AltXkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltXkeyMotionName, fadeValue);
                        }
                        else if (AltXkeyMotionName.Contains("Aoi"))
                        {
                            if (AltXkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltXkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.C))
                    {
                        if (AltCkeyMotionName.Contains("Yukari"))
                        {
                            if (AltCkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltCkeyMotionName, fadeValue);
                        }
                        else if (AltCkeyMotionName.Contains("Maki"))
                        {
                            if (AltCkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltCkeyMotionName, fadeValue);
                        }
                        else if (AltCkeyMotionName.Contains("Akane"))
                        {
                            if (AltCkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltCkeyMotionName, fadeValue);
                        }
                        else if (AltCkeyMotionName.Contains("Aoi"))
                        {
                            if (AltCkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltCkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.V))
                    {
                        if (AltVkeyMotionName.Contains("Yukari"))
                        {
                            if (AltVkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltVkeyMotionName, fadeValue);
                        }
                        else if (AltVkeyMotionName.Contains("Maki"))
                        {
                            if (AltVkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltVkeyMotionName, fadeValue);
                        }
                        else if (AltVkeyMotionName.Contains("Akane"))
                        {
                            if (AltVkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltVkeyMotionName, fadeValue);
                        }
                        else if (AltVkeyMotionName.Contains("Aoi"))
                        {
                            if (AltVkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltVkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.B))
                    {
                        if (AltBkeyMotionName.Contains("Yukari"))
                        {
                            if (AltBkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltBkeyMotionName, fadeValue);
                        }
                        else if (AltBkeyMotionName.Contains("Maki"))
                        {
                            if (AltBkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltBkeyMotionName, fadeValue);
                        }
                        else if (AltBkeyMotionName.Contains("Akane"))
                        {
                            if (AltBkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltBkeyMotionName, fadeValue);
                        }
                        else if (AltBkeyMotionName.Contains("Aoi"))
                        {
                            if (AltBkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltBkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.N))
                    {
                        if (AltNkeyMotionName.Contains("Yukari"))
                        {
                            if (AltNkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltNkeyMotionName, fadeValue);
                        }
                        else if (AltNkeyMotionName.Contains("Maki"))
                        {
                            if (AltNkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltNkeyMotionName, fadeValue);
                        }
                        else if (AltNkeyMotionName.Contains("Akane"))
                        {
                            if (AltNkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltNkeyMotionName, fadeValue);
                        }
                        else if (AltNkeyMotionName.Contains("Aoi"))
                        {
                            if (AltNkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltNkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.M))
                    {
                        if (AltMkeyMotionName.Contains("Yukari"))
                        {
                            if (AltMkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AltMkeyMotionName, fadeValue);
                        }
                        else if (AltMkeyMotionName.Contains("Maki"))
                        {
                            if (AltMkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AltMkeyMotionName, fadeValue);
                        }
                        else if (AltMkeyMotionName.Contains("Akane"))
                        {
                            if (AltMkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AltMkeyMotionName, fadeValue);
                        }
                        else if (AltMkeyMotionName.Contains("Aoi"))
                        {
                            if (AltMkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AltMkeyMotionName, fadeValue);
                        }
                    }
                    #endregion
                    break;

                default:
                    #region 通常時
                    if (RawKeyInput.IsKeyDown(RawKey.F1))
                    {
                        if (_UICanvas.gameObject.activeSelf == true)
                            _UICanvas.gameObject.SetActive(false);
                        else
                            _UICanvas.gameObject.SetActive(true);
                    }

                    if (RawKeyInput.IsKeyDown(RawKey.Q))
                    {
                        if (QkeyMotionName.Contains("Yukari"))
                        {
                            if (QkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(QkeyMotionName, fadeValue);
                        }
                        else if (QkeyMotionName.Contains("Maki"))
                        {
                            if (QkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(QkeyMotionName, fadeValue);
                        }
                        else if (QkeyMotionName.Contains("Akane"))
                        {
                            if (QkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(QkeyMotionName, fadeValue);
                        }
                        else if (QkeyMotionName.Contains("Aoi"))
                        {
                            if (QkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(QkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.W))
                    {
                        if (WkeyMotionName.Contains("Yukari"))
                        {
                            if (WkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(WkeyMotionName, fadeValue);
                        }
                        else if (WkeyMotionName.Contains("Maki"))
                        {
                            if (WkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(WkeyMotionName, fadeValue);
                        }
                        else if (WkeyMotionName.Contains("Akane"))
                        {
                            if (WkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(WkeyMotionName, fadeValue);
                        }
                        else if (WkeyMotionName.Contains("Aoi"))
                        {
                            if (WkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(WkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.E))
                    {
                        if (EkeyMotionName.Contains("Yukari"))
                        {
                            if (EkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(EkeyMotionName, fadeValue);
                        }
                        else if (EkeyMotionName.Contains("Maki"))
                        {
                            if (EkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(EkeyMotionName, fadeValue);
                        }
                        else if (EkeyMotionName.Contains("Akane"))
                        {
                            if (EkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(EkeyMotionName, fadeValue);
                        }
                        else if (EkeyMotionName.Contains("Aoi"))
                        {
                            if (EkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(EkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.R))
                    {
                        if (RkeyMotionName.Contains("Yukari"))
                        {
                            if (RkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(RkeyMotionName, fadeValue);
                        }
                        else if (RkeyMotionName.Contains("Maki"))
                        {
                            if (RkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(RkeyMotionName, fadeValue);
                        }
                        else if (RkeyMotionName.Contains("Akane"))
                        {
                            if (RkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(RkeyMotionName, fadeValue);
                        }
                        else if (RkeyMotionName.Contains("Aoi"))
                        {
                            if (RkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(RkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.T))
                    {
                        if (TkeyMotionName.Contains("Yukari"))
                        {
                            if (TkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(TkeyMotionName, fadeValue);
                        }
                        else if (TkeyMotionName.Contains("Maki"))
                        {
                            if (TkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(TkeyMotionName, fadeValue);
                        }
                        else if (TkeyMotionName.Contains("Akane"))
                        {
                            if (TkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(TkeyMotionName, fadeValue);
                        }
                        else if (TkeyMotionName.Contains("Aoi"))
                        {
                            if (TkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(TkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Y))
                    {
                        if (YkeyMotionName.Contains("Yukari"))
                        {
                            if (YkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(YkeyMotionName, fadeValue);
                        }
                        else if (YkeyMotionName.Contains("Maki"))
                        {
                            if (YkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(YkeyMotionName, fadeValue);
                        }
                        else if (YkeyMotionName.Contains("Akane"))
                        {
                            if (YkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(YkeyMotionName, fadeValue);
                        }
                        else if (YkeyMotionName.Contains("Aoi"))
                        {
                            if (YkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(YkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.U))
                    {
                        if (UkeyMotionName.Contains("Yukari"))
                        {
                            if (UkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(UkeyMotionName, fadeValue);
                        }
                        else if (UkeyMotionName.Contains("Maki"))
                        {
                            if (UkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(UkeyMotionName, fadeValue);
                        }
                        else if (UkeyMotionName.Contains("Akane"))
                        {
                            if (UkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(UkeyMotionName, fadeValue);
                        }
                        else if (UkeyMotionName.Contains("Aoi"))
                        {
                            if (UkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(UkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.I))
                    {
                        if (IkeyMotionName.Contains("Yukari"))
                        {
                            if (IkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(IkeyMotionName, fadeValue);
                        }
                        else if (IkeyMotionName.Contains("Maki"))
                        {
                            if (IkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(IkeyMotionName, fadeValue);
                        }
                        else if (IkeyMotionName.Contains("Akane"))
                        {
                            if (IkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(IkeyMotionName, fadeValue);
                        }
                        else if (IkeyMotionName.Contains("Aoi"))
                        {
                            if (IkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(IkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.O))
                    {
                        if (OkeyMotionName.Contains("Yukari"))
                        {
                            if (OkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(OkeyMotionName, fadeValue);
                        }
                        else if (OkeyMotionName.Contains("Maki"))
                        {
                            if (OkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(OkeyMotionName, fadeValue);
                        }
                        else if (OkeyMotionName.Contains("Akane"))
                        {
                            if (OkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(OkeyMotionName, fadeValue);
                        }
                        else if (OkeyMotionName.Contains("Aoi"))
                        {
                            if (OkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(OkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.P))
                    {
                        if (PkeyMotionName.Contains("Yukari"))
                        {
                            if (PkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(PkeyMotionName, fadeValue);
                        }
                        else if (PkeyMotionName.Contains("Maki"))
                        {
                            if (PkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(PkeyMotionName, fadeValue);
                        }
                        else if (PkeyMotionName.Contains("Akane"))
                        {
                            if (PkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(PkeyMotionName, fadeValue);
                        }
                        else if (PkeyMotionName.Contains("Aoi"))
                        {
                            if (PkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(PkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.A))
                    {
                        if (AkeyMotionName.Contains("Yukari"))
                        {
                            if (AkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(AkeyMotionName, fadeValue);
                        }
                        else if (AkeyMotionName.Contains("Maki"))
                        {
                            if (AkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(AkeyMotionName, fadeValue);
                        }
                        else if (AkeyMotionName.Contains("Akane"))
                        {
                            if (AkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(AkeyMotionName, fadeValue);
                        }
                        else if (AkeyMotionName.Contains("Aoi"))
                        {
                            if (AkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(AkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.S))
                    {
                        if (SkeyMotionName.Contains("Yukari"))
                        {
                            if (SkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(SkeyMotionName, fadeValue);
                        }
                        else if (SkeyMotionName.Contains("Maki"))
                        {
                            if (SkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(SkeyMotionName, fadeValue);
                        }
                        else if (SkeyMotionName.Contains("Akane"))
                        {
                            if (SkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(SkeyMotionName, fadeValue);
                        }
                        else if (SkeyMotionName.Contains("Aoi"))
                        {
                            if (SkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(SkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.D))
                    {
                        if (DkeyMotionName.Contains("Yukari"))
                        {
                            if (DkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(DkeyMotionName, fadeValue);
                        }
                        else if (DkeyMotionName.Contains("Maki"))
                        {
                            if (DkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(DkeyMotionName, fadeValue);
                        }
                        else if (DkeyMotionName.Contains("Akane"))
                        {
                            if (DkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(DkeyMotionName, fadeValue);
                        }
                        else if (DkeyMotionName.Contains("Aoi"))
                        {
                            if (DkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(DkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.F))
                    {
                        if (FkeyMotionName.Contains("Yukari"))
                        {
                            if (FkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(FkeyMotionName, fadeValue);
                        }
                        else if (FkeyMotionName.Contains("Maki"))
                        {
                            if (FkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(FkeyMotionName, fadeValue);
                        }
                        else if (FkeyMotionName.Contains("Akane"))
                        {
                            if (FkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(FkeyMotionName, fadeValue);
                        }
                        else if (FkeyMotionName.Contains("Aoi"))
                        {
                            if (FkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(FkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.G))
                    {
                        if (GkeyMotionName.Contains("Yukari"))
                        {
                            if (GkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(GkeyMotionName, fadeValue);
                        }
                        else if (GkeyMotionName.Contains("Maki"))
                        {
                            if (GkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(GkeyMotionName, fadeValue);
                        }
                        else if (GkeyMotionName.Contains("Akane"))
                        {
                            if (GkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(GkeyMotionName, fadeValue);
                        }
                        else if (GkeyMotionName.Contains("Aoi"))
                        {
                            if (GkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(GkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.H))
                    {
                        if (HkeyMotionName.Contains("Yukari"))
                        {
                            if (HkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(HkeyMotionName, fadeValue);
                        }
                        else if (HkeyMotionName.Contains("Maki"))
                        {
                            if (HkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(HkeyMotionName, fadeValue);
                        }
                        else if (HkeyMotionName.Contains("Akane"))
                        {
                            if (HkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(HkeyMotionName, fadeValue);
                        }
                        else if (HkeyMotionName.Contains("Aoi"))
                        {
                            if (HkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(HkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.J))
                    {
                        if (JkeyMotionName.Contains("Yukari"))
                        {
                            if (JkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(JkeyMotionName, fadeValue);
                        }
                        else if (JkeyMotionName.Contains("Maki"))
                        {
                            if (JkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(JkeyMotionName, fadeValue);
                        }
                        else if (JkeyMotionName.Contains("Akane"))
                        {
                            if (JkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(JkeyMotionName, fadeValue);
                        }
                        else if (JkeyMotionName.Contains("Aoi"))
                        {
                            if (JkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(JkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.K))
                    {
                        if (KkeyMotionName.Contains("Yukari"))
                        {
                            if (KkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(KkeyMotionName, fadeValue);
                        }
                        else if (KkeyMotionName.Contains("Maki"))
                        {
                            if (KkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(KkeyMotionName, fadeValue);
                        }
                        else if (KkeyMotionName.Contains("Akane"))
                        {
                            if (KkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(KkeyMotionName, fadeValue);
                        }
                        else if (KkeyMotionName.Contains("Aoi"))
                        {
                            if (KkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(KkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.L))
                    {
                        if (LkeyMotionName.Contains("Yukari"))
                        {
                            if (LkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(LkeyMotionName, fadeValue);
                        }
                        else if (LkeyMotionName.Contains("Maki"))
                        {
                            if (LkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(LkeyMotionName, fadeValue);
                        }
                        else if (LkeyMotionName.Contains("Akane"))
                        {
                            if (LkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(LkeyMotionName, fadeValue);
                        }
                        else if (LkeyMotionName.Contains("Aoi"))
                        {
                            if (LkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(LkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.Z))
                    {
                        if (ZkeyMotionName.Contains("Yukari"))
                        {
                            if (ZkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(ZkeyMotionName, fadeValue);
                        }
                        else if (ZkeyMotionName.Contains("Maki"))
                        {
                            if (ZkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(ZkeyMotionName, fadeValue);
                        }
                        else if (ZkeyMotionName.Contains("Akane"))
                        {
                            if (ZkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(ZkeyMotionName, fadeValue);
                        }
                        else if (ZkeyMotionName.Contains("Aoi"))
                        {
                            if (ZkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(ZkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.X))
                    {
                        if (XkeyMotionName.Contains("Yukari"))
                        {
                            if (XkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(XkeyMotionName, fadeValue);
                        }
                        else if (XkeyMotionName.Contains("Maki"))
                        {
                            if (XkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(XkeyMotionName, fadeValue);
                        }
                        else if (XkeyMotionName.Contains("Akane"))
                        {
                            if (XkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(XkeyMotionName, fadeValue);
                        }
                        else if (XkeyMotionName.Contains("Aoi"))
                        {
                            if (XkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(XkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.C))
                    {
                        if (CkeyMotionName.Contains("Yukari"))
                        {
                            if (CkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(CkeyMotionName, fadeValue);
                        }
                        else if (CkeyMotionName.Contains("Maki"))
                        {
                            if (CkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(CkeyMotionName, fadeValue);
                        }
                        else if (CkeyMotionName.Contains("Akane"))
                        {
                            if (CkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(CkeyMotionName, fadeValue);
                        }
                        else if (CkeyMotionName.Contains("Aoi"))
                        {
                            if (CkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(CkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.V))
                    {
                        if (VkeyMotionName.Contains("Yukari"))
                        {
                            if (VkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(VkeyMotionName, fadeValue);
                        }
                        else if (VkeyMotionName.Contains("Maki"))
                        {
                            if (VkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(VkeyMotionName, fadeValue);
                        }
                        else if (VkeyMotionName.Contains("Akane"))
                        {
                            if (VkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(VkeyMotionName, fadeValue);
                        }
                        else if (VkeyMotionName.Contains("Aoi"))
                        {
                            if (VkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(VkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.B))
                    {
                        if (BkeyMotionName.Contains("Yukari"))
                        {
                            if (BkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(BkeyMotionName, fadeValue);
                        }
                        else if (BkeyMotionName.Contains("Maki"))
                        {
                            if (BkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(BkeyMotionName, fadeValue);
                        }
                        else if (BkeyMotionName.Contains("Akane"))
                        {
                            if (BkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(BkeyMotionName, fadeValue);
                        }
                        else if (BkeyMotionName.Contains("Aoi"))
                        {
                            if (BkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(BkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.N))
                    {
                        if (NkeyMotionName.Contains("Yukari"))
                        {
                            if (NkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(NkeyMotionName, fadeValue);
                        }
                        else if (NkeyMotionName.Contains("Maki"))
                        {
                            if (NkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(NkeyMotionName, fadeValue);
                        }
                        else if (NkeyMotionName.Contains("Akane"))
                        {
                            if (NkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(NkeyMotionName, fadeValue);
                        }
                        else if (NkeyMotionName.Contains("Aoi"))
                        {
                            if (NkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(NkeyMotionName, fadeValue);
                        }
                    }
                    if (RawKeyInput.IsKeyDown(RawKey.M))
                    {
                        if (MkeyMotionName.Contains("Yukari"))
                        {
                            if (MkeyMotionName.Contains("Active"))
                                Yukari.SetActive(Yukari.activeSelf ? false : true);
                            else
                                anim[0].CrossFade(MkeyMotionName, fadeValue);
                        }
                        else if (MkeyMotionName.Contains("Maki"))
                        {
                            if (MkeyMotionName.Contains("Active"))
                                Maki.SetActive(Maki.activeSelf ? false : true);
                            else
                                anim[1].CrossFade(MkeyMotionName, fadeValue);
                        }
                        else if (MkeyMotionName.Contains("Akane"))
                        {
                            if (MkeyMotionName.Contains("Active"))
                                Akane.SetActive(Akane.activeSelf ? false : true);
                            else
                                anim[2].CrossFade(MkeyMotionName, fadeValue);
                        }
                        else if (MkeyMotionName.Contains("Aoi"))
                        {
                            if (MkeyMotionName.Contains("Active"))
                                Aoi.SetActive(Aoi.activeSelf ? false : true);
                            else
                                anim[3].CrossFade(MkeyMotionName, fadeValue);
                        }
                    }
                    #endregion
                    break;
			} 
        }

        /*if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && anim.runtimeAnimatorController.animationClips[])
        {
            anim.CrossFade("Idle", fadeValue);
        }*/
    }
}
