INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: 腦內的聲音 #portrait: Narrator #layout: left

潛水衣是潛水活動中的關鍵裝備之一，其獨特的設計和材質旨在提供潛水者所需的保護和保溫。

通常由高科技的材料如氯丁橡膠、氨綸、尼龍等製成，潛水衣在水下扮演著保護身體免受溫度變化和水壓的重要角色。

~ PlaySound("pick up")
~ Pickup()

~ getWetsuit = true

獲得物品：潛水衣

-> Find4items

-> END