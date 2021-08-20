using UnityEngine;

public class ItemManager : ScriptableObject
{
    static ItemManager mInstance;
    public static ItemManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = Resources.Load<ItemManager>("DataAssets/Item");
            }
            return mInstance;
        }
    }
    public Item[] dataArray;

    public Item GetItemById(int id)
    {
        return dataArray[id];
    }

    public Item GetItemBySearch(int mainId,int guestId)
    {
        Item item = null;
        for (int i = 0; i < dataArray.Length; i++)
        {
            item = dataArray[i];
            if (item.MainId==mainId&&item.GuestId==guestId)
            {
                break;
            }
        }

        return item;
    }
}
