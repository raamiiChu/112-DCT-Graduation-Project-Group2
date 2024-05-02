using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using DG.Tweening;
using System;

public class InkExternalFunctions
{
    public void Bind(Story story, GameObject triggerGameObject)
    {
        story.BindExternalFunction("Pickup", () =>
        {
            Pickup(triggerGameObject);
        });

        story.BindExternalFunction("PickupFromNPC", (int index) =>
        {
            PickupFromNPC(triggerGameObject, index);
        });

        story.BindExternalFunction("RemoveFromNPC", (int index) =>
        {
            RemoveFromNPC(triggerGameObject, index);
        });

        story.BindExternalFunction("ModifySanity", (int diff) =>
        {
            ModifySanity(diff);
        });

        story.BindExternalFunction("ModifyMelancholy", (int diff) =>
        {
            ModifyMelancholy(diff);
        });

        story.BindExternalFunction("CheckSanity", () =>
        {
            return CheckSanity();
        });

        story.BindExternalFunction("CheckMelancholy", () =>
        {
            return CheckMelancholy();
        });

        story.BindExternalFunction("TriggerAppear", () =>
        {
            TriggerAppear(triggerGameObject);
        });

        story.BindExternalFunction("Disappear", () =>
        {
            Disappear(triggerGameObject);
        });

        story.BindExternalFunction("Rotate", (float diff) =>
        {
            Rotate(triggerGameObject, diff);
        });

        story.BindExternalFunction("DeleteStone", () =>
        {
            DeleteStone();
        });

        story.BindExternalFunction("ShowImage", (int index) =>
        {
            ShowMainImage(index);
        });

        story.BindExternalFunction("HideImage", () =>
        {
            HideMainImage();
        });

        story.BindExternalFunction("ShowControl", () =>
        {
            ShowControl();
        });

        story.BindExternalFunction("ShowMission", (string missionText) =>
        {
            ShowMission(missionText);
        });

        story.BindExternalFunction("PlaySound", (string soundName) =>
        {
            PlaySound(soundName);
        });

        story.BindExternalFunction("ChangeEndingBGM", (string ending) =>
        {
            ChangeEndingBGM(ending);
        });

        story.BindExternalFunction("ChangeScene", (string sceneName) =>
        {
            ChangeScene(sceneName);
        });

        story.BindExternalFunction("ShowCG", (int CGIndex) =>
        {
            ShowCG(CGIndex);
        });

        story.BindExternalFunction("HideCG", () =>
        {
            HideCG();
        });

        story.BindExternalFunction("ShowBlackScreen", () =>
        {
            ShowBlackScreen();
        });

        story.BindExternalFunction("HideBlackScreen", () =>
        {
            HideBlackScreen();
        });

        story.BindExternalFunction("TeleportPlayer", (float x, float y, float z) =>
        {
            TeleportPlayer(x, y, z);
        });

        story.BindExternalFunction("StartSpawnBlocks", () =>
        {
            StartSpawnBlocks();
        });

        story.BindExternalFunction("StopSpawnBlocks", () =>
        {
            StopSpawnBlocks();
        });

        story.BindExternalFunction("ShowRene", () =>
        {
            ShowRene();
        });

        story.BindExternalFunction("ShowParticleThenRene", () =>
        {

            ShowParticleThenRene();
        });

        story.BindExternalFunction("ShowSkyler", () =>
        {
            ShowSkyler();
        });

        story.BindExternalFunction("HideSkyler", () =>
        {
            HideSkyler();
        });

        story.BindExternalFunction("HideLayne", () =>
        {
            HideLayne();
        });

        story.BindExternalFunction("TriggerAuditoryHallucinations", () =>
        {
            TriggerAuditoryHallucinations(triggerGameObject);
        });
    }

