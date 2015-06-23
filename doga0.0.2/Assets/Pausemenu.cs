using UnityEngine;
using System.Collections;

public class Pausemenu : MonoBehaviour {

    public GameObject bt1;
    public GameObject bt2;
    public GameObject bt3;

    TextMesh tbt1, tbt2, tbt3;
    bool pausemenu;
    int button;
    int volume;

	// Use this for initialization
	void Start () {
        pausemenu = false;
        button = 1;
        volume = 100;
        tbt1 = bt1.GetComponent<TextMesh>();
        tbt2 = bt2.GetComponent<TextMesh>();
        tbt3 = bt3.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown("escape"))
        {
            if (pausemenu)
            {
                bt1.renderer.enabled = false;
                bt2.renderer.enabled = false;
                bt3.renderer.enabled = false;
            }
            else
            {
                bt1.renderer.enabled = true;
                bt2.renderer.enabled = true;
                bt3.renderer.enabled = true;
            }
            pausemenu = !pausemenu;
        }

        if (pausemenu)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && button != 1)
            {
                button--;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && button != 3)
            {
                button++;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (button == 1)
                {
                    bt1.renderer.enabled = false;
                    bt2.renderer.enabled = false;
                    bt3.renderer.enabled = false;
                    pausemenu = false;
                }

                if (button == 3)
                {
                    Application.Quit();
                }

            }

            if (Input.GetKey(KeyCode.LeftArrow) && button == 2 && volume > 0)
            {
                volume--;
            }

            if (Input.GetKey(KeyCode.RightArrow) && button == 2 && volume < 100)
            {
                volume++;
            }

            tbt2.text = "Volume : " + volume + "%";
            AudioListener.volume = (float)volume / 100f;
            reset();
            if (button == 1)
            {
                tbt1.color = Color.yellow;
            }
            if (button == 2)
            {
                tbt2.color = Color.yellow;
            }
            if (button == 3)
            {
                tbt3.color = Color.yellow;
            }
        }

	}

    void reset()
    {
        tbt1.color = Color.black;
        tbt2.color = Color.black;
        tbt3.color = Color.black;
    }
}
