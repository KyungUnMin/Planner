using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataMgr
{
    private string[] strDatas = new string[(int)PageMgr.PageType.Count];

    public void Init()
    {
        LoadPrefab();
    }

    private void LoadPrefab()               //어플을 켤때 호출
    {
        for (int i = 0; i < (int)PageMgr.PageType.Count; ++i)
        {
            PageCtrl page = Manager.Page.GetPage((PageMgr.PageType)i);
            string key = System.Enum.GetName(typeof(PageMgr.PageType), (PageMgr.PageType)i);
            strDatas[i] = PlayerPrefs.GetString(key);
            LoadData(page);
            int selectCol = PlayerPrefs.GetInt(key + "INT");
            page.CheckColumnHandler(selectCol);
        }
    }

    private void LoadData(PageCtrl page)
    {
        string[] datas = strDatas[(int)page.type].Split('/');
        if (datas.Length < 2)
            return;

        int gridLen = page.grid.GetTextsLength();
        for (int i = 0; i < gridLen; ++i)
        {
            if (datas[i] == "NULL")
                page.grid.SetTexts(i, "");
            else
                page.grid.SetTexts(i, datas[i]);
        }
    }

    public void SavePrefab()                //어플을 끌때 호출
    {
        for (int i = 0; i < (int)PageMgr.PageType.Count; ++i)
        {
            PageCtrl page = Manager.Page.GetPage((PageMgr.PageType)i);
            SaveData(page);
            string key = System.Enum.GetName(typeof(PageMgr.PageType), (PageMgr.PageType)i);
            PlayerPrefs.SetString(key, strDatas[i]);
            PlayerPrefs.SetInt(key + "INT", page.GetSelectCol());
        }
        PlayerPrefs.Save();
    }

    private void SaveData(PageCtrl page)
    {
        strDatas[(int)page.type] = "";

        foreach (Text mapText in page.grid.GetTexts())
        {
            if (string.IsNullOrEmpty(mapText.text))
                strDatas[(int)page.type] += "NULL";
            else
                strDatas[(int)page.type] += mapText.text;

            strDatas[(int)page.type] += "/";
        }
    }
}