    public void Unbind(Story story)
    {
        string[] funcNames =
        {
            "Pickup",
            "PickupFromNPC",
            "RemoveFromNPC",
            "ModifySanity",
            "ModifyMelancholy",
            "CheckSanity",
            "CheckMelancholy",
            "TriggerAppear",
            "Disappear",
            "Rotate",
            "DeleteStone",
            "ShowImage",
            "HideImage",
            "ShowControl",
            "ShowMission",
            "PlaySound",
            "ChangeEndingBGM",
            "ChangeScene",
            "ShowCG",
            "HideCG",
            "ShowBlackScreen",
            "HideBlackScreen",
            "TeleportPlayer",
            "StartSpawnBlocks",
            "StopSpawnBlocks",
            "ShowRene",
            "ShowParticleThenRene",
            "ShowSkyler",
            "HideSkyler",
            "HideLayne",
            "TriggerAuditoryHallucinations",
        };

        foreach (string funcName in funcNames)
        {
            story.UnbindExternalFunction(funcName);
        }
    }

    public void Pickup(GameObject triggerGameObject)
    {
        triggerGameObject.GetComponentInParent<ItemPickup>().Pickup();
    }

    public void PickupFromNPC(GameObject triggerGameObject, int index)
    {

        Debug.Log(triggerGameObject);
        Item pickUpItem = triggerGameObject.GetComponent<DialogueTrigger>().pickUpItem[index];

        if (pickUpItem)
        {
            InventoryManager.GetInstance().Add(pickUpItem);
        }
    }

    public void RemoveFromNPC(GameObject triggerGameObject, int index)
    {
        Item removeItem = triggerGameObject.GetComponent<DialogueTrigger>().removeItem[index];

        if (removeItem)
        {
            InventoryManager.GetInstance().Remove(removeItem);

        }
    }

    public void ModifySanity(int diff)
    {
        StatusManager.GetInstance().ModifySanity(diff);
    }

    public void ModifyMelancholy(int diff)
    {
        StatusManager.GetInstance().ModifyMelancholy(diff);
    }

    public int CheckSanity()
    {
        int sanity = StatusManager.GetInstance().sanity;
        return sanity;
    }

    public int CheckMelancholy()
    {
        int melancholy = StatusManager.GetInstance().melancholy;
        return melancholy;
    }

    public void TriggerAppear(GameObject triggerGameObject)
    {
        GameObject[] targetGameObjects = triggerGameObject.GetComponent<DialogueTrigger>().targetGameObjects;

        if (targetGameObjects.Length == 0)
        {
            return;
        }

        foreach (GameObject targetGameObject in targetGameObjects)
        {
            GameObject trigger = targetGameObject.transform.Find("Trigger").gameObject;
            trigger.SetActive(true);
        }
    }

    public void Disappear(GameObject triggerGameObject)
    {
        triggerGameObject.transform.parent.Find("Trigger").gameObject.SetActive(false);
        triggerGameObject.transform.parent.Find("Visual").gameObject.SetActive(false);
    }

    public void Rotate(GameObject triggerGameObject, float diff)
    {
        Transform pillar = triggerGameObject.transform.parent.Find("Visual").Find("Pillar");

        if (pillar)
        {
            pillar.DOLocalRotate(new Vector3(0f, diff, 0f), 0.5f, RotateMode.LocalAxisAdd);
        }
    }

    public void DeleteStone()
    {
        GameManager.GetInstance().DeleteStone();
    }

    public void ShowMainImage(int index)
    {
        ShowDialogueImage.GetInstance().ShowMainImage(index);
    }

    public void HideMainImage()
    {
        ShowDialogueImage.GetInstance().HideMainImage();
    }

    public void ShowControl()
    {
        HintManager.GetInstance().ShowControl();
    }

    public void ShowMission(string missionText)
    {
        HintManager.GetInstance().ShowMission(missionText);
    }

