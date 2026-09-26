<div align="center">
  <img src="./optimizerDuck/Resources/Images/LiteClean.png" alt="LiteClean" width="128" />
</div>

<h1 align="center">轻净 LiteClean</h1>

<p align="center"><b>一款免费的 Windows 优化工具，聚焦性能、隐私与简洁。</b></p>

> [!IMPORTANT]
> ### 本软件是 optimizerDuck 的修改版本（modified version / fork）
>
> | | |
> | --- | --- |
> | 原始项目 | [optimizerDuck](https://github.com/itsfatduck/optimizerDuck) |
> | 原始版权 | Copyright (C) 2025–2026 fatDuck (itsfatduck) |
> | 本仓库 | <https://github.com/xinpai/LiteClean> |
> | 修改部分版权 | Copyright (C) 2026 XP06 |
> | 修改日期 | 2026 年 9 月 26 日 |
> | 许可证 | [GNU General Public License v3.0](./LICENSE) |
>
> 完整的修改声明见 **[NOTICE.md](./NOTICE.md)**。

---

## 功能特性

- **系统优化**：按分类整理的性能、隐私、电源管理等优化项，每一项都附带说明。
- **预装应用清理**：扫描并移除 Windows 预装（AppX）应用，释放磁盘与后台资源。
- **可回滚**：应用更改前自动创建系统还原点，所有操作均可在应用内还原。
- **自定义**：自由勾选需要的优化项，按自己的需求组合方案。
- **多语言界面**：内置简体中文、繁体中文、English 等 17 种语言。
- **绿色免安装**：单文件可执行程序，下载即用。

---

## 下载

| 内容 | 地址 |
| --- | --- |
| 程序（Windows x64） | [Releases](https://github.com/xinpai/LiteClean/releases) |
| **完整源代码** | <https://github.com/xinpai/LiteClean> |

> [!NOTE]
> 依据 GNU GPL v3.0，你在获取本程序二进制文件的同时，有权获取**完整的对应源代码**。
> 源码即上表中的仓库，永久公开可获取，无需任何额外费用。

---

## 从源码构建

需要 [.NET SDK](https://dotnet.microsoft.com/download)（项目目标框架为 `net10.0-windows`）。

```bash
git clone https://github.com/xinpai/LiteClean.git
cd LiteClean
dotnet build optimizerDuck.slnx --configuration Release
```

发布单文件版本：

```bash
dotnet publish optimizerDuck/optimizerDuck.csproj --configuration Release /p:PublishProfile=Single
```

---

## 许可证

本程序依据 **GNU General Public License v3.0** 分发，许可证全文见 [`LICENSE`](./LICENSE)
（该文件为自由软件基金会发布的协议原文，未作任何改动）。

```
Copyright (C) 2025–2026 fatDuck (itsfatduck)   — 原始作品
Copyright (C) 2026 XP06                         — 修改部分
```

本程序为自由软件：你可以依据自由软件基金会发布的 GNU 通用公共许可证条款
（第 3 版或你选择的任何更新版本）重新分发和/或修改它。

本程序的分发是希望它有用，但不提供任何担保，甚至没有适销性或特定用途适用性的默示担保。
详见 GNU 通用公共许可证。

---

## 免责声明

本工具会**修改 Windows 系统设置**。使用前请务必备份重要数据，并确认你理解每一项优化的作用。
作者不对因使用本程序而造成的任何系统故障、数据丢失或其它损失承担责任。
详见 [`DISCLAIMER.md`](./DISCLAIMER.md)、[`TERMS.md`](./TERMS.md) 与 [`PRIVACY.md`](./PRIVACY.md)。

本程序与 Microsoft 无任何关联，也未获得其认可。所有商标归其各自所有者所有。
