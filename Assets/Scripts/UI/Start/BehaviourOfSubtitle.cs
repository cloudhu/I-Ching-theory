using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourOfSubtitle : MonoBehaviour
{
    /// <summary>
    /// 字幕
    /// </summary>
    Text textSubtitle;

    /// <summary>
    /// 动画
    /// </summary>
    Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        textSubtitle = GetComponent<Text>();
        StringDispatcher.Instance.AddEventListener("ShowSubtitle", ShowSubtitle);
    }

    private void ShowSubtitle(string str)
    {
        textSubtitle.text = string.Empty;
        if (tweener != null) tweener.Kill();
        tweener = textSubtitle.DOText(str,2f);
    }

    private void OnDestroy()
    {
        StringDispatcher.Instance.RemoveEventListener("ShowSubtitle", ShowSubtitle);
    }
}
