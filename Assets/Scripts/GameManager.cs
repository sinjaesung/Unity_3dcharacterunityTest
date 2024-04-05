using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canPlayerMove = true; //플레이어의 움직임 제어

    public static bool isOpenInventory = false; //인벤토리 활성화
    public static bool isOpenCraftMenu = false; //건축 메뉴창 활성화

    public static bool isNight = false;
    public static bool isWater = false;

    public static bool isPause = false; //메뉴가 호출되면 true

    public static int playerDamage = 0;
    public static Color playerEffectColor;

    //private bool flag = false;

}
