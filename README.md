# DecryptSave-CloverPit Utility

![.NET Version](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue)
![Mod Version](https://img.shields.io/badge/version-1-green)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This utility allows you to decrypt, edit, and re-encrypt save files for CloverPit Demo. Modify your game progress, unlock features, or backup your saves with this simple tool.

## Key Features
- Decrypt CloverPit's GameDataDemo.json files
- Edit save data in plain JSON format
- Re-encrypt modified saves for game compatibility
- No installation required

## Prerequisites
- Steam installation of [CloverPit Demo](https://store.steampowered.com/app/2692780/CloverPit/)
- .NET Framework 4.7.2 (usually included with Windows 10/11)

## Usage Guide

### Step 1: Locate Save File
1. Navigate to CloverPit's save directory:
```bash
...\Program Files (x86)\Steam\steamapps\common\CloverPit Demo\SaveData\GameData
```
2. Copy `GameDataDemo.json` to the directory where you have `DecryptSaveCloverPit.exe`

### Step 2: Decrypt Save File
1. Run `DecryptSaveCloverPit.exe` (this will automatically decrypt the file)
2. Edit the decrypted `GameDataDemo.json` using any text editor:
```json
{
    "myGameDataIndex": 0,
    "dataOpenedTimes": 23,
    "lastGameVersionThatSavedMe": "0.3.6",
    "gameplayDataHasSession": true,
    "gameplayData": {
    }
}
```

### Step 3: Re-encrypt and Replace
1. Run `DecryptSaveCloverPit.exe` again to re-encrypt the file
2. Copy the re-encrypted `GameDataDemo.json` back to the game directory
3. Launch the game to see your changes applied

## Building from Source
1. Clone repository:
```bash
git clone https://github.com/Mikhaelo/DecryptSave-CloverPit.git
```
2. Open `DecryptSaveCloverPit.sln` in Visual Studio 2022
3. Build solution (Output: `bin/Release/DecryptSaveCloverPit.exe`)

## Technical Details
- **Encryption Method:** XOR-based custom algorithm
- **Game Data Key:** `uoiyiuh_+=-5216gh;lj??!/345`
- **Achievements Key:** `afhjttiojd?s0989sdfl12` (not implemented)
- **File Handling:** In-place encryption/decryption

## Safety Notes
1. Always back up original save files
2. Close the game before modifying saves
3. Invalid edits may corrupt save data
4. Use integer values where appropriate

## Troubleshooting
- **File not found:** Ensure .json is in same directory as .exe
- **Corrupted save:** Restore from backup and re-edit
- **No changes applied:** Verify re-encryption step completed
- **Game crashes:** Validate game files through Steam

## License
Distributed under the MIT License. See `LICENSE` for more information.

---
> **Disclaimer:** This tool is not affiliated with or endorsed by the CloverPit developers. Use at your own risk. Modifying save files may violate the game's EULA.
