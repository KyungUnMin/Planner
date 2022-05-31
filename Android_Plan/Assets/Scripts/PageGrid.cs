using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageGrid
{
    private PageCtrl ctrl;
    private int sizeY;
    private int sizeX;
    private Image[] mapImage;
    private Text[] mapTexts;
    private int selectedCol = 0;

    public void Init(Transform content, PageCtrl ctrl)
    {
        this.ctrl = ctrl;

        sizeY = content.childCount;
        sizeX = content.GetChild(0).childCount;
        mapImage = new Image[sizeY * sizeX];
        mapTexts = new Text[sizeY * sizeX];

        for (int y = 0; y < sizeY; ++y)
        {
            Transform row = content.GetChild(y);
            for (int x = 0; x < sizeX; ++x)
            {
                Transform col = row.GetChild(x);
                SetMap(col, y * sizeX + x);
            }
        }

    }

    private void SetMap(Transform grid, int idx)
    {
        Image img = grid.GetComponent<Image>();
        if (img != null)
            mapImage[idx] = img;

        Text text = Util.FindChild<Text>(grid.gameObject, "Text", true);
        if (text != null)
            mapTexts[idx] = text;
    }

    public void CheckColumn(int column, Color color)
    {
        for (int y = 0; y < sizeY; ++y)
        {
            int nowIdx = y * sizeX + column;
            int pastIdx = y * sizeX + selectedCol;

            if (mapImage[nowIdx] != null)
                mapImage[nowIdx].color = color;

            if (mapImage[pastIdx] != null)
                mapImage[pastIdx].color = Color.white;
        }
        selectedCol = column;
    }

    public Text[] GetTexts() { return mapTexts; }
    public int GetTextsLength() { return mapTexts.Length; }

    public void SetTexts(int idx, string str)
    {
        mapTexts[idx].text =  str;
        InputField field = mapTexts[idx].transform.parent.GetComponent<InputField>();
        if (field != null)
            field.text = str;
    }

    public int GetSelectCol() { return selectedCol; }
    public int GetSizeX() { return sizeX; }

    public void SetColumnData(PageGrid src)
    {
        int srcCol = src.GetSelectCol();
        SetGrid(src, srcCol);
        Text[] srcGrid = src.GetTexts();
        mapTexts[0].text = srcGrid[srcCol].text;
    }

    public void SetSubjectData(PageGrid src)
    {
        SetGrid(src, 0);
    }

    private void SetGrid(PageGrid src, int srcCol)
    {
        int srcX = src.GetSizeX();
        Text[] srcGrid = src.GetTexts();
        for (int y = 1; y < sizeY; ++y)
        {
            int srcIdx = y * srcX + srcCol;
            int destIdx = y * sizeX + 1;
            if (srcCol == 0)
                --destIdx;

            mapTexts[destIdx].text = srcGrid[srcIdx].text;
        }
    }

}
