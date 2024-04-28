INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

 # speaker: 腦內的聲音 #portrait: Narrator #layout: left
 
倉庫門上面懸掛著一道密碼鎖
 
 {passwordForWarehouse:
    ~ PlaySound("unlock")
    你輸入了小販給的密碼，倉庫門已開啟。
    ~ Disappear()
  - else:
    等詢問到密碼後再來吧。
}
        
-> END