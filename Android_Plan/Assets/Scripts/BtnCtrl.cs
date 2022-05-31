using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCtrl : MonoBehaviour
{
    public void OnClick(int iType)
    {
        PageMgr.PageType nowType = (PageMgr.PageType)iType;
        if (Manager.Page.GetCurPageType() == nowType)
            return;

        Manager.Page.ChangePage(nowType);
    }

    public void Save()
    {
        Manager.Data.SavePrefab();
    }


}
