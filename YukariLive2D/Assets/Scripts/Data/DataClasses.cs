using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region セーブデータ管理

#region プレイヤーデータ
public class PlayerData
{
	public int version;
    public bool SaveFlag = false;
    
    /// <summary>
    /// キーモーション名
    /// </summary>
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

	public bool YukariFlag = false;
	public bool MakiFlag = false;
	public bool AkaneFlag = false;
	public bool AoiFlag = false;

	public double yukariPosX;
	public double yukariPosY;
	public double yukariPosZ;
	public double yukariScale;

	public double MakiPosX;
	public double MakiPosY;
	public double MakiPosZ;
	public double MakiScale;

	public double AkanePosX;
	public double AkanePosY;
	public double AkanePosZ;
	public double AkaneScale;

	public double AoiPosX;
	public double AoiPosY;
	public double AoiPosZ;
	public double AoiScale;

    public void SaveDataInit()
    {
		version = PlayerDataManager.buildVersion;
		QkeyMotionName = "";
		WkeyMotionName = "";
		EkeyMotionName = "";
		RkeyMotionName = "";
		TkeyMotionName = "";
		YkeyMotionName = "";
		UkeyMotionName = "";
		IkeyMotionName = "";
		OkeyMotionName = "";
		PkeyMotionName = "";
        AkeyMotionName = "";
        SkeyMotionName = "";
        DkeyMotionName = "";
        FkeyMotionName = "";
        GkeyMotionName = "";
        HkeyMotionName = "";
        JkeyMotionName = "";
        KkeyMotionName = "";
        LkeyMotionName = "";
        ZkeyMotionName = "";
        XkeyMotionName = "";
        CkeyMotionName = "";
        VkeyMotionName = "";
        BkeyMotionName = "";
        NkeyMotionName = "";
        MkeyMotionName = "";

		ShiftQkeyMotionName = "";
		ShiftWkeyMotionName = "";
		ShiftEkeyMotionName = "";
		ShiftRkeyMotionName = "";
		ShiftTkeyMotionName = "";
		ShiftYkeyMotionName = "";
		ShiftUkeyMotionName = "";
		ShiftIkeyMotionName = "";
		ShiftOkeyMotionName = "";
		ShiftPkeyMotionName = "";
		ShiftAkeyMotionName = "";
		ShiftSkeyMotionName = "";
		ShiftDkeyMotionName = "";
		ShiftFkeyMotionName = "";
		ShiftGkeyMotionName = "";
		ShiftHkeyMotionName = "";
		ShiftJkeyMotionName = "";
		ShiftKkeyMotionName = "";
		ShiftLkeyMotionName = "";
		ShiftZkeyMotionName = "";
		ShiftXkeyMotionName = "";
		ShiftCkeyMotionName = "";
		ShiftVkeyMotionName = "";
		ShiftBkeyMotionName = "";
		ShiftNkeyMotionName = "";
		ShiftMkeyMotionName = "";

		CtrlQkeyMotionName = "";
		CtrlWkeyMotionName = "";
		CtrlEkeyMotionName = "";
		CtrlRkeyMotionName = "";
		CtrlTkeyMotionName = "";
		CtrlYkeyMotionName = "";
		CtrlUkeyMotionName = "";
		CtrlIkeyMotionName = "";
		CtrlOkeyMotionName = "";
		CtrlPkeyMotionName = "";
		CtrlAkeyMotionName = "";
		CtrlSkeyMotionName = "";
		CtrlDkeyMotionName = "";
		CtrlFkeyMotionName = "";
		CtrlGkeyMotionName = "";
		CtrlHkeyMotionName = "";
		CtrlJkeyMotionName = "";
		CtrlKkeyMotionName = "";
		CtrlLkeyMotionName = "";
		CtrlZkeyMotionName = "";
		CtrlXkeyMotionName = "";
		CtrlCkeyMotionName = "";
		CtrlVkeyMotionName = "";
		CtrlBkeyMotionName = "";
		CtrlNkeyMotionName = "";
		CtrlMkeyMotionName = "";

		AltQkeyMotionName = "";
		AltWkeyMotionName = "";
		AltEkeyMotionName = "";
		AltRkeyMotionName = "";
		AltTkeyMotionName = "";
		AltYkeyMotionName = "";
		AltUkeyMotionName = "";
		AltIkeyMotionName = "";
		AltOkeyMotionName = "";
		AltPkeyMotionName = "";
		AltAkeyMotionName = "";
		AltSkeyMotionName = "";
		AltDkeyMotionName = "";
		AltFkeyMotionName = "";
		AltGkeyMotionName = "";
		AltHkeyMotionName = "";
		AltJkeyMotionName = "";
		AltKkeyMotionName = "";
		AltLkeyMotionName = "";
		AltZkeyMotionName = "";
		AltXkeyMotionName = "";
		AltCkeyMotionName = "";
		AltVkeyMotionName = "";
		AltBkeyMotionName = "";
		AltNkeyMotionName = "";
		AltMkeyMotionName = "";

		YukariFlag = false;
		MakiFlag = false;
		AkaneFlag = false;
		AoiFlag = false;

		yukariPosX = -6;
		yukariPosY = 0;
		yukariPosZ = 0;
		yukariScale = 1;

		MakiPosX = -2;
		MakiPosY = 0;
		MakiPosZ = 1;
		MakiScale = 6;

		AkanePosX = 2;
		AkanePosY = 0;
		AkanePosZ = 2;
		AkaneScale = 6;

		AoiPosX = 6;
		AoiPosY = 0;
		AoiPosZ = 3;
		AoiScale = 6;
    }
}
#endregion

#endregion
