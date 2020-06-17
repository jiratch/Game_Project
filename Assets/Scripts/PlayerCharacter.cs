using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private SettingsPopup gameoverpop;


    //----------
    public Text injured;
    public Slider myhealthBar;
    private int HP;
    public Text HPtext;
    //------------
    void NOINJURED()
    {
        injured.text = "";
    }
    void Start()
    {
        
         
        //--------
        NOINJURED();
        injured.text = "";
        myhealthBar.value = 100;
        injured.text = "";
        HP = 100;
        HPtext.text = "HP : " + HP.ToString() + " %";
        gameoverpop.Close();
       

        //
    }
    private void Update()
    {
        if (HP <= 0) {
            injured.text = "     YOU ARE DIED";
            gameoverpop.Open();
            Cursor.visible = true;
        }

    }

    public void Hurt(int damage)
    {
        HP -= damage;
        HPtext.text = "HP : " + HP.ToString() + " %";
        myhealthBar.value -= damage;
        injured.text = "YOU WERE ATTACKED!!";
       // Debug.Log("HURT");

        Invoke("NOINJURED", 2.0f);

        if (HP <= 0)
        {
            HP = 0;
            HPtext.text = "HP : " + HP.ToString() + " %";
            myhealthBar.value = 0;
            



        }
    }

    



    public void Heal(int heal)
    {

            HP += 5;
            HPtext.text = "HP : " + HP.ToString() + " %";
            myhealthBar.value += 5;
            injured.text = "YOU WERE HEALED!!";
        //    Debug.Log("Heal");

            Invoke("NOINJURED", 2.0f);
        

       
       if(HP>=100) {
            HP = 100;
            HPtext.text = "HP : " + HP.ToString() + " %";
            myhealthBar.value =100;
            injured.text = "YOU WERE HEAL!!";
            Debug.Log("Heal");

            Invoke("NOINJURED", 2.0f);
        }



    }


}


 
