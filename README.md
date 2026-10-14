# 按键出售（Yuzi）

Omni Toolbox 在线模块。默认按住 **Shift＋鼠标右键单击**背包物品，自动选择游戏原生菜单的“出售”或“让雇员出售”。设置支持 Alt、Ctrl、Shift 的非空组合，需同时按住所选键。

仅在 NPC 商店或雇员物品／市场列表界面、且原生菜单确实提供可用的系统出售动作时触发。不选择市场上架，不绕过游戏数量或贵重物品确认。不使用角色缓存猜测槽位，直接验证本次点击的实时槽位；不修改 Omni 本体。

在线模块库：
https://raw.githubusercontent.com/yuanzil1243-oss/OmniToolbox.SellOnClickOnline/master/TreeHouseModules.json

在 Omni 在线模块中刷新该仓库并更新“按键出售”。作者：Yuzi。版本 0.2.0 已通过本机 Omni 1.1.6.6 / Dalamud API 15 程序集编译；实际出售仍需游戏内验证。

技术参考：SimpleTweaksPlugin 的 QuickSellItems 展示了原生物品上下文菜单出售入口。本项目保留原生确认流程。
