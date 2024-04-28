INCLUDE ../Globals.ink
INCLUDE ../ExternalFunctions.ink

~ ShowCG(8)
~ PlaySound("submarine")

# speaker: Skyler #portrait: Skyler #layout: right
「潛水艇，啟動！」

~ PlaySound("underwater bubble")

# speaker: 旁白 #portrait: Narrator #layout: left
Skyler 對潛水艇上的聲控系統下達指令，潛水艇從港口緩緩下沉，而來自海面上的光線也開始逐漸消失。不久後，我們從觀景窗看出去，即變得身漆黑地伸手不見五指。

~ ShowCG(9)

「艇外量度過低，艇外亮度自動調節已開啟。」隨著系統提示音響起，在潛水艇外的燈光亮起，照亮了身旁的黑暗。在燈光的照耀下，還可以看到一些不知名的魚類因為燈光的緣故，不斷在我們身旁來回地遊蕩。

// ~ ShowCG(10)
// 潛水艇下潛脫離畫面

~ ShowCG(11)

# speaker: Skyler #portrait: Skyler #layout: right
我們的目的地要到了！

# speaker: 旁白 #portrait: Narrator #layout: left
在觀景窗中印入眼簾的是一個由鋼筋水泥所構成的建築群，其旁邊還有一些奇怪的大型機械設備與管線。在靠後的另外一區，還有一個一個類似水塔的儲存空間。

// ~ ShowCG(12)
// 潛水艇停在工廠旁

# speaker: Skyler #portrait: Skyler #layout: right
終於輪到我們下去探索了啊！

好了，我先把基礎通訊跟警報裝置設定好了，其他的機器還需要一點時間，那 Layne 你……

# speaker: Layne #portrait: Layne #layout: left
我先自己進去吧，剛好你在外面看著，有狀況隨時喊我。

# speaker: Skyler #portrait: Skyler #layout: right
對了，隊長剛剛還給了我們一些資料，就趁現在看一看吧。

# speaker: 舊工廠資料 #portrait: Narrator #layout: left
舊工廠區。陸地時代的頂尖電腦、生物及化學科技園區，不聯網的保密項目眾多，因早就預料到會有被海水淹沒的可能，所使用的科技設備和檔案大多都有經過特殊處理，是海底時代人類資料留存得最完整的地方。

# speaker:  舊工廠資料 #portrait: Narrator #layout: left
因為有提前準備海底維生設施，初期還有不少正常人類（大多是這裡原本的研究員或工作人員）生活。

# speaker: Skyler #portrait: Skyler #layout: right
酷，我們第一站就是這裡了，之前好像聽說過這裡原本有在進行生物科技研究，廢水汙染也挺嚴重的，生物變異的比例比其他地方還要高，想想就刺激。

~ ShowMission("接受任務：探索舊工廠區")

# speaker: Skyler #portrait: Skyler #layout: right
好。向海前行！

# speaker: Layne #portrait: Layne #layout: left
向海前行！

~ ShowCG(12)

# speaker: Layne #portrait: Layne #layout: left
（嘶，進門時沾到了什麼東西？怎麼黏黏的？）

~ Disappear()