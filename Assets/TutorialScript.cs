using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] UpdatePlayerAttributes updateUI = null;
    // CINEMATIC
    [SerializeField] Camera cam = null;
    [SerializeField] Light2D globalLight = null;
    [SerializeField] Animator dayLightAnimator = null;

    // TO DEACTIVATE - dont forget to activate again
    [SerializeField] Tile_Targeting tileTargeting = null;
    [SerializeField] Player_Movement playerMovement = null;
    [SerializeField] GameObject gameManager = null;
    GameManager gm;
    ZoomCamera zoom;
    [SerializeField] GameObject ui = null;
    [SerializeField] GameObject tutorialTooltips = null;

    // SHOW STUFF
    [SerializeField] GameObject credits0 = null;
    [SerializeField] GameObject credits1 = null;
    [SerializeField] GameObject credits2 = null;
    [SerializeField] GameObject credits3 = null;
    [SerializeField] GameObject credits4 = null;
    [SerializeField] GameObject credits5 = null;
    [SerializeField] GameObject credits6 = null;

    [SerializeField] GameObject tooltip1 = null;
    [SerializeField] GameObject tooltip2 = null;
    [SerializeField] GameObject tooltip3 = null;
    [SerializeField] GameObject tooltip4 = null;
    [SerializeField] GameObject tooltip5 = null;
    [SerializeField] GameObject tooltip6 = null;

    [SerializeField] Transform wp1 = null, wp2 = null, wp3 = null, wp4 = null, wp5 = null, wp6 = null, wp7 = null, wp8 = null, wp9 = null, wp10 = null;

    int state;

    int timer;

    bool done0;

    bool breaky = false;

    private void Awake() {
        updateUI.Init(); 
    }

    private void Update() {
        Time.timeScale = 1.0f;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            breaky = true;
            Debug.Log("Escape");
            player.transform.position = new Vector3(-8.0f, 4.0f, 0.0f);
            playerMovement.enabled = true;
            tileTargeting.enabled = true;
            dayLightAnimator.enabled = true;
            ui.SetActive(true);
            zoom.enabled = true;
            gm.enabled = true;
            tutorialTooltips.SetActive(true);
            Camera.main.orthographicSize = 4.0f;
            Camera.main.transform.localPosition = new Vector3(0, 0.4f, -100f);
            updateUI.Init();
            gameObject.SetActive(false);
        }
    }

    private void Start() {
        // DEACTIVATE STUFF
        tutorialTooltips.SetActive(false);
        gm = gameManager.GetComponent<GameManager>();
        zoom = gameManager.GetComponent<ZoomCamera>();
        playerMovement.enabled = false;
        tileTargeting.enabled = false;
        dayLightAnimator.enabled = false;
        ui.SetActive(false);
        zoom.enabled = false;
        gm.enabled = false;

        // CINEMATIC STUFF
        globalLight.intensity = 0.9f;
        globalLight.color = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        cam.orthographicSize = 2.0f;
        cam.transform.localPosition = new Vector3(0, 0.1f, -100f);

        timer = 0;
        state = 1;
        StartCoroutine("StartTutorial");
    }

    IEnumerator StartTutorial() {
        if (state == 1) {
            Debug.Log("State "+state);
            timer++;
            if (timer == 1) {
                tooltip1.SetActive(true);
            }
            yield return new WaitForSeconds(3.5f);
            tooltip1.SetActive(false);
            state++;
            timer = 0;
        }
        if (state == 2) {
            Debug.Log("State " + state);
            timer++;
            if (timer == 1) {
                tooltip2.SetActive(true);
            }
            yield return new WaitForSeconds(3.0f);
            tooltip2.SetActive(false);
            state++;
            timer = 0;
        }
        if (state == 3) {
            Debug.Log("State " + state);
            timer++;
            if (timer == 1) {
                tooltip3.SetActive(true);
            }
            yield return new WaitForSeconds(2.0f);
            credits0.SetActive(true);
            credits1.SetActive(true);
            tooltip3.SetActive(false);
            tileTargeting.enabled = false;
            playerMovement.enabled = true;
            yield return new WaitForSeconds(1.0f);
            playerMovement.MoveTo(wp1.position);
            //ebug.Log("Waypoint Position: " + waypoint1.position);
            //Debug.Log("Waypoint Position LocaL: " + waypoint1.localPosition);
            yield return new WaitForSeconds(0.7f);
            credits0.SetActive(false);
            playerMovement.MoveTo(wp2.position);
            yield return new WaitForSeconds(1.1f);
            playerMovement.MoveTo(wp3.position);
            yield return new WaitForSeconds(1.0f);
            credits1.SetActive(false);
            credits2.SetActive(true);
            playerMovement.MoveTo(wp4.position);
            yield return new WaitForSeconds(1.3f);
            credits3.SetActive(true);
            playerMovement.MoveTo(wp5.position);
            yield return new WaitForSeconds(2.8f);
            credits2.SetActive(false);
            credits4.SetActive(true);
            playerMovement.MoveTo(wp6.position);
            yield return new WaitForSeconds(1.4f);
            credits3.SetActive(false);
            playerMovement.MoveTo(wp7.position);
            yield return new WaitForSeconds(2.0f);
            credits4.SetActive(false);
            state++;
            timer = 0;
        }
        if (state == 4) {
            Debug.Log("State " + state);
            timer++;
            if (timer == 1) {
                tooltip4.SetActive(true);
            }
            yield return new WaitForSeconds(7.0f);
            tooltip4.SetActive(false);
            tooltip5.SetActive(true);
            yield return new WaitForSeconds(7.0f);
            tooltip5.SetActive(false);
            state++;
            timer = 0;
        }
        if (state == 5) {
            Debug.Log("State " + state);
            timer++;
            if (timer == 1) {
                tooltip6.SetActive(true);
            }
            yield return new WaitForSeconds(5.0f);
            tooltip6.SetActive(false);
            credits5.SetActive(true);
            playerMovement.MoveTo(wp8.position);
            yield return new WaitForSeconds(4.0f);
            credits5.SetActive(false);
            credits6.SetActive(true);
            playerMovement.MoveTo(wp8.position);
            yield return new WaitForSeconds(4.0f);
            credits6.SetActive(false);
            state++;
            timer = 0;
        }
        if (breaky == true) {
            yield break;
        }
        playerMovement.enabled = true;
        tileTargeting.enabled = true;
        dayLightAnimator.enabled = true;
        ui.SetActive(true);
        zoom.enabled = true;
        gm.enabled = true;
        tutorialTooltips.SetActive(true);
        Camera.main.orthographicSize = 4.0f;
        Camera.main.transform.localPosition = new Vector3(0, 0.4f, -100f);
        gameObject.SetActive(false);
        yield break;
    }
}
