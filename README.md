# OmniToolbox 在线模块：按键出售

本目录用于发布 `SellOnClick` 在线模块。模块设计为：按住配置的修饰键，在商店 NPC 或雇员出售界面中左键点击物品，提交一次出售请求。

## 当前依赖

模块必须使用与 Omni Toolbox 相同的 Dalamud API、FFXIVClientStructs 和 `OmniToolbox.Common` 版本编译。Omni 的在线模块协议只负责下载和加载代码，不会为在线模块提供出售 API；出售动作需要直接调用当前游戏版本的 `ShopSell` / `RetainerSell` Agent，因此必须在目标版本 SDK 可用后实现和验证。

## 行为约束

- 只处理 `ShopSell`、`RetainerSell` 等已确认的出售界面。
- 不在普通背包、仓库、装备栏或买入界面响应。
- 修饰键支持 Alt、Ctrl、Shift 以及三者的非空组合。
- 每次鼠标点击最多提交一次出售请求。
- 发送请求前重新读取槽位并检查物品存在、数量和当前出售界面，避免陈旧槽位操作。
- 模块停用时注销输入和 Addon 事件。

## 发布

完成目标 Dalamud SDK 下的编译和游戏内验证后，将最终 `.cs` 或 `.dll` 的 SHA256 写入根目录 `TreeHouseModules.json`，再提交到公开仓库。
