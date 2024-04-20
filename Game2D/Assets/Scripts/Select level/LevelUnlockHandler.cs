using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUnlockHandler : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    int unlockLevelsnumber;
  
    // Start is called before the first frame update
    private void Start()
    {
        if (!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);

        }
        unlockLevelsnumber = PlayerPrefs.GetInt("levelsUnlocked");
        for(int i=0;i<buttons.Length;i++)
        {
            buttons[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        unlockLevelsnumber = PlayerPrefs.GetInt("levelsUnlocked");
        for (int i=0; i<unlockLevelsnumber;i++)
        {
            buttons[i].interactable = true;
        }
    }  // Phương thức để đặt lại trạng thái mở khóa của cấp độ
    public void ResetLevelsUnlocked()
    {
        PlayerPrefs.DeleteKey("levelsUnlocked"); // Xóa khóa từ PlayerPrefs
        Start();
    }
}
