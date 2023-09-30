using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Manager : MonoBehaviour
{

    public Button[] Turret_Slots;
    private int Turret_Slots_Number;
    public Sprite[] Tower_Tier_1;
    public Sprite[] Tower_Tier_2;
    public Sprite[] Tower_Tier_3;
    public Sprite[] Tower_Tier_4;


    private int[] Turret_Slot_Rarity;
   



    public TextMeshProUGUI Money_txt;
    public TextMeshProUGUI Level_txt;
    public TextMeshProUGUI Exp_txt;
    public Scrollbar Exp_Scroll;

    public int Money;
    private int Level = 0;
    public int LevelMax = 5;
    public int[] LevelExp;
    private int exp;

    private float Rarity_Tier_1;
    private float Rarity_Tier_2;
    private float Rarity_Tier_3;
    private float Rarity_Tier_4;

    public TextMeshProUGUI Rarity_Tier_1_txt;
    public TextMeshProUGUI Rarity_Tier_2_txt;
    public TextMeshProUGUI Rarity_Tier_3_txt;
    public TextMeshProUGUI Rarity_Tier_4_txt;
    // Start is called before the first frame update
    void Start()
    {

        Turret_Slot_Rarity = new int[Turret_Slots.Length];

        LevelUp();
        setRarity(Level);
        RefreshShop();
        for (int i = 0; i < Turret_Slots.Length; i++)
        {

            int buttonIndex = i;
            
            Turret_Slots[i].onClick.AddListener(() => ClickOnTurretSlots(buttonIndex));
        }


    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoney(0);


        if (Input.GetKeyDown(KeyCode.D) && Money >=2)
        {
            UpdateMoney(-2);
            RefreshShop();
        }
        if (Input.GetKeyDown(KeyCode.E) )
        {
            UpdateMoney(10);
        }
        if (Input.GetKeyDown(KeyCode.F) && Level <= LevelMax)
        {
            

            if (Level != LevelMax)
            {
                UpdateExp(4);


            }
            if (exp >= LevelExp[Level])
            {
                exp -= LevelExp[Level];
                LevelUp();
                UpdateExp(0);
                

            }


        }
        if(LevelExp[Level]!= 00)
        {
            Exp_Scroll.size = exp / LevelExp[Level];
            Debug.Log(exp);
            Debug.Log(LevelExp[Level]);
        }
        





    }

    
    void UpdateMoney(int change)
    {
        //change = argent gagner après action (perdu si négatif)
        Money = Money + change;
        Money_txt.text = Money.ToString();
    }
    void RefreshShop()
    {

        for (int i = 0; i < Turret_Slots.Length; i++)
        {

            PickRandomTierAndTower(i);





        }
    }

    void setRarity(int level)
    {
        if(level == 1)
        {
            Rarity_Tier_1 = 100;
            Rarity_Tier_2 = 0;
            Rarity_Tier_3 = 0;
            Rarity_Tier_4 = 0;
        }
        if (level == 2)
        {
            Rarity_Tier_1 = 80;
            Rarity_Tier_2 = 20;
            Rarity_Tier_3 = 0;
            Rarity_Tier_4 = 0;
        }
        if (level == 3)
        {
            Rarity_Tier_1 = 50;
            Rarity_Tier_2 = 30;
            Rarity_Tier_3 = 20;
            Rarity_Tier_4 = 0;
        }
        if (level == 4)
        {
            Rarity_Tier_1 = 30;
            Rarity_Tier_2 = 35;
            Rarity_Tier_3 = 25;
            Rarity_Tier_4 = 10;
        }
        if (level == 5)
        {
            Rarity_Tier_1 = 10;
            Rarity_Tier_2 = 20;
            Rarity_Tier_3 = 40;
            Rarity_Tier_4 = 30;
        }
        if (level == 5)
        {
            Rarity_Tier_1 = 0;
            Rarity_Tier_2 = 5;
            Rarity_Tier_3 = 35;
            Rarity_Tier_4 = 60;
        }

        Rarity_Tier_1_txt.text = Rarity_Tier_1.ToString();
        Rarity_Tier_2_txt.text = Rarity_Tier_2.ToString();
        Rarity_Tier_3_txt.text = Rarity_Tier_3.ToString();
        Rarity_Tier_4_txt.text = Rarity_Tier_4.ToString();

    }
    void PickRandomTierAndTower(int i)
    {
        int RandomTier = Random.Range(0, 100);
        if (RandomTier <= Rarity_Tier_1)
        {
            int RandomNumber = Random.Range(0, Tower_Tier_1.Length);
            Turret_Slots[i].image.sprite = Tower_Tier_1[RandomNumber];
            Turret_Slot_Rarity[i] = 1;

        }
        if (RandomTier >= Rarity_Tier_1 && RandomTier <= Rarity_Tier_2 + Rarity_Tier_1)
        {
            int RandomNumber = Random.Range(0, Tower_Tier_2.Length);
            Turret_Slots[i].image.sprite = Tower_Tier_2[RandomNumber];
            Turret_Slot_Rarity[i] = 2;


        }
        if (RandomTier >= Rarity_Tier_2 + Rarity_Tier_1 && RandomTier <= Rarity_Tier_3 + Rarity_Tier_2 + Rarity_Tier_1)
        {
            int RandomNumber = Random.Range(0, Tower_Tier_3.Length);
            Turret_Slots[i].image.sprite = Tower_Tier_3[RandomNumber];
            Turret_Slot_Rarity[i] = 3;


        }
        if (RandomTier >= Rarity_Tier_3 + Rarity_Tier_2 + Rarity_Tier_1 && RandomTier <= Rarity_Tier_4 + Rarity_Tier_3 + Rarity_Tier_2 + Rarity_Tier_1)
        {
            int RandomNumber = Random.Range(0, Tower_Tier_4.Length);
            Turret_Slots[i].image.sprite = Tower_Tier_4[RandomNumber];
            Turret_Slot_Rarity[i] = 4; 

        }
    }

    void UpdateExp(int change)
    {
        exp += change;
        Exp_txt.text = exp.ToString();
    }
    void LevelUp()
    {

        //play sound
        Level += 1;
        setRarity(Level);
        Level_txt.text = Level.ToString();
    }

    void ClickOnTurretSlots(int index)
    {
        Debug.Log("+" + Turret_Slot_Rarity[index]);

        UpdateMoney(- Turret_Slot_Rarity[index]);
        Turret_Slot_Rarity[index] = 0;
        Turret_Slots[index].image.sprite = null;
    }
}
