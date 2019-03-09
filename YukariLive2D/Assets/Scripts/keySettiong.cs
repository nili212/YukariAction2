using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keySettiong : UICanvas {

	public UICanvas parentUI;

	public Dropdown QbuttonText;
	public Dropdown WbuttonText;
	public Dropdown EbuttonText;
	public Dropdown RbuttonText;
	public Dropdown TbuttonText;
	public Dropdown YbuttonText;
	public Dropdown UbuttonText;
	public Dropdown IbuttonText;
	public Dropdown ObuttonText;
	public Dropdown PbuttonText;
	public Dropdown AbuttonText;
    public Dropdown SbuttonText;
    public Dropdown DbuttonText;
    public Dropdown FbuttonText;
    public Dropdown GbuttonText;
    public Dropdown HbuttonText;
    public Dropdown JbuttonText;
    public Dropdown KbuttonText;
    public Dropdown LbuttonText;
    public Dropdown ZbuttonText;
    public Dropdown XbuttonText;
    public Dropdown CbuttonText;
    public Dropdown VbuttonText;
    public Dropdown BbuttonText;
    public Dropdown NbuttonText;
    public Dropdown MbuttonText;

	public Dropdown shift_QbuttonText;
	public Dropdown shift_WbuttonText;
	public Dropdown shift_EbuttonText;
	public Dropdown shift_RbuttonText;
	public Dropdown shift_TbuttonText;
	public Dropdown shift_YbuttonText;
	public Dropdown shift_UbuttonText;
	public Dropdown shift_IbuttonText;
	public Dropdown shift_ObuttonText;
	public Dropdown shift_PbuttonText;
	public Dropdown shift_AbuttonText;
	public Dropdown shift_SbuttonText;
	public Dropdown shift_DbuttonText;
	public Dropdown shift_FbuttonText;
	public Dropdown shift_GbuttonText;
	public Dropdown shift_HbuttonText;
	public Dropdown shift_JbuttonText;
	public Dropdown shift_KbuttonText;
	public Dropdown shift_LbuttonText;
	public Dropdown shift_ZbuttonText;
	public Dropdown shift_XbuttonText;
	public Dropdown shift_CbuttonText;
	public Dropdown shift_VbuttonText;
	public Dropdown shift_BbuttonText;
	public Dropdown shift_NbuttonText;
	public Dropdown shift_MbuttonText;

	public Dropdown ctrl_QbuttonText;
	public Dropdown ctrl_WbuttonText;
	public Dropdown ctrl_EbuttonText;
	public Dropdown ctrl_RbuttonText;
	public Dropdown ctrl_TbuttonText;
	public Dropdown ctrl_YbuttonText;
	public Dropdown ctrl_UbuttonText;
	public Dropdown ctrl_IbuttonText;
	public Dropdown ctrl_ObuttonText;
	public Dropdown ctrl_PbuttonText;
	public Dropdown ctrl_AbuttonText;
	public Dropdown ctrl_SbuttonText;
	public Dropdown ctrl_DbuttonText;
	public Dropdown ctrl_FbuttonText;
	public Dropdown ctrl_GbuttonText;
	public Dropdown ctrl_HbuttonText;
	public Dropdown ctrl_JbuttonText;
	public Dropdown ctrl_KbuttonText;
	public Dropdown ctrl_LbuttonText;
	public Dropdown ctrl_ZbuttonText;
	public Dropdown ctrl_XbuttonText;
	public Dropdown ctrl_CbuttonText;
	public Dropdown ctrl_VbuttonText;
	public Dropdown ctrl_BbuttonText;
	public Dropdown ctrl_NbuttonText;
	public Dropdown ctrl_MbuttonText;

	public Dropdown alt_QbuttonText;
	public Dropdown alt_WbuttonText;
	public Dropdown alt_EbuttonText;
	public Dropdown alt_RbuttonText;
	public Dropdown alt_TbuttonText;
	public Dropdown alt_YbuttonText;
	public Dropdown alt_UbuttonText;
	public Dropdown alt_IbuttonText;
	public Dropdown alt_ObuttonText;
	public Dropdown alt_PbuttonText;
	public Dropdown alt_AbuttonText;
	public Dropdown alt_SbuttonText;
	public Dropdown alt_DbuttonText;
	public Dropdown alt_FbuttonText;
	public Dropdown alt_GbuttonText;
	public Dropdown alt_HbuttonText;
	public Dropdown alt_JbuttonText;
	public Dropdown alt_KbuttonText;
	public Dropdown alt_LbuttonText;
	public Dropdown alt_ZbuttonText;
	public Dropdown alt_XbuttonText;
	public Dropdown alt_CbuttonText;
	public Dropdown alt_VbuttonText;
	public Dropdown alt_BbuttonText;
	public Dropdown alt_NbuttonText;
	public Dropdown alt_MbuttonText;

	public Button ShiftChangeButton;
	public Button CtrlChangeButton;
	public Button AltChangeButton;

	public GameObject NormalSettings;
	public GameObject ShiftSettings;
	public GameObject CtrlSettings;
	public GameObject AltSettings;

	private bool shiftSelect = false;
	private bool ctrlSelect = false;
	private bool altSelect = false;

    //何か対応するモーション名がある場合、数値を返す
    public int MotionNameNum(string key)
    {
        for (int i = 0; i < yukaCon.motionNameList.Count; i++)
        {
            if(yukaCon.motionNameList[i] == key)
            {
                return i;
            }
        }

        return 0;
    }

    void Awake()
    {
         
    }

    void OnEnable()
    {
		specialkeyInit ();

		NormalModeSet ();
		ShiftModeSet ();
		CtrlModeSet ();
		AltModeSet ();
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NormalModeSet()
	{
		QbuttonText.ClearOptions ();
		QbuttonText.AddOptions (yukaCon.motionNameList);
		QbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.QkeyMotionName);

		WbuttonText.ClearOptions();
		WbuttonText.AddOptions(yukaCon.motionNameList);
		WbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.WkeyMotionName);

		EbuttonText.ClearOptions();
		EbuttonText.AddOptions(yukaCon.motionNameList);
		EbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.EkeyMotionName);

		RbuttonText.ClearOptions();
		RbuttonText.AddOptions(yukaCon.motionNameList);
		RbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.RkeyMotionName);

		TbuttonText.ClearOptions();
		TbuttonText.AddOptions(yukaCon.motionNameList);
		TbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.TkeyMotionName);

		YbuttonText.ClearOptions();
		YbuttonText.AddOptions(yukaCon.motionNameList);
		YbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.YkeyMotionName);

		UbuttonText.ClearOptions();
		UbuttonText.AddOptions(yukaCon.motionNameList);
		UbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.UkeyMotionName);

		IbuttonText.ClearOptions();
		IbuttonText.AddOptions(yukaCon.motionNameList);
		IbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.IkeyMotionName);

		ObuttonText.ClearOptions();
		ObuttonText.AddOptions(yukaCon.motionNameList);
		ObuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.OkeyMotionName);

		PbuttonText.ClearOptions();
		PbuttonText.AddOptions(yukaCon.motionNameList);
		PbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.PkeyMotionName);

		AbuttonText.ClearOptions ();
		AbuttonText.AddOptions (yukaCon.motionNameList);
		AbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AkeyMotionName);

		SbuttonText.ClearOptions();
		SbuttonText.AddOptions(yukaCon.motionNameList);
		SbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.SkeyMotionName);

		DbuttonText.ClearOptions();
		DbuttonText.AddOptions(yukaCon.motionNameList);
		DbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.DkeyMotionName);

		FbuttonText.ClearOptions();
		FbuttonText.AddOptions(yukaCon.motionNameList);
		FbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.FkeyMotionName);

		GbuttonText.ClearOptions();
		GbuttonText.AddOptions(yukaCon.motionNameList);
		GbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.GkeyMotionName);

		HbuttonText.ClearOptions();
		HbuttonText.AddOptions(yukaCon.motionNameList);
		HbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.HkeyMotionName);

		JbuttonText.ClearOptions();
		JbuttonText.AddOptions(yukaCon.motionNameList);
		JbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.JkeyMotionName);

		KbuttonText.ClearOptions();
		KbuttonText.AddOptions(yukaCon.motionNameList);
		KbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.KkeyMotionName);

		LbuttonText.ClearOptions();
		LbuttonText.AddOptions(yukaCon.motionNameList);
		LbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.LkeyMotionName);

		ZbuttonText.ClearOptions();
		ZbuttonText.AddOptions(yukaCon.motionNameList);
		ZbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ZkeyMotionName);

		XbuttonText.ClearOptions();
		XbuttonText.AddOptions(yukaCon.motionNameList);
		XbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.XkeyMotionName);

		CbuttonText.ClearOptions();
		CbuttonText.AddOptions(yukaCon.motionNameList);
		CbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CkeyMotionName);

		VbuttonText.ClearOptions();
		VbuttonText.AddOptions(yukaCon.motionNameList);
		VbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.VkeyMotionName);

		BbuttonText.ClearOptions();
		BbuttonText.AddOptions(yukaCon.motionNameList);
		BbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.BkeyMotionName);

		NbuttonText.ClearOptions();
		NbuttonText.AddOptions(yukaCon.motionNameList);
		NbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.NkeyMotionName);

		MbuttonText.ClearOptions();
		MbuttonText.AddOptions(yukaCon.motionNameList);
		MbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.MkeyMotionName);
	}

	public void ShiftModeSet()
	{
		shift_QbuttonText.ClearOptions ();
		shift_QbuttonText.AddOptions (yukaCon.motionNameList);
		shift_QbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftQkeyMotionName);

		shift_WbuttonText.ClearOptions();
		shift_WbuttonText.AddOptions(yukaCon.motionNameList);
		shift_WbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftWkeyMotionName);

		shift_EbuttonText.ClearOptions();
		shift_EbuttonText.AddOptions(yukaCon.motionNameList);
		shift_EbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftEkeyMotionName);

		shift_RbuttonText.ClearOptions();
		shift_RbuttonText.AddOptions(yukaCon.motionNameList);
		shift_RbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftRkeyMotionName);

		shift_TbuttonText.ClearOptions();
		shift_TbuttonText.AddOptions(yukaCon.motionNameList);
		shift_TbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftTkeyMotionName);

		shift_YbuttonText.ClearOptions();
		shift_YbuttonText.AddOptions(yukaCon.motionNameList);
		shift_YbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftYkeyMotionName);

		shift_UbuttonText.ClearOptions();
		shift_UbuttonText.AddOptions(yukaCon.motionNameList);
		shift_UbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftUkeyMotionName);

		shift_IbuttonText.ClearOptions();
		shift_IbuttonText.AddOptions(yukaCon.motionNameList);
		shift_IbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftIkeyMotionName);

		shift_ObuttonText.ClearOptions();
		shift_ObuttonText.AddOptions(yukaCon.motionNameList);
		shift_ObuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftOkeyMotionName);

		shift_PbuttonText.ClearOptions();
		shift_PbuttonText.AddOptions(yukaCon.motionNameList);
		shift_PbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftPkeyMotionName);

		shift_AbuttonText.ClearOptions ();
		shift_AbuttonText.AddOptions (yukaCon.motionNameList);
		shift_AbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftAkeyMotionName);

		shift_SbuttonText.ClearOptions();
		shift_SbuttonText.AddOptions(yukaCon.motionNameList);
		shift_SbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftSkeyMotionName);

		shift_DbuttonText.ClearOptions();
		shift_DbuttonText.AddOptions(yukaCon.motionNameList);
		shift_DbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftDkeyMotionName);

		shift_FbuttonText.ClearOptions();
		shift_FbuttonText.AddOptions(yukaCon.motionNameList);
		shift_FbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftFkeyMotionName);

		shift_GbuttonText.ClearOptions();
		shift_GbuttonText.AddOptions(yukaCon.motionNameList);
		shift_GbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftGkeyMotionName);

		shift_HbuttonText.ClearOptions();
		shift_HbuttonText.AddOptions(yukaCon.motionNameList);
		shift_HbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftHkeyMotionName);

		shift_JbuttonText.ClearOptions();
		shift_JbuttonText.AddOptions(yukaCon.motionNameList);
		shift_JbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftJkeyMotionName);

		shift_KbuttonText.ClearOptions();
		shift_KbuttonText.AddOptions(yukaCon.motionNameList);
		shift_KbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftKkeyMotionName);

		shift_LbuttonText.ClearOptions();
		shift_LbuttonText.AddOptions(yukaCon.motionNameList);
		shift_LbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftLkeyMotionName);

		shift_ZbuttonText.ClearOptions();
		shift_ZbuttonText.AddOptions(yukaCon.motionNameList);
		shift_ZbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftZkeyMotionName);

		shift_XbuttonText.ClearOptions();
		shift_XbuttonText.AddOptions(yukaCon.motionNameList);
		shift_XbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftXkeyMotionName);

		shift_CbuttonText.ClearOptions();
		shift_CbuttonText.AddOptions(yukaCon.motionNameList);
		shift_CbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftCkeyMotionName);

		shift_VbuttonText.ClearOptions();
		shift_VbuttonText.AddOptions(yukaCon.motionNameList);
		shift_VbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftVkeyMotionName);

		shift_BbuttonText.ClearOptions();
		shift_BbuttonText.AddOptions(yukaCon.motionNameList);
		shift_BbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftBkeyMotionName);

		shift_NbuttonText.ClearOptions();
		shift_NbuttonText.AddOptions(yukaCon.motionNameList);
		shift_NbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftNkeyMotionName);

		shift_MbuttonText.ClearOptions();
		shift_MbuttonText.AddOptions(yukaCon.motionNameList);
		shift_MbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.ShiftMkeyMotionName);
	}

	public void CtrlModeSet()
	{
        ctrl_QbuttonText.ClearOptions ();
        ctrl_QbuttonText.AddOptions (yukaCon.motionNameList);
        ctrl_QbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlQkeyMotionName);

        ctrl_WbuttonText.ClearOptions();
        ctrl_WbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_WbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlWkeyMotionName);

        ctrl_EbuttonText.ClearOptions();
        ctrl_EbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_EbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlEkeyMotionName);

        ctrl_RbuttonText.ClearOptions();
        ctrl_RbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_RbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlRkeyMotionName);

        ctrl_TbuttonText.ClearOptions();
        ctrl_TbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_TbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlTkeyMotionName);

        ctrl_YbuttonText.ClearOptions();
        ctrl_YbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_YbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlYkeyMotionName);

        ctrl_UbuttonText.ClearOptions();
        ctrl_UbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_UbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlUkeyMotionName);

        ctrl_IbuttonText.ClearOptions();
        ctrl_IbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_IbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlIkeyMotionName);

        ctrl_ObuttonText.ClearOptions();
        ctrl_ObuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_ObuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlOkeyMotionName);

        ctrl_PbuttonText.ClearOptions();
        ctrl_PbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_PbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlPkeyMotionName);

        ctrl_AbuttonText.ClearOptions ();
        ctrl_AbuttonText.AddOptions (yukaCon.motionNameList);
        ctrl_AbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlAkeyMotionName);

        ctrl_SbuttonText.ClearOptions();
        ctrl_SbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_SbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlSkeyMotionName);

        ctrl_DbuttonText.ClearOptions();
        ctrl_DbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_DbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlDkeyMotionName);

        ctrl_FbuttonText.ClearOptions();
        ctrl_FbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_FbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlFkeyMotionName);

        ctrl_GbuttonText.ClearOptions();
        ctrl_GbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_GbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlGkeyMotionName);

        ctrl_HbuttonText.ClearOptions();
        ctrl_HbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_HbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlHkeyMotionName);

        ctrl_JbuttonText.ClearOptions();
		ctrl_JbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_JbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlJkeyMotionName);

        ctrl_KbuttonText.ClearOptions();
        ctrl_KbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_KbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlKkeyMotionName);

        ctrl_LbuttonText.ClearOptions();
        ctrl_LbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_LbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlLkeyMotionName);

        ctrl_ZbuttonText.ClearOptions();
        ctrl_ZbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_ZbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlZkeyMotionName);

        ctrl_XbuttonText.ClearOptions();
        ctrl_XbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_XbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlXkeyMotionName);

        ctrl_CbuttonText.ClearOptions();
        ctrl_CbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_CbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlCkeyMotionName);

        ctrl_VbuttonText.ClearOptions();
        ctrl_VbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_VbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlVkeyMotionName);

        ctrl_BbuttonText.ClearOptions();
        ctrl_BbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_BbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlBkeyMotionName);

        ctrl_NbuttonText.ClearOptions();
        ctrl_NbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_NbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlNkeyMotionName);

        ctrl_MbuttonText.ClearOptions();
        ctrl_MbuttonText.AddOptions(yukaCon.motionNameList);
        ctrl_MbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.CtrlMkeyMotionName);
	}

	public void AltModeSet()
	{
        alt_QbuttonText.ClearOptions ();
        alt_QbuttonText.AddOptions (yukaCon.motionNameList);
        alt_QbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltQkeyMotionName);

        alt_WbuttonText.ClearOptions();
        alt_WbuttonText.AddOptions(yukaCon.motionNameList);
        alt_WbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltWkeyMotionName);

        alt_EbuttonText.ClearOptions();
        alt_EbuttonText.AddOptions(yukaCon.motionNameList);
        alt_EbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltEkeyMotionName);

        alt_RbuttonText.ClearOptions();
        alt_RbuttonText.AddOptions(yukaCon.motionNameList);
        alt_RbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltRkeyMotionName);

        alt_TbuttonText.ClearOptions();
        alt_TbuttonText.AddOptions(yukaCon.motionNameList);
        alt_TbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltTkeyMotionName);

        alt_YbuttonText.ClearOptions();
        alt_YbuttonText.AddOptions(yukaCon.motionNameList);
        alt_YbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltYkeyMotionName);

        alt_UbuttonText.ClearOptions();
        alt_UbuttonText.AddOptions(yukaCon.motionNameList);
        alt_UbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltUkeyMotionName);

        alt_IbuttonText.ClearOptions();
        alt_IbuttonText.AddOptions(yukaCon.motionNameList);
        alt_IbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltIkeyMotionName);

        alt_ObuttonText.ClearOptions();
        alt_ObuttonText.AddOptions(yukaCon.motionNameList);
        alt_ObuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltOkeyMotionName);

        alt_PbuttonText.ClearOptions();
        alt_PbuttonText.AddOptions(yukaCon.motionNameList);
        alt_PbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltPkeyMotionName);

        alt_AbuttonText.ClearOptions ();
        alt_AbuttonText.AddOptions (yukaCon.motionNameList);
        alt_AbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltAkeyMotionName);

        alt_SbuttonText.ClearOptions();
        alt_SbuttonText.AddOptions(yukaCon.motionNameList);
        alt_SbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltSkeyMotionName);

        alt_DbuttonText.ClearOptions();
        alt_DbuttonText.AddOptions(yukaCon.motionNameList);
        alt_DbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltDkeyMotionName);

        alt_FbuttonText.ClearOptions();
        alt_FbuttonText.AddOptions(yukaCon.motionNameList);
        alt_FbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltFkeyMotionName);

        alt_GbuttonText.ClearOptions();
        alt_GbuttonText.AddOptions(yukaCon.motionNameList);
        alt_GbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltGkeyMotionName);

        alt_HbuttonText.ClearOptions();
        alt_HbuttonText.AddOptions(yukaCon.motionNameList);
        alt_HbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltHkeyMotionName);

        alt_JbuttonText.ClearOptions();
        alt_JbuttonText.AddOptions(yukaCon.motionNameList);
        alt_JbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltJkeyMotionName);

        alt_KbuttonText.ClearOptions();
        alt_KbuttonText.AddOptions(yukaCon.motionNameList);
        alt_KbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltKkeyMotionName);

        alt_LbuttonText.ClearOptions();
        alt_LbuttonText.AddOptions(yukaCon.motionNameList);
        alt_LbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltLkeyMotionName);

        alt_ZbuttonText.ClearOptions();
        alt_ZbuttonText.AddOptions(yukaCon.motionNameList);
        alt_ZbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltZkeyMotionName);

        alt_XbuttonText.ClearOptions();
        alt_XbuttonText.AddOptions(yukaCon.motionNameList);
        alt_XbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltXkeyMotionName);

        alt_CbuttonText.ClearOptions();
        alt_CbuttonText.AddOptions(yukaCon.motionNameList);
        alt_CbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltCkeyMotionName);

        alt_VbuttonText.ClearOptions();
        alt_VbuttonText.AddOptions(yukaCon.motionNameList);
        alt_VbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltVkeyMotionName);

        alt_BbuttonText.ClearOptions();
        alt_BbuttonText.AddOptions(yukaCon.motionNameList);
        alt_BbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltBkeyMotionName);

        alt_NbuttonText.ClearOptions();
        alt_NbuttonText.AddOptions(yukaCon.motionNameList);
        alt_NbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltNkeyMotionName);

        alt_MbuttonText.ClearOptions();
        alt_MbuttonText.AddOptions(yukaCon.motionNameList);
        alt_MbuttonText.value = MotionNameNum(PlayerDataManager.instance.playerData.AltMkeyMotionName);
	}

    public void Back()
    {		
		parentUI.settingOpenFlag = false;
        this.gameObject.SetActive(false);
    }

	public void SaveAndBack()
	{
		PlayerDataManager.instance.playerData.QkeyMotionName = yukaCon.QkeyMotionName = QbuttonText.options[QbuttonText.value].text;
		PlayerDataManager.instance.playerData.WkeyMotionName = yukaCon.WkeyMotionName = WbuttonText.options[WbuttonText.value].text;
		PlayerDataManager.instance.playerData.EkeyMotionName = yukaCon.EkeyMotionName = EbuttonText.options[EbuttonText.value].text;
		PlayerDataManager.instance.playerData.RkeyMotionName = yukaCon.RkeyMotionName = RbuttonText.options[RbuttonText.value].text;
		PlayerDataManager.instance.playerData.TkeyMotionName = yukaCon.TkeyMotionName = TbuttonText.options[TbuttonText.value].text;
		PlayerDataManager.instance.playerData.YkeyMotionName = yukaCon.YkeyMotionName = YbuttonText.options[YbuttonText.value].text;
		PlayerDataManager.instance.playerData.UkeyMotionName = yukaCon.UkeyMotionName = UbuttonText.options[UbuttonText.value].text;
		PlayerDataManager.instance.playerData.IkeyMotionName = yukaCon.IkeyMotionName = IbuttonText.options[IbuttonText.value].text;
		PlayerDataManager.instance.playerData.OkeyMotionName = yukaCon.OkeyMotionName = ObuttonText.options[ObuttonText.value].text;
		PlayerDataManager.instance.playerData.PkeyMotionName = yukaCon.PkeyMotionName = PbuttonText.options[PbuttonText.value].text;
		PlayerDataManager.instance.playerData.AkeyMotionName = yukaCon.AkeyMotionName = AbuttonText.options[AbuttonText.value].text;
		PlayerDataManager.instance.playerData.SkeyMotionName = yukaCon.SkeyMotionName = SbuttonText.options[SbuttonText.value].text;
        PlayerDataManager.instance.playerData.DkeyMotionName = yukaCon.DkeyMotionName = DbuttonText.options[DbuttonText.value].text;
        PlayerDataManager.instance.playerData.FkeyMotionName = yukaCon.FkeyMotionName = FbuttonText.options[FbuttonText.value].text;
        PlayerDataManager.instance.playerData.GkeyMotionName = yukaCon.GkeyMotionName = GbuttonText.options[GbuttonText.value].text;
        PlayerDataManager.instance.playerData.HkeyMotionName = yukaCon.HkeyMotionName = HbuttonText.options[HbuttonText.value].text;
        PlayerDataManager.instance.playerData.JkeyMotionName = yukaCon.JkeyMotionName = JbuttonText.options[JbuttonText.value].text;
        PlayerDataManager.instance.playerData.KkeyMotionName = yukaCon.KkeyMotionName = KbuttonText.options[KbuttonText.value].text;
        PlayerDataManager.instance.playerData.LkeyMotionName = yukaCon.LkeyMotionName = LbuttonText.options[LbuttonText.value].text;
        PlayerDataManager.instance.playerData.ZkeyMotionName = yukaCon.ZkeyMotionName = ZbuttonText.options[ZbuttonText.value].text;
        PlayerDataManager.instance.playerData.XkeyMotionName = yukaCon.XkeyMotionName = XbuttonText.options[XbuttonText.value].text;
        PlayerDataManager.instance.playerData.CkeyMotionName = yukaCon.CkeyMotionName = CbuttonText.options[CbuttonText.value].text;
        PlayerDataManager.instance.playerData.VkeyMotionName = yukaCon.VkeyMotionName = VbuttonText.options[VbuttonText.value].text;
        PlayerDataManager.instance.playerData.BkeyMotionName = yukaCon.BkeyMotionName = BbuttonText.options[BbuttonText.value].text;
        PlayerDataManager.instance.playerData.NkeyMotionName = yukaCon.NkeyMotionName = NbuttonText.options[NbuttonText.value].text;
        PlayerDataManager.instance.playerData.MkeyMotionName = yukaCon.MkeyMotionName = MbuttonText.options[MbuttonText.value].text;

		PlayerDataManager.instance.playerData.ShiftQkeyMotionName = yukaCon.ShiftQkeyMotionName = shift_QbuttonText.options[shift_QbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftWkeyMotionName = yukaCon.ShiftWkeyMotionName = shift_WbuttonText.options[shift_WbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftEkeyMotionName = yukaCon.ShiftEkeyMotionName = shift_EbuttonText.options[shift_EbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftRkeyMotionName = yukaCon.ShiftRkeyMotionName = shift_RbuttonText.options[shift_RbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftTkeyMotionName = yukaCon.ShiftTkeyMotionName = shift_TbuttonText.options[shift_TbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftYkeyMotionName = yukaCon.ShiftYkeyMotionName = shift_YbuttonText.options[shift_YbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftUkeyMotionName = yukaCon.ShiftUkeyMotionName = shift_UbuttonText.options[shift_UbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftIkeyMotionName = yukaCon.ShiftIkeyMotionName = shift_IbuttonText.options[shift_IbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftOkeyMotionName = yukaCon.ShiftOkeyMotionName = shift_ObuttonText.options[shift_ObuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftPkeyMotionName = yukaCon.ShiftPkeyMotionName = shift_PbuttonText.options[shift_PbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftAkeyMotionName = yukaCon.ShiftAkeyMotionName = shift_AbuttonText.options[shift_AbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftSkeyMotionName = yukaCon.ShiftSkeyMotionName = shift_SbuttonText.options[shift_SbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftDkeyMotionName = yukaCon.ShiftDkeyMotionName = shift_DbuttonText.options[shift_DbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftFkeyMotionName = yukaCon.ShiftFkeyMotionName = shift_FbuttonText.options[shift_FbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftGkeyMotionName = yukaCon.ShiftGkeyMotionName = shift_GbuttonText.options[shift_GbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftHkeyMotionName = yukaCon.ShiftHkeyMotionName = shift_HbuttonText.options[shift_HbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftJkeyMotionName = yukaCon.ShiftJkeyMotionName = shift_JbuttonText.options[shift_JbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftKkeyMotionName = yukaCon.ShiftKkeyMotionName = shift_KbuttonText.options[shift_KbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftLkeyMotionName = yukaCon.ShiftLkeyMotionName = shift_LbuttonText.options[shift_LbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftZkeyMotionName = yukaCon.ShiftZkeyMotionName = shift_ZbuttonText.options[shift_ZbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftXkeyMotionName = yukaCon.ShiftXkeyMotionName = shift_XbuttonText.options[shift_XbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftCkeyMotionName = yukaCon.ShiftCkeyMotionName = shift_CbuttonText.options[shift_CbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftVkeyMotionName = yukaCon.ShiftVkeyMotionName = shift_VbuttonText.options[shift_VbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftBkeyMotionName = yukaCon.ShiftBkeyMotionName = shift_BbuttonText.options[shift_BbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftNkeyMotionName = yukaCon.ShiftNkeyMotionName = shift_NbuttonText.options[shift_NbuttonText.value].text;
		PlayerDataManager.instance.playerData.ShiftMkeyMotionName = yukaCon.ShiftMkeyMotionName = shift_MbuttonText.options[shift_MbuttonText.value].text;

		PlayerDataManager.instance.playerData.CtrlQkeyMotionName = yukaCon.CtrlQkeyMotionName = ctrl_QbuttonText.options[ctrl_QbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlWkeyMotionName = yukaCon.CtrlWkeyMotionName = ctrl_WbuttonText.options[ctrl_WbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlEkeyMotionName = yukaCon.CtrlEkeyMotionName = ctrl_EbuttonText.options[ctrl_EbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlRkeyMotionName = yukaCon.CtrlRkeyMotionName = ctrl_RbuttonText.options[ctrl_RbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlTkeyMotionName = yukaCon.CtrlTkeyMotionName = ctrl_TbuttonText.options[ctrl_TbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlYkeyMotionName = yukaCon.CtrlYkeyMotionName = ctrl_YbuttonText.options[ctrl_YbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlUkeyMotionName = yukaCon.CtrlUkeyMotionName = ctrl_UbuttonText.options[ctrl_UbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlIkeyMotionName = yukaCon.CtrlIkeyMotionName = ctrl_IbuttonText.options[ctrl_IbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlOkeyMotionName = yukaCon.CtrlOkeyMotionName = ctrl_ObuttonText.options[ctrl_ObuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlPkeyMotionName = yukaCon.CtrlPkeyMotionName = ctrl_PbuttonText.options[ctrl_PbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlAkeyMotionName = yukaCon.CtrlAkeyMotionName = ctrl_AbuttonText.options[ctrl_AbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlSkeyMotionName = yukaCon.CtrlSkeyMotionName = ctrl_SbuttonText.options[ctrl_SbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlDkeyMotionName = yukaCon.CtrlDkeyMotionName = ctrl_DbuttonText.options[ctrl_DbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlFkeyMotionName = yukaCon.CtrlFkeyMotionName = ctrl_FbuttonText.options[ctrl_FbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlGkeyMotionName = yukaCon.CtrlGkeyMotionName = ctrl_GbuttonText.options[ctrl_GbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlHkeyMotionName = yukaCon.CtrlHkeyMotionName = ctrl_HbuttonText.options[ctrl_HbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlJkeyMotionName = yukaCon.CtrlJkeyMotionName = ctrl_JbuttonText.options[ctrl_JbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlKkeyMotionName = yukaCon.CtrlKkeyMotionName = ctrl_KbuttonText.options[ctrl_KbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlLkeyMotionName = yukaCon.CtrlLkeyMotionName = ctrl_LbuttonText.options[ctrl_LbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlZkeyMotionName = yukaCon.CtrlZkeyMotionName = ctrl_ZbuttonText.options[ctrl_ZbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlXkeyMotionName = yukaCon.CtrlXkeyMotionName = ctrl_XbuttonText.options[ctrl_XbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlCkeyMotionName = yukaCon.CtrlCkeyMotionName = ctrl_CbuttonText.options[ctrl_CbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlVkeyMotionName = yukaCon.CtrlVkeyMotionName = ctrl_VbuttonText.options[ctrl_VbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlBkeyMotionName = yukaCon.CtrlBkeyMotionName = ctrl_BbuttonText.options[ctrl_BbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlNkeyMotionName = yukaCon.CtrlNkeyMotionName = ctrl_NbuttonText.options[ctrl_NbuttonText.value].text;
		PlayerDataManager.instance.playerData.CtrlMkeyMotionName = yukaCon.CtrlMkeyMotionName = ctrl_MbuttonText.options[ctrl_MbuttonText.value].text;

		PlayerDataManager.instance.playerData.AltQkeyMotionName = yukaCon.AltQkeyMotionName = alt_QbuttonText.options[alt_QbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltWkeyMotionName = yukaCon.AltWkeyMotionName = alt_WbuttonText.options[alt_WbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltEkeyMotionName = yukaCon.AltEkeyMotionName = alt_EbuttonText.options[alt_EbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltRkeyMotionName = yukaCon.AltRkeyMotionName = alt_RbuttonText.options[alt_RbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltTkeyMotionName = yukaCon.AltTkeyMotionName = alt_TbuttonText.options[alt_TbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltYkeyMotionName = yukaCon.AltYkeyMotionName = alt_YbuttonText.options[alt_YbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltUkeyMotionName = yukaCon.AltUkeyMotionName = alt_UbuttonText.options[alt_UbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltIkeyMotionName = yukaCon.AltIkeyMotionName = alt_IbuttonText.options[alt_IbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltOkeyMotionName = yukaCon.AltOkeyMotionName = alt_ObuttonText.options[alt_ObuttonText.value].text;
		PlayerDataManager.instance.playerData.AltPkeyMotionName = yukaCon.AltPkeyMotionName = alt_PbuttonText.options[alt_PbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltAkeyMotionName = yukaCon.AltAkeyMotionName = alt_AbuttonText.options[alt_AbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltSkeyMotionName = yukaCon.AltSkeyMotionName = alt_SbuttonText.options[alt_SbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltDkeyMotionName = yukaCon.AltDkeyMotionName = alt_DbuttonText.options[alt_DbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltFkeyMotionName = yukaCon.AltFkeyMotionName = alt_FbuttonText.options[alt_FbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltGkeyMotionName = yukaCon.AltGkeyMotionName = alt_GbuttonText.options[alt_GbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltHkeyMotionName = yukaCon.AltHkeyMotionName = alt_HbuttonText.options[alt_HbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltJkeyMotionName = yukaCon.AltJkeyMotionName = alt_JbuttonText.options[alt_JbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltKkeyMotionName = yukaCon.AltKkeyMotionName = alt_KbuttonText.options[alt_KbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltLkeyMotionName = yukaCon.AltLkeyMotionName = alt_LbuttonText.options[alt_LbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltZkeyMotionName = yukaCon.AltZkeyMotionName = alt_ZbuttonText.options[alt_ZbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltXkeyMotionName = yukaCon.AltXkeyMotionName = alt_XbuttonText.options[alt_XbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltCkeyMotionName = yukaCon.AltCkeyMotionName = alt_CbuttonText.options[alt_CbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltVkeyMotionName = yukaCon.AltVkeyMotionName = alt_VbuttonText.options[alt_VbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltBkeyMotionName = yukaCon.AltBkeyMotionName = alt_BbuttonText.options[alt_BbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltNkeyMotionName = yukaCon.AltNkeyMotionName = alt_NbuttonText.options[alt_NbuttonText.value].text;
		PlayerDataManager.instance.playerData.AltMkeyMotionName = yukaCon.AltMkeyMotionName = alt_MbuttonText.options[alt_MbuttonText.value].text;
        SaveData.SetClass<PlayerData> (PlayerDataManager.playerDataKey, PlayerDataManager.instance.playerData);
		SaveData.Save ();
		parentUI.settingOpenFlag = false;
		this.gameObject.SetActive(false);
	}

	public void ShiftChange()
	{
		if (!shiftSelect) 
		{
			NormalSettings.SetActive (false);
			ShiftSettings.SetActive (true);
			CtrlSettings.SetActive (false);
			AltSettings.SetActive (false);

			shiftSelect = true;
			ctrlSelect = false;
			altSelect = false;
			var _colors = ShiftChangeButton.colors;

			_colors.normalColor = new Color (255f / 255f, 255f / 255f, 0f / 255f); 
			_colors.highlightedColor = new Color (255f / 255f, 255f / 255f, 0f / 255f); 
			_colors.pressedColor = new Color (125f / 255f, 125f / 255f, 0f / 255f); 
			_colors.disabledColor = new Color (255f / 255f, 255f / 255f, 0f / 255f);

			ShiftChangeButton.colors = _colors;
			CtrlChangeButton.colors = ColorBlock.defaultColorBlock;
			AltChangeButton.colors = ColorBlock.defaultColorBlock;
		}
		else
		{
			NormalSettings.SetActive (true);
			ShiftSettings.SetActive (false);
			CtrlSettings.SetActive (false);
			AltSettings.SetActive (false);

			shiftSelect = false;
			ShiftChangeButton.colors = ColorBlock.defaultColorBlock;
			CtrlChangeButton.colors = ColorBlock.defaultColorBlock;
			AltChangeButton.colors = ColorBlock.defaultColorBlock;
		}
	}

	public void CtrlChange()
	{
		if(!ctrlSelect)
		{
			NormalSettings.SetActive (false);
			ShiftSettings.SetActive (false);
			CtrlSettings.SetActive (true);
			AltSettings.SetActive (false);

			shiftSelect = false;
			ctrlSelect = true;
			altSelect = false;
			var _colors = ShiftChangeButton.colors;

			_colors.normalColor = new Color (255f / 255f, 255f / 255f, 0f / 255f); 
			_colors.highlightedColor = new Color (255f / 255f, 255f / 255f, 0f / 255f); 
			_colors.pressedColor = new Color (125f / 255f, 125f/ 255f, 0f / 255f); 
			_colors.disabledColor = new Color (255f / 255f, 255f / 255f, 0f / 255f);

			ShiftChangeButton.colors = ColorBlock.defaultColorBlock;
			CtrlChangeButton.colors = _colors;
			AltChangeButton.colors = ColorBlock.defaultColorBlock;
		}
		else
		{
			NormalSettings.SetActive (true);
			ShiftSettings.SetActive (false);
			CtrlSettings.SetActive (false);
			AltSettings.SetActive (false);

			ctrlSelect = false;
			ShiftChangeButton.colors = ColorBlock.defaultColorBlock;
			CtrlChangeButton.colors = ColorBlock.defaultColorBlock;
			AltChangeButton.colors = ColorBlock.defaultColorBlock;
		}
	}

	public void AltChange()
	{
		if(!altSelect)
		{
			NormalSettings.SetActive (false);
			ShiftSettings.SetActive (false);
			CtrlSettings.SetActive (false);
			AltSettings.SetActive (true);

			shiftSelect = false;
			ctrlSelect = false;
			altSelect = true;
			var _colors = ShiftChangeButton.colors;

			_colors.normalColor = new Color (255f / 255f, 255f / 255f, 0f / 255f); 
			_colors.highlightedColor = new Color (255f / 255f, 255f / 255f, 0f / 255f); 
			_colors.pressedColor = new Color (125f / 255f, 125f/ 255f, 0f / 255f); 
			_colors.disabledColor = new Color (255f / 255f, 255f / 255f, 0f / 255f);

			ShiftChangeButton.colors = ColorBlock.defaultColorBlock;
			CtrlChangeButton.colors = ColorBlock.defaultColorBlock;
			AltChangeButton.colors = _colors;
		}
		else
		{
			NormalSettings.SetActive (true);
			ShiftSettings.SetActive (false);
			CtrlSettings.SetActive (false);
			AltSettings.SetActive (false);

			altSelect = false;
			ShiftChangeButton.colors = ColorBlock.defaultColorBlock;
			CtrlChangeButton.colors = ColorBlock.defaultColorBlock;
			AltChangeButton.colors = ColorBlock.defaultColorBlock;
		}
	}

	public void specialkeyInit()
	{
		NormalSettings.SetActive (true);
		ShiftSettings.SetActive (false);
		CtrlSettings.SetActive (false);
		AltSettings.SetActive (false);


		ShiftChangeButton.colors = ColorBlock.defaultColorBlock;
		CtrlChangeButton.colors = ColorBlock.defaultColorBlock;
		AltChangeButton.colors = ColorBlock.defaultColorBlock;

		shiftSelect = false;
		ctrlSelect = false;
		altSelect = false;
	}
}
