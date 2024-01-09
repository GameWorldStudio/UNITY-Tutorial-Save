using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int level = 0;
    public int health = 0;

    public Text txt_var_level;
    public Text txt_var_health;
    public Text txt_var_pos_x;
    public Text txt_var_pos_y;
    public Text txt_var_pos_z;

    private void Start()
    {
        try
        {
            LoadPlayer();
        }
        catch
        {

        }

        MajUI();
    }

   

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];     
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

        MajUI();

    }

    #region UI METHODE
        
    public void ChangeLevel(int amount)
    {
        level += amount;
        txt_var_level.text = level.ToString();
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        txt_var_health.text = health.ToString();
    }

    public void MajUI()
    {
        txt_var_pos_x.text = transform.position.x.ToString();
        txt_var_pos_y.text = transform.position.y.ToString();
        txt_var_pos_z.text = transform.position.z.ToString();
        txt_var_level.text = level.ToString();
        txt_var_health.text = health.ToString();
    }

    public void DeleteDataPlayer()
    {
        SaveSystem.DeleteDataPlayer();
        level = 0;
        health = 0;
        transform.position = new Vector3(0, 0, 0);
        MajUI();
    }

    #endregion
}
