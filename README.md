<p align="center">
  <img src="Phexor-Task-Manager/Images/phexor-task-manager.png" alt="Phexor Task Manager Logo" width="120"/>
</p>

<h1 align="center">Phexor Task Manager</h1>

<p align="center">
  A lightweight, modern task management desktop application built with WPF and .NET.
</p>

---

## Overview

**Phexor Task Manager** is a Windows desktop application that helps you organize and track your tasks efficiently. It features a clean, warm Phoenix-themed UI with orange accents, a local SQLite database for offline-first storage, and a fully MVVM-based architecture.

---

## Features

- 📋 **Task Overview** – See all your tasks at a glance in a card-based list
- ✅ **Mark as Done** – Check off tasks directly from the overview
- ➕ **Create Tasks** – Add tasks with a title, description, start date, and target date
- ✏️ **Edit Tasks** – Double-click any task to open the edit view and update its details
- 🗑️ **Delete Tasks** – Remove tasks you no longer need
- ⚙️ **Settings** – Configure the logging level (None / Error / Info / Debug)
- 💾 **Local SQLite Database** – All data is stored locally in `Task-Manager.db`, no internet required
- 🎨 **Phoenix Color Palette** – Warm cream background with orange, red, yellow and green accents

---

## Screenshots

> Place your application screenshots here once you have them.

---

## Tech Stack

| Component | Technology |
|-----------|-----------|
| Language | C# |
| Framework | .NET 10 (Windows) |
| UI | WPF (Windows Presentation Foundation) |
| Architecture | MVVM |
| Database | SQLite via `Microsoft.Data.Sqlite` |
| MVVM Toolkit | `CommunityToolkit.Mvvm` |
| Behaviors | `Microsoft.Xaml.Behaviors.Wpf` |

---

## Requirements

- Windows 10 or later
- [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) (or .NET 10 SDK to build from source)

---

## Getting Started

### Run from source

1. **Clone the repository**
   ```bash
   git clone https://github.com/kallioderso/Phexor-Task-Manager.git
   cd Phexor-Task-Manager
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build and run**
   ```bash
   dotnet run --project Phexor-Task-Manager/Phexor-Task-Manager.csproj
   ```

### Build a release executable

```bash
dotnet publish Phexor-Task-Manager/Phexor-Task-Manager.csproj -c Release -r win-x64 --self-contained
```

The output will be placed in `bin/Release/net10.0-windows/win-x64/publish/`.

---

## Project Structure

```
Phexor-Task-Manager/
├── Images/
│   ├── phexor-task-manager.ico   # Application icon
│   └── phexor-task-manager.png   # Application logo
├── MVVM/
│   ├── Model/
│   │   └── Datenbank.cs          # SQLite database access layer
│   ├── View/
│   │   ├── MainView.xaml         # Task list overview
│   │   ├── CreateView.xaml       # New task form
│   │   ├── ChangeView.xaml       # Edit task form
│   │   └── SettingsView.xaml     # Application settings
│   └── ViewModel/
│       ├── MainViewModel.cs
│       ├── CreateViewModel.cs
│       ├── ChangeViewModel.cs
│       └── SettingsViewModel.cs
├── MainWindow.xaml                # Shell window / navigation host
├── App.xaml
└── Phexor-Task-Manager.csproj
```

---

## License

This project is licensed under the **Phexor Non-Commercial License**.  
See the [LICENSE](LICENSE) file for full details.

**Short summary:** Free to use, modify, and share — but **not** for commercial sale or paid redistribution.

---

## Disclaimer

This software is provided **as-is**, without any warranty of any kind.  
The author accepts **no liability** for any damages arising from the use of this software.  
See the [LICENSE](LICENSE) file for the full disclaimer / Haftungsausschluss.
