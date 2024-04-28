INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
一幅使用印象派技巧繪製而成的風景畫。原本是父母寶貝的收藏，但在父母過世後也沒有擦拭過。而如今因為已被海水浸泡許久，早已不見當年的色彩

你摸向掛勾處，發現這邊竟有一把生鏽的鑰匙。

獲得物品：生鏽的鑰匙。

~ ShowMission("接受任務：使用鑰匙")
~ getBasementKey = true

~ Pickup()

-> END