# 🧾 Cheque Printer Windows Service

A lightweight Windows Service built on .NET Framework 4.5 for printing cheques using customizable templates. Designed to support LQ/LX dot matrix printers, POS printers, and Windows-compatible devices via REST-like APIs.

> Developed and maintained by [Riddha Soft Pvt. Ltd.](https://github.com/Riddha-Soft-Pvt-Ltd)

---

## 🔧 Features

- ✅ Self-hosted HTTP API (no IIS)
- 🖨️ Supports Dot Matrix, ESC/P, and Windows printers
- 🧾 Template-based cheque printing with dynamic data
- 📄 Multi-leaf print formatting support
- 🔍 System info endpoint (MAC, IP, machine name)
- 🌐 CORS enabled
- ⚙️ Configurable printer selection via `app.config`

---

## 📦 Requirements

- Windows 7 or higher / Server OS
- [.NET Framework 4.5](https://dotnet.microsoft.com)
- Administrator privileges (to install/start the service)

---

## 🚀 Setup & Installation

### 1. Clone & Build

```bash
git clone https://github.com/Riddha-Soft-Pvt-Ltd/ChequePrinterService.git
cd ChequePrinterService
