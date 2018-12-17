//using UnityEngine;
//using UnityEngine.UI;


//public class LevelSelector : MonoBehaviour {

//    public SceneFader fader;

//    public Button[] levelButtons;

//    void Start()
//    {
//        int levelReached = PlayerPrefs.GetInt("levelReached",1);

//        for (int i = 0; i < levelButtons.Length; i++)
//        {
//            if (i +1 > levelReached)
//                levelButtons[i].interactable = false;

//        }
//    }


//	public void Select(string levelName)
//    {
//        fader.FadeTo(levelName);
//    }
//}
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;

    public Button[] levelButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        Debug.Log("Level Reached"+levelReached);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if( i +1> levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

}
