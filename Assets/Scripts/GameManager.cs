using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canPlayerMove = true; //�÷��̾��� ������ ����

    public static bool isOpenInventory = false; //�κ��丮 Ȱ��ȭ
    public static bool isOpenCraftMenu = false; //���� �޴�â Ȱ��ȭ

    public static bool isNight = false;
    public static bool isWater = false;

    public static bool isPause = false; //�޴��� ȣ��Ǹ� true

    public static int playerDamage = 0;
    public static Color playerEffectColor;

    //private bool flag = false;

}
