# 介紹
## 相依圖
![Project dependency.png](https://github.com/ChimmyJay/TimeMachine/blob/main/.github/Project%20dependency.png)
## 分層 & 結構
```
TimeMachine.Core                            # business logic layer/service layer. 
    {Feature Module}/                       # 功能模組,後續可以以資料夾為單位視情況獨立而一個專案或服務.例如 Account
    {Feature Module}/
        Queries/                            # 報表相關的使用 Query.作為不可修改的物件(Value Object).
        Commands/                           # 剩下的都在這裡.作為不可修改的物件(Value Object).
        Enums/
        DomainModels/                       # Domain 上的概念實體,可以有行為(public method)
        {External Service}.cs               # 模組被外部使用的進入點 參數使用 Queries or Commands. 套完 MediatR 後會不見(但還沒套)
        {External Service}.cs
        {Internal Service}.cs               # 模組的內部服務.不可被其他 Feature Module Or presentation layer 使用
        {Internal Service}.cs
    {Common}/                               # 通用的東西 例如 IJsonSerializer,ICache 
TimeMachine.Infrastructure                  # data access layer/persistence layer. 第三方套件通常也放這裡 例如Serilog,Newtonsoft.Json
    {Feature Module}/
    {Feature Module}/
TimeMachine.WebApi                          # presentation layer 決定程式的運行平台(ex:.NET 5 or WPF)
    Contollers/                  
    Contracts/                              # 與外部服務規範的規格 例如:Web frontend(browser side)
        {Controller}/                       # Group by Controller 比較舒服,Contoller using 時可避免撞名
```
PS: 如果用 EFCore 的話會塞在 TimeMachine.Core

## 開發規範
規範可以打破,但在打破前須先提出討論.

- 通過所有測試
- Contracts 的前綴使用 Action name,後綴加上 Request/Response
- 繼承深度 < 3 (從自訂物件)
- 各 Project 使用 interface 隔開
- TimeMachine.Core 都要有單元測試
- 不吃 Exception & rethrow
- 非同步與同步不要混用 ex: xxx.Result or xxx.GetAwaiter().GetResult()
