using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourOfChange : MonoBehaviour
{

    public Transform Image8;

    /// <summary>
    /// 阴阳爻精灵
    /// </summary>
    public Sprite SpritePositive, SpriteNegative;

    /// <summary>
    /// 
    /// 文本
    /// </summary>
    public Text TextId, TextMain, TextGuest;

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
    /// 卦编号
    /// </summary>
    private int Id = 0;

    /// <summary>
    /// 当前卦象
    /// </summary>
    private Item mCurItem;


    // Start is called before the first frame update
    void Start()
    {
        IndexDispatcher.Instance.AddEventListener("ShowChangeOfSymbol", ShowChangeOfSymbol);
        gameObject.SetActive(false);
    }

    private void ShowChangeOfSymbol(int arg0)
    {
        if (arg0==-1)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);
        if (arg0!= Id)
        {
            Id = arg0;
            mCurItem = ItemManager.Instance.GetItemById(Id-1);
            TextId.DOText(Id.ToString(),2f);
            TextMain.DOText(GetNameById(mCurItem.MainId),2f);
            TextGuest.DOText(GetNameById(mCurItem.GuestId), 2f);
            Name.DOText(mCurItem.Name, 1f);
            UpdateGram(mCurItem.GramId1, Gram1);
            UpdateGram(mCurItem.GramId2, Gram2);
            UpdateGram(mCurItem.GramId3, Gram3);
            UpdateGram(mCurItem.GramId4, Gram4);
            UpdateGram(mCurItem.GramId5, Gram5);
            UpdateGram(mCurItem.GramId6, Gram6);
            GramDes1.text = string.Empty;
            GramDes1.DOText(mCurItem.GramDes1, 2f);
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
            Des1.DOText(mCurItem.Des1, 2f);
            Des2.text = string.Empty;
            Des2.DOText(mCurItem.Des2, 2f);
            Des3.text = string.Empty;
            Des3.DOText(mCurItem.Des3, 2f);
        }
    }

    private string GetNameById(int id)
    {
        string ret = string.Empty;
        switch (id)
        {
            case 0:
                ret = "乾";
                break;
            case 1:
                ret = "坤";
                break;
            case 2:
                ret = "艮";
                break;
            case 3:
                ret = "兑";
                break;
            case 4:
                ret = "坎";
                break;
            case 5:
                ret = "离";
                break;
            case 6:
                ret = "巽";
                break;
            case 7:
                ret = "震";
                break;
            default:
                break;
        }
        return ret;
    }

    private void UpdateGram(int id, Image gram)
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

    private void Update()
    {
        Image8.Rotate(-Vector3.forward * 100 * Time.deltaTime);
    }

    private void OnDestroy()
    {
        IndexDispatcher.Instance.RemoveEventListener("ShowChangeOfSymbol", ShowChangeOfSymbol);
    }
}
