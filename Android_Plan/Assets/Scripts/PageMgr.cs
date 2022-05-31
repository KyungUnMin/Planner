using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageMgr
{
    public enum PageType
    {
        Month = 0,
        Week,
        Daily,
        Count
    }

    private PageType curPage;
    private PageCtrl[] arrPage = new PageCtrl[(int)PageType.Count];
    public PageCtrl GetCurPage() { return arrPage[(int)curPage]; }
    public PageCtrl GetPage(PageType eType) { return arrPage[(int)eType]; }
    public PageType GetCurPageType() { return curPage; }
    

    public void Init(PageType _curPage)
    {
        curPage = _curPage;
        foreach(PageCtrl ctrl in GameObject.FindObjectsOfType<PageCtrl>())
        {
            arrPage[(int)ctrl.type] = ctrl;
            ctrl.Init();
            if (_curPage == ctrl.type)
                ctrl.gameObject.SetActive(true);
            else
                ctrl.gameObject.SetActive(false);
        }
    }

    public void ChangePage(PageType nextType)
    {
        arrPage[(int)curPage].gameObject.SetActive(false);
        arrPage[(int)nextType].gameObject.SetActive(true);

        if ((int)curPage < (int)PageType.Daily)
            arrPage[(int)curPage + 1].grid.SetColumnData(arrPage[(int)curPage].grid);

        for(int nowType = 0; nowType<(int)PageType.Count; ++nowType)
        {
            if((int)curPage != nowType)
                arrPage[nowType].grid.SetSubjectData(arrPage[(int)curPage].grid);
        }

        curPage = nextType;
    }




}
