using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourAbout : MonoBehaviour
{
    private Transform transformSymbol, transformCircle;

    private Text textAbout;

    // Start is called before the first frame update
    void Start()
    {
        transformSymbol = transform.Find("Logo/Symbol8");
        transformCircle = transform.Find("Logo/ImageCircle");
        textAbout = transform.Find("TextAbout").GetComponent<Text>();
        transform.Find("ButtonMenu").GetComponent<Button>().onClick.AddListener(OnButtonMenuClick);
        transform.Find("ButtonQuit").GetComponent<Button>().onClick.AddListener(OnButtonQuitClick);
        textAbout.DOText(@"周易可以追溯到上古,伏羲观天地万物变化，得神启，衍八卦，至周文王时发扬光大，推演出六十四卦，所以易经往往被称为周易。
周易至今已有五千余年的历史，可以说周易是伴随华夏文明一同成长起来的。
古今中外，对周易都是推崇备至，即使不用来卜筮，学周易，明义理，也是普遍认可的。
这其中往往离不开孔圣人对周易的推广，因为他的贡献，即使那些没有学过周易的人都知道“物极必反”、“否极泰来”的道理，
而“天行健，君子以自强不息；地势坤，君子以厚德载物”诸如此类的卦辞、爻辞、象传、彖传，其实早已深入人心，已经成为华夏文明不可分割的重要血缘。
我读周易比较晚，在三十二岁的年纪，先读了金刚经三十二卷，才学习周易六十四卦，似乎冥冥中自有天意，又或者只是机缘巧合。
总之这个年龄的阅历，足以支撑学习这些国粹经典。工作之余，学之余，将自己所学用于实践，就有了这个应用。
有人用周易来卜筮，断吉凶，从而指导日常行为；也有人只是用周易的道理来作为行为准则，这些原则就如孔圣所示：乃君子之道。
我十分认同圣人先贤的观点，预测未来的吉凶祸福不是最重要的，最重要的在于我们如何在每一个时间点上对可获得信息做出正确的应对。
这也是易理所阐明的道理，六爻中每一爻都有其天时、地理、人和，每一爻都有不同信息和应对方式，六爻一起构成了事物演化的规则，而整个卦象又呈现变化的趋势。
我开发这个应用，推崇先明易理，用于卜筮，还是用于指导人生，这都由大家自由去使用。
对于易理，除了经典的卦辞、爻辞、象、彖传等阐述外，我想制作更加简明易懂的六格漫画，当然我是一个程序员，对于漫画创作还是一窍不通，希望通过此文抛砖引玉，寻找一些明易理的人创作这些六格漫画，加载到应用中去。
后期也想制作道德经、黄帝内经、资治通鉴之类的经典演绎，以传承和弘扬华夏文明，我将这个项目进行开源，希望有志同道合的朋友可以加入进来，一起完成这个应用的研发。
PlasticHub开源地址：I Ching theory@ssl://cloud1989@sh02-plasticscm.unity.cn:8787
建议反馈邮箱：cloud198923@qq.com",160f);
    }

    private void OnButtonMenuClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    private void OnButtonQuitClick()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        transformSymbol.Rotate(-Vector3.forward * 200f * Time.deltaTime);
        transformCircle.Rotate(-Vector3.forward * 100f * Time.deltaTime);
    }

    private void OnDestroy()
    {
        transform.Find("ButtonMenu").GetComponent<Button>().onClick.RemoveListener(OnButtonMenuClick);
        transform.Find("ButtonQuit").GetComponent<Button>().onClick.RemoveListener(OnButtonQuitClick);
    }
}
