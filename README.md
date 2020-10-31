[![Build status](https://ci.appveyor.com/api/projects/status/7epw5ywgwjglvgbt?svg=true)](https://ci.appveyor.com/project/zakhor/hoshform)
# HoshForm
## すること
5chの特定板を巡回しスレタイに任意の文字列を含むスレを検索し保守する  
## 実行画面
### フォーム
![image](https://user-images.githubusercontent.com/49256667/97548094-0759ef00-1a12-11eb-86fb-64ee53f2b05c.png)
### コンソール
![image](https://user-images.githubusercontent.com/49256667/97548701-cf06e080-1a12-11eb-823c-3d96bda9959a.png)
## 設定できるもの
* 板（liveanarchyなど、data-date=NGになる板では使えない）
* スレタイ検索ワード
* 保守間隔時間（秒）
* 名前
* 本文（改行により複数登録可）    
HoshForm.dll.configでデフォルト値の変更が可能
## 必要なもの
* .NET Core 3.1  
* GoogleChrome 86以上
