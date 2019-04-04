using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInfo : MonoBehaviour
{

    private static ObjectsInfo _instance;
    public TextAsset objectInfoListText;
    private Dictionary<int, ObjectInfo> objectInfoDict=new Dictionary<int, ObjectInfo>();//通过物品ID来建立与ObjectInfo的联系

    public static ObjectsInfo GetInstance()
    {
        return _instance;
    }

    void Awake()
    {
        _instance = this;
        ReadInfo();
        print(objectInfoDict.Count);
    }

    public ObjectInfo GetObjectInfoById(int id)//根据id获取ObjectInfo详细信息
    {
        ObjectInfo info = null;
        objectInfoDict.TryGetValue(id, out info);
        return info;
    }

    void ReadInfo()
    {
        string text = objectInfoListText.text;
        string[] strArray = text.Split('\n');//按照每行进行分割
        foreach (string str in strArray)
        {
            string[] proArray = str.Split(',');//获取每行的属性
            ObjectInfo info= new ObjectInfo();

            int id = int.Parse(proArray[0]);
            string name = proArray[1];
            string icon_name = proArray[2];
            string str_type = proArray[3];
            ObjectType type = ObjectType.Drug;
            switch (str_type)
            {
                case "Drug":
                    type = ObjectType.Drug;
                    break;
                case "Equip":
                    type = ObjectType.Equip;
                    break;
                case "Mat":
                    type = ObjectType.Mat;
                    break;
            }

            info.id = id;
            info.name = name;
            info.icon_name = icon_name;
            info.type = type;
            if (type == ObjectType.Drug)
            {
                int hp = int.Parse(proArray[4]);
                info.hp = hp;
                int mp = int.Parse(proArray[5]);
                info.mp = mp;
            }
            int price_sell = int.Parse(proArray[6]);
            int price_buy = int.Parse(proArray[7]);
            info.price_sell = price_sell;
            info.price_buy = price_buy;

            objectInfoDict.Add(id,info);//添加到字典中，根据物品ID来获取ObjectInfo中其他信息
        }
        
    }
}

public enum ObjectType
{
    Drug,
    Equip,
    Mat
}
//id,名称,icon名称,类型,加血量,加魔法,出售价,购买价
public class ObjectInfo
{
    public int id;
    public string name;
    public string icon_name;
    public ObjectType type;
    public int hp;
    public int mp;
    public int price_sell;
    public int price_buy;
}
