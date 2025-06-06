# 🧾 Cheque Printer Windows Service

A lightweight Windows Service built on .NET Framework 4.5 that provides APIs to print cheques using predefined templates. It supports customizable formatting, leaf-based printing, and dynamic content generation. Ideal for banking, accounting, and POS scenarios.

---

## 🔧 Features

- ✔️ REST-like HTTP API (self-hosted, no IIS required)
- 🖨️ Support for ESC/P, Dot Matrix (LQ/LX), and Windows printers
- 📄 Template-based cheque printing
- 🧠 Intelligent formatter with multi-leaf support
- 📡 System info API (IP, MAC, Machine Name)
- 🌐 CORS enabled for browser use
- 📁 Config-driven printer selection

---

## 📦 Requirements

- Windows 7/8/10/11 or Server
- [.NET Framework 4.5](https://dotnet.microsoft.com)
- Admin privileges to install/start the service

---

## 🚀 Setup & Run

### 1. Clone Repository

```bash
git clone https://github.com/your-org/ChequePrinterService.git
cd ChequePrinterService