    public void PlaySound(string soundName)
    {
        soundName = soundName.ToLower().Trim();

        string[] soundNames = {
            "alarm", "beep", "pick up",
            "explosion", "fire", "hatch open",
            "paper", "radar", "radio",
            "submarine", "underwater bubble", "unlock"
        };

        int soundIndex = Array.FindIndex(soundNames, name => name == soundName);

        if (soundIndex < 0)
        {
            Debug.LogWarning("No such a sound name: " + soundName);
            return;
        }

        DialogueManager DialogueManagerInstance = DialogueManager.GetInstance();
        AudioSource DialogueManagerAudioSource = DialogueManagerInstance.audioSource;
        AudioClip[] soundClips = DialogueManagerInstance.soundClips;
        AudioClip soundClip = soundClips[soundIndex];

        DialogueManagerAudioSource.PlayOneShot(soundClip);
        DialogueManagerAudioSource.volume = 0.1f;
    }

    public void ChangeEndingBGM(string ending)
    {
        int index;

        switch (ending)
        {
            case "true":
                index = 0;
                break;
            case "normal":
                index = 1;
                break;
            case "bad":
                index = 2;
                break;
            default:
                index = -1;
                break;
        }

        if (index == -1)
        {
            return;
        }

        AudioSource playerCameraAudioSource = GameManager.GetInstance().playerCamera.GetComponent<AudioSource>();
        AudioClip[] endingClips = DialogueManager.GetInstance().endingClips;

        // change bgm then play
        playerCameraAudioSource.clip = endingClips[index];
        playerCameraAudioSource.Play();
    }

    public void ChangeScene(string sceneName)
    {
        GameManager.GetInstance().ChangeScene(sceneName);
    }

    public void ShowCG(int CGIndex)
    {
        DialogueManager DialogueManagerInstance = DialogueManager.GetInstance();

        GameObject CGBackground = DialogueManagerInstance.CGBackground;
        Image CGBackgroundImage = CGBackground.GetComponent<Image>(); ;
        Sprite[] CGImages = DialogueManagerInstance.CGImages;

        CGBackgroundImage.sprite = CGImages[CGIndex];
        CGBackgroundImage.preserveAspect = true;
        CGBackground.SetActive(true);
    }

    public void HideCG()
    {
        DialogueManager DialogueManagerInstance = DialogueManager.GetInstance();
        GameObject CGBackground = DialogueManagerInstance.CGBackground;
        CGBackground.SetActive(false);
    }

    public void ShowBlackScreen()
    {
        BlackScreenToggle.GetInstance().ShowBlackScreen();
    }

    public void HideBlackScreen()
    {
        BlackScreenToggle.GetInstance().HideBlackScreen();
    }

    public void TeleportPlayer(float x, float y, float z)
    {
        GameManager.GetInstance().player.transform.position = new Vector3(x, y, z);
    }

    public void StartSpawnBlocks()
    {
        BlockManager blockManager = GameObject.FindObjectOfType<BlockManager>();
        blockManager.GetComponent<BlockManager>().enabled = true;
    }

    public void StopSpawnBlocks()
    {
        BlockManager.GetInstance().StopSpawnBlocks();
    }

    public void ShowRene()
    {
        GameManager.GetInstance().ShowRene();
    }

    public void ShowParticleThenRene()
    {
        GameManager.GetInstance().ShowParticleThenRene();
    }

    public void ShowSkyler()
    {
        GameObject Skyler = GameObject.FindGameObjectWithTag("Skyler").transform.Find("Body").gameObject;
        Skyler.SetActive(true);
    }

    public void HideSkyler()
    {
        GameObject Skyler = GameObject.FindGameObjectWithTag("Skyler").transform.Find("Body").gameObject;
        Skyler.SetActive(false);
    }

    public void HideLayne()
    {
        GameManager.GetInstance().HidePlayer();
    }

    public void TriggerAuditoryHallucinations(GameObject triggerGameObject)
    {

        GameObject[] AuditoryHallucinations = GameObject.FindGameObjectsWithTag("AuditoryHallucinations");

        if (AuditoryHallucinations.Length > 1)
        {
            Debug.LogWarning("Tag 'AuditoryHallucinations' should be only");
        }

        AuditoryHallucinations[0].GetComponent<AuditoryHallucinations>().enabled = true;
    }
}
