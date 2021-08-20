using Coffee.UIEffects;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourScriptOfSymbol : MonoBehaviour
{
    /// <summary>
    /// 转化按钮
    /// </summary>
    public Button ButtonInclude, ButtonOpposite, ButtonReverse;

    /// <summary>
    /// 阴阳爻精灵
    /// </summary>
    public Sprite SpritePositive, SpriteNegative;

    /// <summary>
    /// 下拉菜单
    /// </summary>
    public Dropdown DropdownId,DropdownMain,DropdownGuest;

    /// <summary>
    /// 初爻编号
    /// </summary>
    public Image Gram1;

    /// <summary>
    /// 二爻编号
    /// </summary>
    public Image Gram2;

    /// <summary>
    /// 三爻编号
    /// </summary>
    public Image Gram3;

    /// <summary>
    /// 四爻编号
    /// </summary>
    public Image Gram4;

    /// <summary>
    /// 五爻编号
    /// </summary>
    public Image Gram5;

    /// <summary>
    /// 上爻编号
    /// </summary>
    public Image Gram6;

    /// <summary>
    /// 初爻卦辞
    /// </summary>
    public Text GramDes1;

    /// <summary>
    ///二爻卦辞
    /// </summary>
    public Text GramDes2;

    /// <summary>
    /// 三爻卦辞
    /// </summary>
    public Text GramDes3;

    /// <summary>
    /// 四爻卦辞
    /// </summary>
    public Text GramDes4;

    /// <summary>
    /// 五爻卦辞
    /// </summary>
    public Text GramDes5;

    /// <summary>
    /// 上爻卦辞
    /// </summary>
    public Text GramDes6;

    /// <summary>
    /// 卦名
    /// </summary>
    public Text Name;

    /// <summary>
    /// 卦辞
    /// </summary>
    public Text Des1;

    /// <summary>
    /// 象
    /// </summary>
    public Text Des2;

    /// <summary>
    /// 彖传
    /// </summary>
    public Text Des3;

    /// <summary>
    /// 主卦编号
    /// </summary>
    private int MainId=0;

    /// <summary>
    /// 客卦编号
    /// </summary>
    private int GuestId=0;

    /// <summary>
    /// 卦编号
    /// </summary>
    private int Id=0;

    /// <summary>
    /// 当前卦象
    /// </summary>
    private Item mCurItem;

    private UIShiny shiny;

    // Start is called before the first frame update
    void Start()
    {
        DropdownId.onValueChanged.AddListener(OnIdChanged);
        DropdownMain.onValueChanged.AddListener(OnMainIdChanged);
        DropdownGuest.onValueChanged.AddListener(OnGuestChanged);
        ButtonInclude.onClick.AddListener(OnIncludeClick);
        ButtonOpposite.onClick.AddListener(OnOppositeClick);
        ButtonReverse.onClick.AddListener(OnReverseClick);
        transform.Find("ButtonMenu").GetComponent<Button>().onClick.AddListener(OnButtonMenuClick);
        transform.Find("ButtonQuit").GetComponent<Button>().onClick.AddListener(OnButtonQuitClick);
        OnIdChanged(0);
    }

    private void OnButtonMenuClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    private void OnButtonQuitClick()
    {
        Application.Quit();
    }

    private void OnReverseClick()
    {
        IndexDispatcher.Instance.Dispatch("ShowChangeOfSymbol", mCurItem.ReverseId);
        ChangeShinyButton(ButtonReverse);
    }

    private void OnOppositeClick()
    {
        IndexDispatcher.Instance.Dispatch("ShowChangeOfSymbol", mCurItem.OppositeId);
        ChangeShinyButton(ButtonOpposite);
    }

    private void OnIncludeClick()
    {
        IndexDispatcher.Instance.Dispatch("ShowChangeOfSymbol", mCurItem.IncludeId);
        ChangeShinyButton(ButtonInclude);
    }

    private void ChangeShinyButton(Button button)
    {
        if (shiny != null)
        {
            shiny.Stop();
            shiny.effectFactor = 1f;
        }
        shiny = button.GetComponent<UIShiny>();
        shiny?.Play();
    }

    private void OnGuestChanged(int arg0)
    {
        if (arg0!=GuestId)
        {
            GuestId = arg0;
            mCurItem = ItemManager.Instance.GetItemBySearch(MainId, GuestId);
            Id = mCurItem.Id;
            MainId = mCurItem.MainId;
            DropdownMain.value = MainId;
            DropdownId.value =Id-1;
            UpdateSymbol();
        }
    }

    private void OnMainIdChanged(int arg0)
    {
        if (arg0!=MainId)
        {
            MainId = arg0;
            mCurItem = ItemManager.Instance.GetItemBySearch(MainId,GuestId);
            Id = mCurItem.Id;
            GuestId = mCurItem.GuestId;
            DropdownId.value = Id-1;
            DropdownGuest.value = GuestId;
            UpdateSymbol();
        }
    }

    private void OnIdChanged(int arg0)
    {
        if ((arg0+1)!=Id)
        {
            Id = arg0+1;
            mCurItem = ItemManager.Instance.GetItemById(arg0);
            MainId= mCurItem.MainId;
            GuestId= mCurItem.GuestId;
            DropdownMain.value = MainId;
            DropdownGuest.value = GuestId;
            UpdateSymbol();
        }
    }

    private void UpdateSymbol()
    {
        IndexDispatcher.Instance.Dispatch("ShowChangeOfSymbol", -1);
        if (shiny != null)
        {
            shiny.Stop();
            shiny.effectFactor = 1f;
        }
        Name.DOText(mCurItem.Name,1f);
        UpdateGram(mCurItem.GramId1, Gram1);
        UpdateGram(mCurItem.GramId2, Gram2);
        UpdateGram(mCurItem.GramId3, Gram3);
        UpdateGram(mCurItem.GramId4, Gram4);
        UpdateGram(mCurItem.GramId5, Gram5);
        UpdateGram(mCurItem.GramId6, Gram6);
        GramDes1.text = string.Empty;
        GramDes1.DOText(mCurItem.GramDes1,2f);
        GramDes2.text = string.Empty;
        GramDes2.DOText(mCurItem.GramDes2, 2f);
        GramDes3.text = string.Empty;
        GramDes3.DOText(mCurItem.GramDes3, 2f);
        GramDes4.text = string.Empty;
        GramDes4.DOText(mCurItem.GramDes4, 2f);
        GramDes5.text = string.Empty;
        GramDes5.DOText(mCurItem.GramDes5, 2f);
        GramDes6.text = string.Empty;
        GramDes6.DOText(mCurItem.GramDes6, 2f);
        Des1.text = string.Empty;
        Des1.DOText(mCurItem.Des1,2f);
        Des2.text = string.Empty;
        Des2.DOText(mCurItem.Des2, 2f);
        Des3.text = string.Empty;
        Des3.DOText(mCurItem.Des3, 2f);
    }

    private void UpdateGram(int id,Image gram)
    {
        if (id == 0)
        {
            gram.DOFade(0, 1f).OnComplete(
                () =>
                {
                    gram.sprite = SpriteNegative;
                    gram.DOFade(1f, 1f);
                });
        }
        else
        {
            gram.DOFade(0, 1f).OnComplete(
            () =>
            {
                gram.sprite = SpritePositive;
                gram.DOFade(1f, 1f);
            });
        }
    }

    private void OnDestroy()
    {
        DropdownId.onValueChanged.RemoveListener(OnIdChanged);
        DropdownMain.onValueChanged.RemoveListener(OnMainIdChanged);
        DropdownGuest.onValueChanged.RemoveListener(OnGuestChanged);
        ButtonInclude.onClick.RemoveListener(OnIncludeClick);
        ButtonOpposite.onClick.RemoveListener(OnOppositeClick);
        ButtonReverse.onClick.RemoveListener(OnReverseClick);
        transform.Find("ButtonMenu").GetComponent<Button>().onClick.RemoveListener(OnButtonMenuClick);
        transform.Find("ButtonQuit").GetComponent<Button>().onClick.RemoveListener(OnButtonQuitClick);
    }
}
