<p align="center">
  <img src="Phexor-Task-Manager/Images/phexor-task-manager.png" alt="Phexor Task Manager Logo" width="120"/>
</p>

<h1 align="center">Phexor Task Manager</h1>

<p align="center">
  a quick, modern and SQL based Task-Manager created in .Net, using C#.
</p>

---

## Overview

**Phexor Task Manager** is just a simple, Desktop Application, there to Create Tasks, Edit them, Mark them as completed and if they get to much, as well to delete them. currently its just allowing you to have one table, but i am already working on a multi table design and code so you can store and sort even more things to remember :)

---

## Features

- Creating new Tasks
  - Creation Time
  - End Time
  - Marked (yes/no)
  - Title
  - Description
- Editing Tasks
- Removing Tasks
- Marking Tasks

---

## Screenshots
[Screenshot1](Phexor-Task-Manager/Images/Screenshot1.png)
[Screenshot1](Phexor-Task-Manager/Images/Screenshot2.png)
[Screenshot1](Phexor-Task-Manager/Images/Screenshot3.png)

---

## Tech Stack
![Static Badge](https://img.shields.io/badge/C%23-language?label=language&color=blue) ![Static Badge](https://img.shields.io/badge/MVVM-Pattern?label=Pattern&color=yellow) ![Static Badge](https://img.shields.io/badge/SQL-Techniques?label=Techniques&color=red) ![Static Badge](https://img.shields.io/badge/XAML-Techniques?label=Techniques&color=red)

---

## Requirements

- Windows 10 or later
  - [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) (or .NET 10 SDK to build from source)
  - Download from last Release:

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

### Download and Run

Download from last Release as .exe
Execute from your download Directory or wherever you saved it in

---

## License

This project is licensed under the **Phexor Non-Commercial License**.  
See the [LICENSE](LICENSE) file for full details.

basically allowing you to use it as you want, but not for Commercial uses like selling it

---

## Disclaimer

This software is provided **as-is**, without any warranty of any kind.  
The author accepts **no liability** for any damages arising from the use of this software.  
See the [LICENSE](LICENSE) file for the full disclaimer.
