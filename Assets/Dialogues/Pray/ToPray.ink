INCLUDE ../Globals.ink
INCLUDE ../ExternalFunctions.ink

~ ShowCG(9)
~ PlaySound("submarine")

# speaker: Skyler #portrait: Skyler #layout: right
前往海底洞穴（對著潛水艇的聲控系統）

我看看啊，海底洞穴的資料。

~ ShowCG(18)
# speaker: 舊工廠資料 #portrait: Narrator #layout: left
海底洞穴。陸地時代就存在的自然洞穴，傳聞是不知名宗教的祭祀聖地，擁有者行事較為隱密，資料庫中無百分之百可信之消息。根據不可靠消息指出該洞穴經人為改造，設有許多機關。

（資料讀取中，請稍後...）

~ ShowCG(19)

透過解析教典內容，初步推測非教徒欲進入「聖地」須通過入口通道機關。<br>配合地形解析，建議分頭進入並同時破解機關。

# speaker: Skyler #portrait: Skyler #layout: right
看來我們必須分頭行動了。

~ HideCG()

# speaker: Skyler #portrait: Skyler #layout: right
你那邊怎麼樣？我前面的路被一塊大石頭擋住了，過不去。

# speaker: Layne #portrait: Layne #layout: left
我這邊也是一塊大石頭，還有四根橫著擋路的石柱子。

# speaker: Skyler #portrait: Skyler #layout: right
擋路的石柱子……是機關嗎？你試試能不能移動它們。

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
提示：按下 P 可以開啟對講機跟 Skyler 通話

~ TriggerAuditoryHallucinations()

~ Disappear()