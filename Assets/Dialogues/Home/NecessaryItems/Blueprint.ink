INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
這張鐵桌早已被滿滿地繡跡與海藻覆蓋，但上面依舊還看的到曾經覆蓋著藍圖的痕跡。

~ PlaySound("paper")
~ ShowImage(15)

然而藍圖上面的圖畫早已模糊不清，變成了一張幾乎不成形的破爛圖紙。不過由於似乎很重要，因此你還是將他帶上。

獲得物品：破爛的藍圖圖紙。

~ getBlueprint = true
~ HideImage()
~ Pickup()

-> END