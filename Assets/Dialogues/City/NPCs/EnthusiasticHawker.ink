INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

 # speaker: 樂觀的小販 #portrait: Narrator #layout: right

-> main

=== main ===

Layne！這裡這裡，你們「逆行者」這次下潛任務的物資已經送達了！多虧有你們，我最近才會有一點生意。

    -> ask

-> END

=== ask ===
* [這次的下潛物資有包含什麼？]
    你說這次的物資嗎？當然還是老樣子——除了潛水面罩、潛水衣、氧氣罐之外，我還幫你們這次新添了「水下相機」，好讓你們能夠在水下拍攝帶不回去的稀有物品，方便讓後面的探險隊能夠知道寶物的位置。
    
    但是由於那些裝備太多了，我全部都將他放在碼頭旁的倉庫之中了，你們再去那拿就是了。
   
    ~ passwordForWarehouse = true
    ~ ShowMission("前往倉庫拿取物資")
   
    另外記住了，由於倉庫有密碼鎖著，刷進去記得輸入密碼：0202。
    
    -> ask
    
* [逆行者？]
    你怎麼會問我這個問題？你不是自己就是其中的一員嗎？這個問題你應該去問逆行者的成員而不是我吧？
    
    -> ask
    
* [最近的生意怎麼樣？]
    唉.....最近真的不比以往，賣東西時在賣的不怎麼樣，就算有貨，也沒人有錢買呀！最近還傳出有人餓死，在以前的世界會有這樣的事情發生嗎？
    
    -> ask
    
* [離開]
    有空再來！   
    
-> DONE 