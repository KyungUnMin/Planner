using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageCtrl : MonoBehaviour
{
    public PageMgr.PageType type;
    public Color selectColor = new Color();

    public PageGrid grid = new PageGrid();
    private Transform content;
    private int selectCol = 0;

    public void Init()
    {
        content = Util.FindChild<VerticalLayoutGroup>(gameObject, "Content", true).transform;
        grid.Init(content, this);
    }

    public void CheckColumnHandler(int column)
    {
        selectCol = column;
        grid.CheckColumn(column, selectColor);
    }

    public int GetSelectCol() { return selectCol; }
    
}
