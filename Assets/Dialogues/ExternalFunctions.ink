EXTERNAL Pickup()
EXTERNAL PickupFromNPC(index)
EXTERNAL RemoveFromNPC(index)

EXTERNAL ModifySanity(diff)
EXTERNAL ModifyMelancholy(diff)

EXTERNAL CheckSanity()
EXTERNAL CheckMelancholy()

EXTERNAL TriggerAppear()
EXTERNAL Disappear()
EXTERNAL Rotate(diff)
EXTERNAL DeleteStone()

EXTERNAL ShowImage(index)
EXTERNAL HideImage()

EXTERNAL ShowControl()
EXTERNAL ShowMission(missionText)

EXTERNAL PlaySound(soundName)
EXTERNAL ChangeEndingBGM(ending)

EXTERNAL ChangeScene(sceneName)

EXTERNAL ShowCG(CGIndex)
EXTERNAL HideCG()
EXTERNAL ShowBlackScreen()
EXTERNAL HideBlackScreen()

EXTERNAL TeleportPlayer(x, y, z)

EXTERNAL StartSpawnBlocks()
EXTERNAL StopSpawnBlocks()

EXTERNAL ShowRene()
EXTERNAL ShowParticleThenRene()
EXTERNAL ShowSkyler()
EXTERNAL HideSkyler()
EXTERNAL HideLayne()

// Act 2
EXTERNAL TriggerAuditoryHallucinations()

=== Find4items ===

{getDivingMask && getOxygenTank && getWetsuit && getUnderwaterCamera:
    # speaker: Layne #portrait: Layne #layout: left
    要搬上潛水艇的物資都找齊了，現在前往碼頭與「逆行者」隊員們會合吧。
    ~ ShowMission("前往碼頭尋找「逆行者」隊長報到")
}

-> DONE

=== CheakPillars ===

{pillarA % 4 == 2 && pillarB % 4 == 2 && pillarC % 4 == 0 && pillarD % 4 == 2:
    ~ PlaySound("click")
    
    # speaker: 腦內的聲音 #portrait: default #layout: left
    洞穴的深處傳來了動靜。
    
    ~ completePillars = 1
    ~ DeleteStone()
}

-> DONE